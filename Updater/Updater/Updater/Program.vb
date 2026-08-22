Imports System.IO
Imports System.Threading

Module Updater

    Sub Main()
        Dim origen As String = "\\192.168.0.34\pub_macdulces\camo\dsfc\EJ\Release\"
        Dim destino As String = "C:\dsfc\EJ\Release\" 'AppDomain.CurrentDomain.BaseDirectory

        ' Esperar a que la app principal se cierre
        Thread.Sleep(2000)

        Try
            For Each archivo In Directory.GetFiles(origen, "*.*", SearchOption.AllDirectories)
                Dim rutaRelativa As String = archivo.Replace(origen, "")
                Dim destinoArchivo As String = Path.Combine(destino, rutaRelativa)

                Directory.CreateDirectory(Path.GetDirectoryName(destinoArchivo))
                File.Copy(archivo, destinoArchivo, True)
            Next

            Process.Start(Path.Combine(destino, "App.exe"))

        Catch ex As Exception
            MsgBox("Error actualizando: " & ex.Message)
        End Try
    End Sub

End Module
