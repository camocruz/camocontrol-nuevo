Public Class frmSelectorPopup

    Private _lista As List(Of MultiColumnDTO)
    Private dtOriginal As DataTable

    Public Property ResultadoID As String
    Public Property ResultadoTexto As String
    Public Property ResultadoExtra As String
    Public Property TextoInicialBusqueda As String
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

    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True   ' Para capturar flechas
        dgDatos.AutoGenerateColumns = False
    End Sub

    Private Sub frmSelectorPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TextoInicialBusqueda <> "" Then
            txtBuscar.Text = TextoInicialBusqueda
            Filtrar()
        End If

        BeginInvoke(New Action(Sub()
                                   txtBuscar.Focus()
                                   txtBuscar.Select(txtBuscar.Text.Length, 0)
                               End Sub))
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

        ' Si no se especifica, mostrar todas
        If ColumnasVisibles Is Nothing OrElse ColumnasVisibles.Count = 0 Then
            ColumnasVisibles = New List(Of String) From {"ID", "Texto", "Extra"}
        End If

        ' ID siempre es col0
        If ColumnasVisibles.Contains("ID") Then
            dgDatos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "ID",
            .DataPropertyName = "ID",
            .HeaderText = dt.Columns(0).ColumnName,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        })
        End If

        ' Texto siempre es col1
        If ColumnasVisibles.Contains("Texto") Then
            dgDatos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Texto",
            .DataPropertyName = "Texto",
            .HeaderText = dt.Columns(1).ColumnName,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .Width = 300
        })
        End If

        ' Extra siempre es col2
        If ColumnasVisibles.Contains("Extra") AndAlso dt.Columns.Count >= 3 Then
            dgDatos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Extra",
            .DataPropertyName = "Extra",
            .HeaderText = dt.Columns(2).ColumnName,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        })
        End If

        dgDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgDatos.MultiSelect = False
        dgDatos.ReadOnly = True
        dgDatos.RowHeadersVisible = False
    End Sub


    ' ============================================================
    '  FILTRAR
    ' ============================================================
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Filtrar()
    End Sub

    Private Sub Filtrar()
        Dim existeExtra As Boolean = (dtOriginal.Columns.Count >= 3)
        Dim filtrado = SelectorHelper.Filtrar(_lista, txtBuscar.Text.Trim(), existeExtra)
        dgDatos.DataSource = filtrado
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
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Dim existeExtra As Boolean = (dtOriginal.Columns.Count >= 3)
            Dim coincidencias = SelectorHelper.Filtrar(_lista, txtBuscar.Text.Trim(), existeExtra)

            If coincidencias.Count = 1 Then
                ResultadoID = coincidencias(0).ID
                ResultadoTexto = coincidencias(0).Texto
                ResultadoExtra = coincidencias(0).Extra
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Exit Sub
            End If

            If coincidencias.Count > 1 Then
                If dgDatos.Rows.Count > 0 Then
                    dgDatos.Focus()
                    dgDatos.Rows(0).Selected = True
                End If
                Exit Sub
            End If
        End If
    End Sub

    ' ============================================================
    '  GRID: ENTER, ESC, DOBLE CLIC
    ' ============================================================
    Private Sub dgDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SeleccionarFilaActual()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellDoubleClick
        SeleccionarFilaActual()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        SeleccionarFilaActual()
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
