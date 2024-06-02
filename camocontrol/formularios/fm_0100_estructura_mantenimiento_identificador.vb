Public Class fm_0100_estructura_mantenimiento_identificador
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public trasladar As String = "N"
    Public id_estructura As Integer = 0
    Public id_estructura_selec As Integer = 0

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
    Private id_estructura_padre As Integer
    Private id_estructura_anterior As Integer
    Private path_estructura As String = ""
    Private path_estructura_base As String = "" 'path sin el id de la estructura referenciada
    Private path_estructura_filtrado As String = ""
    Private id_estructura_padre_filtrado As Integer
    Private csql As String
    Public nodo_padre_tag As String = ""
    Private nodo_hijo_tag As String = ""
    Private filtro_rama As String = "N"

    Private Sub fm_0100_estructura_mantenimiento_identificador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        id_estructura_anterior = id_estructura
        llenar_arbol()
        cm_elementos.SelectedValue = id_estructura
        If id_estructura <> 0 Then
            mostrar_nodo(id_estructura.ToString)
        End If
    End Sub
    Private Sub cargar_otabla_estructura()
        csql = "SELECT estructura.*, tb0107_tipos_estructura.*," _
                    & " estructura.f0100_nombre || ' -- { ' || estructura.f0100_codigo || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_nombre," _
                    & " estructura.f0100_codigo || ' -- { ' || estructura.f0100_nombre || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_codigo" _
                    & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as estructura" _
                        & " join " & database.obtener_esquema & ".tb0107_tipos_estructura" _
                            & " on f0100_id_tipo_estructura = f0107_id_tipo_estructura" _
                        & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as maquina" _
                          & " on maquina.f0100_id_estructura = estructura.f0100_id_maquina_padre" _
                    & " where estructura.f0100_id_cia = '" & vg_id_cia & "' and estructura.f0100_anulado = 'N'" _
                    & " order by estructura.f0100_estructura_padre;"
        otb_estructura_mantenimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim orow As DataRow()
        orow = otb_estructura_mantenimiento.Select("f0100_path = ''")
        id_estructura_raiz = orow(0)("f0100_id_estructura")
    End Sub
    Private Sub llenar_arbol()
        cargar_otabla_estructura()
        If filtro_rama = "N" Then
            tw_estructura.Nodes.Clear()
            CrearNodosDelPadre(otb_estructura_mantenimiento, "0", Nothing)
            tw_estructura.Nodes.Item(0).Expand()
            tx_elemento_seleccionado.Text = "N/D"
            llenar_combo_elementos()
        Else
            llenar_rama_arbol()
            tw_estructura.Nodes.Item(0).Expand()
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
        tw_estructura.Nodes.Clear()
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
            nuevoNodo.Text = "   " & dataRowCurrent("f0107_siglas").ToString().Trim() & "  { " _
                                & dataRowCurrent("f0100_codigo").ToString().Trim() & " }(C:" _
                                & dataRowCurrent("f0100_cantidad_item") & ") --  " _
                                & dataRowCurrent("f0100_nombre").ToString().Trim()

            nuevoNodo.Tag = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            nuevoNodo.Name = dataRowCurrent("f0100_id_estructura").ToString().Trim()

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                tw_estructura.Nodes.Add(nuevoNodo)
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
                                & dataRowCurrent("f0100_nombre").ToString().Trim()

            nuevoNodo.Tag = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            nuevoNodo.Name = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                tw_estructura.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If
            llenar_rama_arbol_secuencia(nuevoNodo.Tag, nuevoNodo)
            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'CrearNodosDelPadre(otb_estructura_mantenimiento, Int32.Parse(dataRowCurrent("f0100_id_estructura").ToString()), nuevoNodo)
        Next dataRowCurrent
    End Sub

    Private Sub tw_estructura_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tw_estructura.AfterSelect
        'MsgBox(e.Node.Tag)
        tx_elemento_seleccionado.Text = e.Node.Text.Trim
        id_estructura = e.Node.Tag.ToString.Trim
        nodo_hijo_tag = nodo_padre_tag
        nodo_padre_tag = e.Node.Tag.ToString.Trim
        cm_elementos.SelectedValue = e.Node.Tag.ToString.Trim
        'Identificamos informacion de la estructura seleccionada.
        Dim rowprod As DataRow() = otb_estructura_mantenimiento.Select("f0100_id_estructura ='" & id_estructura & "'")
        For Each orow As DataRow In rowprod
            path_estructura = orow("f0100_path").ToString.Trim & id_estructura & "-" 'Codigo del producto access
            path_estructura_base = orow("f0100_path").ToString.Trim
            id_estructura_padre = orow("f0100_estructura_padre")
            'MsgBox(path_estructura)
        Next
    End Sub

    Private Sub tw_estructura_BeforeExpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tw_estructura.BeforeExpand
        'MessageBox.Show(e.Node.Text)
        'MsgBox(e.Node.Text)
        For Each onode As TreeNode In e.Node.Nodes
            'MsgBox(onode.Text)
            If onode.Nodes.Count = 0 Then
                llenar_rama_arbol_secuencia(onode.Tag, onode)
            End If
        Next
    End Sub

    Private Sub tw_estructura_DoubleClick(sender As Object, e As EventArgs) Handles tw_estructura.DoubleClick
        mostrar_nodo(id_estructura)
    End Sub

    Private Sub mostrar_nodo(ByVal nombre_nodo As String)
        tw_estructura.Nodes.Clear()
        'si es la raiz del arbol
        If nombre_nodo = id_estructura_raiz.ToString Then
            'llenar_arbol()
            CrearNodosDelPadre(otb_estructura_mantenimiento, "0", Nothing)
            tw_estructura.Nodes.Item(0).Expand()
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
                    'MsgBox("padre")
                    'nodePadre = TreeView1.Nodes.Item(s.Trim)
                Else
                    nodePadre = CrearNodossecuenciales(otb_estructura_mantenimiento, s.Trim, nodePadre)
                    'MsgBox("hijos")
                    'nodePadre = TreeView1.Nodes.Item(s.Trim)
                    'MsgBox(nodePadre.Text)
                End If
            End If
        Next


        'MsgBox(nombre_nodo)
        Dim traer As TreeNode() = tw_estructura.Nodes.Find(nombre_nodo, True)
        If traer.Length <> 0 Then
            Try
                tw_estructura.SelectedNode = traer(0)
                tw_estructura.SelectedNode.Expand()
                tw_estructura.SelectedNode.ForeColor = Color.Red
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub mi_expandir_todo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_expandir_todo.Click
        tw_estructura.ExpandAll()
    End Sub

    Private Sub mi_colapsartodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_colapsartodo.Click
        tw_estructura.CollapseAll()
    End Sub
    Private Sub mi_expandir_rama_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_expandir_rama.Click
        If tw_estructura.SelectedNode Is Nothing Then
            MsgBox("Seleccione primero un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        tw_estructura.SelectedNode.ExpandAll()
    End Sub
    Private Sub mi_quitar_filtro_rama_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_quitar_filtro_rama.Click
        filtro_rama = "N"
        llenar_arbol()
        mostrar_nodo(nodo_padre_tag)
    End Sub
    Private Sub mi_filtrar_rama_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mi_filtrar_rama.Click
        If tw_estructura.SelectedNode Is Nothing Then
            MsgBox("Seleccione primero un elemento", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        path_estructura_filtrado = path_estructura
        id_estructura_padre_filtrado = id_estructura_padre
        filtro_rama = "S"
        llenar_arbol()
    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        If tx_elemento_seleccionado.Text = "N/D" Then
            MsgBox("Debe seleccionar un elemento del arbol", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        id_estructura_selec = id_estructura
        'vf_oform_padre.id_estructura = id_estructura
        'vf_oform_padre.cambiar_estructura = "S"
        Me.Hide()
    End Sub
    Private Sub cm_elementos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_elementos.Validating

        If cm_elementos.SelectedIndex = -1 Then
            Exit Sub
        End If

        mostrar_nodo(cm_elementos.SelectedValue)
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
            nuevoNodo.Text = "   " & dataRowCurrent("f0107_siglas").ToString().Trim() & "  { " _
                                & dataRowCurrent("f0100_codigo").ToString().Trim() & " }  --  " _
                                & dataRowCurrent("f0100_nombre").ToString().Trim()

            nuevoNodo.Tag = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            nuevoNodo.Name = dataRowCurrent("f0100_id_estructura").ToString().Trim()
            'MsgBox(nuevoNodo.Text)
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                tw_estructura.Nodes.Add(nuevoNodo)
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

    Private Sub bt_salir_Click(sender As Object, e As EventArgs) Handles bt_salir.Click
        id_estructura = id_estructura_anterior
        'MsgBox(id_estructura)
        Me.Hide()
    End Sub

    Private Sub bt_crear_estructura_Click(sender As Object, e As EventArgs) Handles bt_crear_estructura.Click
        'Controlo que tenga permiso para consultar la estructura global del mantenimiento desde otros formularios
        Dim puede_visualizar As String = "N"
        puede_visualizar = cl_gestion_permisos.identificar_un_permiso_especial_usuario("CONSULTAR_ESTRUCT_MANTO", vg_usuario_autoriza)
        If puede_visualizar = "N" Then
            MsgBox("No tiene permiso para visualizar esta informacion.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_estructura_manto As New camocontrol.fm_0100_estructura_mantenimiento
        oform_estructura_manto.vf_oform_padre = Me
        'oform_mostrar_datos.csql = csql
        'oform_mostrar_datos.titulo_formulario = "Notificacion de Actividades"
        oform_estructura_manto.vg_id_cia = vg_id_cia
        oform_estructura_manto.vg_usuario_autoriza = vg_usuario_autoriza
        oform_estructura_manto.nodo_a_mostrar = id_estructura
        oform_estructura_manto.ShowDialog()
        Dispose()
    End Sub
End Class
