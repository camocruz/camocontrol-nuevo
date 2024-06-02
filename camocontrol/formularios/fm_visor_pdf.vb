Public Class fm_visor_pdf
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Public path_file As String = ""

    Private Sub fm_visor_pdf_Load(sender As Object, e As EventArgs) Handles Me.Load
        AxAcroPDF1.src = path_file
    End Sub
End Class
