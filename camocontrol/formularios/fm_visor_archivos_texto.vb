Public Class fm_visor_archivos_texto
    Public txt_texto As String = ""
    Public path_txt As String = ""

    Private Sub fm_visor_archivos_texto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If txt_texto = "" Then
            Try
                RichTextBox1.LoadFile(path_txt, RichTextBoxStreamType.PlainText)
            Catch ex As Exception
                MsgBox("El archivo esta abierto", MsgBoxStyle.Critical, "Error")
            End Try

        Else
            RichTextBox1.Text = txt_texto
        End If
    End Sub
End Class
