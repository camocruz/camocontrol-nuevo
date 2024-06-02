Public Class fm_0400_rp_ip_cguno
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_rp As Integer
    Public id_ipp As Integer
    Public tree_path As String = ""
    Public id_item As Integer
    Public id_estructura As Integer = 0
    Public otb_items_programa_produccion As DataTable

    'Private otipo_nota As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    Private dg_row_id_personal_rp As Integer = 0
    Private dg_row_id_tercero As String
    Private dg_row_horas As Decimal
    Private dg_row_nota As String = ""

    Private estado_rp As String = "C" 'A = abierto  C = cerrado  B = cerrado por administrador sin cumplir requisitos
    Private descripcion_producto As String = ""
    Private verror As String = "S"
    Private vexiste As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private item_restringido As String = "S"
    Private usuario_con_acceso_total As String = "N"
    Private t_improd_total As Decimal = 0 'Tiempo improductivo total
    Private tot_produccion As Decimal = 0 'Produccion total
    Private ind_productividad As Decimal = 0 'Indice de productividad
    Private recorte_consumido As Decimal = 0
    Private recorte_generado As Decimal = 0
    Private id_estandar_productivo As Integer = 0
    Private produccion_programada As Decimal = 0
    Private h_h_programada As Decimal = 0
    Private tomar_fecha_sistema As String = "N" 'para definir si la fecha a usar para consumos es la del sistema o la del RP

    Private otb_items As DataTable
    Private otb_reporte_produccion As DataTable
    Private otb_doc_mov_invent_relacionados As DataTable
    Private otb_info_personal As DataTable
    Private otb_personal_grillas As DataTable
    Private otb_personal_rp As DataTable 'es la datatable con los registros actuales relacionados en el rp
    Private otb_indicadores_productivos As DataTable
    Private otb_plantilla_produccion As DataTable

    Private Sub fm_0400_rp_ip_cguno_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-RPD"
        vf_var_config_notas = "TN-RPD-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
        vf_id_notas_archivos = id_rp
        cargar_info_rp()
    End Sub

    Private Sub cargar_info_rp()
        csql = "select *" _
                    & " FROM " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                    & " where f0402_id_cia = '" & vg_id_cia & "' and f0402_id_rp = '" & id_rp & "'"
        otb_reporte_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_reporte_produccion.Rows
            'id_item = orow("f0402_id_item")
            id_rp = orow("f0402_id_rp")
            id_ipp = orow("f0402_id_ipp")
            id_item = orow("f0402_id_item")
            'lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_rp, vg_id_cia)
            vf_id_notas_archivos = orow("f0402_id_rp")
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
            tx_id_rp.Text = orow("f0402_id_rp")
            dtp_fecha.Value = orow("f0402_fecha_produccion")
            dtp_fecha_vencimiento.Value = orow("f0402_fecha_vence")
            tx_lote.Text = orow("f0402_lote")
            tx_horas_hombre.Text = orow("f0402_horas_hombre")

        Next

    End Sub
End Class
