Imports App.ApiClient.CS.GestionArchivos
Imports App.ApiClient.CS.GestionArchivos.FileEncryptor
Imports App.ApiClient.CS.GestionArchivos.Helpers
Imports App.ApiClient.CS.GestionArchivos.Models
Imports System.Configuration
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

    Private Sub btnProbarAES_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnProbarAES.Click

        txtResultado.Clear()

        Dim encryptor As IFileEncryptor =
        New FileEncryptor()

        Dim textoOriginal As String =
        "Carlos Architect"

        Dim textoCifrado As String =
        encryptor.EncryptText(textoOriginal)

        Dim textoDescifrado As String =
        encryptor.DecryptText(textoCifrado)

        txtResultado.AppendText(
        "Original: " &
        textoOriginal)

        txtResultado.AppendText(
        Environment.NewLine &
        Environment.NewLine)

        txtResultado.AppendText(
        "Cifrado: " &
        textoCifrado)

        txtResultado.AppendText(
        Environment.NewLine &
        Environment.NewLine)

        txtResultado.AppendText(
        "Descifrado: " &
        textoDescifrado)

    End Sub

    Private Sub btnProbarArchivo_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnProbarArchivo.Click

        Dim encryptor As IFileEncryptor =
            New FileEncryptor()

        Dim archivoOrigen As String =
            "C:\Temp\GestionArchivosTest\Entrada\prueba.txt"

        Dim archivoCifrado As String =
            "C:\Temp\GestionArchivosTest\Salida\prueba.txt.enc"

        Dim archivoRecuperado As String =
            "C:\Temp\GestionArchivosTest\Temporal\prueba_recuperado.txt"

        Dim result =
            encryptor.EncryptFile(
                archivoOrigen,
                archivoCifrado)

        encryptor.DecryptFile(
            archivoCifrado,
            archivoRecuperado,
            result.KeyVersion,
            result.HashSHA256)

        txtResultado.Clear()

        txtResultado.AppendText(
            "Hash: " &
            result.HashSHA256)

        txtResultado.AppendText(
            Environment.NewLine &
            Environment.NewLine)

        txtResultado.AppendText(
            "Archivo recuperado: " &
            archivoRecuperado)

    End Sub
    Private Sub btnVerificarClaves_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnVerificarClaves.Click

        Dim claves = EncryptionKeyLoader.LoadKeys()

        txtResultado.Clear()

        txtResultado.AppendText(
            "Cantidad de claves: " &
            claves.Count.ToString())

        txtResultado.AppendText(
            Environment.NewLine &
            Environment.NewLine)

        For Each clave In claves

            txtResultado.AppendText(
                "Versión: " &
                clave.KeyVersion.ToString())

            txtResultado.AppendText(
                Environment.NewLine)

            txtResultado.AppendText(
                "Activa: " &
                clave.IsActiveForNewEncryptions.ToString())

            txtResultado.AppendText(
                Environment.NewLine)

            txtResultado.AppendText(
                "Key Bytes: " &
                clave.Key.Length.ToString())

            txtResultado.AppendText(
                Environment.NewLine)

            txtResultado.AppendText(
                "IV Bytes: " &
                clave.IV.Length.ToString())

            txtResultado.AppendText(
                Environment.NewLine &
                Environment.NewLine)

        Next

    End Sub
    Private Sub btnGenerarNombre_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnGenerarNombre.Click

        Dim nombre As String =
            FileNameHelper.GenerateDocumentName(
                "FCC",
                345,
                3)

        Dim ruta As String =
           PathHelper.BuildStoragePath("C:\Temp\GestionArchivosTest", DateTime.Now)




        txtResultado.Text = nombre & vbCrLf & ruta

    End Sub
    Private Sub btnGenerarRutaArchivo_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnGenerarRutaArchivo.Click

        Dim ruta As String =
        PathHelper.BuildFilePath(
            "C:\Temp\GestionArchivosTest",
            DateTime.Now,
            "FCC-00000345-003.pdf")

        Dim ruta2 As String =
            PathHelper.BuildFixedFilePath(
            "C:\Temp\GestionArchivosTest",
            "INSTRUCTIVOS",
            "INS-00000025-001.pdf")

        txtResultado.Text = ruta & vbCrLf & ruta2

    End Sub
    Private Sub btnProbarConfiguracion_Click(
    sender As Object,
    e As EventArgs) _
    Handles btnProbarConfiguracion.Click

        'Dim config As New ConfiguracionSoporteDigitalDto()

        'config.NombreConfiguracion = "FACTURAS"

        'config.DirectorioBase =
        '    "E:\FS\Compras"

        'config.UsarCarpetasPorFecha = True

        'config.TamanoMaximoKb = 10240

        'config.ExtensionesPermitidas =
        '    "pdf;jpg;png"

        'config.EncriptarArchivos = True

        Dim config As New ConfiguracionSoporteDigitalDto()

        config.NombreConfiguracion = "INSTRUCTIVOS"

        config.DirectorioBase = "E:\FS\Documentacion"

        config.UsarCarpetasPorFecha = False

        config.CarpetaFija = "INSTRUCTIVOS"

        config.EncriptarArchivos = True

        config.ComprimirImagenes = False

        txtResultado.Clear()

        txtResultado.AppendText(
            "Configuración: " &
            config.NombreConfiguracion)

        txtResultado.AppendText(
            Environment.NewLine)

        txtResultado.AppendText(
            "Base: " &
            config.DirectorioBase)

        txtResultado.AppendText(
            Environment.NewLine)

        txtResultado.AppendText(
            "Encriptar: " &
            config.EncriptarArchivos.ToString())

    End Sub

End Class