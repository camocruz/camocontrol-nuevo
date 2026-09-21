Imports System.Text

Public NotInheritable Class DuplicateValidatorService

    Public Shared Function DetectarExacto(texto As String,
                                          lista As List(Of TextValidationOptionDTO)) As DuplicateMatchDTO

        Dim match = lista.FirstOrDefault(Function(x) x.Description.Equals(texto, StringComparison.OrdinalIgnoreCase))

        If match Is Nothing Then Return Nothing

        Return New DuplicateMatchDTO With {
            .TextoComparado = match.Description,
            .TipoCoincidencia = "Exacto",
            .Puntaje = 100
        }
    End Function


    Public Shared Function DetectarParcial(texto As String,
                                           lista As List(Of TextValidationOptionDTO)) As List(Of DuplicateMatchDTO)

        Dim resultados As New List(Of DuplicateMatchDTO)

        For Each item In lista
            If item.Description.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 Then
                resultados.Add(New DuplicateMatchDTO With {
                    .TextoComparado = item.Description,
                    .TipoCoincidencia = "Parcial",
                    .Puntaje = 50
                })
            End If
        Next

        Return resultados
    End Function


    Public Shared Function DetectarTokens(texto As String,
                                          lista As List(Of TextValidationOptionDTO)) As List(Of DuplicateMatchDTO)

        Dim resultados As New List(Of DuplicateMatchDTO)
        Dim tokens = texto.Split(" "c).Where(Function(t) t.Length > 2).ToList()

        For Each item In lista
            For Each token In tokens
                If item.Description.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0 Then
                    resultados.Add(New DuplicateMatchDTO With {
                        .TextoComparado = item.Description,
                        .TipoCoincidencia = "Token",
                        .Puntaje = 40
                    })
                    Exit For
                End If
            Next
        Next

        Return resultados
    End Function


    Public Shared Function DetectarSimilaridad(texto As String,
                                               lista As List(Of TextValidationOptionDTO)) As List(Of DuplicateMatchDTO)

        Dim resultados As New List(Of DuplicateMatchDTO)

        For Each item In lista
            Dim distancia = Levenshtein(texto.ToUpper(), item.Description.ToUpper())

            If distancia <= 3 Then
                resultados.Add(New DuplicateMatchDTO With {
                    .TextoComparado = item.Description,
                    .TipoCoincidencia = "Similar",
                    .Puntaje = 30
                })
            End If
        Next

        Return resultados
    End Function


    Private Shared Function Levenshtein(a As String, b As String) As Integer
        If a.Length = 0 Then Return b.Length
        If b.Length = 0 Then Return a.Length

        Dim matriz(a.Length, b.Length) As Integer

        For i = 0 To a.Length
            matriz(i, 0) = i
        Next

        For j = 0 To b.Length
            matriz(0, j) = j
        Next

        For i = 1 To a.Length
            For j = 1 To b.Length
                Dim costo = If(a(i - 1) = b(j - 1), 0, 1)

                matriz(i, j) = Math.Min(
                    Math.Min(matriz(i - 1, j) + 1, matriz(i, j - 1) + 1),
                    matriz(i - 1, j - 1) + costo
                )
            Next
        Next

        Return matriz(a.Length, b.Length)
    End Function

End Class



