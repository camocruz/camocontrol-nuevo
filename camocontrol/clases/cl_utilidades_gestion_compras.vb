Public Class cl_utilidades_gestion_compras
    Public Shared Function suministrar_datatable_informacion_un_item(ByVal id_item As Integer, ByVal id_cia As String)
        Dim csql As String
        csql = "select * from " & database.obtener_esquema & ".tb0300_items"
        csql += " where f0300_id_item = '" & id_item & "' and f0300_id_cia = '" & id_cia & "'"
        Dim otb_info_item As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_info_item
    End Function


    Public Shared Function calcular_costos_compra(ByVal tipo_calculo As Integer,
                                                  ByVal cantidad As Decimal,
                                                  ByVal costo_unit As Decimal,
                                                  ByVal impuesto As Decimal,
                                                  ByVal descuento As Decimal,
                                                  ByVal costo_total As Decimal,
                                                  ByVal costo_unit_iva As Decimal,
                                                  ByVal costo_total_iva As Decimal)

        Dim valores(6) As Decimal
        If cantidad = 0 Then
            valores(1) = 0
            valores(2) = 0
            valores(3) = 0
            valores(4) = 0
            valores(5) = 0
            MsgBox("La cantidad no puede ser 0", MsgBoxStyle.Critical, "Error")
            Return valores
            Exit Function
        End If
        Select Case tipo_calculo
            'TODO ESTE CASE CALCULA UNICAMENTE EL CostoUnitConDescuento
            Case 1
                costo_unit = costo_unit * (1 - (descuento / 100))
            Case 2
                costo_unit = costo_unit_iva / (1 + (impuesto / 100))
            Case 3
                costo_unit = costo_total_iva / ((1 + (impuesto / 100)) * cantidad)
            Case 4
                costo_unit = costo_total / cantidad
        End Select
        'Apartir del costo unitario calculado recalculo los otros valores TENIENDO COMO VALORES FIJOS LA CANTIDAD - IMPUESTO - DESCUENTO
        valores(1) = costo_unit                             'costo unitario Con descuento sin IVA. BASE DE TODOS LOS CALCULOS SIGUIENTES
        valores(2) = cantidad * costo_unit                  'Subtotal SinIVA
        valores(3) = costo_unit * (1 + (impuesto / 100))    'Costo unitario con IVA
        valores(4) = cantidad * valores(3)                  'Subtotal ConIVA
        valores(5) = costo_unit / (1 - (descuento / 100))   'Costo unitario SinDescuento y SinIVA

        'MsgBox(valores(1) & " - " & valores(2) & " - " & valores(3) & " - " & valores(4))
        Return valores
    End Function

    Public Shared Function suministrar_tabla_items(ByVal vg_id_cia As String)
        Dim csql As String = ""
        Dim otb_items As DataTable
        csql = "SELECT tb0300_items.*," _
            & " f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as descripcion_larga," _
            & " f0002_unidad_medicion" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
              & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                & "  on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
            & " where f0300_id_cia = '" & vg_id_cia & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_items
    End Function


    Public Shared Function form_suministrar_item_cantidad(ByVal usuario As String, ByVal vg_id_cia As String,
                                                          ByVal fecha_cort_inventario As DateTime,
                                                          Optional filtro As String = "",
                                                          Optional id_item As Integer = 0, Optional cant As Decimal = 0,
                                                          Optional id_bodega As Integer = 0,
                                                          Optional m_inventario As String = "N",
                                                          Optional m_edit_item As String = "S",
                                                          Optional m_ent_sal As String = "N",
                                                          Optional m_clasificador As String = "N",
                                                          Optional m_cantidad As String = "S",
                                                          Optional m_info_trazabilidad As String = "N"
                                                           )

        'creo la variable estructura para almacenar la informacion del item
        Dim info_item_mov_inventario As cl_estructuras_variables.info_item_mov_inventario = Nothing
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_suministrar_item_cant
        oform_catalogo_items.vg_usuario_autoriza = usuario
        oform_catalogo_items.vg_id_cia = vg_id_cia
        oform_catalogo_items.fecha_cort_inventario = fecha_cort_inventario
        oform_catalogo_items.id_bodega = id_bodega
        oform_catalogo_items.filtro_items = filtro
        oform_catalogo_items.id_item = id_item
        oform_catalogo_items.cant_item = cant
        oform_catalogo_items.m_inventario = m_inventario
        oform_catalogo_items.m_clasificador = m_clasificador
        oform_catalogo_items.m_edit_item = m_edit_item
        oform_catalogo_items.m_ent_sal = m_ent_sal
        oform_catalogo_items.m_cantidad = m_cantidad
        oform_catalogo_items.m_info_trazabilidad = m_info_trazabilidad
        oform_catalogo_items.ShowDialog()

        If oform_catalogo_items.info_gestionada = "N" Then
            info_item_mov_inventario.id_item = 0
        Else
            info_item_mov_inventario = oform_catalogo_items.info_item_mov
        End If
        oform_catalogo_items.Close()
        Return info_item_mov_inventario
    End Function

    Public Shared Sub movimientos_compras_item(ByVal id_item As String, vg_usuario_autoriza As String, vg_id_cia As String)

        Dim csql As String = comunes.suministrar_valor_variable_configuracion("ST-0300-05", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_item)
        csql = csql.Replace("$002$", vg_id_cia)
        'MsgBox(csql)
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        'oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Historico compras del Item"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.ShowDialog()

    End Sub
    Public Shared Function formulacion_entregar_estructura_otb_formula()
        Dim otb_formula As New DataTable
        'creo la estructura de la datatabla formula
        'Creamos la datatable que contiene toda la formula
        ' Create a new DataTable.
        Dim ocolumn_formula As DataColumn

        ' Create firts column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "path"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 2da column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Int32")
        ocolumn_formula.ColumnName = "id_elemento"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 3a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Int32")
        ocolumn_formula.ColumnName = "id_item"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 4a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "nombre"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 5a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "tamaño_bache_produccion"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 5a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "baches_requeridos"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 5a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "cantidad"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 6a column.
        'ocolumn_formula = New DataColumn()
        'ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        'ocolumn_formula.ColumnName = "cant_nucleo"
        'otb_formula.Columns.Add(ocolumn_formula)

        ' Create 7a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "unidad"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 8a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "costo"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 9a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "costo_unitario"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 11a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "nombre_proceso"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 3a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Int32")
        ocolumn_formula.ColumnName = "id_tipo_item"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 11a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "tipo_item"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 11a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "agrupacion"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 14a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "consumible"
        otb_formula.Columns.Add(ocolumn_formula)

        Return otb_formula
    End Function

    Public Shared Function formulacion_entregar_formula_item_directa(ByVal id_item_padre As String, ByVal cantidad As Decimal,
                                                                     ByVal iteracion As String,
                                                                     ByVal otb_plantillas_ST_0300_06 As DataTable,
                                                                     ByVal otb_items_plantillas_ST_0300_07 As DataTable,
                                                                     Optional ByVal id_plantilla As Integer = 0)
        Dim otb_formula As New DataTable
        'Creo la estructura de la otb_formula
        otb_formula = cl_utilidades_gestion_compras.formulacion_entregar_estructura_otb_formula()

        'Primero identifico la plantilla
        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String

        If id_plantilla <> 0 Then
            filtro_plantilla = "f0350_id_plantilla = '" & id_plantilla & "'"
        Else
            filtro_plantilla = "f0350_id_item = '" & id_item_padre & "'" _
                                                     & " and f0350_activa = 'S'"
        End If
        dataviewplantilla = New DataView(otb_plantillas_ST_0300_06, filtro_plantilla, "", DataViewRowState.CurrentRows)
        'MsgBox(otb_plantillas_ST_0300_06.Rows.Count & "---" & dataviewplantilla.Count)
        Dim contador_iteracion As Integer = 0
        For Each orowplantilla As DataRowView In dataviewplantilla
            'Identifico los items de la plantilla
            Dim dataviewitemsplantilla As New DataView
            dataviewitemsplantilla = New DataView(otb_items_plantillas_ST_0300_07, "f0351_id_plantilla = '" & orowplantilla("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
            'otb_formula = dataviewitemsplantilla.ToTable
            For Each orowitemsplantilla As DataRowView In dataviewitemsplantilla
                contador_iteracion += 1
                Dim cantidad_item As Decimal = (cantidad / orowplantilla("f0350_produccion_x_bache")) * orowitemsplantilla("f0351_cantidad")
                'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
                Dim dataviewplantillaitem As New DataView
                dataviewplantillaitem = New DataView(otb_plantillas_ST_0300_06, "f0350_id_item = '" & orowitemsplantilla("f0351_id_item") & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
                Dim bache_prod_item As Decimal
                For Each orowplantillaitem As DataRowView In dataviewplantillaitem
                    bache_prod_item = orowplantillaitem("f0350_produccion_x_bache")
                Next
                Dim semiproducto As String = "N"
                Dim baches_requeridos As Decimal
                If orowitemsplantilla("f0300_id_tipo_item").ToString = "25" Then
                    baches_requeridos = cantidad_item / bache_prod_item
                    semiproducto = "S"
                Else
                    semiproducto = "N"
                End If


                'Llenamos el datarow de tabla formula
                Dim orow_dosificacion As DataRow = otb_formula.NewRow
                orow_dosificacion("path") = iteracion & contador_iteracion & ".)"
                orow_dosificacion("id_elemento") = orowitemsplantilla("f0351_id_elemento")
                orow_dosificacion("id_item") = orowitemsplantilla("f0300_id_item")
                orow_dosificacion("nombre") = orowitemsplantilla("f0300_descripcion_item")
                orow_dosificacion("cantidad") = cantidad_item
                'orow_dosificacion("costo_nucleo") = cost_item
                orow_dosificacion("unidad") = orowitemsplantilla("f0002_unidad_medicion")
                If semiproducto = "S" Then
                    orow_dosificacion("tamaño_bache_produccion") = bache_prod_item
                    orow_dosificacion("baches_requeridos") = baches_requeridos
                End If

                'orow_dosificacion("cant_bache") = cantidad_bache
                orow_dosificacion("nombre_proceso") = orowplantilla("f0350_descripcion")
                orow_dosificacion("id_tipo_item") = orowitemsplantilla("f0302_id_tipo_item")
                orow_dosificacion("tipo_item") = orowitemsplantilla("f0302_descripcion_tipo_item")
                orow_dosificacion("consumible") = orowitemsplantilla("f0300_consumible")
                'orow_dosificacion("cant_bache_proceso") = orow.Item("f0350_produccion_x_bache")
                otb_formula.Rows.Add(orow_dosificacion)
            Next
        Next
        Return otb_formula
    End Function

    Public Shared Function formulacion_entregar_formula_item(ByVal id_item_padre As String, ByVal cantidad As Decimal,
                                                             ByVal iteracion As String,
                                                             ByVal otb_plantillas_ST_0300_06 As DataTable,
                                                             ByVal otb_items_plantillas_ST_0300_07 As DataTable,
                                                             ByVal recurrencias As Integer)
        Dim otb_formula As New DataTable
        'Verifico loops infinitos
        If recurrencias > 100 Then
            otb_formula = Nothing
            MsgBox("Iteracion infinita!!!")
            Return otb_formula
            Exit Function
        End If

        'Creo la estructura de la otb_formula
        otb_formula = cl_utilidades_gestion_compras.formulacion_entregar_estructura_otb_formula()
        'MsgBox("aqui")
        'Primero identifico la plantilla

        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_padre & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas_ST_0300_06, filtro_plantilla, "", DataViewRowState.CurrentRows)
        Dim contador_iteracion As Integer = 0
        For Each orowplantilla As DataRowView In dataviewplantilla
            'Identifico los items de la plantilla
            Dim dataviewitemsplantilla As New DataView
            dataviewitemsplantilla = New DataView(otb_items_plantillas_ST_0300_07, "f0351_id_plantilla = '" & orowplantilla("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
            'otb_formula = dataviewitemsplantilla.ToTable
            If dataviewitemsplantilla.Count = 0 Then
                otb_formula = Nothing
                Return otb_formula
                Exit Function
            End If
            For Each orowitemsplantilla As DataRowView In dataviewitemsplantilla
                contador_iteracion += 1
                Dim cantidad_item As Decimal = (cantidad / orowplantilla("f0350_produccion_x_bache")) * orowitemsplantilla("f0351_cantidad")
                'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
                Dim dataviewplantillaitem As New DataView
                dataviewplantillaitem = New DataView(otb_plantillas_ST_0300_06, "f0350_id_item = '" & orowitemsplantilla("f0351_id_item") & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
                Dim bache_prod_item As Decimal
                For Each orowplantillaitem As DataRowView In dataviewplantillaitem
                    bache_prod_item = orowplantillaitem("f0350_produccion_x_bache")
                Next
                Dim semiproducto As String = "N"
                Dim baches_requeridos As Decimal
                If orowitemsplantilla("f0300_id_tipo_item").ToString = "25" And dataviewplantillaitem.Count <> 0 Then
                    baches_requeridos = cantidad_item / bache_prod_item
                    semiproducto = "S"
                Else
                    semiproducto = "N"
                End If


                'Llenamos el datarow de tabla formula
                Dim orow_dosificacion As DataRow = otb_formula.NewRow
                orow_dosificacion("path") = iteracion & contador_iteracion & ".)"
                orow_dosificacion("id_elemento") = orowitemsplantilla("f0351_id_elemento")
                orow_dosificacion("id_item") = orowitemsplantilla("f0300_id_item")
                orow_dosificacion("nombre") = orowitemsplantilla("f0300_descripcion_item")
                orow_dosificacion("cantidad") = cantidad_item
                'orow_dosificacion("costo_nucleo") = cost_item
                orow_dosificacion("unidad") = orowitemsplantilla("f0002_unidad_medicion")
                If semiproducto = "S" Then
                    orow_dosificacion("tamaño_bache_produccion") = bache_prod_item
                    orow_dosificacion("baches_requeridos") = baches_requeridos
                End If

                'orow_dosificacion("cant_bache") = cantidad_bache
                orow_dosificacion("nombre_proceso") = orowplantilla("f0350_descripcion")
                orow_dosificacion("id_tipo_item") = orowitemsplantilla("f0302_id_tipo_item")
                orow_dosificacion("tipo_item") = orowitemsplantilla("f0302_descripcion_tipo_item")
                orow_dosificacion("consumible") = orowitemsplantilla("f0300_consumible")
                'orow_dosificacion("cant_bache_proceso") = orow.Item("f0350_produccion_x_bache")
                otb_formula.Rows.Add(orow_dosificacion)
                Dim otb_temp As DataTable = Nothing
                otb_temp = cl_utilidades_gestion_compras.formulacion_entregar_formula_item(orowitemsplantilla("f0300_id_item"),
                                                                                   cantidad_item,
                                                                                   iteracion & contador_iteracion & ".",
                                                                                   otb_plantillas_ST_0300_06, otb_items_plantillas_ST_0300_07,
                                                                                   recurrencias + 1)

                If IsNothing(otb_temp) = False Then
                    otb_formula.Merge(otb_temp)
                Else
                    MsgBox("Error en la formulacion de1: " & orowitemsplantilla("f0300_id_item"))
                End If
            Next
        Next
        Return otb_formula
    End Function

    Public Shared Function entregar_formula_item(ByVal id_item As Integer, ByVal vg_id_cia As String, ByVal otb_costo_items As DataTable,
                                                 ByVal array_costos_sugeridos As Decimal()())
        Dim csql As String
        Dim otb_items_todas_plantillas As DataTable
        Dim otb_formula As DataTable
        Dim otb_plantillas As DataTable
        Dim orow_plantillas_del_item() As DataRow = {}
        Dim orow_items_plantilla() As DataRow = {}
        Dim id_elemento As Integer
        Dim cantidad_formula As Decimal
        Dim iter As String
        Dim cantidad_bache As Decimal
        Dim cantidad_bache_global As Decimal

        'si otb_costo_items es null entonces lleno el datatable. esto implica que los tiempos de calculo aumentan,
        'es mejor cargar la datatable en el formuario padre y entregarla llena a la funcion.
        Try
            Dim dd As Integer
            dd = otb_costo_items.Rows.Count
        Catch ex As Exception
            'entrega en el campo "costo_unit" un array de dos filas, donde la fila 1 es el costo sin IVA
            ' y la segunda fila es el costo con IVA.
            csql = comunes.suministrar_valor_variable_configuracion("ST-0300-03", vg_id_cia)
            otb_costo_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        End Try

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)


        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_todas_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)


        'creo la estructura de la datatabla formula
        'Creamos la datatable que contiene toda la formula
        ' Create a new DataTable.
        otb_formula = New DataTable
        Dim ocolumn_formula As DataColumn

        ' Create firts column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "path"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 2da column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Int32")
        ocolumn_formula.ColumnName = "id_elemento"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 3a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Int32")
        ocolumn_formula.ColumnName = "id_item"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 4a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "nombre"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 5a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "cantidad"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 6a column.
        'ocolumn_formula = New DataColumn()
        'ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        'ocolumn_formula.ColumnName = "cant_nucleo"
        'otb_formula.Columns.Add(ocolumn_formula)

        ' Create 6a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "unidad"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 7a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "costo"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 8a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "costo_nucleo"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 9a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "nombre_proceso"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 10a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "cant_bache_proceso"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 11a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.Decimal")
        ocolumn_formula.ColumnName = "costo_unitario"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 12a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "tipo_item"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 13a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "agrupacion"
        otb_formula.Columns.Add(ocolumn_formula)

        ' Create 14a column.
        ocolumn_formula = New DataColumn()
        ocolumn_formula.DataType = System.Type.GetType("System.String")
        ocolumn_formula.ColumnName = "consumible"
        otb_formula.Columns.Add(ocolumn_formula)

        Dim contador1 As Integer = 0
        Dim contador2 As Integer = 0
        'busco si el item tiene plantillas asociadas
        orow_plantillas_del_item = otb_plantillas.Select("f0350_id_item = '" & id_item & "' and f0350_activa = 'S'")
        For Each orow_plantilla As DataRow In orow_plantillas_del_item
            orow_items_plantilla = otb_items_todas_plantillas.Select("f0351_id_plantilla = '" & orow_plantilla("f0350_id_plantilla") & "'",
                                                                     "descripcion_larga ASC")
            cantidad_bache = orow_plantilla("f0350_produccion_x_bache")
            cantidad_bache_global = cantidad_bache

            'agrego el primer row a tabla de dosificacion del item que estamos analizando
            'calculamos el costo
            Dim arraycostos() As Decimal = {0, 0}
            Dim cost_item As Decimal = 0
            Dim cost_item_iva As Decimal = 0
            arraycostos = cl_utilidades_gestion_compras.calcular_costo_item_total(id_item,
                                                                                  cantidad_bache / cantidad_bache_global, 1,
                                                    otb_plantillas, otb_items_todas_plantillas, otb_costo_items, array_costos_sugeridos)
            cost_item = arraycostos(0)
            cost_item_iva = arraycostos(1)

            Dim orow_dosificacion As DataRow = otb_formula.NewRow
            orow_dosificacion("path") = "1.)"
            'orow_dosificacion("id_elemento") = orow.Item("f0351_id_elemento")
            orow_dosificacion("id_item") = orow_plantilla("f0350_id_item")
            orow_dosificacion("nombre") = orow_plantilla("descripcion_larga")
            orow_dosificacion("cantidad") = 1
            orow_dosificacion("costo_nucleo") = cost_item
            orow_dosificacion("unidad") = orow_plantilla("f0002_unidad_medicion")
            'orow_dosificacion("cant_bache") = cantidad_bache
            orow_dosificacion("nombre_proceso") = orow_plantilla("f0350_descripcion")
            orow_dosificacion("tipo_item") = orow_plantilla("f0302_descripcion_tipo_item")
            orow_dosificacion("consumible") = orow_plantilla("f0300_consumible")
            'orow_dosificacion("cant_bache_proceso") = orow.Item("f0350_produccion_x_bache")
            otb_formula.Rows.Add(orow_dosificacion)

            contador1 += 1
            'recorro los items de la plantilla
            For Each orow_item As DataRow In orow_items_plantilla
                'Realizo una copia de la estructura de otb_formula para llenarla en la funcion redundante
                Dim otb_formula_items As DataTable = otb_formula.Clone
                contador2 += 1
                id_elemento = orow_item("f0351_id_elemento")
                cantidad_formula = orow_item("f0351_cantidad")
                iter = contador1 & "." & contador2 & "."
                otb_formula.Merge(cl_utilidades_gestion_compras.llenar_datatable_formula(otb_formula_items, otb_items_todas_plantillas,
                                                                                         otb_plantillas, otb_costo_items, array_costos_sugeridos,
                                         id_elemento, cantidad_formula, iter, cantidad_bache, cantidad_bache_global, vg_id_cia, 1))
            Next
        Next
        Return otb_formula
    End Function

    Public Shared Function llenar_datatable_formula(ByVal otb_formula As DataTable,
                                        ByVal otb_items_todas_plantillas As DataTable,
                                        ByVal otb_plantillas As DataTable, ByVal otb_costo_items As DataTable,
                                        ByVal array_costos_sugeridos As Decimal()(),
                                        ByVal id_elemento As Integer, ByVal cantidad_formula As Decimal, ByVal iter As String,
                                        ByVal cantidad_bache As Decimal, ByVal cantidad_bache_global As Decimal, ByVal vg_id_cia As String,
                                        ByVal cont_ciclos As Integer)

        Dim id_oitem As Integer
        Dim orow_plantillas_del_item() As DataRow = {}
        Dim tiene_plantilla As String = "N"
        Dim orows_item() As DataRow

        If cont_ciclos > 200 Then
            MsgBox("Formulacion redundante infinita.")
            Return 1
            Exit Function
        Else
            'MsgBox(cont_ciclos)
        End If

        'consigo la informacion del elemento de la formula.
        orows_item = otb_items_todas_plantillas.Select("f0351_id_elemento = '" & id_elemento & "'", "descripcion_larga ASC")
        For Each orow As DataRow In orows_item
            'agrego row a tabla de dosificacion
            Dim orow_dosificacion As DataRow = otb_formula.NewRow
            orow_dosificacion("path") = iter & ")"
            orow_dosificacion("id_elemento") = orow.Item("f0351_id_elemento")
            orow_dosificacion("id_item") = orow.Item("f0351_id_item")
            orow_dosificacion("nombre") = orow.Item("descripcion_larga")
            orow_dosificacion("cantidad") = cantidad_formula / cantidad_bache_global 'orow.Item("f0351_cantidad")
            'orow_dosificacion("cant_nucleo") = cantidad_formula / cantidad_bache_global 'orow.Item("f0351_cantidad")
            orow_dosificacion("unidad") = orow.Item("f0002_unidad_medicion")
            orow_dosificacion("tipo_item") = orow.Item("f0302_descripcion_tipo_item")
            'orow_dosificacion("cant_bache") = cantidad_bache
            'orow_dosificacion("nombre_proceso") = orow.Item("f0350_descripcion")
            'orow_dosificacion("cant_bache_proceso") = orow.Item("f0350_produccion_x_bache")

            'calculamos el costo
            Dim arraycostos() As Decimal = {0, 0}
            Dim cost_item As Decimal = 0
            Dim cost_item_iva As Decimal = 0
            arraycostos = cl_utilidades_gestion_compras.calcular_costo_item_total(orow.Item("f0351_id_item"), cantidad_formula / cantidad_bache_global, 1,
                                                    otb_plantillas, otb_items_todas_plantillas, otb_costo_items, array_costos_sugeridos)
            cost_item = arraycostos(0)
            cost_item_iva = arraycostos(1)

            'identifico si el item tiene plantillas
            orow_plantillas_del_item = otb_plantillas.Select("f0350_id_item = '" & orow.Item("f0351_id_item") & "' and f0350_activa = 'S'")
            tiene_plantilla = "N"
            If orow_plantillas_del_item.Count > 0 Then
                tiene_plantilla = "S"
                orow_dosificacion("costo_nucleo") = cost_item
                orow_dosificacion("costo_unitario") = cost_item / (cantidad_formula / cantidad_bache_global)
            Else
                orow_dosificacion("costo") = cost_item
                orow_dosificacion("costo_unitario") = cost_item / (cantidad_formula / cantidad_bache_global)
            End If

            'Determino la produccion por bache del elemnto
            For Each oorow As DataRow In orow_plantillas_del_item
                orow_dosificacion("nombre_proceso") = oorow.Item("f0350_descripcion")
                orow_dosificacion("cant_bache_proceso") = oorow.Item("f0350_produccion_x_bache")
            Next

            otb_formula.Rows.Add(orow_dosificacion)
            id_oitem = orow.Item("f0351_id_item")
        Next

        If tiene_plantilla = "S" Then
            Dim contador As Integer = 0
            Dim cantidad_hijo As Decimal = 0
            'Hay plantillas asociadas
            For Each orow_plantilla As DataRow In orow_plantillas_del_item 'orow_plantillas_item
                Dim produccion_x_bache_hijo As Decimal = orow_plantilla("f0350_produccion_x_bache")
                'Identificar items de cada plantilla
                Dim orow_items_plantilla() As DataRow
                orow_items_plantilla = otb_items_todas_plantillas.Select("f0351_id_plantilla = '" & orow_plantilla("f0350_id_plantilla") & "'",
                                                                         "descripcion_larga ASC")
                For Each orow_item As DataRow In orow_items_plantilla
                    contador += 1
                    cantidad_hijo = (cantidad_formula / produccion_x_bache_hijo) * orow_item("f0351_cantidad")

                    cont_ciclos += 1
                    'Realizo una copia de la estructura de otb_formula para llenarla en la funcion redundante
                    Dim otb_formula_items As DataTable = otb_formula.Clone
                    otb_formula.Merge(cl_utilidades_gestion_compras.llenar_datatable_formula(otb_formula_items, otb_items_todas_plantillas,
                                                                                             otb_plantillas, otb_costo_items, array_costos_sugeridos,
                                                                 orow_item("f0351_id_elemento"), cantidad_hijo, iter & contador.ToString & ".",
                                                                 produccion_x_bache_hijo, cantidad_bache_global, vg_id_cia, cont_ciclos))
                Next
            Next
        End If

        Return otb_formula
    End Function

    Public Shared Function calcular_costo_item_total(id_item As Integer, cantidad As Decimal, iter As Integer,
                                                     ByVal otb_plantillas As DataTable, ByVal otb_items_todas_plantillas As DataTable,
                                                     ByVal otb_costo_items As DataTable, ByVal array_costos_sugeridos As Decimal()())

        'esta funcion entrega un arreglo
        'me aseguro que no hay bucles infinitos
        Dim ocontador As Integer = iter + 1
        If ocontador > 200 Then
            MsgBox("Formulacion redundante infinita.")
            Return 1
            Exit Function
        End If
        Dim costo() As Decimal = {0, 0}
        Dim costo_temp() As Decimal = {0, 0}
        Dim arraycostos() As Decimal
        Dim tiene_cost_sug As String = "N"
        'identifico si el item tiene plantillas asociadas
        Dim orow_plantillas_item() As DataRow
        orow_plantillas_item = otb_plantillas.Select("f0350_id_item = '" & id_item & "' and f0350_activa = 'S'")
        'MsgBox(orow_plantillas_item.Length)
        If orow_plantillas_item.Count = 0 Then
            'busco si el item tiene valores sugeridos
            'array_costos_sugeridos es un arreglo de arrays de dos filas donde la fila 1 es el item y la fila 2 es el valor sugerido
            For Each orow_costo_sugerido As Array In array_costos_sugeridos
                If orow_costo_sugerido(0) = id_item Then
                    tiene_cost_sug = "S"
                    costo = {orow_costo_sugerido(1) * cantidad, orow_costo_sugerido(1) * cantidad}
                End If
            Next
            If tiene_cost_sug = "N" Then
                Dim orow_info_costo_item() As DataRow
                orow_info_costo_item = otb_costo_items.Select("f0300_id_item = '" & id_item & "'")
                For Each orow As DataRow In orow_info_costo_item
                    arraycostos = orow("costo_unit")
                    costo = {arraycostos(0) * cantidad, arraycostos(1) * cantidad}
                Next
            End If
        Else
            'Hay plantillas asociadas
            For Each orow_plantilla As DataRow In orow_plantillas_item
                Dim produccion_x_bache As Decimal = orow_plantilla("f0350_produccion_x_bache")
                'Identificar items de cada plantilla
                Dim orow_items_plantilla() As DataRow
                orow_items_plantilla = otb_items_todas_plantillas.Select("f0351_id_plantilla = '" & orow_plantilla("f0350_id_plantilla") & "'")
                For Each orow_item As DataRow In orow_items_plantilla
                    costo_temp = cl_utilidades_gestion_compras.calcular_costo_item_total(orow_item("f0351_id_item"), orow_item("f0351_cantidad"), ocontador,
                                                           otb_plantillas, otb_items_todas_plantillas, otb_costo_items, array_costos_sugeridos)
                    costo = {costo_temp(0) + costo(0), costo_temp(1) + costo(1)}
                Next
                'costo = (costo / produccion_x_bache) * cantidad
                costo = {(costo(0) / produccion_x_bache) * cantidad, (costo(1) / produccion_x_bache) * cantidad}
                'MsgBox(costo.ToString("C2") & "  " & orow_plantilla("f0350_produccion_x_bache"))
            Next
        End If
        Return costo
    End Function

    Public Shared Function suministrar_inventario_item_compania(ByVal id_item As Integer, ByVal id_cia As String)
        Dim csql As String
        Dim inventario As Decimal = 0
        csql = "select coalesce(sum(f0309_entrada) - sum(f0309_salida),0) as inventario" _
               & " from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " where f0309_id_item = '" & id_item & "'" _
               & " and f0309_anulado = 'N'"
        Dim otb_inventario As DataTable
        otb_inventario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_inventario.Rows
            inventario = orow("inventario")
        Next
        Return inventario
    End Function

    Public Shared Function suministrar_inventario_item_bodega(ByVal id_bodega As Integer, ByVal id_item As Integer)
        Dim csql As String
        Dim inventario As Decimal = 0
        csql = "select coalesce(sum(f0309_entrada) - sum(f0309_salida),0) as inventario" _
               & " from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " where f0309_id_bodega = '" & id_bodega & "' and f0309_id_item = '" & id_item & "'" _
               & " and f0309_anulado = 'N'"
        Dim otb_inventario As DataTable
        otb_inventario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_inventario.Rows
            inventario = orow("inventario")
        Next
        Return inventario
    End Function

    Public Shared Function suministrar_inventario_item_bodega_fecha(ByVal id_bodega As Integer, ByVal id_item As Integer, ByVal fecha As DateTime)
        Dim csql As String
        Dim inventario As Decimal = 0
        Dim fecha_sql As String = fecha.ToString("yyyy/MMM/dd HH:mm:ss.f")
        csql = "select coalesce(sum(f0309_entrada) - sum(f0309_salida),0) as inventario" _
               & " from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " where f0309_id_bodega = '" & id_bodega & "' and f0309_id_item = '" & id_item & "'" _
               & " and f0309_fecha_movimiento < '" & fecha_sql & "'" _
               & " and f0309_anulado = 'N'"
        Dim otb_inventario As DataTable
        otb_inventario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_inventario.Rows
            inventario = orow("inventario")
        Next
        Return inventario
    End Function

    Public Shared Function suministrar_consecutivo_nuevo_documento_mov_inventario(ByVal id_tipo_documento As Integer, ByVal vg_id_cia As String)
        Dim csql As String
        Dim consecutivo As Integer
        Dim otb_doctos As DataTable
        csql = "select coalesce(max(right(f0310_id_documento , 8)),'0') as actual" _
        & " from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
            & " Join " & database.obtener_esquema & ".tb0311_tipos_doc_mov_inventarios" _
            & " on f0310_id_tipo_documento = f0311_id_tipo_doc" _
            & " where f0310_id_tipo_documento = '" & id_tipo_documento & "' and" _
            & " substring(f0310_id_documento from 1 for char_length(f0311_documento || '-')) = f0311_documento || '-'"


        'csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
        '& " where f0310_id_tipo_documento = '" & id_tipo_documento & "' and f0310_id_cia = '" & vg_id_cia & "'"
        otb_doctos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim orow As DataRow()
        orow = otb_doctos.Select("", "")
        consecutivo = CInt(orow(0)("actual")) + 1
        Return consecutivo
    End Function

    Public Shared Function ValidarFechaMovimiento(ByVal FechaMov As DateTime, ByVal vg_id_cia As String)
        Dim Result(2) As String
        Result(1) = "S"
        'VALIDO SI FECHA DE MOVIMIENTO ESTA HABILITADA
        Dim txt_rango_fechas As String() = Split(comunes.suministrar_valor_variable_configuracion("CONFIG-0300-05", vg_id_cia), ";")
        'si el control de fechas es automatico a los 5 dias anteriores maximo el tercer parametro debe ser "S"
        If txt_rango_fechas(2) = "S" Then
            If FechaMov < comunes.g_fechahora.AddDays(-5) Then
                Result(2) = "La fecha esta cerrada para movimientos de inventario"
                Result(1) = "N"
            End If
        Else
            If FechaMov < CDate(txt_rango_fechas(0)) Or FechaMov > CDate(txt_rango_fechas(1)) Then
                Result(2) = "La fecha esta cerrada para movimientos de inventario"
                Result(1) = "N"
            End If
        End If
        'Valido que la fecha no sea superior a la fecha del sistema
        If FechaMov > comunes.g_fechahora Then
            Result(2) = "La fecha del documento no puede ser superior a la fecha del sistema"
            Result(1) = "N"
        End If
        Return Result
    End Function

    Public Shared Function grabar_nuevo_documento_mov_inventario(ByVal codigo_docto As String, ByVal id_bodega As Integer,
                                                            ByVal id_tipo_documento As Integer,
                                                            ByVal fecha_mov As DateTime,
                                                            ByVal usuario As String,
                                                            ByVal vg_id_cia As String, Optional docto_origen As String = "",
                                                            Optional docto_contable As String = "")
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        Dim ocreado As String = "N" 'para saber si fue creado el documento efectivamente

        'VALIDO SI FECHA DE MOVIMIENTO ESTA HABILITADA
        Dim fechavalidada As String()
        fechavalidada = ValidarFechaMovimiento(fecha_mov, vg_id_cia)
        If fechavalidada(1) = "N" Then
            MsgBox(fechavalidada(2), MsgBoxStyle.Critical, "Error")
            ocreado = "N"
            Return ocreado
            Exit Function
        End If


        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
        & " (f0310_id_cia, f0310_id_bodega, f0310_id_tipo_documento, f0310_id_documento, f0310_fecha," _
        & " f0310_id_documento_origen, f0310_documento_contabilidad," _
        & " f0310_usuario_crear, f0310_usuario_modificar)" _
        & " VALUES" _
        & " (@f0310_id_cia, @f0310_id_bodega, @f0310_id_tipo_documento, @f0310_id_documento, @f0310_fecha," _
        & " @f0310_id_documento_origen, @f0310_documento_contabilidad," _
        & " @f0310_usuario_crear, @f0310_usuario_modificar)"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'crear_parametros_seguimiento(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0310_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0310_id_bodega", NpgsqlDbType.Integer).Value = id_bodega
        ocmd.Parameters.Add("@f0310_id_tipo_documento", NpgsqlDbType.Integer).Value = id_tipo_documento
        ocmd.Parameters.Add("@f0310_id_documento", NpgsqlDbType.Varchar).Value = codigo_docto
        ocmd.Parameters.Add("@f0310_id_documento_origen", NpgsqlDbType.Varchar).Value = docto_origen
        ocmd.Parameters.Add("@f0310_documento_contabilidad", NpgsqlDbType.Varchar).Value = docto_contable
        ocmd.Parameters.Add("@f0310_fecha", NpgsqlDbType.Timestamp).Value = fecha_mov
        ocmd.Parameters.Add("@f0310_usuario_crear", NpgsqlDbType.Varchar).Value = usuario
        ocmd.Parameters.Add("@f0310_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario
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
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If
        If verror = "N" Then
            ocreado = "S"
        End If
        ocmd = Nothing
        oconn_form.Close()
        Return ocreado
    End Function

    Public Shared Sub grabar_nuevo_movimiento_inventario(ByVal codigo_docto As String, ByVal id_bodega As Integer,
                                                         ByVal id_mov_docto As Integer,
                                                         ByVal id_item As Integer,
                                                         ByVal cant_entrada As Decimal,
                                                         ByVal cant_salida As Decimal,
                                                         ByVal fecha_mov As DateTime,
                                                         ByVal usuario As String,
                                                         ByVal vg_id_cia As String,
                                                         Optional cant_teorica As Decimal = 0,
                                                         Optional id_clasificador As Integer = 0,
                                                         Optional otb_info_trazabilidad As DataTable = Nothing,
                                                         Optional id_doc_ref As String = "",
                                                         Optional costo_unit As Decimal = 0,
                                                         Optional id_item_sc As Integer = 0,
                                                         Optional id_sc As Integer = 0,
                                                         Optional item_correlacionado As Integer = 0)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'VALIDO SI FECHA DE MOVIMIENTO ESTA HABILITADA
        Dim fechavalidada As String()
        fechavalidada = ValidarFechaMovimiento(fecha_mov, vg_id_cia)
        If fechavalidada(1) = "N" Then
            MsgBox(fechavalidada(2), MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Verifico que el item no este bloqueado para consumo
        csql = "select * from " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_item = '" & id_item & "'" ' and f0300_consumible = 'N'"
        Dim otb_consumible As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim consumible As String = "S"
        Dim costo_mov As Decimal = 0
        Dim costo_promedio As Decimal = 0
        Dim id_factura_costo As Integer = 0
        For Each orow As DataRow In otb_consumible.Rows
            consumible = orow("f0300_consumible")
            If cant_entrada = 0 Then
                costo_mov = orow("f0300_ultimo_costo") * cant_salida
                costo_promedio = orow("f0300_costo_promedio") * cant_salida
            Else
                costo_mov = orow("f0300_ultimo_costo") * cant_entrada
                costo_promedio = orow("f0300_costo_promedio") * cant_entrada
            End If
            id_factura_costo = orow("f0300_id_ultima_factura")
        Next
        If costo_mov > 1000000000 Or costo_promedio > 1000000000 Then
            MsgBox("Costos de movimiento excesivos, verificar los costos del item: " _
                   & id_item & " id_factura: " & id_factura_costo & vbCrLf & "Utilidades gestion de compras")
            Exit Sub
        End If

        If consumible = "N" Then
            Exit Sub
        End If

        'Identifico el inventario antes de la fecha del movimiento
        Dim inventario_actual As Decimal = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega_fecha(id_bodega, id_item, fecha_mov)
        'Primero valido que si el mov es de salida no genere inventarios negativos.
        'controlo la posibilidad de generar inventarios negativos
        Dim permitir_negativos As String = "N"
        permitir_negativos = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-02", vg_id_cia)
        'MsgBox(permitir_negativos)
        Dim inv_negativo As String = "N"
        If inventario_actual - Math.Round(cant_salida, 4) < 0 And permitir_negativos = "N" Then
            'MsgBox(inventario_actual & " - " & cant_salida)
            inv_negativo = "S"
        End If

        If inv_negativo = "S" Then
            MsgBox("Saldo negativo, no se realiza movimiento", MsgBoxStyle.Critical, "Denegado")
            Exit Sub
        End If

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0309_items_movimientos" _
        & " (f0309_id_cia, f0309_id_mov_docto, f0309_id_item,  f0309_id_bodega, f0309_id_documento, f0309_entrada," _
        & " f0309_salida, f0309_teorico, f0309_fecha_movimiento," _
        & " f0309_id_item_solicitud, f0309_id_solicitud_compra, f0309_id_mov_item_correl," _
        & " f0309_costo_unit_entrada, f0309_costo_tot, f0309_id_factura_costo, f0309_costo_tot_promedio," _
        & " f0309_id_clasificador, f0309_id_doc_ref, f0309_usuario_crear, f0309_usuario_modificar)" _
        & " VALUES" _
        & " (@f0309_id_cia, @f0309_id_mov_docto, @f0309_id_item,  @f0309_id_bodega, @f0309_id_documento, @f0309_entrada," _
        & " @f0309_salida, @f0309_teorico, @f0309_fecha_movimiento," _
        & " @f0309_id_item_solicitud, @f0309_id_solicitud_compra, @f0309_id_mov_item_correl," _
        & " @f0309_costo_unit_entrada, @f0309_costo_tot, @f0309_id_factura_costo, @f0309_costo_tot_promedio," _
        & " @f0309_id_clasificador, @f0309_id_doc_ref, @f0309_usuario_crear, @f0309_usuario_modificar)"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'crear_parametros_seguimiento(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0309_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0309_id_mov_docto", NpgsqlDbType.Numeric).Value = id_mov_docto
        ocmd.Parameters.Add("@f0309_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0309_id_bodega", NpgsqlDbType.Integer).Value = id_bodega
        ocmd.Parameters.Add("@f0309_id_documento", NpgsqlDbType.Varchar).Value = codigo_docto
        ocmd.Parameters.Add("@f0309_entrada", NpgsqlDbType.Numeric).Value = cant_entrada
        ocmd.Parameters.Add("@f0309_salida", NpgsqlDbType.Numeric).Value = cant_salida
        ocmd.Parameters.Add("@f0309_teorico", NpgsqlDbType.Numeric).Value = cant_teorica
        'ocmd.Parameters.Add("@f0309_inventario", NpgsqlDbType.Numeric).Value = 0
        ocmd.Parameters.Add("@f0309_fecha_movimiento", NpgsqlDbType.Timestamp).Value = fecha_mov
        ocmd.Parameters.Add("@f0309_id_factura_costo", NpgsqlDbType.Integer).Value = id_factura_costo
        ocmd.Parameters.Add("@f0309_costo_unit_entrada", NpgsqlDbType.Numeric).Value = costo_unit
        ocmd.Parameters.Add("@f0309_costo_tot", NpgsqlDbType.Numeric).Value = costo_mov
        If id_item_sc = 0 Then
            ocmd.Parameters.Add("@f0309_id_item_solicitud", NpgsqlDbType.Integer).Value = DBNull.Value
            ocmd.Parameters.Add("@f0309_id_solicitud_compra", NpgsqlDbType.Integer).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0309_id_item_solicitud", NpgsqlDbType.Integer).Value = id_item_sc
            ocmd.Parameters.Add("@f0309_id_solicitud_compra", NpgsqlDbType.Integer).Value = id_sc
        End If
        If item_correlacionado = 0 Then
            ocmd.Parameters.Add("@f0309_id_mov_item_correl", NpgsqlDbType.Integer).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0309_id_mov_item_correl", NpgsqlDbType.Integer).Value = item_correlacionado
        End If
        'calcula el costo promedio
        If Left(codigo_docto, 4) = "EAR-" Then
            ocmd.Parameters.Add("@f0309_costo_tot_promedio", NpgsqlDbType.Numeric).Value = costo_mov
        Else
            If costo_promedio = 0 Then
                costo_promedio = costo_mov
            End If
            ocmd.Parameters.Add("@f0309_costo_tot_promedio", NpgsqlDbType.Numeric).Value = costo_promedio
        End If
        ocmd.Parameters.Add("@f0309_id_clasificador", NpgsqlDbType.Integer).Value = id_clasificador
        ocmd.Parameters.Add("@f0309_id_doc_ref", NpgsqlDbType.Varchar).Value = id_doc_ref
        ocmd.Parameters.Add("@f0309_usuario_crear", NpgsqlDbType.Varchar).Value = usuario
        ocmd.Parameters.Add("@f0309_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario
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
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()

        If verror = "S" Then
            Exit Sub
        End If

        'ejecuto si existe informacion de trazabilidad
        Dim id_mov_item_nuevo As String = ""
        If IsNothing(otb_info_trazabilidad) = False Then
            'busco el f0309_id_mov_item creado
            id_mov_item_nuevo = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0309_id_mov_item",
                                                                                             "f0309_usuario_crear",
                                                                                             usuario,
                                                                                             "tb0309_items_movimientos")
        End If

        'modifico el inventario del registro y movimientos posteriores
        'csql = "select * from " & database.obtener_esquema & ".tb0309_items_movimientos" _
        '& " where f0309_id_bodega = '" & id_bodega & "' and f0309_id_item = '" & id_item & "'" _
        '& " and f0309_fecha_movimiento >= '" & fecha_mov.ToString("yyyy/MMM/dd HH:mm:ss.f") & "'" _
        '& " and f0309_anulado = 'N'" _
        '& " order by f0309_fecha_movimiento asc, f0309_id_mov_item asc"
        'Dim otb_mov_post As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        '''''cl_utilidades_datatables.visualizar_datos_visor("", "", "", nuevo_inventario, {}, otb_mov_post)
        'recorro el datatable y modifico valores de inventario
        'For Each orow As DataRow In otb_mov_post.Rows
        ''''MsgBox(nuevo_inventario & " salida:" & orow("f0309_salida") & " entrada: " & orow("f0309_entrada"))
        'inventario_actual = inventario_actual - orow("f0309_salida") + orow("f0309_entrada")
        'cl_utilidades_gestion_compras.modificar_solo_inventario_movimiento(orow("f0309_id_mov_item"), inventario_actual)
        ' Next

        'si hay informacion de trazabilidad asociada entonces la guardo
        If IsNothing(otb_info_trazabilidad) = False Then
            For Each orow As DataRow In otb_info_trazabilidad.Rows
                'Inserción parametrizada
                csql = "INSERT INTO " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                & " (f0318_id_cia, f0318_id_mov_item, f0318_id_mov_docto, f0318_id_item, f0318_id_bodega, f0318_id_documento," _
                & " f0318_fecha_movimiento, f0318_info_trazable," _
                & " f0318_usuario_crear, f0318_usuario_modificar)" _
                & " VALUES" _
                & " (@f0318_id_cia, @f0318_id_mov_item, @f0318_id_mov_docto, @f0318_id_item,  @f0318_id_bodega, @f0318_id_documento," _
                & " @f0318_fecha_movimiento, @f0318_info_trazable," _
                & " @f0318_usuario_crear, @f0318_usuario_modificar)"

                'Instancia la conexión que estará vigente para todas las operaciones CRUD
                oconn_form = database.obtener_conexion()
                'Crear el comando
                Dim ocmd2 As New NpgsqlCommand(csql, oconn_form)
                ocmd2 = database.obtener_comando(oconn_form)
                ocmd2.CommandText = csql

                'crear_parametros_seguimiento(ocmd)
                ocmd2.Parameters.Clear()
                ocmd2.Parameters.Add("@f0318_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
                ocmd2.Parameters.Add("@f0318_id_mov_item", NpgsqlDbType.Numeric).Value = id_mov_item_nuevo
                ocmd2.Parameters.Add("@f0318_id_mov_docto", NpgsqlDbType.Numeric).Value = id_mov_docto
                ocmd2.Parameters.Add("@f0318_id_item", NpgsqlDbType.Integer).Value = id_item
                ocmd2.Parameters.Add("@f0318_id_bodega", NpgsqlDbType.Integer).Value = id_bodega
                ocmd2.Parameters.Add("@f0318_id_documento", NpgsqlDbType.Varchar).Value = codigo_docto
                ocmd2.Parameters.Add("@f0318_fecha_movimiento", NpgsqlDbType.Timestamp).Value = fecha_mov
                ocmd2.Parameters.Add("@f0318_info_trazable", NpgsqlDbType.Varchar).Value = orow("info_trazable")
                ocmd2.Parameters.Add("@f0318_usuario_crear", NpgsqlDbType.Varchar).Value = usuario
                ocmd2.Parameters.Add("@f0318_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario
                verror = "N"
                Try
                    'Compila el comando en la Base de datos.
                    ocmd2.Prepare()
                Catch ex As Exception
                    verror = "S"
                    MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
                End Try
                If verror = "N" Then
                    Try
                        ocmd2.ExecuteNonQuery()
                    Catch ex As Exception
                        verror = "S"
                        MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
                    End Try
                End If

                ocmd2 = Nothing
                oconn_form.Close()
            Next

        End If
        'ACTUALIZO LOS INVENTARIOS DEL ITEM EN TODAS LAS BODEGAS A PARTIR DEL INVENTARIO ACTUAL
        'csql = comunes.suministrar_valor_variable_configuracion("ST-0300-37", vg_id_cia)
        'csql = csql.Replace("$df001$", database.obtener_esquema)
        'csql = csql.Replace("$001$", vg_id_cia)
        'csql = csql.Replace("$002$", usuario)
        'csql = csql.Replace("$003$", id_item)
        'cl_utilidades_datatables.ejecutar_csql(csql)
        'MsgBox(csql)
    End Sub

    Public Shared Function entregar_tabla_movimiento_inventario_item_bodega(ByVal id_item As Integer, ByVal id_bodega As Integer,
                                                                                   ByVal fecha_ini As DateTime, ByVal vg_id_cia As String)

        Dim csql As String = ""
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-10", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_item)
        csql = csql.Replace("$003$", id_bodega)
        csql = csql.Replace("$004$", fecha_ini.ToString("yyyy/MMM/dd HH:mm:ss.f"))
        'Clipboard.SetDataObject(csql)
        'MsgBox(csql)
        Dim otb_mov As DataTable
        otb_mov = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_mov.Rows.Count)
        Return otb_mov
    End Function

    Public Shared Function verificar_viabilidad_varios_consumos_salidas(ByVal id_bodega As Integer,
                                                                ByVal fecha_sugerida As DateTime,
                                                                ByVal items_cantidades As DataTable,
                                                                ByVal vg_id_cia As String,
                                                                ByVal usuario As String)
        Dim consumos_invalidos As String = ""
        'Valido que la fecha no sea superior a la fecha del sistema
        If fecha_sugerida > comunes.g_fechahora Then
            consumos_invalidos = "La fecha del movimiento no puede ser superior a la fecha actual."
            Return consumos_invalidos
            Exit Function
        End If
        'Estructura del datatable items_cantidades: {id_item, nombre, cantidad}
        'creo una tabla con todos los movimientos posteriores o iguales a la fecha de consumo sugerida
        'MsgBox(fecha_sugerida)
        Dim otb_movimientos As DataTable
        Dim csql As String = "select f0309_id_mov_item,f0309_id_item,f0300_descripcion_item,f0309_salida,f0309_entrada,f0309_fecha_movimiento,f0309_inventario"
        csql += " from " & database.obtener_esquema & ".tb0309_items_movimientos"
        csql += " join " & database.obtener_esquema & ".tb0300_items"
        csql += " on f0309_id_item = f0300_id_item"
        csql += " where f0309_id_bodega = '" & id_bodega & "' and f0309_fecha_movimiento >= '" & fecha_sugerida.ToString("yyyy/MMM/dd HH:mm:ss.f") & "'"
        csql += " and f0309_anulado = 'N'"
        otb_movimientos = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'Es un registro nuevo entonces creo un nuevo datarow y lo agrego a la datatable para cada item a consumir
        For Each orow As DataRow In items_cantidades.Rows
            'identifico la descripcion del item
            Dim desc_item As String = ""
            Dim rows_otb_ordenados As DataRow()
            rows_otb_ordenados = otb_movimientos.Select("f0309_id_item = '" & orow("id_item") & "'", "")
            If rows_otb_ordenados.Length > 0 Then
                desc_item = rows_otb_ordenados(0)("f0300_descripcion_item")
            End If


            Dim n_datarow As DataRow
            n_datarow = otb_movimientos.NewRow
            n_datarow("f0309_id_mov_item") = 0
            n_datarow("f0309_id_item") = orow("id_item")
            n_datarow("f0300_descripcion_item") = desc_item
            n_datarow("f0309_salida") = orow("cantidad")
            n_datarow("f0309_entrada") = 0
            n_datarow("f0309_fecha_movimiento") = fecha_sugerida
            n_datarow("f0309_inventario") = 0
            otb_movimientos.Rows.Add(n_datarow)

            'Primero determino cual seria el inventario anterior al primer registro de la tabla
            Dim inventario_ant As Decimal = 0
            inventario_ant = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega_fecha(id_bodega, orow("id_item"), fecha_sugerida)
            If orow("id_item") = 4470 Then
                'MsgBox("INVENTARIO: " & inventario_ant & " BODEGA: " & id_bodega & " FECHA: " & fecha_sugerida)
            End If
            'MsgBox(orow("id_item") & " - " & fecha_sugerida & " Inventario: " & inventario_ant)
            'reordeno los rows la tabla y modifico los valores de inventario verificando valores negativos
            'Dim rows_otb_ordenados As DataRow()
            rows_otb_ordenados = otb_movimientos.Select("f0309_id_item = '" & orow("id_item") & "'", "f0309_fecha_movimiento ASC, f0309_id_mov_item ASC")
            Dim cont1 As Integer = 1
            Dim negativo_menor As Decimal = 0
            For Each orow_ord As DataRow In rows_otb_ordenados
                inventario_ant = inventario_ant - orow_ord("f0309_salida") + orow_ord("f0309_entrada")
                orow_ord("f0309_inventario") = inventario_ant
                'controlo la posibilidad de generar inventarios negativos
                Dim permitir_negativos As String = "N"
                permitir_negativos = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-02", vg_id_cia)
                If inventario_ant < 0 And permitir_negativos = "N" Then
                    'MsgBox("AQUI: " & orow("f0309_id_mov_item"))
                    'MsgBox("Inventario negativo para el item: " & orow_ord("f0309_id_item") & " - " & orow_ord("f0309_salida") & " INV_ANT: " & inventario_ant)
                    negativo_menor = inventario_ant
                End If
                cont1 += 1
            Next
            'realizo esto si hay inventarios negativos
            If negativo_menor < 0 Then
                'si no tengo la descripcion del item entonces la averiguo
                If desc_item = "" Then
                    Dim otb_info_item As DataTable = suministrar_datatable_informacion_un_item(orow("id_item"), vg_id_cia)
                    desc_item = otb_info_item.Rows(0)("f0300_descripcion_item")
                End If
                consumos_invalidos += "ITEM: ("
                consumos_invalidos += orow("id_item") & ") " & desc_item & vbCrLf _
                    & " Solicitado: " & Math.Round(orow("cantidad"), 4) & " Deficit: " & Math.Round(negativo_menor, 4) & vbCrLf
            End If
        Next
        Return consumos_invalidos
    End Function

    Public Shared Function verificar_viabilidad_modificacion_movimiento_inventario(ByVal id_mov_item As Integer,
                                                                                   ByVal id_item As Integer, ByVal id_bodega As Integer,
                                                                                   ByVal fecha_sugerida As DateTime,
                                                                                   ByVal cant_entrada As Decimal,
                                                                                   ByVal cant_salida As Decimal,
                                                                                   ByVal anular As String,
                                                                                   ByVal vg_id_cia As String,
                                                                                   ByVal usuario As String)
        'si id_mov_item es 0 quiere decir que voy a analizar el ingreso de un nuevo registro a los movimientos que puede afectar los inventarios
        ' de los otros movimientos porque puedo variar la fecha del documento..

        Dim otb_mov_item As DataTable
        'MsgBox(id_item & " mov: " & id_mov_item & " fecha: " & fecha_sugerida)
        otb_mov_item = cl_utilidades_gestion_compras.entregar_tabla_movimiento_inventario_item_bodega(id_item, id_bodega,
                                                                                                      fecha_sugerida, vg_id_cia)
        'cl_utilidades_datatables.visualizar_datos_visor("", "", "", "", {}, otb_mov_item)


        'Si es un registro nuevo entonces creo un nuevo datarow y lo agrego a la datatable
        If id_mov_item = 0 Then
            Dim n_datarow As DataRow
            n_datarow = otb_mov_item.NewRow
            n_datarow("f0309_id_mov_item") = 0
            n_datarow("f0309_id_item") = id_item
            n_datarow("f0309_id_bodega") = id_bodega
            n_datarow("f0309_entrada") = cant_entrada
            'n_datarow("f0309_salida") = cant_salida
            n_datarow("f0309_salida") = cant_salida
            n_datarow("f0309_fecha_movimiento") = fecha_sugerida
            n_datarow("f0309_anulado") = "N"
            otb_mov_item.Rows.Add(n_datarow)
        End If

        'MsgBox("Movimientos del item: " & otb_mov_item.Rows.Count)
        'cl_utilidades_datatables.visualizar_datos_visor("", "", "", "", {}, otb_mov_item)

        'Primero determino cual seria el inventario anterior al primer registro de la tabla
        Dim inventario_ant As Decimal = 0
        inventario_ant = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega_fecha(id_bodega, id_item, fecha_sugerida)
        'Dim orow1 As DataRow()
        'orow1 = otb_mov_item.Select("", "f0309_fecha_movimiento ASC, f0309_id_mov_item ASC")

        'MsgBox(orow1(0)("f0309_id_mov_item") & " - " & orow1(0)("f0309_inventario"))

        'If orow1(0)("f0309_id_mov_item") <> 0 Then
        'inventario_ant = orow1(0)("f0309_inventario") - orow1(0)("f0309_entrada") + orow1(0)("f0309_salida")
        'Else
        'If orow1.Length > 1 Then
        'inventario_ant = orow1(1)("f0309_inventario") - orow1(1)("f0309_entrada") + orow1(1)("f0309_salida")
        'orow1(0)("f0309_inventario") = orow1(1)("f0309_inventario")
        'End If
        'End If

        'MsgBox("Inventario anterior: " & inventario_ant)
        'modifico el datarow con los valores sugeridos si no es un movimiento de nuevo registro
        If id_mov_item <> 0 Then
            Dim rows_otb As DataRow()
            rows_otb = otb_mov_item.Select("f0309_id_mov_item = '" & id_mov_item & "'")
            'MsgBox(otb_mov_item.Rows.Count)
            'MsgBox(rows_otb.Length)
            'MsgBox(rows_otb.Length)
            If anular = "N" Then
                rows_otb(0)("f0309_entrada") = cant_entrada
                rows_otb(0)("f0309_salida") = cant_salida
                rows_otb(0)("f0309_fecha_movimiento") = fecha_sugerida
            Else
                rows_otb(0)("f0309_anulado") = "S"
                rows_otb(0)("f0309_usuario_anular") = usuario
            End If
            rows_otb(0)("f0309_usuario_modificar") = usuario
            rows_otb(0)("f0309_fm") = comunes.g_fechahora
        End If

        'reordeno los rows la tabla y modifico los valores de inventario verificando valores negativos
        Dim rows_otb_ordenados As DataRow()
        rows_otb_ordenados = otb_mov_item.Select("", "f0309_fecha_movimiento ASC, f0309_id_mov_item ASC")
        Dim cont1 As Integer = 1
        For Each orow As DataRow In rows_otb_ordenados
            'Si es el primer movimiento y es diferente registro entonces hay que tomar el inventario de este registro.
            If cont1 = 1 And orow("f0309_id_mov_item") <> id_mov_item Then
                'MsgBox("Registro: " & cont1 & " Inventario: " & orow("f0309_inventario"))
                inventario_ant = orow("f0309_inventario")
                GoTo sale
            End If
            If orow("f0309_anulado") = "N" Then
                inventario_ant = inventario_ant + orow("f0309_entrada") - orow("f0309_salida")
                orow("f0309_inventario") = inventario_ant
                'controlo la posibilidad de generar inventarios negativos
                Dim permitir_negativos As String = "N"
                permitir_negativos = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-02", vg_id_cia)
                If inventario_ant < 0 And permitir_negativos = "N" Then
                    'MsgBox("AQUI: " & orow("f0309_id_mov_item"))
                    otb_mov_item = Nothing
                    Return otb_mov_item
                    Exit Function
                End If
            End If
sale:
            cont1 += 1
        Next
        Return otb_mov_item
    End Function

    Public Shared Sub modificar_movimientos_inventarios(ByVal id_mov_item As Integer,
                                                        ByVal id_item As Integer, ByVal id_bodega As Integer,
                                                        ByVal cant_entrada As Decimal,
                                                        ByVal cant_salida As Decimal,
                                                        ByVal anular As String,
                                                        ByVal vg_id_cia As String,
                                                        ByVal usuario As String,
                                                        Optional fecha_sugerida As DateTime = Nothing)

        If fecha_sugerida = Nothing Then
            'Identifico la fecha del registro si no he definido una nueva fecha
            Dim csql As String
            csql = "select * from " & database.obtener_esquema & ".tb0309_items_movimientos" _
                & " where f0309_id_mov_item = '" & id_mov_item & "'"
            Dim otb1 As DataTable
            otb1 = cl_utilidades_datatables.cargar_informacion_postgres(csql)

            Dim orowinfo As DataRow()
            orowinfo = otb1.Select("")
            fecha_sugerida = orowinfo(0)("f0309_fecha_movimiento")
        End If
        'MsgBox("verifico viabilidad")
        'verifico si el cambio es viable
        Dim otb_mov_item As DataTable = Nothing
        otb_mov_item = cl_utilidades_gestion_compras.verificar_viabilidad_modificacion_movimiento_inventario(id_mov_item,
                                                                                                             id_item, id_bodega,
                                                                                                             fecha_sugerida,
                                                                                                             cant_entrada,
                                                                                                             cant_salida,
                                                                                                             anular, vg_id_cia, usuario)
        If otb_mov_item Is Nothing Then
            'MsgBox(id_mov_item)
            MsgBox("Cambio no realizado, Inventario Negativo", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'MsgBox("Ejecuto cambio")
        Dim fecha_act As Date = comunes.g_fechahora
        ejecutar_database_movimiento_inventario(id_mov_item,
                                                cant_entrada,
                                                cant_salida,
                                                fecha_sugerida,
                                                anular,
                                                usuario,
                                                usuario,
                                                fecha_act)

        'For Each orow As DataRow In otb_mov_item.Rows
        'ejecutar_database_movimiento_inventario(orow("f0309_id_mov_item"),
        'orow("f0309_entrada"),
        'orow("f0309_salida"),
        'orow("f0309_fecha_movimiento"),
        'orow("f0309_anulado"),
        'orow("f0309_usuario_modificar"),
        'orow("f0309_usuario_anular"),
        'orow("f0309_fm"))
        'Next
    End Sub

    Public Shared Sub modificar_solo_inventario_movimiento(ByVal id_mov_item As Integer,
                                                           ByVal inventario As Decimal)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0309_items_movimientos set"
        csql += " f0309_inventario = @f0309_inventario"
        csql += " where f0309_id_mov_item = @f0309_id_mov_item"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0309_inventario", NpgsqlDbType.Numeric).Value = inventario
        ocmd.Parameters.Add("@f0309_id_mov_item", NpgsqlDbType.Integer).Value = id_mov_item
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

    Public Shared Sub ejecutar_database_movimiento_inventario(ByVal id_mov_item As Integer,
                                                      ByVal cant_entrada As Decimal,
                                                      ByVal cant_salida As Decimal,
                                                      ByVal fecha_movimiento As DateTime,
                                                      ByVal anulado As String,
                                                      ByVal usuario_modificar As String,
                                                      ByVal usuario_anular As String,
                                                      ByVal f0309_fm As DateTime)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0309_items_movimientos set"
        csql += " f0309_entrada = @f0309_entrada,"
        csql += " f0309_salida = @f0309_salida,"
        'csql += " f0309_inventario = @f0309_inventario,"
        csql += " f0309_fecha_movimiento = @f0309_fecha_movimiento,"
        csql += " f0309_usuario_modificar = @f0309_usuario_modificar,"
        csql += " f0309_anulado = @f0309_anulado,"
        csql += " f0309_usuario_anular = @f0309_usuario_anular,"
        csql += " f0309_fm = @f0309_fm"
        csql += " where f0309_id_mov_item = @f0309_id_mov_item"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0309_entrada", NpgsqlDbType.Numeric).Value = cant_entrada
        ocmd.Parameters.Add("@f0309_salida", NpgsqlDbType.Numeric).Value = cant_salida
        'ocmd.Parameters.Add("@f0309_inventario", NpgsqlDbType.Numeric).Value = inventario
        ocmd.Parameters.Add("@f0309_fecha_movimiento", NpgsqlDbType.Timestamp).Value = fecha_movimiento
        ocmd.Parameters.Add("@f0309_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario_modificar
        ocmd.Parameters.Add("@f0309_anulado", NpgsqlDbType.Varchar).Value = anulado
        ocmd.Parameters.Add("@f0309_usuario_anular", NpgsqlDbType.Varchar).Value = usuario_anular
        ocmd.Parameters.Add("@f0309_fm", NpgsqlDbType.Timestamp).Value = f0309_fm
        ocmd.Parameters.Add("@f0309_id_mov_item", NpgsqlDbType.Integer).Value = id_mov_item
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

    Public Shared Sub mostrar_documento_movimiento_inventario(ByVal codigo_documento As String,
                                                              ByVal usuario As String, ByVal vg_id_cia As String,
                                                              Optional editable As String = "N",
                                                              Optional bloq_info_encab As String = "S",
                                                              Optional m_ent_sal As String = "N",
                                                              Optional m_clasificador As String = "S",
                                                              Optional m_inventario As String = "S",
                                                              Optional m_edit_item As String = "N",
                                                              Optional m_cantidad As String = "S",
                                                              Optional m_info_trazabilidad As String = "N",
                                                              Optional identifica_receptor As String = "N")

        ' m_ent_sal Para determinar comportamiento del grupo de RB entrada y salida
        '''''''' E = Activado entrada edicion de grupo RB deshabilitada
        '''''''' S = Activado salida edicion de grupo RB deshabilitada
        '''''''' D = Edicion de grupo RB Habilitada
        '''''''' N = Edicion de grupo RB deshabilitada


        'Verifico que el documento exista
        Dim csql As String = ""
        Dim otb_enc_documento As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
            & " where f0310_id_documento = '" & codigo_documento & "'"
        otb_enc_documento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_enc_documento.Rows.Count = 0 Then
            MsgBox("Documento no existe", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_consumos_produccion As New camocontrol.fm_0300_doc_movimientos_inventarios
        'oform_consumos_produccion.vf_oform_padre = Me
        oform_consumos_produccion.vf_elemento_nuevo = "N"
        oform_consumos_produccion.vg_id_cia = vg_id_cia
        oform_consumos_produccion.vg_usuario_autoriza = usuario
        oform_consumos_produccion.codigo_documento = codigo_documento
        oform_consumos_produccion.editable = editable
        oform_consumos_produccion.bloq_info_encab = bloq_info_encab
        oform_consumos_produccion.m_ent_sal = m_ent_sal
        oform_consumos_produccion.m_clasificador = m_clasificador
        oform_consumos_produccion.m_inventario = m_inventario
        oform_consumos_produccion.m_edit_item = m_edit_item
        oform_consumos_produccion.m_cantidad = m_cantidad
        oform_consumos_produccion.m_info_trazabilidad = m_info_trazabilidad
        oform_consumos_produccion.identifica_receptor = identifica_receptor
        oform_consumos_produccion.ShowDialog()
    End Sub

    Public Shared Sub habilitar_documento(ByVal codigo_documento As String, ByVal usuario_modificar As String)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0310_documentos_movimientos_inventarios set"
        csql += " f0310_habilitado = 'S',"
        csql += " f0310_usuario_modificar = @f0310_usuario_modificar,"
        csql += " f0310_fm = @f0310_fm"
        csql += " where f0310_id_documento = @f0310_id_documento"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0310_id_documento", NpgsqlDbType.Varchar).Value = codigo_documento
        ocmd.Parameters.Add("@f0310_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario_modificar
        ocmd.Parameters.Add("@f0310_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
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

    Public Shared Function anular_documento(ByVal codigo_documento As String, ByVal usuario_modificar As String, ByVal vg_id_cia As String)
        Dim csql As String
        Dim anulado As String = "N"
        'Si el documento que estoy anulando es un EPR (Entrada de produccion entonces garantizo que el reporte de produccion no este cerrado
        Dim documento_origen As String = ""
        Dim otb_reporte_produccion As DataTable
        Dim id_rp As Integer
        Dim tipo_documento As String = ""
        Dim array_documeto As String() = Split(codigo_documento, "-")
        tipo_documento = array_documeto(0)
        Dim estado_rp As String = "A"
        If tipo_documento = "EPR" Or tipo_documento = "CPR" Or tipo_documento = "CNP" Or tipo_documento = "ARP" Then
            'Determino el RP que genera la produccion.
            csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_id_documento = '" & codigo_documento & "' and f0310_anulado = 'N'"
            Dim otb_docto As DataTable
            otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            If otb_docto.Rows.Count <> 0 Then
                Dim orow_doct As DataRow() = otb_docto.Select("")
                Dim orp As String() = Split(orow_doct(0)("f0310_id_documento_origen"), "-")
                id_rp = orp(1)
                MsgBox("RP-" & id_rp & " -- " & codigo_documento)
                'Identifico el estado en que se encuentra el RP
                csql = "select *" _
                    & " FROM " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                    & " where f0402_id_cia = '" & vg_id_cia & "' and f0402_id_rp = '" & id_rp & "'"
                otb_reporte_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                Dim orow_info_rp As DataRow() = otb_reporte_produccion.Select("", "")
                estado_rp = orow_info_rp(0)("f0402_estado")
            End If
            If tipo_documento = "EPR" Then
                'Busco si hay consumos de produccion asociados.
                csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_id_documento_origen = '" & "RP-" & id_rp & "' and f0310_anulado = 'N'" _
                             & " and f0310_id_tipo_documento = '1'"
                Dim otb_cpr_asociados As DataTable
                otb_cpr_asociados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                'si hay consumos de produccion asociados no permite anular el documento.
                If otb_cpr_asociados.Rows.Count > 0 Then
                    MsgBox("Para anular este documento primero debe anular el consumo de produccion.", MsgBoxStyle.Information, "Info")
                    Return anulado
                    Exit Function
                End If
            End If
        End If
        If estado_rp = "C" Then
            MsgBox("Para anular este documento primero debe colocar el RP en estado Abierto", MsgBoxStyle.Information, "Info")
            Return anulado
            Exit Function
        End If

        csql = "select * from " & database.obtener_esquema & ".tb0309_items_movimientos" _
                             & " where f0309_id_documento = '" & codigo_documento & "' and f0309_anulado = 'N'"
        Dim otb_movimientos As DataTable
        otb_movimientos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_movimientos.Rows.Count = 0 Then
            'si no hay movimientos que anular
        End If
        Dim id_mov_item As Integer
        Dim id_item As Integer
        Dim id_bodega As Integer
        Dim fecha_sugerida As DateTime
        Dim anular As String = "S"

        'verifico si el cambio es viable
        Dim otb_mov_item As DataTable = Nothing
        For Each orow As DataRow In otb_movimientos.Rows
            id_mov_item = orow("f0309_id_mov_item")
            id_item = orow("f0309_id_item")
            id_bodega = orow("f0309_id_bodega")
            fecha_sugerida = orow("f0309_fecha_movimiento")
            otb_mov_item = cl_utilidades_gestion_compras.verificar_viabilidad_modificacion_movimiento_inventario(id_mov_item, id_item, id_bodega, fecha_sugerida,
                                                                                                  0, 0, "S", vg_id_cia, usuario_modificar)
            If otb_mov_item Is Nothing Then
                'MsgBox(id_mov_item)
                MsgBox("Cambio no realizado, Inventario Negativo", MsgBoxStyle.Exclamation, "Error")
                anulado = "N"
                Return anulado
                Exit Function
            End If
        Next
        'si llego aqui es porque todos los cambios fueron posibles
        For Each orow As DataRow In otb_movimientos.Rows
            id_mov_item = orow("f0309_id_mov_item")
            id_item = orow("f0309_id_item")
            id_bodega = orow("f0309_id_bodega")
            fecha_sugerida = orow("f0309_fecha_movimiento")
            cl_utilidades_gestion_compras.modificar_movimientos_inventarios(id_mov_item, id_item, id_bodega, 0, 0, "S", vg_id_cia,
                                                                            usuario_modificar, fecha_sugerida)
            'ACTUALIZO LOS INVENTARIOS DEL ITEM EN TODAS LAS BODEGAS A PARTIR DEL INVENTARIO ACTUAL
            'csql = comunes.suministrar_valor_variable_configuracion("ST-0300-37", vg_id_cia)
            'csql = csql.Replace("$df001$", database.obtener_esquema)
            'csql = csql.Replace("$001$", vg_id_cia)
            'csql = csql.Replace("$002$", usuario_modificar)
            'csql = csql.Replace("$003$", id_item)
            'cl_utilidades_datatables.ejecutar_csql(csql)
        Next
        'Anulo el documento
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0310_documentos_movimientos_inventarios set"
        csql += " f0310_habilitado = 'N',"
        csql += " f0310_anulado = 'S',"
        csql += " f0310_usuario_modificar = @f0310_usuario_modificar,"
        csql += " f0310_usuario_anular = @f0310_usuario_anular,"
        csql += " f0310_fm = @f0310_fm"
        csql += " where f0310_id_documento = @f0310_id_documento"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0310_id_documento", NpgsqlDbType.Varchar).Value = codigo_documento
        ocmd.Parameters.Add("@f0310_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario_modificar
        ocmd.Parameters.Add("@f0310_usuario_anular", NpgsqlDbType.Varchar).Value = usuario_modificar
        ocmd.Parameters.Add("@f0310_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
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



        'acciones que debo ejecutar cuando el documento es una entrada de almacen por recepcion de producto terminado.
        If tipo_documento = "EPR" Or tipo_documento = "CPR" Then
            If tipo_documento = "EPR" Then
                'Si el documento que estoy anulando es un EPR (Entrada de produccion entonces tambien debo modificar el reporte de produccion
                'Determino la nueva cantidad producida.
                csql = "select sum(f0309_entrada) as cantidad" _
                             & " from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " Join " & database.obtener_esquema & ".tb0309_items_movimientos" _
                             & " on f0310_id_documento = f0309_id_documento" _
                             & " where f0310_id_documento_origen = '" & documento_origen & "'" _
                             & " and f0310_id_tipo_documento = '4'" _
                             & " and f0310_anulado = 'N' and f0310_id_cia = '" & vg_id_cia & "'"
                'Clipboard.SetDataObject(csql)
                'MsgBox(csql)
                Dim otb_tot As DataTable
                otb_tot = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                Dim ocantidad As Decimal
                Dim orowscantidad As DataRow()
                orowscantidad = otb_tot.Select("", "")
                Try
                    ocantidad = orowscantidad(0)("cantidad")
                Catch ex As Exception
                    ocantidad = 0
                End Try

                'Actualizo la cantidad en la bd
                cl_utilidades_gestion_produccion.actualizar_cantidad_produccion(id_rp, ocantidad, usuario_modificar)
                'Anulo el documento de salida de invetario de MP
                'Primero identifico cual es el documento de salida.
                csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                    & " where f0310_id_documento_origen = '" & documento_origen & "'" _
                    & " and f0310_id_tipo_documento = '1'" _
                    & " and f0310_anulado = 'N' and f0310_id_cia = '" & vg_id_cia & "'"
                Dim otb_consumo As DataTable
                otb_consumo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                If otb_consumo.Rows.Count > 0 Then
                    Dim orow_consumo As DataRow()
                    orow_consumo = otb_consumo.Select("", "")
                    Dim id_docto_consumo As String = orow_consumo(0)("f0310_id_documento")
                    'Anulo el documento de consumo
                    cl_utilidades_gestion_compras.anular_documento(id_docto_consumo, usuario_modificar, vg_id_cia)
                End If
                'MsgBox("hola")
            End If

            'Elimino la bodega de descarga para habilitar nueva seleccion
            'Instancia la conexión que estará vigente para todas las operaciones CRUD
            oconn_form = database.obtener_conexion()
            'actualizacion parametrizada
            csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set"
            csql += " f0402_id_bodega_consumo_insumos = '0'"
            csql += " where f0402_id_rp = @f0402_id_rp"

            'Crear el comando
            ocmd = New NpgsqlCommand(csql, oconn_form)
            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            'crear_parametros_solicitud(ocmd)
            ocmd.Parameters.Clear()
            ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = id_rp
            'MsgBox(id_rp)
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
        End If

        'Acciones que debo ejecutar si el tipo de documento es una entrada de almacen por recepcion de compra
        If tipo_documento = "EAR" Then
            'Elimino la referencia al docuemnto de inventario en los items solicitados
            csql = "UPDATE " & database.obtener_esquema & ".tb0305_items_solicitados"
            csql += " Set f0305_docto_mov_inventario=''"
            csql += " WHERE f0305_docto_mov_inventario = '" & codigo_documento & "'"
            'Instancia la conexión que estará vigente para todas las operaciones CRUD
            oconn_form = database.obtener_conexion()
            'actualizacion parametrizada
            'Crear el comando
            ocmd = New NpgsqlCommand(csql, oconn_form)
            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            'crear_parametros_solicitud(ocmd)
            ocmd.Parameters.Clear()
            'ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = id_rp
            'MsgBox(id_rp)
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

            'Desapruebo la factura registrada.
            csql = "UPDATE " & database.obtener_esquema & ".tb0307_facturas_compras"
            csql += " Set f0307_doc_entrada = '',"
            csql += " f0307_id_bodega_entrada = 0,"
            csql += " f0307_recepcion_aprobada = 'N',"
            csql += " f0307_aprobada = 'N',"
            csql += " f0307_usuario_aprobar = ''"
            csql += " WHERE f0307_doc_entrada = '" & codigo_documento & "'"
            'Instancia la conexión que estará vigente para todas las operaciones CRUD
            oconn_form = database.obtener_conexion()
            'actualizacion parametrizada
            'Crear el comando
            ocmd = New NpgsqlCommand(csql, oconn_form)
            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            'crear_parametros_solicitud(ocmd)
            ocmd.Parameters.Clear()
            'ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = id_rp
            'MsgBox(id_rp)
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
        End If
        If verror = "N" Then
            anulado = "S"
        End If
        Return anulado
    End Function

End Class
