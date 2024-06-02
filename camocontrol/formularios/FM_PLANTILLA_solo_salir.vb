Public Class FM_PLANTILLA_solo_salir
    Public vcerrar As String = "N"
    Public vg_id_cia As String = ""
    Public vg_usuario_nn As String = ""
    Public vg_usuario_autoriza As String = ""
    Public vf_oform_padre As Object = Nothing
    Public vf_t_string As String = "" 'variable que se usara para almacenar datos de intercambio entre formularios
    Public vf_elemento_nuevo As String = "S"
    Public vf_otabla_permisos As DataTable
    'Objeto para manejar la configuración Regional
    Protected oregioninfo As System.Globalization.RegionInfo
    Private Sub FM_PLANTILLA_solo_salir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Establece la configuración Regional a "US"
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-us")
        oregioninfo = New System.Globalization.RegionInfo("us")

        'Establece el separador de Decimales para formato moneda
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        'Establece el separador de Decimales para formato numerico
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        'Establece el separador de miles para formato numerico
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'Establece el número de Decimales para formato numerico
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalDigits = 0
        Me.lb_fecha.Text = Now.ToString("yyyy/MM/dd")
        'ToolTip1.SetToolTip(bt_salir, "Salir")

        'Usuario NN
        'vg_usuario_nn = comunes.suministrar_valor_variable_configuracion("CONFIG-0500-01", vg_id_cia)
    End Sub
    Private Sub bt_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt_salir.Click
        'Manejador del Evento click del botón [SALIR]
        vcerrar = "S"
        Dispose()
        'Me.Close()
    End Sub
    Private Sub FM_PLANTILLA_solo_salir_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If vcerrar = "N" Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub
    Private Sub FM_PLANTILLA_solo_salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = vbCr Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub FM_PLANTILLA_solo_salir_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        'Combinacion de teclado para cerrar el formulario
        If e.Alt + e.KeyCode = Keys.Q Then
            'Dispose()
        End If
    End Sub
End Class