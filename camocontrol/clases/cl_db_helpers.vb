Public Class cl_db_helpers
    ''' <summary>
    ''' Convierte de forma defensiva a Integer y retorna DBNull.Value si no es convertible.
    ''' Útil cuando el parámetro en BD admite NULL.
    ''' </summary>
    Public Shared Function SafeIntOrDbNull(value As Object) As Object
        Try
            If value Is Nothing OrElse value Is DBNull.Value Then
                Return DBNull.Value
            End If
            Dim s As String = value.ToString().Trim()
            If s = "" Then
                Return DBNull.Value
            End If
            Dim d As Decimal
            If Decimal.TryParse(s, d) Then
                Return Convert.ToInt32(Math.Truncate(d))
            End If
            Return DBNull.Value
        Catch ex As Exception
            Return DBNull.Value
        End Try
    End Function

    ''' <summary>
    ''' Convierte de forma defensiva a Integer. Si no es convertible devuelve 0.
    ''' Útil cuando la columna NO admite NULL y quieres un fallback seguro.
    ''' </summary>
    Public Shared Function SafeIntZero(value As Object) As Integer
        Try
            If value Is Nothing OrElse value Is DBNull.Value Then
                Return 0
            End If
            Dim s As String = value.ToString().Trim()
            If s = "" Then
                Return 0
            End If
            Dim d As Decimal
            If Decimal.TryParse(s, d) Then
                Return Convert.ToInt32(Math.Truncate(d))
            End If
            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class