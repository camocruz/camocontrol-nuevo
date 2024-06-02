Public Class fm_gestion_fechas
    Public ofecha_tx As String
    Public fecha_ini As Date
    Private Sub bt_salir_Click(sender As System.Object, e As System.EventArgs) Handles bt_salir.Click
        ofecha_tx = "ND"
        Hide()
    End Sub
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        ofecha_tx = MonthCalendar1.SelectionEnd.ToString("yyyy/MM/dd") & " " & nud_hora.Value.ToString.PadLeft(2, "0") & ":" & nud_minuto.Value.ToString.PadLeft(2, "0")
        Hide()
    End Sub
    Private Sub fm_gestion_fechas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MonthCalendar1.SetDate(fecha_ini)
        nud_hora.Value = Hour(fecha_ini)
        nud_minuto.Value = Minute(fecha_ini)
    End Sub
End Class