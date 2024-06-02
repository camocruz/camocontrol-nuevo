Public Class fm_gestion_fechas_rango
    Public rango_fechas(3) As String
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private Sub fm_gestion_fechas_rango_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Set the Format type and the CustomFormat string.
        dtp_fecha_ini.Format = DateTimePickerFormat.Custom
        dtp_fecha_ini.CustomFormat = "yyyy/MM/dd"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin.CustomFormat = "yyyy/MM/dd"
    End Sub
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_rango_fechas()
        'dtp_fecha_ini.Value = MonthCalendar1.SelectionStart
        'dtp_fecha_fin.Value = MonthCalendar1.SelectionEnd
        If verror_requisitos = "N" Then
            rango_fechas(0) = "S"
            rango_fechas(1) = dtp_fecha_ini.Value.ToString("yyyy/MM/dd") 'fecha inicial del rango
            rango_fechas(2) = dtp_fecha_fin.Value.AddDays(1).ToString("yyyy/MM/dd") 'fecha final del rango + 1 dia, para consultas
            rango_fechas(3) = dtp_fecha_fin.Value.ToString("yyyy/MM/dd") 'fecha final del rango seleccionado
            Hide()
        Else
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub dtp_fecha_ini_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha_ini.Validating
        'validar_rango_fechas()
        dtp_fecha_ini.Value = CDate(dtp_fecha_ini.Value.ToString("yyyy/MM/dd"))
        MonthCalendar1.SelectionStart = dtp_fecha_ini.Value
    End Sub
    Private Sub dtp_fecha_fin_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha_fin.Validating
        'validar_rango_fechas()
        dtp_fecha_fin.Value = CDate(dtp_fecha_fin.Value.ToString("yyyy/MM/dd"))
        MonthCalendar1.SelectionEnd = dtp_fecha_fin.Value
    End Sub
    Private Sub validar_rango_fechas()
        If dtp_fecha_ini.Value > dtp_fecha_fin.Value Then
            MsgBox(dtp_fecha_ini.Value.ToString & " < " & dtp_fecha_fin.Value.ToString)
            MonthCalendar1.SetDate(comunes.g_fechahora)
            MonthCalendar1.SelectionEnd = dtp_fecha_fin.Value
            verror_requisitos = "S"
            vmensaje_requisitos = "La fecha final no puede ser menor a la fecha inicial!"
        End If
    End Sub
    Private Sub MonthCalendar1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MonthCalendar1.Validating
        dtp_fecha_ini.Value = CDate(MonthCalendar1.SelectionStart.ToString("yyyy/MM/dd"))
        dtp_fecha_fin.Value = CDate(MonthCalendar1.SelectionEnd.ToString("yyyy/MM/dd"))
    End Sub

    Private Sub bt_salir_Click(sender As System.Object, e As System.EventArgs) Handles bt_salir.Click
        rango_fechas(0) = "N"
        Hide()
    End Sub
End Class