Public Class FI_VISOR_CR
    'Objeto para manejar la configuración Regional
    Protected oregioninfo As System.Globalization.RegionInfo
    Private Sub FI_VISOR_CR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub
End Class