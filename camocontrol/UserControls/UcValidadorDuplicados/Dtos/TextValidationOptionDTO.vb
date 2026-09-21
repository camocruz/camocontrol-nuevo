Public Class TextValidationOptionDTO
    Public Property Description As String
    Public Property Code As String
    Public Property Extra As String

    Public Property IsRequired As Boolean
    Public Property MaxLength As Integer
    Public Property Pattern As String

    Public Overrides Function ToString() As String
        Return $"{Code} - {Description}"
    End Function
End Class

