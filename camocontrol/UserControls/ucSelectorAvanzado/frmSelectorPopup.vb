Public Class frmSelectorPopup

    Private _lista As List(Of MultiColumnDTO)
    Private dtOriginal As DataTable
    Private listaFiltrada As List(Of MultiColumnDTO)
    Private SeleccionAutomaticaHabilitada As Boolean = False

    ' Debounce
    Private WithEvents debounceTimer As New Timer With {.Interval = 150}

    ' Resultado
    Public Property ResultadoID As String
    Public Property ResultadoTexto As String
    Public Property ResultadoExtra As String

    ' Texto inicial para búsqueda automática
    Public Property TextoInicialBusqueda As String = ""

    ' Columnas visibles en el popup
    Public Property ColumnasVisibles As List(Of String)

    ' Mapeo de columnas reales del DataTable
    Public Property ColumnaID As String = "id"
    Public Property ColumnaTexto As String = "nombre"
    Public Property ColumnaExtra As String = "planta"


    ' ============================================================
    '   CONSTRUCTOR
    ' ============================================================
    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
        dgDatos.AutoGenerateColumns = False

        AddHandler dgDatos.CellPainting, AddressOf dgDatos_CellPainting
    End Sub


    ' ============================================================
    '   LOAD
    ' ============================================================
    Private Sub frmSelectorPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TextoInicialBusqueda <> "" Then
            SeleccionAutomaticaHabilitada = True
            txtBuscar.Text = TextoInicialBusqueda
            Filtrar()
        End If

        BeginInvoke(New Action(Sub()
                                   txtBuscar.Focus()
                                   txtBuscar.Select(txtBuscar.Text.Length, 0)
                               End Sub))
    End Sub


    ' ============================================================
    '   CARGAR DATOS
    ' ============================================================
    Public Sub CargarDatos(lista As List(Of MultiColumnDTO), dt As DataTable)
        _lista = lista
        dtOriginal = dt

        ConfigurarGrid()
        dgDatos.DataSource = _lista
    End Sub


    ' ============================================================
    '   CONFIGURAR GRID (MAPEO POR NOMBRE REAL)
    ' ============================================================
    Private Sub ConfigurarGrid()
        dgDatos.Columns.Clear()

        If ColumnasVisibles Is Nothing OrElse ColumnasVisibles.Count = 0 Then
            ColumnasVisibles = New List(Of String) From {"ID", "Texto", "Extra"}
        End If

        Dim idxID As Integer = dtOriginal.Columns.IndexOf(ColumnaID)
        Dim idxTexto As Integer = dtOriginal.Columns.IndexOf(ColumnaTexto)
        Dim idxExtra As Integer = dtOriginal.Columns.IndexOf(ColumnaExtra)

        ' ID
        If ColumnasVisibles.Contains("ID") AndAlso idxID >= 0 Then
            dgDatos.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "ID",
                .DataPropertyName = "ID",
                .HeaderText = dtOriginal.Columns(idxID).ColumnName,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            })
        End If

        ' TEXTO
        If ColumnasVisibles.Contains("Texto") AndAlso idxTexto >= 0 Then
            dgDatos.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "Texto",
                .DataPropertyName = "Texto",
                .HeaderText = dtOriginal.Columns(idxTexto).ColumnName,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            })
        End If

        ' EXTRA
        If ColumnasVisibles.Contains("Extra") AndAlso idxExtra >= 0 Then
            dgDatos.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "Extra",
                .DataPropertyName = "Extra",
                .HeaderText = dtOriginal.Columns(idxExtra).ColumnName,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            })
        End If

        dgDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgDatos.MultiSelect = False
        dgDatos.ReadOnly = True
        dgDatos.RowHeadersVisible = False
    End Sub


    ' ============================================================
    '   FILTRAR (CON DEBOUNCE)
    ' ============================================================
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        debounceTimer.Stop()
        debounceTimer.Start()
    End Sub

    Private Sub debounceTimer_Tick(sender As Object, e As EventArgs) Handles debounceTimer.Tick
        debounceTimer.Stop()
        Filtrar()
    End Sub

    Private Sub Filtrar()
        Dim texto As String = txtBuscar.Text.Trim()

        Dim existeExtra As Boolean = _lista.Any(Function(x) Not String.IsNullOrEmpty(x.Extra))

        listaFiltrada = SelectorHelper.Filtrar(_lista, texto, existeExtra)

        ' Selección automática
        If SeleccionAutomaticaHabilitada AndAlso listaFiltrada.Count = 1 Then
            Dim dto As MultiColumnDTO = listaFiltrada(0)

            ResultadoID = dto.ID
            ResultadoTexto = dto.Texto
            ResultadoExtra = dto.Extra

            Me.DialogResult = DialogResult.OK
            Me.Close()
            Exit Sub
        End If

        dgDatos.DataSource = listaFiltrada

        If listaFiltrada.Count = 0 Then
            lblCantidad.Text = "Sin resultados para: """ & texto & """"
        Else
            lblCantidad.Text = "Registros: " & listaFiltrada.Count.ToString()
        End If
    End Sub


    ' ============================================================
    '   SELECCIÓN
    ' ============================================================
    Private Sub SeleccionarFilaActual()
        If dgDatos.CurrentRow Is Nothing Then Exit Sub

        Dim dto As MultiColumnDTO = CType(dgDatos.CurrentRow.DataBoundItem, MultiColumnDTO)

        ResultadoID = dto.ID
        ResultadoTexto = dto.Texto
        ResultadoExtra = dto.Extra

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellDoubleClick
        SeleccionarFilaActual()
    End Sub

    Private Sub dgDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SeleccionarFilaActual()
        End If
    End Sub


    ' ============================================================
    '   LIMPIAR FILTRO
    ' ============================================================
    Private Sub btnLimpiarFiltro_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltro.Click
        txtBuscar.Text = ""
        Filtrar()
    End Sub


    ' ============================================================
    '   RESALTADO DE COINCIDENCIAS
    ' ============================================================
    Private Sub dgDatos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim textoBusqueda As String = txtBuscar.Text.Trim().ToUpper()
        If textoBusqueda = "" Then Exit Sub

        Dim valorCelda As String = e.FormattedValue?.ToString()
        If String.IsNullOrEmpty(valorCelda) Then Exit Sub

        Dim tokens As List(Of String) =
            textoBusqueda.Split({" "c}, StringSplitOptions.RemoveEmptyEntries).
                          Select(Function(t) t.Trim().ToUpper()).ToList()

        Dim valorUpper As String = valorCelda.ToUpper()

        If Not tokens.Any(Function(tok As String) valorUpper.Contains(tok)) Then Exit Sub

        e.Handled = True
        e.PaintBackground(e.CellBounds, True)

        Dim g = e.Graphics
        Dim font = e.CellStyle.Font
        Dim brushNormal As Brush = New SolidBrush(e.CellStyle.ForeColor)
        Dim brushHighlight As Brush = New SolidBrush(Color.DarkOrange)

        Dim x As Integer = e.CellBounds.X + 4
        Dim y As Integer = e.CellBounds.Y + 2

        Dim textoOriginal As String = valorCelda
        Dim textoRestante As String = textoOriginal
        Dim textoRestanteUpper As String = textoRestante.ToUpper()

        Dim partes As New List(Of Tuple(Of String, Boolean))

        For Each tok As String In tokens
            Dim idx As Integer = textoRestanteUpper.IndexOf(tok)
            If idx >= 0 Then
                If idx > 0 Then partes.Add(Tuple.Create(textoRestante.Substring(0, idx), False))
                partes.Add(Tuple.Create(textoRestante.Substring(idx, tok.Length), True))

                textoRestante = textoRestante.Substring(idx + tok.Length)
                textoRestanteUpper = textoRestante.ToUpper()
            End If
        Next

        If textoRestante.Length > 0 Then partes.Add(Tuple.Create(textoRestante, False))

        For Each p As Tuple(Of String, Boolean) In partes
            Dim brush As Brush = If(p.Item2, brushHighlight, brushNormal)
            g.DrawString(p.Item1, font, brush, x, y)
            x += TextRenderer.MeasureText(p.Item1, font).Width
        Next

        e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
    End Sub

End Class

