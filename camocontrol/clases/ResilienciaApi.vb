Imports System
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Polly
Imports Polly.Timeout
Imports Polly.CircuitBreaker
Imports Polly.Fallback
Imports Polly.Wrap

''' <summary>
''' Clase reutilizable de resiliencia basada en Polly.
''' Soporta: Timeout, Retry (exponencial + jitter), Circuit Breaker, Fallback y Logging opcional.
''' Uso típico:
'''   Dim r As New ResilienciaApi(form, lblEstado)
'''   Dim policy = r.CrearPolitica(Of String)(timeoutSec:=10, retryCount:=4, fallbackValue:="{}")
'''   Dim resultado = Await r.ExecuteAsync(Of String)(Function() MyHttpCallAsync(), policy)
''' </summary>
Public Class ResilienciaApi

    Private ReadOnly _form As Form
    Private ReadOnly _lblEstado As Label
    Private ReadOnly _log As Action(Of String)
    Private ReadOnly _rand As Random = New Random()

    Public Sub New(Optional form As Form = Nothing, Optional lblEstado As Label = Nothing, Optional logAction As Action(Of String) = Nothing)
        _form = form
        _lblEstado = lblEstado

        If logAction IsNot Nothing Then
            _log = logAction
        ElseIf _form IsNot Nothing AndAlso _lblEstado IsNot Nothing Then
            _log = Sub(msg)
                       Try
                           _form.Invoke(Sub() _lblEstado.Text = msg)
                       Catch
                           ' Ignorar errores UI logging
                       End Try
                   End Sub
        Else
            _log = Sub(msg)
                       Try
                           Console.WriteLine(msg)
                       Catch
                       End Try
                   End Sub
        End If
    End Sub

    ''' <summary>
    ''' Crea una política completa (genérica) con:
    '''  - Timeout (pessimistic)
    '''  - Retry con backoff exponencial + jitter
    '''  - Circuit Breaker
    '''  - Fallback con valor por defecto
    ''' </summary>
    Public Function CrearPolitica(Of T)(Optional timeoutSec As Integer = 10,
                                        Optional retryCount As Integer = 3,
                                        Optional initialDelaySeconds As Double = 1,
                                        Optional exceptionsAllowedBeforeBreaking As Integer = 2,
                                        Optional durationOfBreakSeconds As Integer = 30,
                                        Optional fallbackValue As T = Nothing) As IAsyncPolicy(Of T)

        ' 1) Timeout (pessimistic)
        Dim timeoutPolicy = Policy.TimeoutAsync(Of T)(TimeSpan.FromSeconds(timeoutSec), TimeoutStrategy.Pessimistic)

        ' 2) Retry con backoff exponencial + jitter
        Dim retryPolicy = Policy(Of T) _
            .Handle(Of Exception)() _
            .WaitAndRetryAsync(
                retryCount,
                Function(retryAttempt)
                    Dim expo = initialDelaySeconds * Math.Pow(2.0, retryAttempt - 1)
                    Dim jitterMs = _rand.Next(0, 1000)
                    Return TimeSpan.FromSeconds(expo).Add(TimeSpan.FromMilliseconds(jitterMs))
                End Function,
                onRetry:=Sub(delegateResult, timespan, retryNumber, context)
                             Try
                                 Dim msg As String = If(delegateResult.Exception IsNot Nothing,
                                                        delegateResult.Exception.Message,
                                                        delegateResult.ToString())
                                 _log($"Retry {retryNumber} - esperando {timespan.TotalSeconds:F2}s - error: {msg}")
                             Catch
                             End Try
                         End Sub
            )

        ' 3) Circuit Breaker
        ' Usar argumentos posicionales (el primer parámetro en las sobrecargas es handledEventsAllowedBeforeBreaking)
        Dim circuitBreakerPolicy = Policy(Of T) _
            .Handle(Of Exception)() _
            .CircuitBreakerAsync(
                exceptionsAllowedBeforeBreaking,                             ' handledEventsAllowedBeforeBreaking (posicional)
                TimeSpan.FromSeconds(durationOfBreakSeconds),               ' durationOfBreak
                Sub(delegateResult, breakDelay)                             ' onBreak: DelegateResult(Of T), TimeSpan
                    Try
                        Dim msg As String = If(delegateResult.Exception IsNot Nothing,
                                               delegateResult.Exception.Message,
                                               delegateResult.ToString())
                        _log($"Circuito abierto por {breakDelay.TotalSeconds:F0} s - motivo: {msg}")
                    Catch
                    End Try
                End Sub,
                Sub()                                                      ' onReset (Action)
                    Try
                        _log("Circuito restablecido.")
                    Catch
                    End Try
                End Sub,
                Sub()                                                      ' onHalfOpen (Action)
                    Try
                        _log("Circuito en Half-Open: probando operación.")
                    Catch
                    End Try
                End Sub
            )

        ' 4) Fallback: devuelve fallbackValue si todo falla
        Dim fallbackPolicy = Policy(Of T) _
            .Handle(Of Exception)() _
            .FallbackAsync(
                fallbackValue,
                onFallbackAsync:=Function(delegateResult, context)
                                     Try
                                         Dim msg As String = If(delegateResult.Exception IsNot Nothing,
                                                                delegateResult.Exception.Message,
                                                                delegateResult.ToString())
                                         _log($"Fallback activado. Excepción: {msg}")
                                     Catch
                                     End Try
                                     Return Task.CompletedTask
                                 End Function
            )

        ' 5) Componer políticas: fallback -> circuitBreaker -> retry -> timeout
        Dim politicaCompleta As IAsyncPolicy(Of T) = fallbackPolicy _
            .WrapAsync(circuitBreakerPolicy) _
            .WrapAsync(retryPolicy) _
            .WrapAsync(timeoutPolicy)

        Return politicaCompleta
    End Function

    ''' <summary>
    ''' Ejecuta una operación asincrónica a través de la política proporcionada.
    ''' </summary>
    Public Async Function ExecuteAsync(Of T)(operation As Func(Of Task(Of T)), Optional policy As IAsyncPolicy(Of T) = Nothing, Optional cancellationToken As CancellationToken = Nothing) As Task(Of T)
        If operation Is Nothing Then
            Throw New ArgumentNullException(NameOf(operation))
        End If

        Dim activePolicy As IAsyncPolicy(Of T) = policy
        If activePolicy Is Nothing Then
            activePolicy = CrearPolitica(Of T)()
        End If

        Try
            ' Ejecuta usando la política. Se pasa un lambda que ignora el CancellationToken si la operación no lo usa.
            Return Await activePolicy.ExecuteAsync(Function(ct) operation(), cancellationToken)
        Catch ex As Exception
            Try
                _log($"ExecuteAsync fallo definitivamente: {ex.Message}")
            Catch
            End Try
            Throw
        End Try
    End Function

End Class
