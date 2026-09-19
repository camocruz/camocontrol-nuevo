Imports System.Data

Public Module SelectorHelper

    ' ============================================================
    '  EXTRAER TOKENS SQL
    ' ============================================================
    Public Function ExtraerTokensSQL(texto As String) As List(Of String)
        Dim tokens As New List(Of String)

        If String.IsNullOrWhiteSpace(texto) Then Return tokens

        texto = texto.Replace("%", " ")

        For Each t As String In texto.Split(" "c)
            Dim limpio = t.Trim()
            If limpio <> "" Then tokens.Add(limpio)
        Next

        Return tokens
    End Function

    ' ============================================================
    '  CONSTRUIR LISTA DTO
    ' ============================================================
    Public Function ConstruirLista(dt As DataTable) As List(Of MultiColumnDTO)
        Dim lista As New List(Of MultiColumnDTO)

        For Each row As DataRow In dt.Rows
            Dim dto As New MultiColumnDTO()

            Select Case dt.Columns.Count

                Case 1
                    dto.ID = row(0).ToString()
                    dto.Texto = row(0).ToString()
                    dto.Extra = ""

                Case 2
                    dto.ID = row(0).ToString()
                    dto.Texto = row(1).ToString()
                    dto.Extra = ""

                Case Else   ' 3 columnas
                    dto.ID = row(0).ToString()
                    dto.Texto = row(1).ToString()   ' ← TEXTO SIEMPRE ES COLUMNA 1
                    dto.Extra = row(2).ToString()   ' ← EXTRA ES COLUMNA 2

            End Select

            lista.Add(dto)
        Next

        Return lista
    End Function


    ' ============================================================
    '  FILTRAR LISTA
    ' ============================================================
    Public Function Filtrar(lista As List(Of MultiColumnDTO),
                        texto As String,
                        existeExtra As Boolean) As List(Of MultiColumnDTO)

        If String.IsNullOrWhiteSpace(texto) Then
            Return lista.ToList()
        End If

        Dim tokens As List(Of String) =
            texto.ToLower().Split({" "c}, StringSplitOptions.RemoveEmptyEntries).
                  Select(Function(t) t.Trim()).ToList()

        Dim resultado As New List(Of MultiColumnDTO)

        For Each x As MultiColumnDTO In lista

            Dim idItem As String = If(x.ID, "").ToLower()
            Dim textoItem As String = If(x.Texto, "").ToLower()
            Dim extraItem As String = If(x.Extra, "").ToLower()

            Dim coincideTokens As Boolean = True

            For Each token As String In tokens

                If existeExtra Then
                    ' 3 columnas → ID + Texto + Extra
                    If Not idItem.Contains(token) AndAlso
                       Not textoItem.Contains(token) AndAlso
                       Not extraItem.Contains(token) Then

                        coincideTokens = False
                        Exit For
                    End If

                Else
                    ' 1 o 2 columnas → ID + Texto
                    If Not idItem.Contains(token) AndAlso
                       Not textoItem.Contains(token) Then

                        coincideTokens = False
                        Exit For
                    End If
                End If

            Next

            If coincideTokens Then resultado.Add(x)
        Next

        Return resultado
    End Function


End Module
