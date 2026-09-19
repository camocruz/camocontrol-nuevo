Public Class frmSelectorPopup

    Private _lista As List(Of MultiColumnDTO)
    Private dtOriginal As DataTable
    Private listaFiltrada As List(Of MultiColumnDTO)
    Private SeleccionAutomaticaHabilitada As Boolean = False
    'Agregar un temporizador para el debounce
    Private WithEvents debounceTimer As New Timer With {.Interval = 150}


    Public Property ResultadoID As String
    Public Property ResultadoTexto As String
    Public Property ResultadoExtra As String
    Public Property TextoInicialBusqueda As String = ""
    '----------------------------------------
    Public Property ColumnasVisibles As List(Of String)
    'Ejemplos de uso: 
    '{"Texto"}  
    '{"ID", "Texto"}  
    '{"Texto", "Extra"}  
    '{"ID", "Texto", "Extra"} 
    'Si no lo asignas, el popup usará: {"ID", "Texto", "Extra"}
    'uso real en fm_0600_p1...:
    'UcTerceroRel.ColumnasVisiblesPopup = New List(Of String) From {"Texto", "Extra"}
    'UcTerceroRel.Inicializar(otb_tercero)

    '----------------------------------------
    'Este es el constructor del formulario. Se ejecuta al crear una instancia de frmSelectorPopup.
    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True   ' Para capturar flechas
        dgDatos.AutoGenerateColumns = False

        ' Activar resaltado de coincidencias
        AddHandler dgDatos.CellPainting, AddressOf dgDatos_CellPainting
    End Sub


    Private Sub frmSelectorPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TextoInicialBusqueda <> "" Then
            SeleccionAutomaticaHabilitada = True   ' ← SOLO aquí se activa
            txtBuscar.Text = TextoInicialBusqueda
            Filtrar()
        End If



        BeginInvoke(New Action(Sub()
                                   txtBuscar.Focus()
                                   txtBuscar.Select(txtBuscar.Text.Length, 0)
                               End Sub))
    End Sub

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
                If idx > 0 Then
                    partes.Add(Tuple.Create(textoRestante.Substring(0, idx), False))
                End If

                partes.Add(Tuple.Create(textoRestante.Substring(idx, tok.Length), True))

                textoRestante = textoRestante.Substring(idx + tok.Length)
                textoRestanteUpper = textoRestante.ToUpper()
            End If
        Next

        If textoRestante.Length > 0 Then
            partes.Add(Tuple.Create(textoRestante, False))
        End If

        For Each p As Tuple(Of String, Boolean) In partes
            Dim brush As Brush = If(p.Item2, brushHighlight, brushNormal)
            g.DrawString(p.Item1, font, brush, x, y)
            x += TextRenderer.MeasureText(p.Item1, font).Width
        Next

        e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
    End Sub


    Private Sub frmSelectorPopup_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    ' ============================================================
    '  CARGAR DATOS + CONFIGURAR GRID
    ' ============================================================
    Public Sub CargarDatos(lista As List(Of MultiColumnDTO), dt As DataTable)
        _lista = lista
        dtOriginal = dt

        ConfigurarGrid(dtOriginal)
        dgDatos.DataSource = _lista
    End Sub

    Private Sub ConfigurarGrid(dt As DataTable)
        dgDatos.Columns.Clear()

        ' Si no se especifica, mostrar ID, Texto, Extra
        If ColumnasVisibles Is Nothing OrElse ColumnasVisibles.Count = 0 Then
            ColumnasVisibles = New List(Of String) From {"ID", "Texto", "Extra"}
        End If

        ' ============================
        '   COLUMNA ID (col 0)
        ' ============================
        If ColumnasVisibles.Contains("ID") Then
            Dim colID As New DataGridViewTextBoxColumn With {
            .Name = "ID",
            .DataPropertyName = "ID",
            .HeaderText = dt.Columns(0).ColumnName,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            .MinimumWidth = 70
        }
            dgDatos.Columns.Add(colID)
        End If

        ' ============================
        '   COLUMNA TEXTO (col 1)
        ' ============================
        If ColumnasVisibles.Contains("Texto") Then
            Dim colTexto As New DataGridViewTextBoxColumn With {
            .Name = "Texto",
            .DataPropertyName = "Texto",
            .HeaderText = dt.Columns(1).ColumnName,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .MinimumWidth = 200
        }
            dgDatos.Columns.Add(colTexto)
        End If

        ' ============================
        '   COLUMNA EXTRA (col 2)
        ' ============================
        If ColumnasVisibles.Contains("Extra") AndAlso dt.Columns.Count >= 3 Then
            Dim colExtra As New DataGridViewTextBoxColumn With {
            .Name = "Extra",
            .DataPropertyName = "Extra",
            .HeaderText = dt.Columns(2).ColumnName,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            .MinimumWidth = 120
        }
            dgDatos.Columns.Add(colExtra)
        End If

        ' ============================
        '   CONFIGURACIÓN GENERAL
        ' ============================
        dgDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgDatos.MultiSelect = False
        dgDatos.ReadOnly = True
        dgDatos.RowHeadersVisible = False
        dgDatos.AllowUserToResizeRows = False
        dgDatos.AllowUserToResizeColumns = True
    End Sub



    ' ============================================================
    '  FILTRAR
    ' ============================================================
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        debounceTimer.Stop()
        debounceTimer.Start()
    End Sub
    'esta función se ejecuta cuando el temporizador de debounce se activa, lo que significa que el usuario ha
    'dejado de escribir por un tiempo determinado (150 ms en este caso).
    'Esto evita que la función Filtrar() se ejecute con cada pulsación de tecla, mejorando el rendimiento y la experiencia del usuario.
    Private Sub debounceTimer_Tick(sender As Object, e As EventArgs) Handles debounceTimer.Tick
        debounceTimer.Stop()
        Filtrar()
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        SeleccionAutomaticaHabilitada = False   ' ← usuario está escribiendo
    End Sub

    Private Sub Filtrar()
        Dim texto As String = txtBuscar.Text.Trim()

        ' Detectar si existe columna Extra en la lista
        Dim existeExtra As Boolean = _lista.Any(Function(x) Not String.IsNullOrEmpty(x.Extra))

        ' Usar motor de filtrado unificado
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

        ' Actualizar grid
        dgDatos.DataSource = listaFiltrada

        ' Actualizar contador
        If listaFiltrada.Count = 0 Then
            lblCantidad.Text = "Sin resultados para: """ & texto & """"
        Else
            lblCantidad.Text = "Registros: " & listaFiltrada.Count.ToString()
        End If
    End Sub




    ' ============================================================
    '  NAVEGACIÓN GLOBAL (FLECHAS, ESC)
    ' ============================================================
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        ' ESC → cerrar
        If keyData = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return True
        End If

        ' ↓ → bajar al grid
        If keyData = Keys.Down Then
            If txtBuscar.Focused Then
                If dgDatos.Rows.Count > 0 Then
                    dgDatos.Focus()
                    dgDatos.Rows(0).Selected = True
                End If
                Return True
            End If
        End If

        ' ↑ → bajar al grid
        If keyData = Keys.Up Then
            If txtBuscar.Focused Then
                If dgDatos.Rows.Count > 0 Then
                    dgDatos.Focus()
                    dgDatos.Rows(0).Selected = True
                End If
                Return True
            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' ============================================================
    '  ENTER EN txtBuscar
    ' ============================================================
    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        ' Si pega texto dentro del popup → NO selección automática
        If e.Control AndAlso e.KeyCode = Keys.V Then
            SeleccionAutomaticaHabilitada = False
        End If

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            ' Si hay filas → mover al grid
            If dgDatos.Rows.Count > 0 Then
                dgDatos.Focus()
                dgDatos.Rows(0).Selected = True
            End If
        End If
    End Sub


    ' ============================================================
    '  GRID: ENTER, ESC, DOBLE CLIC
    ' ============================================================
    Private Sub dgDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SeleccionarFilaActual()
        End If
    End Sub


    Private Sub dgDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellDoubleClick
        SeleccionarFilaActual()
    End Sub
    Private Sub btnLimpiarFiltro_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltro.Click
        txtBuscar.Text = ""
        Filtrar()
    End Sub
    Private Sub SeleccionarFilaActual()
        If dgDatos.CurrentRow Is Nothing Then Exit Sub

        Dim dto As MultiColumnDTO = CType(dgDatos.CurrentRow.DataBoundItem, MultiColumnDTO)

        ResultadoID = dto.ID
        ResultadoTexto = dto.Texto
        ResultadoExtra = dto.Extra

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


End Class
