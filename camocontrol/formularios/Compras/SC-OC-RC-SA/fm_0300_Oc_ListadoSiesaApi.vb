Imports System.Net.Http
Imports App.ApiClient.CS.DTOs
Imports App.ApiClient.CS.Exceptions
Imports App.ApiClient.CS.Http
Imports App.ApiClient.CS.Interfaces
Imports App.ApiClient.CS.Services
Imports App.ApiClient.CS.Helpers
Imports System.Linq

Public Class fm_0300_Oc_ListadoSiesaApi
    Private _ordenes As List(Of OrdenCompraDto)
    Private _encabezados As DataTable
    Private _detalles As DataTable


    Private Sub fm_0300_Oc_ListadoSiesaApi_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargar_listadoApi()
    End Sub


    Private Async Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_listadoApi()
    End Sub
    Private Async Sub cargar_listadoApi()
        btnCargar.Enabled = False

        Try
            Dim baseUrl As String = "https://api.siesacloud.com/"
            Dim conniKey As String = "ff96a448b64d3a764b2501749fd6e354"
            Dim conniToken As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjNiZjFiNGE5LTY3ZDUtNGU5MC1iYmI1LWJiMjRiNGJjY2U5NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjZiY2FhMDAwLTRkNTYtNGMwYS1iODRmLTcxY2JhMWM5NWNjMCJ9.6mqPMJgJwaUU2VCjdvTfIx_TXJGVOy2AZN6d7pZXo-Y"
            Dim clientId As String = "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0"

            Dim http = HttpClientFactory.Crear(baseUrl, conniKey, conniToken, clientId)

            Dim apiClient As New SiesaApiClient(http)
            Dim servicio As New OrdenCompraApiService(apiClient)

            Dim idCompania As Integer = 9174
            Dim tamPag As Integer = 100
            Dim rowidMinimo As Integer = 7

            ' Cargar TODAS las páginas
            Dim lista As List(Of OrdenCompraDto) =
                Await servicio.ObtenerOrdenesCompraAsync(idCompania, 1, tamPag, rowidMinimo)

            _ordenes = lista

            ' Construir tablas auxiliares a partir de _ordenes
            _encabezados = ConstruirEncabezados()
            _detalles = ConstruirDetalles()

            ' Evitar disparos prematuros del evento SelectionChanged al asignar DataSource
            RemoveHandler dgvEncabezado.SelectionChanged, AddressOf dgvEncabezado_SelectionChanged
            dgvEncabezado.DataSource = _encabezados
            AddHandler dgvEncabezado.SelectionChanged, AddressOf dgvEncabezado_SelectionChanged

            'dgvOrdenes.DataSource = lista
            lblTotal.Text = $"Total: {lista.Count} registros"

        Catch ex As SiesaApiException
            MessageBox.Show(ex.Message, "Error de negocio Siesa")

        Catch ex As HttpRequestException
            MessageBox.Show("Error HTTP: " & ex.Message)

        Catch ex As Exception
            MessageBox.Show("Error inesperado: " & ex.Message)

        Finally
            btnCargar.Enabled = True
        End Try
    End Sub
    Private Sub dgvEncabezado_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEncabezado.SelectionChanged
        If dgvEncabezado.CurrentRow Is Nothing Then Exit Sub
        If _ordenes Is Nothing OrElse _ordenes.Count = 0 Then
            dgvDetalle.DataSource = Nothing
            Exit Sub
        End If

        Dim rowid As Integer = CInt(dgvEncabezado.CurrentRow.Cells("RowID").Value)

        ' Filtrar usando LINQ sobre _ordenes en lugar de iterar sobre _detalles
        Dim matches = _ordenes.Where(Function(o) o.f420_rowid = rowid).ToList()

        If matches.Count = 0 Then
            dgvDetalle.DataSource = Nothing
            Exit Sub
        End If

        ' Construir un DataTable con las columnas de detalle y llenarlo desde los matches
        Dim dtFiltrado As New DataTable()
        dtFiltrado.Columns.Add("RowID", GetType(Integer))
        dtFiltrado.Columns.Add("Referencia", GetType(String))
        dtFiltrado.Columns.Add("Descripción", GetType(String))
        dtFiltrado.Columns.Add("Cantidad", GetType(Decimal))
        dtFiltrado.Columns.Add("Precio", GetType(Decimal))
        dtFiltrado.Columns.Add("ValorNeto", GetType(Decimal))

        For Each oc In matches
            dtFiltrado.Rows.Add(
                oc.f420_rowid,
                oc.f120_referencia,
                oc.f120_descripcion,
                oc.f421_cant_pedida,
                oc.f421_precio_unitario,
                oc.f421_vlr_neto
            )
        Next

        dgvDetalle.DataSource = dtFiltrado
    End Sub


    Private Function ConstruirEncabezados() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("RowID", GetType(Integer))
        dt.Columns.Add("Proveedor", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("Tipo Documento", GetType(String))
        dt.Columns.Add("Consecutivo", GetType(Integer))
        dt.Columns.Add("Estado", GetType(String))

        Dim grupos = _ordenes.
            GroupBy(Function(x) x.f420_rowid).
            Select(Function(g) g.First()).
            OrderByDescending(Function(o) o.f420_rowid) ' Orden descendente por rowid

        For Each oc In grupos
            dt.Rows.Add(
                oc.f420_rowid,
                oc.f200_razon_social_prov,
                oc.f420_fecha,
                oc.f420_id_tipo_docto,
                oc.f420_consec_docto,
                oc.f420_desc_estado
            )
        Next

        Return dt
    End Function
    Private Function ConstruirDetalles() As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add("RowID", GetType(Integer))
        dt.Columns.Add("Referencia", GetType(String))
        dt.Columns.Add("Descripción", GetType(String))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Precio", GetType(Decimal))
        dt.Columns.Add("ValorNeto", GetType(Decimal))

        For Each oc In _ordenes
            dt.Rows.Add(
                oc.f420_rowid,
                oc.f120_referencia,
                oc.f120_descripcion,
                oc.f421_cant_pedida,
                oc.f421_precio_unitario,
                oc.f421_vlr_neto
            )
        Next

        Return dt
    End Function
End Class
