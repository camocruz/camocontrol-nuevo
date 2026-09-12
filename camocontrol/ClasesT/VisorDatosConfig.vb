Public Class VisorDatosConfig
    Public Property IdSql As String
    Public Property IdCia As String
    Public Property IdUsuario As String
    Public Property Titulo As String
    Public Property Replacements As String()
    Public Property TablaDatos As DataTable
    Public Property NombreFormulario As String = "Visor de datos"
    Public Property PermitirExportar As Boolean = True
    Public Property FormPadre As Object
    Public Property AgregarCheckBox As Boolean = False
    Public Property NombreColumnaId As String
    Public Property IdTercero As String
    Public Property Modal As Boolean = True
    Public Property SeleccionMultiple As Boolean = True
    Public Property Filtro As String
    Public Property Contexto As String
End Class
