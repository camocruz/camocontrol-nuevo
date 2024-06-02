Public Class fm_0600_recursos_listado
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_estructura As Integer
    Public id_accion As Integer

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private otb_solicitudes As DataTable
    Private otb_recursos As DataTable
    Private id_item_accion As Integer 'registro del item solicitado en la tabla tb0305_items_solicitudes
    Private id_solicitud_c As Integer 'registro de la solicitud de compra en la tabla
    Private path_accion As String = "" 'Este es el path de la accion a la cual pertenecen las solicitud

    Private Sub fm_0600_recursos_listado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        bt_anular.Enabled = False

        dg_solicitud.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_solicitud.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_solicitud.AllowUserToAddRows = False
        dg_solicitud.AllowUserToDeleteRows = False
        dg_solicitud.ReadOnly = True

        dg_listado.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_listado.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_listado.AllowUserToAddRows = False
        dg_listado.AllowUserToDeleteRows = False
        dg_listado.ReadOnly = True
        'dg_listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        cargar_datatables()
        dg_solicitud.Rows.Clear()
        llenar_grilla_solicitudes()
    End Sub
    Private Sub cargar_datatables()
        'busco la informacion de la accion
        Dim otb_info_accion As DataTable
        otb_info_accion = cl_utilidades_gestion_acciones.suministrar_datatable_info_de_una_accion(id_accion, vg_id_cia)
        'determino el path de la acion
        path_accion = otb_info_accion.Rows(0)("f0600_path") & id_accion & "-"


        'carga informacion del ecabezado de las solicitudes de compra
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-35", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_accion)
        csql = csql.Replace("$003$", path_accion)
        otb_solicitudes = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'carga informacion de los items en las solictudes
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-36", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_accion)
        csql = csql.Replace("$003$", path_accion)
        otb_recursos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub llenar_grilla_solicitudes()
        For Each orow As DataRow In otb_solicitudes.Rows
            agregar_fila_solicitudes(orow)
        Next
    End Sub
    Private Sub agregar_fila_solicitudes(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0304_id_solicitud"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0306_estado_compras").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0304_id_accion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = Mid(Trim(orow.Item("f0304_anotacion").ToString), 1, 100)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_solicitud.Rows.Add(orowgrid)
    End Sub
    Private Sub cargar_listado_items()
        Dim dv_items As New DataView(otb_recursos)
        Dim dv_filter As String = "id_sc = '" & id_solicitud_c & "'"
        dv_items.RowFilter = dv_filter
        dg_listado.DataSource = dv_items
    End Sub

    Private Sub bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
        oform_agregar_solicitud.vf_oform_padre = Me
        oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
        oform_agregar_solicitud.vg_id_cia = vg_id_cia
        oform_agregar_solicitud.id_estructura = id_estructura
        oform_agregar_solicitud.id_accion = id_accion
        oform_agregar_solicitud.vf_elemento_nuevo = "S"
        oform_agregar_solicitud.lb_titulo.Text = "Nueva Solicitud de Compra"
        oform_agregar_solicitud.tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
        oform_agregar_solicitud.ShowDialog()
        cargar_datatables()
        dg_solicitud.Rows.Clear()
        llenar_grilla_solicitudes()
    End Sub
    Private Sub dg_solicitud_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_solicitud.CellDoubleClick
        If dg_solicitud.Rows.Count = 0 Then
            Exit Sub
        End If

        If dg_solicitud.Columns(dg_solicitud.CurrentCell.ColumnIndex).Name = "dgocell_id_solicitud" Then
            id_solicitud_c = dg_solicitud.CurrentCell.Value
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
            oform_agregar_solicitud.vf_oform_padre = Me
            oform_agregar_solicitud.id_solicitud_compra = id_solicitud_c
            oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
            oform_agregar_solicitud.vg_id_cia = vg_id_cia
            oform_agregar_solicitud.id_estructura = id_estructura
            oform_agregar_solicitud.id_accion = id_accion
            oform_agregar_solicitud.vf_elemento_nuevo = "N"
            oform_agregar_solicitud.ShowDialog()
            cargar_datatables()
            dg_solicitud.Rows.Clear()
            llenar_grilla_solicitudes()
        End If
    End Sub
    Private Sub dg_solicitud_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_solicitud.CellClick
        If dg_solicitud.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_solicitud.Text = dg_solicitud.CurrentRow.Cells("dgocell_id_solicitud").Value
        id_solicitud_c = dg_solicitud.CurrentRow.Cells("dgocell_id_solicitud").Value
        cargar_listado_items()
    End Sub
    Private Sub dg_listado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_listado.CellDoubleClick
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If

        If dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name = "id" Then
            id_item_accion = dg_listado.CurrentCell.Value
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_agregar_recurso As New camocontrol.fm_0300_sc_items
            oform_agregar_recurso.vf_oform_padre = Me
            oform_agregar_recurso.id_solicitud_compra = 1 'la solicitud 1 se usa para las acciones de mantenimiento
            oform_agregar_recurso.vg_usuario_autoriza = vg_usuario_autoriza
            oform_agregar_recurso.vg_id_cia = vg_id_cia
            oform_agregar_recurso.id_estructura = id_estructura
            oform_agregar_recurso.id_accion = id_accion
            oform_agregar_recurso.id_item_solicitud = id_item_accion
            oform_agregar_recurso.vf_elemento_nuevo = "N"
            oform_agregar_recurso.ShowDialog()
            cargar_datatables()
            dg_solicitud.Rows.Clear()
            llenar_grilla_solicitudes()
            cargar_listado_items()
        End If
    End Sub

    Private Sub bt_generar_informe_Click(sender As System.Object, e As System.EventArgs) Handles bt_generar_informe.Click
        If tx_solicitud.Text.Trim = "" Then
            MsgBox("Seleccione un documento", MsgBoxStyle.Information, "Seleccionar")
            Exit Sub
        End If
        cl_informes_comunes.informe_solicitud_compra(tx_solicitud.Text, vg_id_cia)
    End Sub

    Private Sub bt_items_relacionados_Click(sender As Object, e As EventArgs) Handles bt_items_relacionados.Click
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-36", vg_id_cia, vg_usuario_autoriza, "Items Relacionados", {vg_id_cia, id_accion, path_accion})
        'carga informacion de los items en las solictudes
    End Sub
End Class
