Public Class cl_opciones
    Private pr_codigo As String
    Private pr_formulario As String
    Private pr_control As String
    Private pr_contexto As String

    Public Property codigo() As String
        Get
            Return pr_codigo
        End Get
        Set(ByVal value As String)
            pr_codigo = value
        End Set
    End Property
    Public Property formulario() As String
        Get
            Return pr_formulario
        End Get
        Set(ByVal value As String)
            pr_formulario = value
        End Set
    End Property
    Public Property control() As String
        Get
            Return pr_control
        End Get
        Set(ByVal value As String)
            pr_control = value
        End Set
    End Property
    Public Property contexto() As String
        Get
            Return pr_contexto
        End Get
        Set(ByVal value As String)
            pr_contexto = value
        End Set
    End Property

End Class
