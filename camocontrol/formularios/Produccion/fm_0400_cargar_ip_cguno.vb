Public Class fm_0400_cargar_ip_cguno
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"

    Private Sub fm_0400_cargar_ip_cguno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        traer_informacion_ultimas_ip()
    End Sub
    Private Sub traer_informacion_ultimas_ip()
        Dim csql As String
        csql = "SELECT" _
               & " substring(f0405_ip_num from 1 for 3) as co," _
               & " max(substring(f0405_ip_num from 8 for 6)) as consecutivo" _
               & " FROM " & database.obtener_esquema & ".tb0405_encabezado_ip_cg_umpr4015_9" _
               & " group by co;"

        Dim otb As DataTable
        otb = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        dg_maximos.DataSource = otb

        'Dim c1 As String = otb.Rows(0)(0)
        'Dim c2 As String = otb.Rows(0)(1)

        'Lb_p1.Text = c1
        'Lb_p2.Text = c2

    End Sub

    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        cl_importador_planos.cargar_informe_produccion_ip(vg_id_cia, vg_usuario_autoriza)
        traer_informacion_ultimas_ip()
    End Sub
End Class
