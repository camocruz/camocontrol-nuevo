Imports System.Net

Namespace MisExtensiones
    Module MetodosDeExtension
        <Runtime.CompilerServices.Extension>
        Public Function IsLoopback(ip As IPAddress) As Boolean
            Return ip.Equals(IPAddress.Loopback) OrElse ip.Equals(IPAddress.IPv6Loopback)
        End Function
    End Module
End Namespace

