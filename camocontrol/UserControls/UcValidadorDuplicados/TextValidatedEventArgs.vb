Public Class TextValidatedEventArgs
    Inherits EventArgs

    Public ReadOnly Property Result As TextValidatedResultDTO

    Public Sub New(result As TextValidatedResultDTO)
        Me.Result = result
    End Sub
End Class
