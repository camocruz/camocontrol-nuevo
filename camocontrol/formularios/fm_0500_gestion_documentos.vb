Public Class fm_0500_gestion_documentos
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_despacho As Integer
    Public mostrar_solo_despacho As String = "S"

    Private otipo_nota As String

    Public id_accion As Integer = 0 'Varibale que se llenara cuando se genere una reclamacion

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private verror_cargue As String = "N"
    Private cargue_bloqueado As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_documentos As DataTable
    Private otb_tipos_documentos As DataTable
    Private doc_ed As Integer
    Private config_archivos As String


    Private Sub fm_0500_gestion_documentos_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False

        csql = "select * from " & database.obtener_esquema & ".tb0500_tipos_documentos order by f0500_tipo_documento"
        otb_tipos_documentos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo_documento
            'Valor que se muestra al usuario
            .DisplayMember = "f0500_tipo_documento"
            'Valor interno que almacena el objeto
            .ValueMember = "f0500_id_tipo_documento"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipos_documentos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        cargar_otb_documentos()
    End Sub
    Private Sub cargar_otb_documentos()
        csql = "select *, f0501_codigo_documento || '  <=>  ' || f0501_titulo_documento as titulo from " & database.obtener_esquema & ".tb0501_documentos"
        otb_documentos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub cargar_combos_documentos()
        Dim dv_documentos As DataView = New DataView(otb_documentos, "f0501_id_tipo_documento = '" & cm_tipo_documento.SelectedValue & "'" _
                                                             , "f0501_codigo_documento", DataViewRowState.CurrentRows)

        With cm_codigo_documento
            'Valor que se muestra al usuario
            .DisplayMember = "titulo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0501_id_documento"
            'Origen de Datos del ComboBox
            .DataSource = dv_documentos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_nombre_documento
            'Valor que se muestra al usuario
            .DisplayMember = "f0501_titulo_documento"
            'Valor interno que almacena el objeto
            .ValueMember = "f0501_id_documento"
            'Origen de Datos del ComboBox
            .DataSource = dv_documentos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub limpiar_documentos()
        tx_id_documento.Text = ""
        cm_codigo_documento.Text = ""
        cm_nombre_documento.Text = ""
        dg_ediciones.DataSource = ""
    End Sub
    Private Sub cm_tipo_documento_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_tipo_documento.Validating
        If cm_tipo_documento.SelectedIndex = -1 Then
            cm_codigo_documento.Enabled = False
            cm_nombre_documento.Enabled = False
            limpiar_documentos()
            Exit Sub
        End If
        cargar_combos_documentos()
        cm_codigo_documento.Enabled = True
        cm_nombre_documento.Enabled = True
        Dim orows_tipos_documentos As DataRow()
        orows_tipos_documentos = otb_tipos_documentos.Select("f0500_id_tipo_documento = '" & cm_tipo_documento.SelectedValue & "'")
        For Each orow As DataRow In orows_tipos_documentos
            config_archivos = orow("f0500_config_archivos")
        Next
        limpiar_documentos()
    End Sub

    Private Sub cm_codigo_documento_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_codigo_documento.Validating
        If cm_codigo_documento.SelectedIndex = -1 Then
            limpiar_documentos()
            Exit Sub
        End If
        cm_nombre_documento.SelectedValue = cm_codigo_documento.SelectedValue
        tx_id_documento.Text = cm_codigo_documento.SelectedValue
        cargar_ediciones_documento()
    End Sub

    Private Sub cm_nombre_documento_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_nombre_documento.Validating
        If cm_nombre_documento.SelectedIndex = -1 Then
            limpiar_documentos()
            Exit Sub
        End If
        cm_codigo_documento.SelectedValue = cm_nombre_documento.SelectedValue
        tx_id_documento.Text = cm_nombre_documento.SelectedValue
        cargar_ediciones_documento()
    End Sub

    Private Sub cargar_ediciones_documento()
        csql = "select f0502_ed as ed, to_char(f0502_fecha_revision,'yyyy-MM-dd') as f_rev," _
            & " to_char(f0502_fecha_aprobacion,'yyyy-MM-dd') as f_aprob," _
            & " to_char(f0502_fecha_max_vigencia,'yyyy-MM-dd') as f_vigencia," _
            & " to_char(f0502_fecha_inicio_tramites,'yyyy-MM-dd') as f_ini_tramites," _
            & " f0502_descripcion_ed as cambio from " & database.obtener_esquema & ".tb0502_documentos_ed" _
            & " where f0502_id_documento = '" & tx_id_documento.Text & "'" _
            & " ORDER BY f0502_ed DESC"
        Dim otb_ediciones As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_ediciones.DataSource = otb_ediciones

    End Sub

    Private Sub bt_nuevo_documento_Click(sender As Object, e As EventArgs) Handles bt_nuevo_documento.Click
        If cm_tipo_documento.SelectedIndex = -1 Then
            MsgBox("Seleccione el tipo de documento", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_info_documento As New camocontrol.fm_0500_info_documento
        'oform_grilla_programacion.ods_hijo = ods
        oform_info_documento.vf_oform_padre = Me
        oform_info_documento.vg_id_cia = vg_id_cia
        oform_info_documento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_info_documento.id_tipo_documento = cm_tipo_documento.SelectedValue
        oform_info_documento.vf_elemento_nuevo = "S"
        oform_info_documento.ShowDialog()
        cargar_otb_documentos()
        cargar_combos_documentos()
        limpiar_documentos()
    End Sub

    Private Sub bt_editar_documento_Click(sender As Object, e As EventArgs) Handles bt_editar_documento.Click
        If tx_id_documento.Text = "" Then
            MsgBox("Seleccione un documento.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_info_documento As New camocontrol.fm_0500_info_documento
        'oform_grilla_programacion.ods_hijo = ods
        oform_info_documento.vf_oform_padre = Me
        oform_info_documento.vg_id_cia = vg_id_cia
        oform_info_documento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_info_documento.id_documento = tx_id_documento.Text
        oform_info_documento.vf_elemento_nuevo = "N"
        oform_info_documento.ShowDialog()
        cargar_otb_documentos()
        cargar_combos_documentos()
        cargar_ediciones_documento()
        cm_codigo_documento.SelectedValue = tx_id_documento.Text
        cm_nombre_documento.SelectedValue = tx_id_documento.Text
    End Sub

    Private Sub bt_nueva_version_Click(sender As Object, e As EventArgs) Handles bt_nueva_version.Click
        If tx_id_documento.Text = "" Then
            MsgBox("Seleccione un documento.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_version_documento As New camocontrol.fm_0500_version_del_documento
        'oform_grilla_programacion.ods_hijo = ods
        oform_version_documento.vf_oform_padre = Me
        oform_version_documento.vg_id_cia = vg_id_cia
        oform_version_documento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_version_documento.id_documento = tx_id_documento.Text
        oform_version_documento.config_archivos = config_archivos
        oform_version_documento.vf_elemento_nuevo = "S"
        oform_version_documento.ShowDialog()
        cargar_ediciones_documento()
    End Sub

    Private Sub dg_ediciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_ediciones.CellClick
        If dg_ediciones.Rows.Count = 0 Then
            Exit Sub
        End If
        doc_ed = dg_ediciones.CurrentRow.Cells("ed").Value
        'MsgBox(id_doc_ed)
    End Sub

    Private Sub dg_ediciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_ediciones.CellDoubleClick
        If tx_id_documento.Text = "" Or dg_ediciones.Rows.Count = 0 Then
            MsgBox("Seleccione un documento.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_version_documento As New camocontrol.fm_0500_version_del_documento
        'oform_grilla_programacion.ods_hijo = ods
        oform_version_documento.vf_oform_padre = Me
        oform_version_documento.vg_id_cia = vg_id_cia
        oform_version_documento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_version_documento.id_documento = tx_id_documento.Text
        oform_version_documento.doc_ed = doc_ed
        oform_version_documento.vf_elemento_nuevo = "N"
        oform_version_documento.config_archivos = config_archivos
        oform_version_documento.ShowDialog()
        cargar_ediciones_documento()
    End Sub

    Private Sub bt_referenciado_Click(sender As Object, e As EventArgs) Handles bt_referenciado.Click
        If tx_id_documento.Text = "" Then
            MsgBox("Seleccione un documento.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_relaciones_documento As New camocontrol.fm_0500_documentos_interrelaciones
        'oform_grilla_programacion.ods_hijo = ods
        oform_relaciones_documento.vf_oform_padre = Me
        oform_relaciones_documento.vg_id_cia = vg_id_cia
        oform_relaciones_documento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_relaciones_documento.id_documento = tx_id_documento.Text
        oform_relaciones_documento.config_archivos = config_archivos
        oform_relaciones_documento.vf_elemento_nuevo = "S"
        oform_relaciones_documento.ShowDialog()
        cargar_ediciones_documento()
    End Sub

    Private Sub bt_acceso_Click(sender As Object, e As EventArgs) Handles bt_acceso.Click
        If tx_id_documento.Text = "" Then
            MsgBox("Seleccione un documento.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_accesos_copias_documento As New camocontrol.fm_0500_control_copias_accesos
        'oform_grilla_programacion.ods_hijo = ods
        oform_accesos_copias_documento.vf_oform_padre = Me
        oform_accesos_copias_documento.vg_id_cia = vg_id_cia
        oform_accesos_copias_documento.vg_usuario_autoriza = vg_usuario_autoriza
        oform_accesos_copias_documento.id_documento = tx_id_documento.Text
        oform_accesos_copias_documento.config_archivos = config_archivos
        oform_accesos_copias_documento.vf_elemento_nuevo = "S"
        oform_accesos_copias_documento.ShowDialog()
        'cargar_ediciones_documento()
    End Sub

    Private Sub bt_informe_control_Click(sender As Object, e As EventArgs) Handles bt_informe_control.Click
        If tx_id_documento.Text.Trim = "" Then
            MsgBox("Seleccione un documento.", MsgBoxStyle.Information, "Seleccionar")
            Exit Sub
        End If
        cl_informes_comunes.reporte_control_documento(vg_id_cia, tx_id_documento.Text)
    End Sub
End Class
