Imports System.Text.RegularExpressions
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmValidadorDuplicados

    ' ============================================
    ' CAMPOS Y PROPIEDADES
    ' ============================================
    Public Property Options As List(Of TextValidationOptionDTO)
    Public Property CampoTexto As String
    Public Property CampoCodigo As String
    Public Property CampoExtra As String

    Private _rule As TextValidationOptionDTO
    Private _duplicados As List(Of DuplicateMatchDTO)
    Private _sugerenciasFiltradas As New List(Of TextValidationOptionDTO)
    Private WithEvents debounceTimer As New Timer() With {.Interval = 250}

    ' Clase interna para evitar problemas con ValueTuple
    Private Class ResultadoScore
        Public Property Opt As TextValidationOptionDTO
        Public Property Score As Integer
    End Class


    ' ============================================
    ' INICIALIZACIÓN
    ' ============================================
    Public Sub Inicializar(options As List(Of TextValidationOptionDTO),
                           regla As TextValidationOptionDTO,
                           textoActual As String)

        Me.Options = options
        _rule = regla

        txtEntrada.Text = textoActual.Trim()
        lblRegla.Text = ConstruirTextoRegla(regla)

        AplicarFiltro()
        AnalizarDuplicados()
    End Sub

    Private Function ConstruirTextoRegla(regla As TextValidationOptionDTO) As String
        If regla Is Nothing Then Return ""
        Dim req As String = If(regla.IsRequired, "Obligatorio", "Opcional")
        Dim len As String = If(regla.MaxLength > 0, "Máx: " & regla.MaxLength, "Sin límite")
        Dim pat As String = If(String.IsNullOrWhiteSpace(regla.Pattern), "", "Patrón: " & regla.Pattern)
        Return regla.Code & " - " & req & " - " & len & " " & pat
    End Function


    ' ============================================
    ' FILTRO DE SUGERENCIAS (LÓGICA HÍBRIDA)
    ' ============================================
    Private Sub AplicarFiltro()

        lstSugerencias.Items.Clear()
        _sugerenciasFiltradas.Clear()

        If Options Is Nothing OrElse Options.Count = 0 Then Exit Sub

        Dim texto As String = txtEntrada.Text.Trim().ToUpperInvariant()
        If texto = "" Then Exit Sub

        Dim tokens() As String = texto.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim resultados As New List(Of ResultadoScore)

        For Each opt In Options

            Dim desc As String = If(opt.Description, "").Trim().ToUpperInvariant()
            Dim code As String = If(opt.Code, "").Trim().ToUpperInvariant()
            If desc = "" AndAlso code = "" Then Continue For

            Dim score As Integer = CalcularScore(opt, tokens, texto)

            ' Lógica híbrida: coincidencia literal o score alto
            Dim coincideLiteral As Boolean = desc.Contains(texto) OrElse code.Contains(texto)
            Dim coincideScore As Boolean = score >= 10

            If coincideLiteral OrElse coincideScore Then
                resultados.Add(New ResultadoScore With {.Opt = opt, .Score = score})
            End If

        Next

        ' Ordenar por score descendente
        resultados.Sort(Function(a, b) b.Score.CompareTo(a.Score))

        ' Limitar a top 20
        Dim maxItems As Integer = Math.Min(20, resultados.Count)

        For i = 0 To maxItems - 1
            Dim r = resultados(i)
            _sugerenciasFiltradas.Add(r.Opt)
            lstSugerencias.Items.Add($"{r.Opt.Description} ({r.Score})")
        Next

        PriorizarSeleccionSugerencias()

    End Sub

    Private Function CalcularScore(opt As TextValidationOptionDTO,
                                   tokens() As String,
                                   rawText As String) As Integer

        Dim score As Integer = 0
        Dim code As String = If(opt.Code, "").ToUpperInvariant()
        Dim desc As String = If(opt.Description, "").ToUpperInvariant()

        For Each t In tokens
            If code.Contains(t) Then score += 3
            If desc.Contains(t) Then score += 2
        Next

        Dim lenDiff As Integer = Math.Abs(desc.Length - rawText.Length)
        score += Math.Max(0, 5 - lenDiff)

        Return score
    End Function


    ' ============================================
    ' DETECCIÓN DE DUPLICADOS
    ' ============================================
    Private Sub AnalizarDuplicados()

        lstDuplicados.Items.Clear()
        _duplicados = New List(Of DuplicateMatchDTO)

        If Options Is Nothing OrElse Options.Count = 0 Then Exit Sub

        Dim texto As String = txtEntrada.Text.Trim()
        If texto = "" Then Exit Sub

        Dim exacto = DuplicateValidatorService.DetectarExacto(texto, Options)
        If exacto IsNot Nothing Then _duplicados.Add(exacto)

        _duplicados.AddRange(DuplicateValidatorService.DetectarParcial(texto, Options))
        _duplicados.AddRange(DuplicateValidatorService.DetectarTokens(texto, Options))
        _duplicados.AddRange(DuplicateValidatorService.DetectarSimilaridad(texto, Options))

        MostrarDuplicados()

    End Sub


    ' ============================================
    ' MOSTRAR DUPLICADOS
    ' ============================================
    Private Sub MostrarDuplicados()

        lstDuplicados.Items.Clear()

        If _duplicados Is Nothing OrElse _duplicados.Count = 0 Then
            lblDuplicadosInfo.Text = "Duplicados encontrados: 0"
            picEstado.Image = My.Resources.icon_ok
            Exit Sub
        End If

        For Each d In _duplicados
            lstDuplicados.Items.Add($"{d.TipoCoincidencia}: {d.TextoComparado.Trim()}")
        Next

        lblDuplicadosInfo.Text = $"Duplicados encontrados: {_duplicados.Count}"

        If _duplicados.Any(Function(x) x.TipoCoincidencia = "Exacta") Then
            picEstado.Image = My.Resources.icon_error
        Else
            picEstado.Image = My.Resources.icon_warning
        End If

    End Sub


    ' ============================================
    ' TOOLTIP DUPLICADOS
    ' ============================================
    Private Sub lstDuplicados_MouseMove(sender As Object, e As MouseEventArgs) Handles lstDuplicados.MouseMove
        Dim index As Integer = lstDuplicados.IndexFromPoint(e.Location)
        If index < 0 OrElse index >= _duplicados.Count Then Exit Sub

        Dim d As DuplicateMatchDTO = _duplicados(index)
        toolTipPopup.SetToolTip(lstDuplicados, $"{d.TipoCoincidencia}{vbCrLf}Texto: {d.TextoComparado.Trim()}")
    End Sub


    ' ============================================
    ' TOOLTIP SUGERENCIAS
    ' ============================================
    Private Sub lstSugerencias_MouseMove(sender As Object, e As MouseEventArgs) Handles lstSugerencias.MouseMove
        Dim index As Integer = lstSugerencias.IndexFromPoint(e.Location)
        If index < 0 OrElse index >= _sugerenciasFiltradas.Count Then Exit Sub

        Dim opt As TextValidationOptionDTO = _sugerenciasFiltradas(index)
        Dim tip As String = $"Código: {opt.Code}{vbCrLf}Descripción: {opt.Description.Trim()}"
        If Not String.IsNullOrWhiteSpace(opt.Extra) Then
            tip &= vbCrLf & $"Extra: {opt.Extra.Trim()}"
        End If
        toolTipPopup.SetToolTip(lstSugerencias, tip)
    End Sub


    ' ============================================
    ' NAVEGACIÓN SUGERENCIAS
    ' ============================================
    Private Sub lstSugerencias_KeyDown(sender As Object, e As KeyEventArgs) Handles lstSugerencias.KeyDown

        If lstSugerencias.Items.Count = 0 Then Exit Sub

        Select Case e.KeyCode

            Case Keys.Up
                If lstSugerencias.SelectedIndex > 0 Then
                    lstSugerencias.SelectedIndex -= 1
                End If
                e.Handled = True

            Case Keys.Down
                If lstSugerencias.SelectedIndex < lstSugerencias.Items.Count - 1 Then
                    lstSugerencias.SelectedIndex += 1
                End If
                e.Handled = True

            Case Keys.Enter
                AceptarSugerenciaSeleccionada()
                e.Handled = True

        End Select

    End Sub

    Private Sub AceptarSugerenciaSeleccionada()

        Dim index As Integer = lstSugerencias.SelectedIndex
        If index < 0 OrElse index >= _sugerenciasFiltradas.Count Then Exit Sub

        Dim opt As TextValidationOptionDTO = _sugerenciasFiltradas(index)

        txtEntrada.Text = opt.Description.Trim()

        AplicarFiltro()
        AnalizarDuplicados()

    End Sub


    ' ============================================
    ' DEBOUNCE
    ' ============================================
    Private Sub txtEntrada_TextChanged(sender As Object, e As EventArgs) Handles txtEntrada.TextChanged
        debounceTimer.Stop()
        debounceTimer.Start()
    End Sub

    Private Sub debounceTimer_Tick(sender As Object, e As EventArgs) Handles debounceTimer.Tick
        debounceTimer.Stop()
        AplicarFiltro()
        AnalizarDuplicados()
    End Sub


    ' ============================================
    ' DOBLE‑CLICK EN SUGERENCIAS
    ' ============================================
    Private Sub lstSugerencias_DoubleClick(sender As Object, e As EventArgs) Handles lstSugerencias.DoubleClick
        AceptarSugerenciaSeleccionada()
    End Sub


    ' ============================================
    ' NAVEGACIÓN DUPLICADOS
    ' ============================================
    Private Sub lstDuplicados_KeyDown(sender As Object, e As KeyEventArgs) Handles lstDuplicados.KeyDown

        If lstDuplicados.Items.Count = 0 Then Exit Sub

        Select Case e.KeyCode

            Case Keys.Up
                If lstDuplicados.SelectedIndex > 0 Then
                    lstDuplicados.SelectedIndex -= 1
                End If
                e.Handled = True

            Case Keys.Down
                If lstDuplicados.SelectedIndex < lstDuplicados.Items.Count - 1 Then
                    lstDuplicados.SelectedIndex += 1
                End If
                e.Handled = True

            Case Keys.Enter
                AceptarDuplicadoSeleccionado()
                e.Handled = True

        End Select

    End Sub

    Private Sub lstDuplicados_DoubleClick(sender As Object, e As EventArgs) Handles lstDuplicados.DoubleClick
        AceptarDuplicadoSeleccionado()
    End Sub

    Private Sub AceptarDuplicadoSeleccionado()

        Dim index As Integer = lstDuplicados.SelectedIndex
        If index < 0 OrElse index >= _duplicados.Count Then Exit Sub

        Dim d As DuplicateMatchDTO = _duplicados(index)

        txtEntrada.Text = d.TextoComparado.Trim()

        AplicarFiltro()
        AnalizarDuplicados()

    End Sub


    ' ============================================
    ' BOTONES
    ' ============================================
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtEntrada.Clear()
        AplicarFiltro()
        AnalizarDuplicados()
    End Sub


    ' ============================================
    ' ENTER EN txtEntrada
    ' ============================================
    Private Sub txtEntrada_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEntrada.KeyDown

        If e.KeyCode = Keys.Enter Then

            If lstSugerencias.Items.Count > 0 AndAlso lstSugerencias.SelectedIndex >= 0 Then
                AceptarSugerenciaSeleccionada()
                e.Handled = True
                Exit Sub
            End If

            If lstDuplicados.Items.Count > 0 AndAlso lstDuplicados.SelectedIndex >= 0 Then
                AceptarDuplicadoSeleccionado()
                e.Handled = True
                Exit Sub
            End If

            btnAceptar.PerformClick()
            e.Handled = True

        End If

    End Sub


    ' ============================================
    ' PRIORIDAD DE SELECCIÓN EN SUGERENCIAS
    ' ============================================
    Private Sub PriorizarSeleccionSugerencias()

        If lstSugerencias.Items.Count = 0 Then Exit Sub

        Dim texto As String = txtEntrada.Text.Trim().ToUpperInvariant()

        ' 1. Coincidencia exacta
        For i = 0 To _sugerenciasFiltradas.Count - 1
            Dim opt = _sugerenciasFiltradas(i)
            If opt.Description.Trim().ToUpperInvariant() = texto Then
                lstSugerencias.SelectedIndex = i
                Exit Sub
            End If
        Next

        ' 2. Coincidencia literal (contiene el texto)
        For i = 0 To _sugerenciasFiltradas.Count - 1
            Dim opt = _sugerenciasFiltradas(i)
            If opt.Description.ToUpperInvariant().Contains(texto) Then
                lstSugerencias.SelectedIndex = i
                Exit Sub
            End If
        Next

        ' 3. Si no hay coincidencias → primera
        lstSugerencias.SelectedIndex = 0

    End Sub

End Class
