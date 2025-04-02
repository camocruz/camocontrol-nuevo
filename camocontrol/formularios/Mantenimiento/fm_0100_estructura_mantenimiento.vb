Public Class fm_0100_estructura_mantenimiento
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public trasladar As String = "N"

    Public nodo_a_mostrar As String = "" 'para que cuando abra el formulario se muestre un nodo especifico

    'Private oform_mover As New camocontrol.fm_0100_trasladar_ramal
    Private oform_mover As camocontrol.fm_0100_trasladar_ramal

    Private otb_estructura_mantenimiento As DataTable
    Private otb_rama_estructura_mantenimiento As DataTable

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private verror As String = "S"

    Private id_estructura_raiz As Integer 'la estructura origen de todo el arbol. es la compañia.
    Private id_estructura As Integer
    Private id_estructura_padre As Integer
    Private path_estructura As String = ""
    Private path_estructura_base As String = "" 'path sin el id de la estructura referenciada
    Private path_estructura_filtrado As String = ""
    Private id_estructura_padre_filtrado As Integer
    Private actualizar_familia As String = "N" 'Indica si cuando se traslada se cambia la maquina a la que pertenece FAMILIA MAQUINA
    Private csql As String
    Public nodo_padre_tag As String = ""
    Private nodo_hijo_tag As String = ""
    Private filtro_rama As String = "N"

    Private Sub fm_0100_estructura_mantenimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'mi_gestion_traslados_rama.Enabled = False

        bt_anular.Enabled = False
        bt_grabar.Enabled = False
        bt_nuevo.Enabled = False
        bt_generar_informe.Enabled = False
        bt_editar.Enabled = False
        cargar_combo_compañias()
        cm_compania.SelectedValue = vg_id_cia
        llenar_arbol()
        If nodo_a_mostrar <> "" Then
            mostrar_nodo(nodo_a_mostrar)
        End If
    End Sub
    Private Sub cm_compania_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_compania.Validating
        If cm_compania.Text.ToString = "" Then
            Exit Sub
        End If
        llenar_arbol()
    End Sub
    Private Sub cargar_combo_compañias()
        Dim otb_info_companias As DataTable
        otb_info_companias = comunes.cargar_informacion_companias
        With cm_compania
            'Valor que se muestra al usuario
            .DisplayMember = "compania"
            'Valor interno que almacena el objeto
            .ValueMember = "f0001_id_cia"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_companias
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub cargar_otabla_estructura()
        csql = "SELECT estructura.*, tb0107_tipos_estructura.*," _
                    & " estructura.f0100_nombre || ' -- { ' || estructura.f0100_id_estructura || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_nombre," _
                    & " estructura.f0100_id_estructura || ' -- { ' || estructura.f0100_nombre || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_codigo" _
                    & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as estructura" _
                        & " join " & database.obtener_esquema & ".tb0107_tipos_estructura" _
                            & " on f0100_id_tipo_estructura = f0107_id_tipo_estructura" _
                        & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as maquina" _
                          & " on maquina.f0100_id_estructura = estructura.f0100_id_maquina_padre" _
                    & " where estructura.f0100_id_cia = '" & vg_id_cia & "' and estructura.f0100_anulado = 'N'" _
                    & " order by estructura.f0100_estructura_padre;"
        otb_estructura_mantenimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Clipboard.SetText(csql)
        Dim orow As DataRow()
        orow = otb_estructura_mantenimiento.Select("f0100_path = ''")
        'MsgBox(orow.Length & " - " & orow(0)("f0100_id_estructura").ToString)
        id_estructura_raiz = orow(0)("f0100_id_estructura")
    End Sub
    Private Sub llenar_arbol()
        cargar_otabla_estructura()
        If filtro_rama = "N" Then
            TreeView1.Nodes.Clear()
            CrearNodosDelPadre(otb_estructura_mantenimiento, "0", Nothing)
            TreeView1.Nodes.Item(0).Expand()
            tx_elemento_seleccionado.Text = "N/D"
            llenar_combo_elementos()
        Else
            llenar_rama_arbol()
            TreeView1.Nodes.Item(0).Expand()
        End If
    End Sub
    Private Sub llenar_rama_arbol()
        csql = "SELECT estructura.*, tb0107_tipos_estructura.*," _
            & " estructura.f0100_nombre || ' -- { ' || estructura.f0100_codigo || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_nombre," _
            & " estructura.f0100_codigo || ' -- { ' || estructura.f0100_nombre || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_codigo" _
            & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as estructura" _
                & " join " & database.obtener_esquema & ".tb0107_tipos_estructura" _
                    & " on f0100_id_tipo_estructura = f0107_id_tipo_estructura" _
                & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as maquina" _
                  & " on maquina.f0100_id_estructura = estructura.f0100_id_maquina_padre" _
            & " where substring(estructura.f0100_path || estructura.f0100_id_estructura || '-' from 1 for " & Len(path_estructura_filtrado) & ") = '" & path_estructura_filtrado & "'" _
            & " order by estructura.f0100_estructura_padre;"
        otb_rama_estructura_mantenimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_rama_estructura_mantenimiento.Rows.Count)
        TreeView1.Nodes.Clear()
        CrearNodosDelPadre(otb_rama_estructura_mantenimiento, id_estructura_padre_filtrado, Nothing)
        'TreeView1.Nodes.Item(0).Expand()
        tx_elemento_seleccionado.Text = "N/D"
        'llenar_combo_elementos()
    End Sub
    Private Sub llenar_rama_arbol_secuencia(ByVal indicePadre As String, ByVal nodePadre As TreeNode)
        'MsgBox("Hola")
        Dim dataviewhijosnodo As New DataView
        dataviewhijosnodo = New DataView(otb_estructura_mantenimiento, "", "f0100_codigo", DataViewRowState.CurrentRows)
        dataviewhijosnodo.RowFilter = otb_estructura_mantenimiento.Columns("f0100_estructura_padre").ColumnName + " = " + indicePadre.ToString()
        For Each dataRowCurrent As DataRowView In dataviewhijosnodo
            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = "   " & dataRowCurrent("f0107_siglas").ToString().Trim() & "  { id= " _
                                & dataRowCurrent("f0100_id_estructura") & " } --  " _
                                & dataRowCurrent("f0100_nombre").ToString().Trim()

            nuevoNodo.Tag = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            nuevoNodo.Name = dataRowCurrent("f0100_id_estructura").ToString().Trim()

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If
        Next
        'tx_elemento_seleccionado.Text = "N/D"
        'llenar_combo_elementos()
    End Sub
    Public Sub actualizar_arbol()
        llenar_arbol() 'Actualiza la info con los nuevos cambios
        mostrar_nodo(nodo_padre_tag)
    End Sub
    Private Sub llenar_combo_elementos()
        If rb_nombre.Checked = True Then
            llenar_combo_elementos_nombre()
        Else
            llenar_combo_elementos_codigo()
        End If
    End Sub
    Private Sub llenar_combo_elementos_codigo()
        With cm_elementos
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion_codigo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_estructura_mantenimiento
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub llenar_combo_elementos_nombre()
        With cm_elementos
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion_nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_estructura_mantenimiento
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub CrearNodosDelPadre(ByVal odatatable As DataTable, ByVal indicePadre As String, ByVal nodePadre As TreeNode)
        Dim ods As New DataSet
        Dim dataViewHijos As New DataView
        'codigo_padre de quien dependo
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(odatatable, "", "f0100_codigo", DataViewRowState.CurrentRows)

        dataViewHijos.RowFilter = odatatable.Columns("f0100_estructura_padre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos
            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = "   " & dataRowCurrent("f0107_siglas").ToString().Trim() & "  { " _
                                & dataRowCurrent("f0100_codigo").ToString().Trim() & " }  --  " _
                                & dataRowCurrent("f0100_id_estructura").ToString().Trim() & "  " _
                                & dataRowCurrent("f0100_nombre").ToString().Trim()

            nuevoNodo.Tag = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            nuevoNodo.Name = dataRowCurrent("f0100_id_estructura").ToString().Trim()

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If
            llenar_rama_arbol_secuencia(nuevoNodo.Tag, nuevoNodo)
            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'CrearNodosDelPadre(otb_estructura_mantenimiento, Int32.Parse(dataRowCurrent("f0100_id_estructura").ToString()), nuevoNodo)
        Next dataRowCurrent
    End Sub
    Private Sub TreeView1_BeforeExpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        'MessageBox.Show(e.Node.Text)
        'MsgBox(e.Node.Text)
        For Each onode As TreeNode In e.Node.Nodes
            'MsgBox(onode.Text)
            If onode.Nodes.Count = 0 Then
                llenar_rama_arbol_secuencia(onode.Tag, onode)
            End If
        Next
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        'MsgBox(e.Node.Tag)
        tx_elemento_seleccionado.Text = e.Node.Text.Trim
        id_estructura = e.Node.Tag.ToString.Trim
        nodo_hijo_tag = nodo_padre_tag
        nodo_padre_tag = e.Node.Tag.ToString.Trim

        'Identificamos informacion de la estructura seleccionada.
        Dim rowprod As DataRow() = otb_estructura_mantenimiento.Select("f0100_id_estructura ='" & id_estructura & "'")
        For Each orow As DataRow In rowprod
            path_estructura = orow("f0100_path").ToString.Trim & id_estructura & "-" 'Codigo del producto access
            path_estructura_base = orow("f0100_path").ToString.Trim
            id_estructura_padre = orow("f0100_estructura_padre")
            If orow("f0100_id_tipo_estructura") = "00000003" Then
                actualizar_familia = "S"
            End If
            'MsgBox(path_estructura)
        Next

        If trasladar = "S" Then
            oform_mover.valor_raiz = "-"
            oform_mover.otabla = "tb0100_estructura_mantenimiento"
            oform_mover.campo_id = "f0100_id_estructura"
            oform_mover.campo_path = "f0100_path"
            oform_mover.campo_dependencia = "f0100_estructura_padre"
            oform_mover.campo_agrupacion_principal = "f0100_id_maquina_padre"
            If oform_mover.rb_padre.Checked = True Then
                oform_mover.lb_padre.Text = e.Node.Text.Trim & " <> " & path_estructura
                oform_mover.id_padre = id_estructura
            Else
                oform_mover.lb_hijo.Text = e.Node.Text.Trim & " <> " & path_estructura
                oform_mover.id_hijo = id_estructura
            End If
            If oform_mover.chk_raiz.Checked = True Then
                oform_mover.id_padre = 0
                oform_mover.valor_raiz = "-"
            End If
        End If
    End Sub
    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        mostrar_nodo(id_estructura)
    End Sub
    Private Sub mostrar_nodo(ByVal nombre_nodo As String)
        TreeView1.Nodes.Clear()
        'si es la raiz del arbol
        If nombre_nodo = id_estructura_raiz.ToString Then
            'llenar_arbol()
            CrearNodosDelPadre(otb_estructura_mantenimiento, "0", Nothing)
            TreeView1.Nodes.Item(0).Expand()
            Exit Sub
        End If
        Dim dataViewHijos As New DataView
        Dim arraypath As String() = {}
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(otb_estructura_mantenimiento, "", "f0100_codigo", DataViewRowState.CurrentRows)
        dataViewHijos.RowFilter = otb_estructura_mantenimiento.Columns("f0100_id_estructura").ColumnName + " = " + nombre_nodo 'cm_elementos.SelectedValue.ToString()
        For Each dataRowCurrent As DataRowView In dataViewHijos
            Dim txt_path As String = dataRowCurrent("f0100_path").ToString().Trim() & dataRowCurrent("f0100_id_estructura").ToString().Trim()
            'MsgBox(txt_path)
            arraypath = txt_path.Split("-")
        Next
        Dim cont As Integer = 0
        Dim nodePadre As TreeNode = Nothing
        For Each s As String In arraypath
            If s.Trim <> "" Then
                If cont = 0 Then
                    nodePadre = CrearNodossecuenciales(otb_estructura_mantenimiento, s, Nothing)
                    cont = 1
                    'nodePadre = TreeView1.Nodes.Item(s.Trim)
                Else
                    nodePadre = CrearNodossecuenciales(otb_estructura_mantenimiento, s.Trim, nodePadre)
                    'nodePadre = TreeView1.Nodes.Item(s.Trim)
                    'MsgBox(nodePadre.Text)
                End If
            End If
        Next


        'MsgBox(nombre_nodo)
        Dim traer As TreeNode() = TreeView1.Nodes.Find(nombre_nodo, True)
        If traer.Length <> 0 Then
            Try
                TreeView1.SelectedNode = traer(0)
                TreeView1.SelectedNode.Expand()
                TreeView1.SelectedNode.ForeColor = Color.Red
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub mostrar_nodo_obsoleto(ByVal nombre_nodo As String)
        'MsgBox("mostrar nodo: " & nombre_nodo)
        Dim traer As TreeNode() = TreeView1.Nodes.Find(nombre_nodo, True)
        'If traer.Length <> 0 Then
        Try
            'MsgBox("Entro")
            TreeView1.SelectedNode = traer(0)
            TreeView1.SelectedNode.Expand()
            TreeView1.SelectedNode.ForeColor = Color.Red
        Catch ex As Exception

        End Try
        'Else

        'End If
    End Sub
    Private Sub bt_crear_elemento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt_crear_elemento.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim padre As String = id_estructura
        Dim nuevo As String = ""
        TreeView1.SelectedNode.Expand()
        'Pregunta si realmente desea crear un nuevo elemento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Crear Nuevo", "Desea crear un elemento hijo de: " & tx_elemento_seleccionado.Text & "?")
        If respuesta = "N" Then
            Exit Sub
        End If
        If cm_compania.Text.ToString = "" Then
            MsgBox("Seleccione una compañia", MsgBoxStyle.Exclamation, "Seleccionar")
            Exit Sub
        End If
        If tx_elemento_seleccionado.Text = "N/D" Then
            MsgBox("Seleccione el elemento padre", MsgBoxStyle.Exclamation, "Seleccionar")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_info_elemento As New camocontrol.fm_0100_elemento_estructura_mantenimiento
        'oform_grilla_programacion.ods_hijo = ods
        oform_info_elemento.vf_oform_padre = Me
        oform_info_elemento.lb_titulo.Text = "Nuevo Elemento Estructura Mantenimiento"
        oform_info_elemento.vg_id_cia = cm_compania.SelectedValue
        oform_info_elemento.vg_usuario_autoriza = vg_usuario_autoriza
        'oform_info_elemento.otb_estructura_mantenimiento = otb_estructura_mantenimiento
        oform_info_elemento.id_estructura_padre = id_estructura
        oform_info_elemento.path_estructura_padre = path_estructura
        'MsgBox(path_estructura)
        'oform_info_elemento.cm_codigo.Enabled = False
        oform_info_elemento.vf_elemento_nuevo = "S"
        oform_info_elemento.ShowDialog()
        nuevo = nodo_padre_tag
        cargar_otabla_estructura()
        'llenar_arbol() 'Actualiza la info con los nuevos cambios
        'MsgBox(nodo_padre_tag)
        ruta_critica(padre)
        mostrar_nodo(nuevo)
        'recalcular_relaciones_arbol()
    End Sub
    Private Sub bt_info_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_info_elemento.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_info_elemento As New camocontrol.fm_0100_elemento_estructura_mantenimiento
        'oform_grilla_programacion.ods_hijo = ods
        oform_info_elemento.vf_oform_padre = Me
        oform_info_elemento.vg_id_cia = cm_compania.SelectedValue
        'oform_info_elemento.otb_estructura_mantenimiento = otb_estructura_mantenimiento
        oform_info_elemento.id_estructura = id_estructura
        oform_info_elemento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_info_elemento.vf_elemento_nuevo = "N"
        oform_info_elemento.ShowDialog()
        cargar_otabla_estructura()
        'MsgBox(nodo_padre_tag)
        ruta_critica(nodo_padre_tag)
        'llenar_arbol() 'Actualiza la info con los nuevos cambios
        'mostrar_nodo(nodo_padre_tag)
    End Sub
    Private Sub mi_expandir_todo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_expandir_todo.Click
        TreeView1.ExpandAll()
    End Sub

    Private Sub mi_colapsartodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_colapsartodo.Click
        TreeView1.CollapseAll()
    End Sub
    Private Sub mi_expandir_rama_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_expandir_rama.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione primero un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        TreeView1.SelectedNode.ExpandAll()
    End Sub
    Private Sub mi_quitar_filtro_rama_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_quitar_filtro_rama.Click
        filtro_rama = "N"
        llenar_arbol()
        mostrar_nodo(nodo_padre_tag)
    End Sub
    Private Sub mi_filtrar_rama_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mi_filtrar_rama.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione primero un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        path_estructura_filtrado = path_estructura
        id_estructura_padre_filtrado = id_estructura_padre
        filtro_rama = "S"
        llenar_arbol()
    End Sub
    Private Sub mi_ruta_estructura_Click(sender As System.Object, e As System.EventArgs) Handles mi_ruta_estructura.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione primero un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        ruta_critica(id_estructura)
    End Sub
    Private Sub cm_elementos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_elementos.Validating
        If cm_elementos.SelectedIndex = -1 Then
            cm_elementos.Text = ""
            Exit Sub
        End If
        ruta_critica(cm_elementos.SelectedValue)
    End Sub
    Private Sub ruta_critica(id_nodo As String)
        'MsgBox("entro")
        TreeView1.Nodes.Clear()
        Dim dataViewHijos As New DataView
        Dim arraypath As String() = {}
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(otb_estructura_mantenimiento, "", "f0100_codigo", DataViewRowState.CurrentRows)
        dataViewHijos.RowFilter = otb_estructura_mantenimiento.Columns("f0100_id_estructura").ColumnName + " = " + id_nodo
        For Each dataRowCurrent As DataRowView In dataViewHijos
            Dim txt_path As String = dataRowCurrent("f0100_path").ToString().Trim() & dataRowCurrent("f0100_id_estructura").ToString().Trim()
            'MsgBox(txt_path)
            arraypath = txt_path.Split("-")
        Next
        Dim cont As Integer = 0
        Dim nodePadre As TreeNode = Nothing
        For Each s As String In arraypath
            If s.Trim <> "" Then
                If cont = 0 Then
                    nodePadre = CrearNodossecuenciales(otb_estructura_mantenimiento, s, Nothing)
                    cont = 1
                    'nodePadre = TreeView1.Nodes.Item(s.Trim)
                Else
                    nodePadre = CrearNodossecuenciales(otb_estructura_mantenimiento, s.Trim, nodePadre)
                    'nodePadre = TreeView1.Nodes.Item(s.Trim)
                    'MsgBox(nodePadre.Text)
                End If
            End If
        Next
        If arraypath.Length > 1 Then
            'MsgBox("mostrar nodo")
            mostrar_nodo(id_nodo)
        Else
            'MsgBox("muy bien")
            filtro_rama = "N"
            llenar_arbol()
        End If
    End Sub
    Private Function CrearNodossecuenciales(ByVal odatatable As DataTable, ByVal id_nuevo_nodo As String, ByVal nodePadre As TreeNode)
        Dim dataViewNodo As New DataView
        'codigo_padre de quien dependo
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewNodo = New DataView(odatatable, "", "f0100_codigo", DataViewRowState.CurrentRows)
        dataViewNodo.RowFilter = odatatable.Columns("f0100_id_estructura").ColumnName + " = " + id_nuevo_nodo.ToString()
        Dim nuevoNodo As New TreeNode
        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewNodo

            nuevoNodo.Text = "   " & dataRowCurrent("f0107_siglas").ToString().Trim() & "  { id= " _
                                & dataRowCurrent("f0100_id_estructura").ToString().Trim() & " }  --  " _
                                & dataRowCurrent("f0100_nombre").ToString().Trim()

            nuevoNodo.Tag = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            nuevoNodo.Name = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            'MsgBox(nuevoNodo.Text)
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If
        Next dataRowCurrent
        Return nuevoNodo
    End Function
    Private Sub rb_nombre_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_nombre.CheckedChanged
        llenar_combo_elementos()
    End Sub

    Private Sub bt_mantenimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_mantenimientos.Click

        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_programar_actividad As New camocontrol.fm_0100_programacion_actividad_manto_menu
        oform_programar_actividad.vf_oform_padre = Me
        oform_programar_actividad.lb_estructura.Text = tx_elemento_seleccionado.Text
        oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
        oform_programar_actividad.vg_id_cia = cm_compania.SelectedValue
        oform_programar_actividad.path_estructura = path_estructura
        oform_programar_actividad.id_estructura = id_estructura
        'oform_programar_actividad.vf_elemento_nuevo = "N"
        oform_programar_actividad.ShowDialog()
    End Sub

    Private Sub bt_trasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_trasladar.Click
        'Pregunta si realmente desea crear un nuevo elemento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Trasladar Ramal", "Desea trasladar un ramal de un lugar a otro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        trasladar = "S"
        oform_mover = New camocontrol.fm_0100_trasladar_ramal
        oform_mover.vf_oform_padre = Me
        oform_mover.vg_id_cia = vg_id_cia
        oform_mover.formulario_origen = Me.Name
        oform_mover.Show()

    End Sub

    Private Sub bt_reportar_falla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_reportar_falla.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Falla", "Desea reportar una falla?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_reportar_falla As New camocontrol.fm_0100_reportar_falla_maquina
        'oform_grilla_programacion.ods_hijo = ods
        oform_reportar_falla.vf_oform_padre = Me
        oform_reportar_falla.vg_id_cia = cm_compania.SelectedValue
        oform_reportar_falla.id_estructura = id_estructura
        oform_reportar_falla.id_fuente_falla = "00000001"
        oform_reportar_falla.cm_fuente_accion.Enabled = False
        oform_reportar_falla.vg_usuario_autoriza = vg_usuario_autoriza
        oform_reportar_falla.tx_estructura.Text = tx_elemento_seleccionado.Text.Trim
        oform_reportar_falla.ShowDialog()

    End Sub

    Private Sub bt_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_imagen.Click
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'Dim oform_gestion_accion As New camocontrol.fm_0600_p1_definicion_accion
        'oform_buscar_colada.vf_oform_padre = Me
        'oform_gestion_accion.ShowDialog()
        If IsDBNull(id_estructura) = True Then
            Exit Sub
        End If

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
            & " where f0100_id_estructura = '" & id_estructura & "'"
        Dim otb_info_estructura As DataTable
        Dim path_imagen As String = ""
        otb_info_estructura = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_estructura.Rows
            path_imagen = orow("f0100_path_file_imagen")
        Next
        If path_imagen = "" Then
            MsgBox("No hay imagen asociada", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'borramos todos los temporales
        Dim dir_temp As String() = Directory.GetFiles(Path.GetTempPath(), "*.tmp")
        For Each f As String In dir_temp
            Try
                File.Delete(f)
            Catch ex As Exception
            End Try
        Next
        Dim file_temp As String = Path.GetTempFileName()
        verror = cl_utilidades_gestion_documentos.suministrar_archivo(path_imagen, file_temp, "N")
        If verror = "N" Then
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_imagen As New camocontrol.fm_visor_imagen
            'oform_grilla_programacion.ods_hijo = ods
            'oform_imagen.vf_oform_padre = Me
            oform_imagen.vg_id_cia = vg_id_cia
            oform_imagen.vg_usuario_autoriza = vg_usuario_autoriza
            oform_imagen.path_file = file_temp
            oform_imagen.Text = "Soporte"
            oform_imagen.ShowDialog()
        End If

    End Sub

    Private Sub bt_recalcular_path_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_recalcular_path.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Seleccione un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'funcion que recalculara las estructuras padre de la estructura de mantenimiento.
        cl_utilidades_gestion_mantenimiento.actualizar_maquina_padre_de_las_maquinas()
        cl_utilidades_gestion_mantenimiento.actualizar_estructura_padre(vg_id_cia)
        cl_utilidades_gestion_mantenimiento.actualizar_hijos_de_maquinas(vg_id_cia)
        MsgBox("Path y elementos de maquina recalculados", MsgBoxStyle.Information, "Recalculo")
        Dispose()
    End Sub

    Private Sub bt_comprar_Click(sender As System.Object, e As System.EventArgs) Handles bt_comprar.Click
        Dim ocampos As String(,) = {{"f0100_id_cia", "$c"}, {"f0100_nombre", "$c"}, {"f0100_descripcion", "$c"}}
        Dim otabla As String = "tb0100_estructura_mantenimiento"
        Dim id_rama As String = 46
        Dim campo_rama As String = "f0100_estructura_padre"
        Dim campo_id As String = "f0100_id_estructura"
        cl_utilidades_datatables.copiar_ramal(ocampos, otabla, id_rama, campo_rama, campo_id)
    End Sub

End Class
