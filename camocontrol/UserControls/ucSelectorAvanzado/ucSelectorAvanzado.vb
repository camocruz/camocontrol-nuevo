Public Class ucSelectorAvanzado

    Private _lista As List(Of MultiColumnDTO)
    Private valorOriginal As String = ""
    Private asignandoValor As Boolean = False
    Private _soloLectura As Boolean = False
    Private dtOriginal As DataTable

    Public Property SoloLectura As Boolean
        Get
            Return _soloLectura
        End Get
        Set(value As Boolean)
            _soloLectura = value
            AplicarSoloLectura()
        End Set
    End Property

    Public Property SelectedID As String
    Public Property SelectedText As String
    Public Property SelectedExtra As String
    Public Property ColumnasVisiblesPopup As List(Of String)

    Public Event SeleccionRealizada(id As String, texto As String, extra As String)

    Private Sub AplicarSoloLectura()
        If _soloLectura Then
            txtValor.ReadOnly = True
            txtValor.BackColor = Color.LightGray
            txtValor.Cursor = Cursors.Default
        Else
            txtValor.ReadOnly = False
            txtValor.BackColor = Color.White
            txtValor.Cursor = Cursors.IBeam
        End If
    End Sub

    Private Sub ucSelectorAvanzado_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AjustarAnchoTextBox()
        AjustarAltura()
    End Sub

    Private Sub AjustarAnchoTextBox()
        txtValor.Width = Me.Width - 4
    End Sub

    Private Sub AjustarAltura()
        Me.Height = txtValor.Height + 4
    End Sub

    ' ============================================================
    '  CARGA NORMAL
    ' ============================================================
    Public Sub Inicializar(dt As DataTable)
        dtOriginal = dt
        _lista = SelectorHelper.ConstruirLista(dt)
    End Sub

    ' ============================================================
    '  CARGA CON SELECCIÓN AUTOMÁTICA
    ' ============================================================
    Public Sub InicializarConSeleccion(dt As DataTable, id As String)
        dtOriginal = dt
        _lista = SelectorHelper.ConstruirLista(dt)

        If String.IsNullOrWhiteSpace(id) Then Exit Sub
        AsignarSeleccionDirecta(id)
    End Sub

    ' ============================================================
    '  ASIGNAR SELECCIÓN DIRECTA
    ' ============================================================
    Public Sub AsignarSeleccionDirecta(id As String)
        Dim encontrado = _lista.FirstOrDefault(Function(x) x.ID = id)

        If encontrado Is Nothing Then
            SelectedID = ""
            SelectedText = ""
            SelectedExtra = ""
            txtValor.Text = ""
            valorOriginal = ""
            Exit Sub
        End If

        asignandoValor = True

        SelectedID = encontrado.ID
        SelectedText = encontrado.Texto
        SelectedExtra = encontrado.Extra
        txtValor.Text = SelectedText
        valorOriginal = SelectedText

        asignandoValor = False

        RaiseEvent SeleccionRealizada(SelectedID, SelectedText, SelectedExtra)
    End Sub

    ' ============================================================
    '  CLICK EN TEXTBOX
    ' ============================================================
    Private Sub txtValor_Click(sender As Object, e As EventArgs) Handles txtValor.Click
        If _soloLectura Then Exit Sub

        If SelectedID Is Nothing OrElse SelectedID.Trim() = "" Then
            AbrirPopupConBusqueda()
        End If
    End Sub

    ' ============================================================
    '  TEXTBOX VACIO E INTENTO DE ESCRITURA → ABRIR POPUP
    ' ============================================================
    Private Sub txtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValor.KeyPress
        If asignandoValor Then Exit Sub

        If txtValor.Text.Trim() = "" Then
            e.Handled = True
            AbrirPopup(e.KeyChar.ToString())
        End If
    End Sub



    ' ============================================================
    '  TEXT CHANGED
    ' ============================================================
    Private Sub txtValor_TextChanged(sender As Object, e As EventArgs) Handles txtValor.TextChanged

        If _soloLectura Then Exit Sub
        If asignandoValor Then Exit Sub
        If SelectedID Is Nothing OrElse SelectedID.Trim() = "" Then Exit Sub
        If txtValor.Text.Trim() = valorOriginal.Trim() Then Exit Sub

        Dim r = MessageBox.Show("¿Desea modificar la selección?",
                                "Confirmar",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question)

        If r = DialogResult.No Then
            asignandoValor = True
            txtValor.Text = valorOriginal
            asignandoValor = False
            Exit Sub
        End If

        SelectedID = ""
        SelectedText = ""
        SelectedExtra = ""
    End Sub

    ' ============================================================
    '  ENTER → ABRIR POPUP
    ' ============================================================
    Private Sub txtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If _soloLectura Then Exit Sub

            If SelectedID Is Nothing OrElse SelectedID.Trim() = "" Then
                AbrirPopupConBusqueda()
            End If
        End If
    End Sub

    ' ============================================================
    '  FILTRAR Y ABRIR POPUP
    ' ============================================================
    Private Sub AbrirPopupConBusqueda()
        Dim textoBusqueda As String = txtValor.Text.Trim()

        Dim existeExtra As Boolean =
        (dtOriginal IsNot Nothing AndAlso dtOriginal.Columns.Count >= 3)

        Dim coincidencias = SelectorHelper.Filtrar(_lista, textoBusqueda, existeExtra)

        Dim frm As New frmSelectorPopup
        frm.ColumnasVisibles = ColumnasVisiblesPopup
        frm.CargarDatos(coincidencias, dtOriginal)

        Dim pos = Me.PointToScreen(New Point(0, Me.Height))
        frm.StartPosition = FormStartPosition.Manual
        frm.Location = pos

        If frm.ShowDialog() = DialogResult.OK Then
            asignandoValor = True

            SelectedID = frm.ResultadoID
            SelectedText = frm.ResultadoTexto   ' ← SIEMPRE TEXTO (col1)
            SelectedExtra = frm.ResultadoExtra

            txtValor.Text = SelectedText

            valorOriginal = SelectedText

            asignandoValor = False

            RaiseEvent SeleccionRealizada(SelectedID, SelectedText, SelectedExtra)
        End If
    End Sub


    ' ============================================================
    '  ABRIR POPUP SIN FILTRAR
    ' ============================================================
    Private Sub AbrirPopup(textoBusqueda As String)
        Dim frm As New frmSelectorPopup

        ' PASO CLAVE: pasar la búsqueda inicial al popup
        frm.TextoInicialBusqueda = textoBusqueda

        frm.ColumnasVisibles = ColumnasVisiblesPopup
        frm.CargarDatos(_lista, dtOriginal)

        Dim pos = Me.PointToScreen(New Point(0, Me.Height))
        frm.StartPosition = FormStartPosition.Manual
        frm.Location = pos

        If frm.ShowDialog() = DialogResult.OK Then
            asignandoValor = True

            SelectedID = frm.ResultadoID
            SelectedText = frm.ResultadoTexto
            SelectedExtra = frm.ResultadoExtra

            txtValor.Text = SelectedText
            valorOriginal = SelectedText

            asignandoValor = False

            RaiseEvent SeleccionRealizada(SelectedID, SelectedText, SelectedExtra)
        End If
    End Sub


End Class



