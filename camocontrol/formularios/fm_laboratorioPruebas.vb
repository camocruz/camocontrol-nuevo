Imports App.ApiClient.CS.GestionArchivos.FileEncryptor
Imports App.ApiClient.CS.GestionArchivos.Helpers
Public Class fm_laboratorioPruebas
    Private Sub btnGenerarClave_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnGenerarClave.Click

        Dim aesKey As String =
        SecurityHelper.ToBase64(
            SecurityHelper.GenerateAes256Key())

        Dim aesIv As String =
        SecurityHelper.ToBase64(
            SecurityHelper.GenerateInitializationVector())

        Dim claves = EncryptionKeyLoader.LoadKeys()

        txtResultado.Text =
        "AES_KEY_1=" & aesKey &
        Environment.NewLine &
        Environment.NewLine &
        "AES_IV_1=" & aesIv
    End Sub
End Class