Public Class UcValidadorDuplicados

    ' ============================================
    ' CAMPOS PRIVADOS
    ' ============================================
    Private _options As List(Of TextValidationOptionDTO)
    Private _rule As TextValidationOptionDTO

    ' ============================================
    ' PROPIEDADES DE CONFIGURACIÓN
    ' ============================================
    Public Property CampoTexto As String = "Description"
    Public Property CampoCodigo As String = "Code"
    Public Property CampoExtra As String = "Extra"

    Public Property Options As List(Of TextValidationOptionDTO)
        Get
            Return _options
        End Get
        Set(value As List(Of TextValidationOptionDTO))
            _options = value
        End Set
    End Property

    Public Property Rule As TextValidationOptionDTO
        Get
            Return _rule
        End Get
        Set(value As TextValidationOptionDTO)
            _rule = value
        End Set
    End Property


    ' ============================================
    ' ABRIR POPUP
    ' ============================================
    Private Sub btnValidador_Click(sender As Object, e As EventArgs) Handles btnValidador.Click
        Dim popup As New frmValidadorDuplicados()

        popup.CampoTexto = Me.CampoTexto
        popup.CampoCodigo = Me.CampoCodigo
        popup.CampoExtra = Me.CampoExtra

        popup.Inicializar(Me.Options, Me.Rule, txtValor.Text)

        If popup.ShowDialog() = DialogResult.OK Then
            txtValor.Text = popup.txtEntrada.Text
            ActualizarEstado()
        End If
    End Sub


    ' ============================================
    ' ACTUALIZAR ICONO DE ESTADO
    ' ============================================
    Private Sub ActualizarEstado()
        Dim texto As String = txtValor.Text.Trim()

        If texto = "" Then
            picEstado.Image = Nothing
            toolTipEstado.SetToolTip(picEstado, "")
            Exit Sub
        End If

        Dim exacto = DuplicateValidatorService.DetectarExacto(texto, _options)
        If exacto IsNot Nothing Then
            picEstado.Image = My.Resources.icon_error
            toolTipEstado.SetToolTip(picEstado, "Duplicado exacto: " & exacto.TextoComparado)
            Exit Sub
        End If

        Dim parciales = DuplicateValidatorService.DetectarParcial(texto, _options)
        Dim tokens = DuplicateValidatorService.DetectarTokens(texto, _options)
        Dim similares = DuplicateValidatorService.DetectarSimilaridad(texto, _options)

        If parciales.Count > 0 OrElse tokens.Count > 0 OrElse similares.Count > 0 Then
            picEstado.Image = My.Resources.icon_warning
            toolTipEstado.SetToolTip(picEstado, "Posibles duplicados detectados")
            Exit Sub
        End If

        picEstado.Image = My.Resources.icon_ok
        toolTipEstado.SetToolTip(picEstado, "Texto válido")
    End Sub


    ' ============================================
    ' CARGA DESDE DATATABLE
    ' ============================================
    Public Sub LoadFromDataTable(dt As DataTable,
                                 campoTexto As String,
                                 Optional campoCodigo As String = "",
                                 Optional campoExtra As String = "")
        Me.CampoTexto = campoTexto
        Me.CampoCodigo = campoCodigo
        Me.CampoExtra = campoExtra

        Dim lista As New List(Of TextValidationOptionDTO)

        For Each row As DataRow In dt.Rows
            Dim dto As New TextValidationOptionDTO() With {
                .Description = row(campoTexto).ToString()
            }

            If campoCodigo <> "" AndAlso dt.Columns.Contains(campoCodigo) Then
                dto.Code = row(campoCodigo).ToString()
            End If

            If campoExtra <> "" AndAlso dt.Columns.Contains(campoExtra) Then
                dto.Extra = row(campoExtra).ToString()
            End If

            lista.Add(dto)
        Next

        Me.Options = lista
    End Sub


    ' ============================================
    ' CARGA DESDE LISTA DE DTOs
    ' ============================================
    Public Sub LoadFromDTOs(Of T)(listaDTO As List(Of T),
                                  campoTexto As String,
                                  Optional campoCodigo As String = "",
                                  Optional campoExtra As String = "")
        Me.CampoTexto = campoTexto
        Me.CampoCodigo = campoCodigo
        Me.CampoExtra = campoExtra

        Dim lista As New List(Of TextValidationOptionDTO)

        For Each obj As T In listaDTO
            Dim dto As New TextValidationOptionDTO() With {
                .Description = ObtenerValorPropiedad(obj, campoTexto)
            }

            If campoCodigo <> "" Then
                dto.Code = ObtenerValorPropiedad(obj, campoCodigo)
            End If

            If campoExtra <> "" Then
                dto.Extra = ObtenerValorPropiedad(obj, campoExtra)
            End If

            lista.Add(dto)
        Next

        Me.Options = lista
    End Sub

    Private Function ObtenerValorPropiedad(Of T)(obj As T, nombreProp As String) As String
        Dim p = obj.GetType().GetProperty(nombreProp)
        If p Is Nothing Then Return ""
        Dim val = p.GetValue(obj)
        If val Is Nothing Then Return ""
        Return val.ToString()
    End Function


    Private Sub txtValor_TextChanged(sender As Object, e As EventArgs) Handles txtValor.TextChanged
        ActualizarEstado()
    End Sub

End Class














