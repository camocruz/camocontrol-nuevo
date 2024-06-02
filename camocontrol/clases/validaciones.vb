Public Class validaciones
    Public Shared Function validar_null_fecha(ByVal ofecha As Object)
        'Método que valida un item de fecha, para verificar si es un valor [NULL].
        'En caso de que no sea un valor [NULL], devuelve un string de la fecha en formato yyyy/MM/dd
        'En caso de que sea [NULL], devuelve un string vacío.
        Dim vfecha As String = ""
        If Not IsDBNull(ofecha) Then
            vfecha = CDate(ofecha).ToString("yyyy/MM/dd")
        End If
        Return vfecha
    End Function
    Public Shared Function g_validar_fecha(ByVal ofecha As Object)
        Dim vfecha As String = ""
        Dim verrorfecha As String = "N"
        Dim vmensajeerror As String = ""
        If Trim(ofecha) = "" Then
            verrorfecha = "S"
            vmensajeerror = "No es una Fecha válida"
        End If
        'Verifica que sea una fecha válida
        If Not IsDate(ofecha) Then
            verrorfecha = "S"
            vmensajeerror = "No es una Fecha válida"
        End If
        'Verifica que haya utilizado el formato yyyy/MM/dd
        If Mid(ofecha, 5, 1) <> "/" Or Mid(ofecha, 8, 1) <> "/" Then
            verrorfecha = "S"
            vmensajeerror = "La fecha no está en el formato aaaa/mm/dd"
        End If
        If vmensajeerror <> "" Then
            MessageBox.Show(vmensajeerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If
        Return verrorfecha
    End Function
    Public Shared Function g_dia_semana(ByVal dia As String) As String
        Dim ndia As Integer
        Dim cdia As String = ""
        ndia = CInt(dia)
        If ndia = 0 Then
            cdia = "Domingo"
        End If
        If ndia = 1 Then
            cdia = "Lunes"
        End If
        If ndia = 2 Then
            cdia = "Martes"
        End If
        If ndia = 3 Then
            cdia = "Miércoles"
        End If
        If ndia = 4 Then
            cdia = "Jueves"
        End If
        If ndia = 5 Then
            cdia = "Viernes"
        End If
        If ndia = 6 Then
            cdia = "Sábado"
        End If
        Return cdia
    End Function
    Public Shared Function g_mensajes(ByVal vtip As String, ByVal vmen As String) As String
        Dim vmensaje As String
        Dim vtipo As String
        vmensaje = vmen
        vtipo = vtip

        If vtipo = "1" Then  ' tipo ERROR
            MessageBox.Show(vmensaje, "Error", MessageBoxButtons.OK, _
            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If

        If vtipo = "2" Then  ' Exito en el proceso
            MessageBox.Show(vmensaje, "Proceso OK", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        If vtipo = "3" Then  ' Advertencia en el proceso
            MessageBox.Show(vmensaje, "Advertencia", MessageBoxButtons.OK, _
            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
        Return vtipo
    End Function
End Class
