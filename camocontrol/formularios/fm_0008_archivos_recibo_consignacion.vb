Public Class fm_0008_archivos_recibo_consignacion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private otb_archivo As DataTable

    Private Sub fm_0008_archivos_recibo_consignacion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
        bt_grabar.Enabled = False
        bt_anular.Enabled = False
        bt_generar_informe.Enabled = False

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0008_configuracion_planos_recaudos order by f0008_descripcion_banco"
        otb_archivo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_archivo_recaudo
            'Valor que se muestra al usuario
            .DisplayMember = "f0008_descripcion_banco"
            'Valor interno que almacena el objeto
            .ValueMember = "f0008_id_config"
            'Origen de Datos del ComboBox
            .DataSource = otb_archivo
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub bt_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo.Click
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_configurar_plano_consignaciones As New camocontrol.fm_0008_configurar_archivo_recibo
        oform_configurar_plano_consignaciones.vf_oform_padre = Me
        oform_configurar_plano_consignaciones.vg_id_cia = vg_id_cia
        oform_configurar_plano_consignaciones.vg_usuario_autoriza = vg_usuario_autoriza
        oform_configurar_plano_consignaciones.vf_elemento_nuevo = "S"
        oform_configurar_plano_consignaciones.ShowDialog()
        Dispose()
    End Sub

    Private Sub bt_editar_Click(sender As System.Object, e As System.EventArgs) Handles bt_editar.Click
        If cm_archivo_recaudo.SelectedIndex = -1 Then
            MsgBox("Seleccione el archivo plano a editar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_configurar_plano_consignaciones As New camocontrol.fm_0008_configurar_archivo_recibo
        oform_configurar_plano_consignaciones.vf_oform_padre = Me
        oform_configurar_plano_consignaciones.vg_id_cia = vg_id_cia
        oform_configurar_plano_consignaciones.vg_usuario_autoriza = vg_usuario_autoriza
        oform_configurar_plano_consignaciones.vf_elemento_nuevo = "N"
        oform_configurar_plano_consignaciones.id_config = cm_archivo_recaudo.SelectedValue
        oform_configurar_plano_consignaciones.ShowDialog()
        Dispose()
    End Sub
End Class
