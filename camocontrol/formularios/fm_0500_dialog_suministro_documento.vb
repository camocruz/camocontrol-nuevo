Public Class fm_0500_dialog_suministro_documento
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public accion_seleccionada As Integer = 0 '1=copia, 2=visualizar

    Private Sub fm_0500_dialog_suministro_documento_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        'Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        'vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        'vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        'Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        bt_aceptar.Enabled = False
    End Sub
    Private Sub bt_aceptar_Click(sender As System.Object, e As System.EventArgs) Handles bt_aceptar.Click
        If rb_copia.Checked = True Then
            accion_seleccionada = 1
        End If
        If rb_visualizar.Checked = True Then
            accion_seleccionada = 2
        End If
        Me.Hide()
    End Sub
    Private Sub bt_cancelar_Click(sender As System.Object, e As System.EventArgs) Handles bt_cancelar.Click
        accion_seleccionada = 0
        Me.Hide()
    End Sub
    Private Sub rb_copia_CheckedChanged(sender As Object, e As System.EventArgs) Handles rb_copia.CheckedChanged
        bt_aceptar.Enabled = True
    End Sub
    Private Sub rb_visualizar_CheckedChanged(sender As Object, e As System.EventArgs) Handles rb_visualizar.CheckedChanged
        bt_aceptar.Enabled = True
    End Sub
End Class
