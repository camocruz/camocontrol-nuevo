Public Class fm_0400_pp_ordenes_produccion_arbol
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_item_clonar As Integer 'Es el id del item padre de todo el arbol
    Public id_item_pp As Integer 'el f0401_id_ipp de un programa de produccion.
    Public tree_path_base As String
    Public nodo_buscar As String = ""

    Public proceder_edicion_ipp As String
    ' DIV = La ipp se dividira en varias ipps diferentes
    ' MOD = La ipp solo modificara sus valores
    Public otb_edicion As DataTable 'Datatable que almacenara los datos de edicion del IPP

    Private otipo_nota As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_items_plantillas As DataTable
    Private otb_plantillas As DataTable
    Private otb_items_programa_produccion As DataTable
    Private otb_reportes_produccion As DataTable

    Private path_estructura_filtrado As String = ""
    Private id_estructura_padre_filtrado As Integer


    Private tipo_registro As String
    Private numero_registro As Integer = 0
    Private filtro_rama As String = "N"
    Private cantidad_dimanica As Decimal 'Cantidad que usare para asignar cantidad de items de acuerdo a recorrido por treeview
    Private cantidad_produccion As Decimal  'Cantidad requerida en un OP
    Private fecha_op_inicio As Date
    Private fecha_op_final As Date
    Private id_item_seleccionado_tree As Integer 'El id_item del nodo seleccionado
    Public name_nodo_creado As String
    Private id_ipp_nodo_padre As String 'el id_ipp del nodo inicial de un ramal del arbol
    Private item_principal_seleccionado_tree As String = "N"


    Private Sub fm_0400_pp_ordenes_produccion_arbol_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'id_prog_prod = 4
        'MsgBox("id_prog_prod:" & id_prog_prod & vbCrLf _
        '      & "id_item_clonar: " & id_item_clonar & vbCrLf _
        '     & "id_item_pp: " & id_item_pp & vbCrLf _
        '      & "tree_path_base: " & tree_path_base)

        'Cargo informacion de las plantillas y sus items
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "select * from " & database.obtener_esquema & ".tb0401_items_prog_prod" _
            & " where f0401_id_ipp = '" & id_item_pp & "'"
        Dim otb_info_programa_prod As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_programa_prod.Rows
            tx_cantidad_ordenada.Text = CDec(orow("f0401_cantidad")).ToString("N2")
        Next
        llenar_arbol()
        If nodo_buscar <> "" Then
            expandir_nodo(nodo_buscar)
        End If
    End Sub

    Private Sub llenar_arbol()
        cargar_otabla_items_programa_produccion()
        cargar_otabla_reportes_produccion()
        If filtro_rama = "N" Then
            TreeView1.Nodes.Clear()
            CrearNodosDelPadre(otb_items_programa_produccion, tree_path_base, Nothing)
            'TreeView1.Nodes.Item(0).Expand()
            'tx_elemento_seleccionado.Text = "N/D"
            'llenar_combo_elementos()
        Else
            'llenar_rama_arbol()
            'TreeView1.Nodes.Item(0).Expand()
        End If
        Dim cantidad_programada As Decimal
        Dim cantidad_producida As Decimal
        Try
            cantidad_programada = CDec(otb_items_programa_produccion.Compute("sum(f0401_cantidad)", "f0401_tree_path ='" & tree_path_base & "'" _
                                                                                        & " and f0401_anulado = 'N'"))
        Catch ex As Exception
            cantidad_programada = 0
        End Try
        Try
            cantidad_producida = CDec(otb_reportes_produccion.Compute("sum(f0402_cantidad_producida)",
                                                                      "f0401_id_item = '" & id_item_clonar & "'" _
                                                                      & " and f0401_tree_path ='" & tree_path_base & "'" _
                                                                      & " and f0401_anulado = 'N' and f0402_anulado = 'N'"))
        Catch ex As Exception
            cantidad_producida = 0
        End Try
        tx_cantidad_programada.Text = cantidad_programada.ToString("N2")
        tx_cantidad_producida.Text = cantidad_producida.ToString("N2")
    End Sub

    Private Sub cargar_otabla_items_programa_produccion()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-03", vg_id_cia)
        csql = csql.Replace("$001$", tree_path_base)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_programa_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_items_programa_produccion.Rows.Count)
    End Sub
    Private Sub cargar_otabla_reportes_produccion()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-06", vg_id_cia)
        csql = csql.Replace("$001$", tree_path_base)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_reportes_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Function calcular_produccion_x_id_ipp(ByVal id_ipp As Integer)
        Dim cantidad_producida As Decimal
        If IsDBNull(otb_reportes_produccion.Compute("sum(f0402_cantidad_producida)",
                                                                      "f0402_id_ipp = '" & id_ipp & "'" _
                                                                      & " and f0401_anulado = 'N' and f0402_anulado = 'N'")
                    ) = False Then
            cantidad_producida = CDec(otb_reportes_produccion.Compute("sum(f0402_cantidad_producida)",
                                                                      "f0402_id_ipp = '" & id_ipp & "'" _
                                                                      & " and f0401_anulado = 'N' and f0402_anulado = 'N'"))
        Else
            cantidad_producida = 0
        End If

        Try

        Catch ex As Exception

        End Try
        Return cantidad_producida
    End Function
    Private Sub CrearNodosDelPadre(ByVal odatatable As DataTable, ByVal indicePadre As String, ByVal nodePadre As TreeNode)
        Dim ods As New DataSet
        Dim dataViewHijos As New DataView
        'codigo_padre de quien dependo
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(odatatable, "", "f0401_fecha_inicio", DataViewRowState.CurrentRows)
        dataViewHijos.RowFilter = odatatable.Columns("f0401_tree_path").ColumnName + " = '" + indicePadre.ToString() + "'"
        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos
            Dim nuevoNodo As New TreeNode
            cantidad_dimanica = CDec(dataRowCurrent("f0401_cantidad"))
            Dim cantidad_baches As Decimal = 0
            Dim unidades_x_bache As Decimal = dataRowCurrent("f0401_unid_x_bache")
            If unidades_x_bache <> 0 Then
                cantidad_baches = cantidad_dimanica / unidades_x_bache
            Else
                cantidad_baches = 0
            End If
            If dataRowCurrent("f0401_cerrado") = "N" Then
                nuevoNodo.Text = "   {A} "
            Else
                nuevoNodo.Text = "   {C} "
            End If
            nuevoNodo.Text += "(IPP-" & dataRowCurrent("f0401_id_ipp").ToString().Trim() & ")   " _
                                & "   Cantidad Programada: " _
                                & CDec(dataRowCurrent("f0401_cantidad")).ToString("N1").PadLeft(8, " ")

            nuevoNodo.Tag = dataRowCurrent("f0401_id_item").ToString().Trim()
            nuevoNodo.Name = "IPP-" & dataRowCurrent("f0401_id_ipp").ToString

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
                'nuevoNodo.ForeColor = Color.Green
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            Dim nuevo_path As String = indicePadre.ToString & Split(nuevoNodo.Name, "-")(1) & "-"
            llenar_rama_arbol_reportes_produccion(Split(nuevoNodo.Name, "-")(1), nuevoNodo)
            llenar_rama_arbol_secuencia(otb_items_programa_produccion, nuevo_path, nuevoNodo)
            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'MsgBox(nuevo_path)
        Next dataRowCurrent
    End Sub

    Private Sub llenar_rama_arbol_secuencia(ByVal otb_items_programa_produccion As DataTable, ByVal path_padre As String, ByVal nodePadre As TreeNode)
        Dim dataViewHijos As New DataView
        'identifico los items hijos que estan programados
        dataViewHijos = New DataView(otb_items_programa_produccion, "", "f0401_id_ipp", DataViewRowState.CurrentRows)
        dataViewHijos.RowFilter = otb_items_programa_produccion.Columns("f0401_tree_path").ColumnName + " = '" + path_padre.ToString() + "'"
        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each orow_producto_semiterminado_programado As DataRowView In dataViewHijos
            Dim id_item_semiproducto As Integer
            id_item_semiproducto = orow_producto_semiterminado_programado("f0401_id_item")
            Dim cantidad_programada As Decimal
            cantidad_programada = CDec(orow_producto_semiterminado_programado("f0401_cantidad"))

            'identifico informacion de la plantilla de produccion del producto semiterminado
            Dim dataviewplantilla As New DataView
            Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_semiproducto & "'" _
                                             & " and f0350_activa = 'S'"
            dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
            Dim texto_nodo As String = ""
            For Each orowplantilla As DataRowView In dataviewplantilla
                'Identifico el item en la plantilla
                texto_nodo = ""
                Dim bache_prod_item As Decimal
                bache_prod_item = orowplantilla("f0350_produccion_x_bache")

                If orow_producto_semiterminado_programado("f0401_cerrado") = "N" Then
                    texto_nodo = " {A} "
                Else
                    texto_nodo = " {C} "
                End If

                texto_nodo += " (IPP-" & orow_producto_semiterminado_programado("f0401_id_ipp") & ")" _
                        & "  --  " & orowplantilla("f0300_descripcion_item").ToString _
                        & " { Cantidad Requerida: " _
                        & cantidad_programada.ToString("N2") & " " & orowplantilla("f0002_unidad_medicion") _
                        & " << #Baches: " & (cantidad_programada / bache_prod_item).ToString("N2") _
                        & " de " & bache_prod_item.ToString("N2") & " >> }" _
                        & "  [" _
                        & CDate(orow_producto_semiterminado_programado("f0401_fecha_inicio")).ToString("yyyy/MM/dd HH:mm") _
                        & " - " _
                        & CDate(orow_producto_semiterminado_programado("f0401_fecha_final")).ToString("yyyy/MM/dd HH:mm") _
                        & " ] => PRODUCCION: " & CDec(calcular_produccion_x_id_ipp(orow_producto_semiterminado_programado("f0401_id_ipp"))).ToString("N2")
            Next
            Dim id_ipp As Integer = orow_producto_semiterminado_programado("f0401_id_ipp")
            Dim path_ipp As String = orow_producto_semiterminado_programado("f0401_tree_path")
            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = texto_nodo
            nuevoNodo.Tag = orow_producto_semiterminado_programado("f0401_id_item").ToString().Trim()
            nuevoNodo.Name = "IPP-" & id_ipp.ToString
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
                nuevoNodo.ForeColor = Color.Green
            End If
            'Llenar informacion de reportes de produccion.
            llenar_rama_arbol_reportes_produccion(Split(nuevoNodo.Name, "-")(1), nuevoNodo)
            'llenamos las ipp de los subproductos
            llenar_rama_arbol_secuencia(otb_items_programa_produccion, path_ipp & id_ipp & "-", nuevoNodo)
        Next orow_producto_semiterminado_programado
    End Sub

    Private Sub llenar_rama_arbol_reportes_produccion(id_ipp_padre As String, ByVal nodePadre As TreeNode)
        Dim dataviewrp As New DataView
        'identifico los items hijos que estan programados
        dataviewrp = New DataView(otb_reportes_produccion, "", "", DataViewRowState.CurrentRows)
        dataviewrp.RowFilter = otb_reportes_produccion.Columns("f0402_id_ipp").ColumnName + " = '" + id_ipp_padre + "'"
        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each orow_reporte_produccion As DataRowView In dataviewrp
            Dim id_rp As Integer
            id_rp = orow_reporte_produccion("f0402_id_rp")
            Dim cantidad_producida As Decimal
            cantidad_producida = CDec(orow_reporte_produccion("f0402_cantidad_producida"))
            Dim lote As String = orow_reporte_produccion("f0402_lote")
            Dim texto_nodo As String = ""
            texto_nodo = ""
            'If orow_reporte_produccion("f0402_estado") = "A" Then
            'texto_nodo = " {A} "
            'Else
            'texto_nodo = " {C} "
            'End If
            Select Case orow_reporte_produccion("f0402_estado")
                Case "A"
                    texto_nodo = " {A} "
                Case "B"
                    texto_nodo = " {B} "
                Case "C"
                    texto_nodo = " {C} "
            End Select
            texto_nodo += " (RP-" & orow_reporte_produccion("f0402_id_rp") & ")" _
                    & " { Lote: " _
                    & lote.ToString() _
                    & "  } [" _
                    & CDate(orow_reporte_produccion("f0402_fecha_produccion")).ToString("yyyy/MM/dd") _
                    & " <=> " _
                    & CDate(orow_reporte_produccion("f0402_fecha_vence")).ToString("yyyy/MM/dd") _
                    & " ]"

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = texto_nodo
            nuevoNodo.Tag = orow_reporte_produccion("f0401_id_item").ToString().Trim()
            nuevoNodo.Name = "RP-" & orow_reporte_produccion("f0402_id_rp").ToString
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
                nuevoNodo.ForeColor = Color.Red
            End If
        Next orow_reporte_produccion
    End Sub

    Private Sub llenar_rama_arbol_secuencia_previos(ByVal id_item_padre As String, ByVal nodePadre As TreeNode, cantidad As Decimal)
        'llena el treeview pero no afecta la base de datos.
        'Lleno como nodos los semiproductos del producto_terminado
        'Primero identifico la plantilla

        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_padre & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
        For Each orowplantilla As DataRowView In dataviewplantilla
            'Identifico los items de la plantilla
            Dim dataviewitemsplantilla As New DataView
            dataviewitemsplantilla = New DataView(otb_items_plantillas, "f0351_id_plantilla = '" & orowplantilla("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
            For Each orowitemsplantilla As DataRowView In dataviewitemsplantilla
                Dim cantidad_item As Decimal = (cantidad / orowplantilla("f0350_produccion_x_bache")) * orowitemsplantilla("f0351_cantidad")
                'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
                Dim dataviewplantillaitem As New DataView
                dataviewplantillaitem = New DataView(otb_plantillas, "f0350_id_item = '" & orowitemsplantilla("f0351_id_item") & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
                Dim bache_prod_item As Decimal
                For Each orowplantillaitem As DataRowView In dataviewplantillaitem
                    bache_prod_item = orowplantillaitem("f0350_produccion_x_bache")
                Next

                Dim nuevoNodo2 As New TreeNode
                Dim texto_nodo As String
                Dim semiproducto As String = "N"
                texto_nodo = orowitemsplantilla("f0351_id_item") & " -- " & orowitemsplantilla("f0300_descripcion_item").ToString.PadRight(60, "-") _
                    & " { Cantidad Requerida: " _
                    & cantidad_item.ToString("N1") & " " & orowitemsplantilla("f0002_unidad_medicion")
                If orowitemsplantilla("f0300_id_tipo_item").ToString = "25" Then
                    texto_nodo += " << #Baches: " & (cantidad_item / bache_prod_item).ToString("N1") _
                        & " de " & bache_prod_item.ToString("N1") & " >> }"
                    semiproducto = "S"
                Else
                    texto_nodo += " }"
                    semiproducto = "N"
                End If
                'para agregar solo los items tipo semiproductos
                If semiproducto = "S" Then
                    nuevoNodo2.Text = texto_nodo
                    nuevoNodo2.Tag = orowitemsplantilla("f0351_id_item")
                    nuevoNodo2.Name = "IPP-" & orowitemsplantilla("f0351_id_elemento")
                    ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                    ' del primer nivel que no dependen de otro nodo.
                    If nodePadre Is Nothing Then
                        TreeView1.Nodes.Add(nuevoNodo2)
                    Else
                        ' se añade el nuevo nodo al nodo padre.
                        nodePadre.Nodes.Add(nuevoNodo2)
                    End If
                    llenar_rama_arbol_secuencia_previos(orowitemsplantilla("f0351_id_item"), nodePadre, cantidad_item)
                End If
            Next
        Next
    End Sub

    Private Sub crear_op_semiproductos(ByVal id_item_padre As Integer, ByVal id_ipp_padre As Integer, ByVal path_padre As String, cantidad_padre As Decimal,
                                       ByVal fecha_ini As Date, ByVal fecha_fin As Date)
        'Primero identifico la plantilla del item al que le quiero crear los hijos
        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_padre & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
        For Each orowplantilla As DataRowView In dataviewplantilla
            'Identifico y recorro los items de la plantilla
            Dim dataviewitemsplantilla As New DataView
            dataviewitemsplantilla = New DataView(otb_items_plantillas, "f0351_id_plantilla = '" & orowplantilla("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
            For Each orowitemsplantilla As DataRowView In dataviewitemsplantilla
                'Identifico informacion del item de la plantilla

                'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
                Dim dataviewplantillaitem As New DataView
                dataviewplantillaitem = New DataView(otb_plantillas, "f0350_id_item = '" & orowitemsplantilla("f0351_id_item") & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
                Dim bache_prod_item As Decimal
                For Each orowplantillaitem As DataRowView In dataviewplantillaitem
                    bache_prod_item = orowplantillaitem("f0350_produccion_x_bache")
                Next

                'Determino cantidad requerida del item
                Dim cantidad_item As Decimal = (cantidad_padre / orowplantilla("f0350_produccion_x_bache")) * orowitemsplantilla("f0351_cantidad")
                Dim cant_baches As Decimal
                Dim semiproducto As String = "N"
                Dim id_item_hijo As Integer = orowitemsplantilla("f0351_id_item")
                If orowitemsplantilla("f0300_id_tipo_item").ToString = "25" Then
                    semiproducto = "S"
                    cant_baches = cantidad_item / bache_prod_item
                Else
                    semiproducto = "N"
                End If
                Dim item_programable As String = "N" 'Indica si el item se debe programar para produccion
                If orowitemsplantilla("f0300_pp_programable").ToString = "S" Then
                    item_programable = "S"
                Else
                    item_programable = "N"
                End If
                'para agregar solo los items tipo semiproductos
                If semiproducto = "S" Then
                    Dim id_ipp_creada As Integer
                    'creo la orden de produccion
                    'Agregar solo los items programables
                    If item_programable = "S" Then
                        id_ipp_creada = nueva_op(id_prog_prod, id_item_hijo, cantidad_item, cant_baches, id_ipp_padre, path_padre, fecha_ini, fecha_fin)
                        'creo las ordenes de produccion hijos
                        crear_op_semiproductos(id_item_hijo, id_ipp_creada, path_padre & id_ipp_creada & "-", cantidad_item, fecha_ini, fecha_fin)
                    Else
                        'ESTA CREANDO DOBLE PROGRAMACION. NO VEO LA NECESIDAD DE ESTA LINEA DE CODIGOS. LA DEJO PARA MAS ADELANTE
                        'crear subitems que sean programables pero hijos del no programable
                        'Primero identifico la plantilla del item no programable

                        'Dim dataviewplantilla_np As New DataView
                        'Dim filtro_plantilla_np As String = "f0350_id_item = '" & id_item_hijo & "'" _
                        '& " and f0350_activa = 'S'"
                        'dataviewplantilla_np = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
                        'For Each orowplantilla_np As DataRowView In dataviewplantilla_np
                        'Identifico los items de la plantilla
                        'Dim dataviewitemsplantilla_np As New DataView
                        'dataviewitemsplantilla_np = New DataView(otb_items_plantillas, "f0351_id_plantilla = '" & orowplantilla_np("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
                        'For Each orowitemsplantilla_np As DataRowView In dataviewitemsplantilla
                        'creo los suitems que sean programables
                        'crear_op_semiproductos(orowitemsplantilla_np("f0351_id_item"), id_ipp_padre, path_padre, cantidad_item)
                        'Next
                        'Next
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub bt_nueva_orden_de_produccion_Click(sender As Object, e As EventArgs) Handles bt_nueva_orden_de_produccion.Click
        'Pregunta si realmente desea crear una nueva OP
        Dim respuesta As String = "N"
        Dim cantidad_producir As String
        respuesta = comunes.g_mensaje_YesNo("Crear nueva OP", "Desea crear una nueva OP?")
        If respuesta = "N" Then
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cantidad_producir = comunes.formulario_parametro_texto("0", "Cantidad a Producir", False).ToString.Trim
            If IsNumeric(cantidad_producir) = True Then
                If CDec(cantidad_producir) = 0 Then
                    MsgBox("Edicion OP cancelada, la cantidad debe ser diferente de 0", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                'MsgBox(rango_fechas(1))
                'MsgBox(rango_fechas(3))
                'MsgBox(CDec(cantidad_producir))
                cantidad_produccion = CDec(cantidad_producir)
                Dim cant_baches As Decimal
                Dim t_bache As Decimal = entregar_valor_campo_plantilla(id_item_clonar, "f0350_produccion_x_bache")
                If CDec(t_bache) = 0 Then
                    MsgBox("Edicion de OP cancelada, revise la plantilla del producto, cantidad bache = 0 o no existe", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
                'MsgBox(id_item_clonar)
                cant_baches = cantidad_produccion / t_bache
                fecha_op_inicio = CDate(rango_fechas(1))
                fecha_op_final = CDate(rango_fechas(3))
                Dim nuevo_id_ipp As Integer
                nuevo_id_ipp = nueva_op(id_prog_prod, id_item_clonar, cantidad_produccion, cant_baches, id_item_pp, tree_path_base, fecha_op_inicio, fecha_op_final)
                crear_op_semiproductos(id_item_clonar, nuevo_id_ipp, tree_path_base & nuevo_id_ipp & "-", cantidad_produccion, fecha_op_inicio, fecha_op_final)
                'MsgBox("path: " & tree_path_base & op_creada & "-")
                llenar_arbol()
                expandir_nodo("IPP-" & nuevo_id_ipp)
            Else
                MsgBox("Creacion de OP cancelada, la cantidad debe ser numerica", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Else
            MsgBox("Creacion de OP cancelada", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

    End Sub

    Private Function nueva_op(ByVal oid_prog_prod As Integer, id_item As Integer, ByVal cantidad As Decimal, ByVal num_baches As Decimal,
                         ByVal id_ipp_padre As Integer, ByVal path As String, ByVal fecha_ini As Date, ByVal fecha_fin As Date)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0401_items_prog_prod" _
                & " (f0401_id_cia, f0401_id_prog_prod, f0401_id_item, f0401_cantidad," _
                & " f0401_cant_baches, f0401_unid_x_bache," _
                & " f0401_fecha_inicio, f0401_fecha_final, f0401_id_ipp_padre, f0401_tree_path," _
                & " f0401_usuario_modificar, f0401_usuario_crear, f0401_fm)" _
                & " VALUES" _
                & " (@f0401_id_cia, @f0401_id_prog_prod, @f0401_id_item, @f0401_cantidad," _
                & " @f0401_cant_baches, @f0401_unid_x_bache," _
                & " @f0401_fecha_inicio, @f0401_fecha_final, @f0401_id_ipp_padre, @f0401_tree_path," _
                & " @f0401_usuario_modificar, @f0401_usuario_crear, @f0401_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_id_prog_prod", NpgsqlDbType.Integer).Value = oid_prog_prod
        ocmd.Parameters.Add("@f0401_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0401_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0401_cantidad", NpgsqlDbType.Numeric).Value = cantidad
        ocmd.Parameters.Add("@f0401_cant_baches", NpgsqlDbType.Numeric).Value = num_baches
        ocmd.Parameters.Add("@f0401_unid_x_bache", NpgsqlDbType.Numeric).Value = cantidad / num_baches
        ocmd.Parameters.Add("@f0401_fecha_inicio", NpgsqlDbType.Timestamp).Value = fecha_ini 'fecha_op_inicio
        ocmd.Parameters.Add("@f0401_fecha_final", NpgsqlDbType.Timestamp).Value = fecha_fin 'fecha_op_final
        ocmd.Parameters.Add("@f0401_id_ipp_padre", NpgsqlDbType.Integer).Value = id_ipp_padre
        ocmd.Parameters.Add("@f0401_tree_path", NpgsqlDbType.Varchar).Value = path
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        Dim op_creada As Integer

        If verror = "N" Then
            op_creada = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0401_id_ipp", "f0401_usuario_crear", vg_usuario_autoriza, "tb0401_items_prog_prod")
        Else
            op_creada = 0
        End If
        Return op_creada
    End Function

    Private Sub editar_op(ByVal id_ipp As Integer, ByVal cantidad As Decimal, ByVal num_baches As Decimal,
                          ByVal fecha_inicio As Date, ByVal fecha_final As Date)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0401_items_prog_prod set "
        csql += "f0401_cantidad = @f0401_cantidad,"
        csql += "f0401_cant_baches = @f0401_cant_baches,"
        csql += "f0401_unid_x_bache = @f0401_unid_x_bache,"
        csql += "f0401_fecha_inicio = @f0401_fecha_inicio, "
        csql += "f0401_fecha_final = @f0401_fecha_final,"
        csql += "f0401_usuario_modificar = @f0401_usuario_modificar,"
        csql += "f0401_fm = @f0401_fm"
        csql += " where f0401_id_ipp = @f0401_id_ipp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_id_ipp", NpgsqlDbType.Integer).Value = id_ipp
        ocmd.Parameters.Add("@f0401_cantidad", NpgsqlDbType.Numeric).Value = cantidad
        ocmd.Parameters.Add("@f0401_cant_baches", NpgsqlDbType.Numeric).Value = num_baches
        ocmd.Parameters.Add("@f0401_unid_x_bache", NpgsqlDbType.Numeric).Value = cantidad / num_baches
        ocmd.Parameters.Add("@f0401_fecha_inicio", NpgsqlDbType.Timestamp).Value = fecha_op_inicio
        ocmd.Parameters.Add("@f0401_fecha_final", NpgsqlDbType.Timestamp).Value = fecha_op_final
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        tipo_registro = Split(e.Node.Name, "-")(0)
        lb_tipo_registro.Text = tipo_registro & " #:"
        numero_registro = Split(e.Node.Name, "-")(1)
        tx_id_registro.Text = numero_registro

        id_item_seleccionado_tree = e.Node.Tag
        'MsgBox(id_item_seleccionado_tree)
        item_principal_seleccionado_tree = "N"
        'Try
        '    id_ipp_nodo_padre = Split(e.Node.Parent.Name, "-")(1)
        'Catch ex As Exception
        '    item_principal_seleccionado_tree = "S"
        'End Try

        If e.Node.Parent Is Nothing Then
            item_principal_seleccionado_tree = "S"
            id_ipp_nodo_padre = 0
        Else
            Dim parts As String() = e.Node.Parent.Name.Split("-"c)
            If parts.Length > 1 AndAlso Integer.TryParse(parts(1), Nothing) Then
                id_ipp_nodo_padre = parts(1)
            Else
                ' Manejar formato inesperado
                id_ipp_nodo_padre = 0
            End If
        End If

        If item_principal_seleccionado_tree = "S" Then
            id_ipp_nodo_padre = 0
        Else
            'no debo redefinir el id_item_clonar pues al hacer clic en otro lado del arbol se cambia este valor y degenera la programacion
            'pues el nuevo IPP tomara el ultimo valor asignado al tocar cualquier rama del arbol.
            'id_item_clonar = e.Node.Parent.Tag
        End If
        'MsgBox(tipo_registro & "--" & numero_registro)
        'MsgBox(id_ipp_nodo_padre)
        'MsgBox("Principal. " & item_principal_seleccionado_tree)
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        Select Case tipo_registro
            Case "RP"
                consultar_rp()
            Case "IPP"
                editar_op()
        End Select
    End Sub

    Private Function entregar_valor_campo_ipp(ByVal id_ipp As Integer, campo As String)
        Dim valor = Nothing
        'Busco la informacion del id_ipp del subproducto
        Dim dataviewitemsprogramados As New DataView
        Dim filtro_ipp As String
        filtro_ipp = "f0401_id_ipp = '" & id_ipp & "'"
        dataviewitemsprogramados = New DataView(otb_items_programa_produccion, filtro_ipp, "", DataViewRowState.CurrentRows)
        For Each orowsubipp As DataRowView In dataviewitemsprogramados
            valor = orowsubipp(campo)
        Next
        Return valor
    End Function

    Private Function entregar_valor_campo_plantilla(ByVal id_item As Integer, ByVal campo As String)
        'identifico informacion de la plantilla de produccion del producto semiterminado
        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
        Dim valor = Nothing
        For Each orowplantilla As DataRowView In dataviewplantilla
            valor = orowplantilla(campo)
        Next
        Return valor
    End Function

    Private Sub bt_editar_op_Click(sender As Object, e As EventArgs) Handles bt_editar_op.Click
        editar_op()
    End Sub

    Private Sub editar_op()
        If tipo_registro <> "IPP" Then
            'no se esta seleccionando un item de prodgrama de produccion(ipp) sino un rdp (reporte de produccion)
            Exit Sub
        End If
        'Valido si tiene permiso para editar la OP
        Dim autorizado As String = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_editar_op", vf_otabla_permisos, vg_usuario_autoriza)


        'Valido si el IPP esta cerrado
        Dim ocerrado = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_cerrado")
        If ocerrado = "S" Then
            MsgBox("El IPP esta CERRADO", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Pregunta si realmente desea editar esta IPP
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Editar OP", "Desea EDITAR esta OP?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Identificamos la cantidad actual del registro
        Dim ocantidad_prog As Decimal = 0
        Dim oinfo_reg As DataRow()
        oinfo_reg = otb_items_programa_produccion.Select("f0401_id_ipp = '" & numero_registro & "'")
        'cl_utilidades_datatables.visualizar_datos_visor("", "", "", "", {}, otb_items_programa_produccion)
        For Each orow As DataRow In oinfo_reg
            ocantidad_prog = orow("f0401_cantidad")
        Next
        'inicializamos la variable que determinara la accion a realizar al cerrar el form
        proceder_edicion_ipp = "ND"
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_editar_ipp As New camocontrol.fm_0400_pp_edicion_programa
        'oform_grilla_programacion.ods_hijo = ods
        oform_editar_ipp.vf_oform_padre = Me
        oform_editar_ipp.vg_id_cia = vg_id_cia
        oform_editar_ipp.vg_usuario_autoriza = vg_usuario_autoriza
        oform_editar_ipp.item_principal_seleccionado_tree = item_principal_seleccionado_tree
        oform_editar_ipp.id_item_pp = numero_registro
        oform_editar_ipp.cantidad_original = ocantidad_prog
        oform_editar_ipp.otb_items_programa_produccion = otb_items_programa_produccion
        oform_editar_ipp.ShowDialog()
        'si no se genera cambio entonces salgo
        If proceder_edicion_ipp = "ND" Then
            Exit Sub
        End If
        Select Case proceder_edicion_ipp
            Case "MOD"
                'Modifico el IPP
                For Each orow As DataRow In otb_edicion.Rows
                    Dim cant_baches As Decimal
                    cantidad_produccion = orow("cantidad")
                    fecha_op_inicio = orow("fecha_ini")
                    fecha_op_final = orow("fecha_fin")
                    cant_baches = cantidad_produccion / entregar_valor_campo_plantilla(id_item_seleccionado_tree, "f0350_produccion_x_bache")
                    editar_op(tx_id_registro.Text, cantidad_produccion, cant_baches, fecha_op_inicio, fecha_op_final)
                    editar_op_semiproductos(id_item_seleccionado_tree, tx_id_registro.Text, cantidad_produccion, fecha_op_inicio, fecha_op_final)
                    'MsgBox("path: " & tree_path_base & op_creada & "-")
                    llenar_arbol()
                    Dim nombre_nodo As String
                    nombre_nodo = tipo_registro & "-" & tx_id_registro.Text
                    expandir_nodo(nombre_nodo)
                Next
            Case "DIV"
                'identifico la informacion necesaria para crear los hijos
                'crear_op_semiproductos(ByVal id_item_padre As Integer, ByVal id_ipp_padre As Integer, 
                'ByVal path_padre As String, cantidad As Decimal)
                Dim id_ipp_padre As Integer = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_id_ipp_padre")
                Dim id_item_padre As Integer = entregar_valor_campo_ipp(id_ipp_padre, "f0401_id_item")
                Dim path_padre As String = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_tree_path")

                'Encuentro el factor para calcular la cantidades requeridas del item, debido a que el programa calcula
                'las cantidades del item hijo de acuerdo a las cantidades del item padre y la funcion crear_op_semiproductos
                'tiene como argumento la cantidad del item padre
                Dim cantidad_padre As Decimal = entregar_valor_campo_ipp(id_ipp_padre, "f0401_cantidad")
                Dim cantidad_hijo As Decimal = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_cantidad")
                Dim factor_correccion As Decimal = cantidad_padre / cantidad_hijo

                Dim onew_cantidad As Decimal = 0
                Dim fecha_ini As Date
                Dim fecha_fin As Date

                'Antes crear las nuevas OP primero debo Anular OP antigua que fue dividida, si esta ya tiene
                'RP entonces no puedo crear nuevas OP
                verror = "N"
                anular_op()
                If verror = "S" Then
                    Exit Sub
                End If
                For Each orow As DataRow In otb_edicion.Rows
                    onew_cantidad = orow("cantidad") * factor_correccion
                    fecha_ini = orow("fecha_ini")
                    fecha_fin = orow("fecha_fin")
                    crear_op_semiproductos(id_item_padre, id_ipp_padre, path_padre, onew_cantidad, fecha_ini, fecha_fin)
                Next


                'vuelvo a cargar el arbol
                llenar_arbol()
                Dim nombre_nodo As String
                nombre_nodo = "IPP-" & id_ipp_padre
                expandir_nodo(nombre_nodo)
        End Select
    End Sub

    Private Sub editar_op_semiproductos(ByVal id_item_padre As Integer, ByVal id_ipp_padre As Integer, cantidad_ipp_padre As Decimal,
                                        ByVal fecha_ini As Date, ByVal fecha_fin As Date)
        'Primero identifico la plantilla del item padre
        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_padre & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
        For Each orowplantilla As DataRowView In dataviewplantilla
            'Identifico los items de la plantilla
            Dim dataviewitemsplantilla As New DataView
            dataviewitemsplantilla = New DataView(otb_items_plantillas, "f0351_id_plantilla = '" & orowplantilla("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
            For Each orowitemsplantilla As DataRowView In dataviewitemsplantilla
                Dim cantidad_item As Decimal = (orowitemsplantilla("f0351_cantidad") / orowplantilla("f0350_produccion_x_bache")) * cantidad_ipp_padre
                'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
                Dim dataviewplantillaitem As New DataView
                dataviewplantillaitem = New DataView(otb_plantillas, "f0350_id_item = '" & orowitemsplantilla("f0351_id_item") & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
                Dim bache_prod_item As Decimal
                For Each orowplantillaitem As DataRowView In dataviewplantillaitem
                    bache_prod_item = orowplantillaitem("f0350_produccion_x_bache")
                Next
                Dim semiproducto As String = "N"
                Dim id_item_hijo As Integer = orowitemsplantilla("f0351_id_item")
                If orowitemsplantilla("f0300_id_tipo_item").ToString = "25" Then
                    semiproducto = "S"
                Else
                    semiproducto = "N"
                End If
                'para agregar solo los items tipo semiproductos
                If semiproducto = "S" Then
                    'Busco la informacion del id_ipp del subproducto
                    Dim dataviewsubitemsprogramados As New DataView
                    Dim filtro_ipp As String
                    filtro_ipp = "f0401_id_ipp_padre = '" & id_ipp_padre & "' and f0401_id_item = '" & id_item_hijo & "'"
                    dataviewsubitemsprogramados = New DataView(otb_items_programa_produccion, filtro_ipp, "", DataViewRowState.CurrentRows)
                    Dim id_ipp_hijo As Integer
                    For Each orowsubipp As DataRowView In dataviewsubitemsprogramados
                        'MsgBox(orowsubipp("f0401_id_ipp"))
                        'Edito la informacion del subproducto programado
                        'MsgBox(cantidad_item)
                        editar_op(orowsubipp("f0401_id_ipp"), cantidad_item, cantidad_item / bache_prod_item, fecha_ini, fecha_fin)
                        id_ipp_hijo = orowsubipp("f0401_id_ipp")
                    Next
                    editar_op_semiproductos(id_item_hijo, id_ipp_hijo, cantidad_item, fecha_ini, fecha_fin)
                End If
            Next
        Next
    End Sub

    Private Sub mi_imprimir_etiqueta_Click(sender As Object, e As EventArgs) Handles mi_imprimir_etiqueta.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        If tx_id_registro.Text = "" Or tipo_registro <> "RP" Then
            MsgBox("Seleccione un RP")
            Exit Sub
        End If
        Dim oform_impresion_etiquetas As New camocontrol.fm_0400_impresion_etiquetas
        'oform_grilla_programacion.ods_hijo = ods
        oform_impresion_etiquetas.vf_oform_padre = Me
        oform_impresion_etiquetas.vg_id_cia = vg_id_cia
        oform_impresion_etiquetas.vg_usuario_autoriza = vg_usuario_autoriza
        'oform_impresion_etiquetas.tx_op_ppal.Text = tx_id_registro.Text
        'oform_impresion_etiquetas.id_item = id_item_seleccionado_tree
        oform_impresion_etiquetas.descripcion_item = lb_producto.Text
        oform_impresion_etiquetas.id_rp = Split(tx_id_registro.Text, "-")(0)
        oform_impresion_etiquetas.ShowDialog()
    End Sub

    Private Sub mi_ajustar_cantidad_bache_Click(sender As Object, e As EventArgs) Handles mi_ajustar_cantidad_bache.Click
        If item_principal_seleccionado_tree = "S" Or tipo_registro <> "IPP" Then
            MsgBox(item_principal_seleccionado_tree)
            MsgBox(tipo_registro)
            MsgBox("Solo se puede modificar la informacion de semiproductos", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If

        'Pregunta si realmente desea crear una nueva OP
        Dim respuesta As String = "N"
        Dim cantidad_baches_subproducto As Decimal = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_cant_baches")
        Dim nueva_cantidad_baches_subproducto As String
        respuesta = comunes.g_mensaje_YesNo("Editar OP", "Desea EDITAR la cantidad de esta OP?")
        If respuesta = "N" Then
            Exit Sub
        End If

        Dim cantidad_padre As Decimal = entregar_valor_campo_ipp(id_ipp_nodo_padre, "f0401_cantidad")
        'MsgBox(id_ipp_nodo_padre & " cantidad: " & cantidad_padre)
        Dim unidades_x_bache_padre As Decimal = entregar_valor_campo_ipp(id_ipp_nodo_padre, "f0401_unid_x_bache")
        fecha_op_inicio = entregar_valor_campo_ipp(id_ipp_nodo_padre, "f0401_fecha_inicio")
        fecha_op_final = entregar_valor_campo_ipp(id_ipp_nodo_padre, "f0401_fecha_final")
        Dim cantidad_padre_nueva As Decimal
        nueva_cantidad_baches_subproducto = comunes.formulario_parametro_texto("0", "Cantidad de baches a Producir", False).ToString.Trim
        If IsNumeric(nueva_cantidad_baches_subproducto) = True Then
            If CDec(nueva_cantidad_baches_subproducto) = 0 Then
                MsgBox("Edicion OP cancelada, la cantidad debe ser diferente de 0", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            cantidad_padre_nueva = CDec(nueva_cantidad_baches_subproducto) * cantidad_padre / cantidad_baches_subproducto

            'MsgBox(CDec(nueva_cantidad_baches_subproducto) & " * " & cantidad_padre & " / " & cantidad_baches_subproducto)
            'MsgBox(cantidad_padre_nueva)
        Else
            MsgBox("La cantidad debe ser numerica", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim nueva_cantidad_baches_padre As Decimal = cantidad_padre_nueva / unidades_x_bache_padre
        'MsgBox("Cant padre nueva: " & cantidad_padre_nueva & " nuevo numero de baches: " & nueva_cantidad_baches_padre)
        editar_op(id_ipp_nodo_padre, cantidad_padre_nueva, nueva_cantidad_baches_padre, fecha_op_inicio, fecha_op_final)
        editar_op_semiproductos(id_item_clonar, id_ipp_nodo_padre, cantidad_padre_nueva, fecha_op_inicio, fecha_op_final)
        'MsgBox("path: " & tree_path_base & op_creada & "-")
        llenar_arbol()
        expandir_nodo(tipo_registro & "-" & tx_id_registro.Text)

    End Sub

    Private Sub bt_anular_op_Click(sender As Object, e As EventArgs) Handles bt_anular_op.Click
        If tx_id_registro.Text = "" Or tipo_registro <> "IPP" Then
            Exit Sub
        End If
        'Valido si el IPP esta cerrado
        Dim ocerrado = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_cerrado")
        If ocerrado = "S" Then
            MsgBox("El IPP esta CERRADO", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Pregunta si realmente desea crear una nueva OP
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular OP", "Desea ANULAR esta OP?")
        If respuesta = "N" Then
            Exit Sub
        End If

        anular_op()

        If verror = "N" Then
            MsgBox("OP Anulada", MsgBoxStyle.Information, "Info")
            llenar_arbol()
            'MsgBox(id_ipp_nodo_padre.ToString)
            expandir_nodo(tipo_registro & "-" & id_ipp_nodo_padre.ToString)
            Try
                'TreeView1.Nodes.Item(id_ipp_nodo_padre.ToString).Expand()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub anular_op()
        Dim path_anular As String = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_tree_path") & tx_id_registro.Text & "-"

        'Verifico que no existan reportes de produccion asociados activos.
        csql = "select * from camocontrol.tb0401_items_prog_prod" _
           & " Join camocontrol.tb0402_reporte_produccion" _
           & " on f0401_id_ipp = f0402_id_ipp and f0402_anulado = 'N'" _
           & " where f0401_id_ipp = '" & tx_id_registro.Text & "'" _
           & " or substring(f0401_tree_path from 1 for char_length('" & path_anular & "')) = '" & path_anular & "'"
        Dim otb_subprogramas As DataTable
        otb_subprogramas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_subprogramas.Rows.Count > 0 Then
            verror = "S"
            MsgBox("No se puede anular debido a que existen reportes de produccion relacionados.", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        'MsgBox(id_ipp_nodo_padre.ToString)
        anular_op_bd(tx_id_registro.Text, path_anular)
    End Sub
    Private Sub anular_op_bd(ByVal id_ipp As Integer, ByVal path_anular As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0401_items_prog_prod set "
        csql += "f0401_anulado = 'S',"
        csql += "f0401_usuario_anular = @f0401_usuario_modificar,"
        csql += "f0401_usuario_modificar = @f0401_usuario_modificar,"
        csql += "f0401_fm = @f0401_fm"
        csql += " where f0401_id_ipp = '" & id_ipp & "' or substring(f0401_tree_path from 1 for char_length('" & path_anular & "')) = '" & path_anular & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub mi_reporte_produccion_consultar_Click(sender As Object, e As EventArgs) Handles mi_reporte_produccion_consultar.Click
        consultar_rp()
    End Sub

    Private Sub consultar_rp()
        If tipo_registro <> "RP" Then
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_reporte_produccion As New camocontrol.fm_0400_rp_reporte_lotes_produccion
        oform_reporte_produccion.vf_oform_padre = Me
        oform_reporte_produccion.vf_elemento_nuevo = "N"
        oform_reporte_produccion.vg_id_cia = vg_id_cia
        oform_reporte_produccion.vg_usuario_autoriza = vg_usuario_autoriza
        oform_reporte_produccion.vf_var_config_notas = "TN-RPD-001"
        oform_reporte_produccion.vf_id_notas_archivos = tx_id_registro.Text
        oform_reporte_produccion.id_rp = tx_id_registro.Text
        oform_reporte_produccion.id_item = id_item_seleccionado_tree
        'MsgBox("Hola")
        oform_reporte_produccion.ShowDialog()
        llenar_arbol()
        expandir_nodo(tipo_registro & "-" & tx_id_registro.Text)
    End Sub

    Private Sub mi_reporte_produccion_nuevo_Click(sender As Object, e As EventArgs) Handles mi_reporte_produccion_nuevo.Click
        If tipo_registro <> "IPP" Then
            Exit Sub
        End If
        'Valido si el IPP esta cerrado
        Dim ocerrado = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_cerrado")
        If ocerrado = "S" Then
            MsgBox("El IPP esta CERRADO", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Busco la informacion del IPP al que le creo un rp
        Dim orow_ipp As DataRow()
        orow_ipp = otb_items_programa_produccion.Select("f0401_id_ipp = '" & tx_id_registro.Text & "'")
        Dim path_ipp As String = ""
        path_ipp = orow_ipp(0)("f0401_tree_path") & tx_id_registro.Text & "-"


        Dim nodo_expandir As String = TreeView1.SelectedNode.Name
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_reporte_produccion As New camocontrol.fm_0400_rp_reporte_lotes_produccion
        oform_reporte_produccion.vf_oform_padre = Me
        oform_reporte_produccion.vg_id_cia = vg_id_cia
        oform_reporte_produccion.vf_var_config_notas = "TN-RPD-001"
        oform_reporte_produccion.vg_usuario_autoriza = vg_usuario_autoriza
        oform_reporte_produccion.lb_titulo.Text = "Nuevo Reporte de Produccion"
        oform_reporte_produccion.vf_elemento_nuevo = "S"
        oform_reporte_produccion.id_prog_prod = id_prog_prod
        oform_reporte_produccion.id_ipp = tx_id_registro.Text
        oform_reporte_produccion.tree_path = path_ipp
        oform_reporte_produccion.id_item = id_item_seleccionado_tree
        'MsgBox("Hola")
        oform_reporte_produccion.ShowDialog()
        llenar_arbol()
        expandir_nodo(name_nodo_creado)
    End Sub

    Private Sub expandir_nodo(ByVal nombre_nodo As String)
        nodo_buscar = ""
        Try
            'MsgBox("-" & TreeView1.SelectedNode.Name & "-")
            Dim a As TreeNode() = TreeView1.Nodes.Find(nombre_nodo, True)
            TreeView1.SelectedNode = a(0)
            TreeView1.SelectedNode.Expand()
            TreeView1.SelectedNode.ForeColor = Color.Blue
        Catch ex As Exception
            If Strings.Left(nombre_nodo, 3) = "RP-" Then
                Dim a As TreeNode() = TreeView1.Nodes.Find("IPP-" & id_ipp_nodo_padre, True)
                TreeView1.SelectedNode = a(0)
                TreeView1.SelectedNode.Expand()
                TreeView1.SelectedNode.ForeColor = Color.Blue
                'MsgBox("Reporte Produccion anulado", MsgBoxStyle.Information, "Info")
            Else
                'MsgBox("El nodo no existe", MsgBoxStyle.Information, "Info")
            End If
        End Try
    End Sub


    Private Sub mi_cerrar_item_programado_Click(sender As Object, e As EventArgs) Handles mi_cerrar_item_programado.Click
        If tipo_registro <> "IPP" Then
            Exit Sub
        End If
        Dim hijos_abiertos As String = "N"
        'Verifico que todos los items hijos esten cerrados

        'Primero identifico el path
        Dim path_item As String = entregar_valor_campo_ipp(tx_id_registro.Text, "f0401_tree_path") & tx_id_registro.Text & "-"

        'identifico si hay ipp hijos abiertos
        csql = "select * from " & database.obtener_esquema & ".tb0401_items_prog_prod" _
            & " where substring(f0401_tree_path from 1 for char_length('" & path_item & "')) = '" & path_item & "'" _
            & " and f0401_anulado = 'N' and f0401_cerrado = 'N'"
        Dim otb_ipp_abiertos As DataTable
        Dim orows_rp_abieros As DataRow()
        Dim lista_abiertos As String = "Documentos Abiertos: " & vbCrLf
        otb_ipp_abiertos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'cargo nuevamente la tabla de reportes de produccion
        cargar_otabla_reportes_produccion()
        'verifico los rp que dependen directamente del ipp puesto que luego analizare los ipp hijos con sus rp
        'verifico si el IPP tiene reportes de produccion asociados, si no los tiene no deja cerrar
        orows_rp_abieros = otb_reportes_produccion.Select("f0402_id_ipp = '" & tx_id_registro.Text & "'")
        If orows_rp_abieros.Length = 0 Then
            lista_abiertos += "IPP SIN REPORTES DE PRODUCCION."
            hijos_abiertos = "S"
        End If
        'Busco si hay reportes asociados abiertos
        orows_rp_abieros = otb_reportes_produccion.Select("f0402_id_ipp = '" & tx_id_registro.Text & "' and f0402_estado = 'A'")
        'MsgBox(orows_rp_abieros.Length)
        If orows_rp_abieros.Length > 0 Then
            For Each orow_rp As DataRow In orows_rp_abieros
                lista_abiertos += "RP-" & orow_rp("f0402_id_rp") & vbCrLf
            Next
            hijos_abiertos = "S"
        End If
        'Recorro los IPP hijos buscando abietos
        If otb_ipp_abiertos.Rows.Count > 0 Then
            For Each orow As DataRow In otb_ipp_abiertos.Rows
                lista_abiertos += "IPP-" & orow("f0401_id_ipp") & vbCrLf
                'Busco si hay reportes asociados abiertos
                orows_rp_abieros = otb_reportes_produccion.Select("f0402_id_ipp = '" & orow("f0401_id_ipp") & "' and f0402_estado = 'A'")
                'MsgBox(orows_rp_abieros.Length)
                If orows_rp_abieros.Length > 0 Then
                    For Each orow_rp As DataRow In orows_rp_abieros
                        lista_abiertos += "RP-" & orow_rp("f0402_id_rp") & vbCrLf
                    Next
                    hijos_abiertos = "S"
                End If
            Next
            hijos_abiertos = "S"
        End If
        If hijos_abiertos = "S" Then
            MsgBox(lista_abiertos, MsgBoxStyle.Information, "Documentos Abiertos")
            Exit Sub
        End If
        cerrar_ipp(tx_id_registro.Text, path_item)
        If verror = "N" Then
            MsgBox("IPP Cerrado", MsgBoxStyle.Information, "Info")
            llenar_arbol()
            expandir_nodo(tipo_registro & "-" & tx_id_registro.Text)
        End If
    End Sub

    Private Sub cerrar_ipp(ByVal id_ipp As Integer, ByVal path_anular As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0401_items_prog_prod set "
        csql += "f0401_cerrado = 'S',"
        csql += "f0401_usuario_modificar = @f0401_usuario_modificar,"
        csql += "f0401_fm = @f0401_fm"
        csql += " where f0401_id_ipp = '" & id_ipp & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
End Class
