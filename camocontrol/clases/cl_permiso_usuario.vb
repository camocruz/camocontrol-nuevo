Public Class cl_permiso_usuario
    Private pr_usuario As String
    Private pr_id_opcion As String
    Public Property usuario() As String
        Get
            Return pr_usuario
        End Get
        Set(ByVal value As String)
            pr_usuario = value
        End Set
    End Property
    Public Property id_opcion() As String
        Get
            Return pr_id_opcion
        End Get
        Set(ByVal value As String)
            pr_id_opcion = value
        End Set
    End Property
End Class
