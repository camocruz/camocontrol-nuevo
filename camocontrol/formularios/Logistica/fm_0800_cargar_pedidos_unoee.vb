Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports RestSharp


Public Class fm_0800_cargar_pedidos_unoee

    Private Async Sub btnCargarSinPaginacion_Click(sender As Object, e As EventArgs)

        ' Configurar cliente RestSharp 113
        Dim options As New RestClientOptions("https://apiqa.siesacloud.com") With {
            .Timeout = TimeSpan.FromMinutes(5)
        }

        Dim client As New RestClient(options)

        ' Filtro EXACTO que usas en Postman
        Dim filtro As String = "(f350_id_cia = 1 and f350_consec_docto > 0) or (f350_id_cia = 2 and f350_consec_docto > 0)"
        Dim filtroCodificado As String = Uri.EscapeDataString(filtro)

        ' URL COMPLETA (igual que Postman)
        Dim fullUrl As String =
            "https://apiqa.siesacloud.com/connekta/siesa/estandar/consulta/v3" &
            "?idCompania=9174" &
            "&descripcion=API_v2_Ventas_Facturas_DesdePedido" &
            "&paginacion=numPag=1|tamPag=100" &
            $"&parametros={filtroCodificado}"

        ' Crear request
        Dim request As New RestRequest(fullUrl, Method.Get)

        ' Headers correctos
        request.AddHeader("client_id", "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0")
        request.AddHeader("ConniKey", "ff96a448b64d3a764b2501749fd6e354")
        request.AddHeader("ConniToken", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjNiZjFiNGE5LTY3ZDUtNGU5MC1iYmI1LWJiMjRiNGJjY2U5NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjZiY2FhMDAwLTRkNTYtNGMwYS1iODRmLTcxY2JhMWM5NWNjMCJ9.6mqPMJgJwaUU2VCjdvTfIx_TXJGVOy2AZN6d7pZXo-Y")  ' <-- PÉGALO COMPLETO
        ' NO agregar: request.AddHeader("parametros", "")

        ' Ejecutar
        Dim response As RestResponse = Await client.ExecuteAsync(request)

        ' Mostrar URL real enviada (debug)
        Console.WriteLine(client.BuildUri(request).ToString())

        If Not response.IsSuccessful Then
            MessageBox.Show("Error: " & response.StatusDescription & vbCrLf & response.Content)
            Exit Sub
        End If

        ' Parsear JSON
        Dim json As JObject = JObject.Parse(response.Content)

        ' Extraer tabla
        Dim tablaJson As JArray = CType(json("detalle")("Table"), JArray)

        If tablaJson Is Nothing OrElse tablaJson.Count = 0 Then
            MessageBox.Show("La API no devolvió registros.")
            Exit Sub
        End If

        ' Convertir a DataTable
        Dim dt As DataTable = tablaJson.ToObject(Of DataTable)()

        ' Mostrar en DataGridView
        DataGridView1.DataSource = dt

    End Sub


    Private Async Function CargarPaginaAsync(numPag As Integer) As Task(Of DataTable)

        Dim options As New RestClientOptions("https://apiqa.siesacloud.com") With {
        .Timeout = TimeSpan.FromMinutes(5)
    }

        Dim client As New RestClient(options)

        Dim filtro As String = "(f350_id_cia = 1 and f350_consec_docto > 0) or (f350_id_cia = 2 and f350_consec_docto > 0)"
        Dim filtroCodificado As String = Uri.EscapeDataString(filtro)

        Dim fullUrl As String =
        "https://apiqa.siesacloud.com/connekta/siesa/estandar/consulta/v3" &
        "?idCompania=9174" &
        "&descripcion=API_v2_Ventas_Facturas_DesdePedido" &
        $"&paginacion=numPag={numPag}|tamPag=100" &
        $"&parametros={filtroCodificado}"

        Dim request As New RestRequest(fullUrl, Method.Get)

        request.AddHeader("client_id", "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0")
        request.AddHeader("ConniKey", "ff96a448b64d3a764b2501749fd6e354")
        request.AddHeader("ConniToken", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjNiZjFiNGE5LTY3ZDUtNGU5MC1iYmI1LWJiMjRiNGJjY2U5NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjZiY2FhMDAwLTRkNTYtNGMwYS1iODRmLTcxY2JhMWM5NWNjMCJ9.6mqPMJgJwaUU2VCjdvTfIx_TXJGVOy2AZN6d7pZXo-Y")

        Dim response As RestResponse = Await client.ExecuteAsync(request)

        If Not response.IsSuccessful Then
            Return Nothing
        End If

        Dim json As JObject = JObject.Parse(response.Content)

        If json("codigo") IsNot Nothing AndAlso json("codigo").ToString() = "1" Then
            Return Nothing
        End If

        Dim tablaJson As JArray = CType(json("detalle")("Table"), JArray)

        If tablaJson Is Nothing OrElse tablaJson.Count = 0 Then
            Return Nothing
        End If

        Return tablaJson.ToObject(Of DataTable)()

    End Function

    Private Async Function ObtenerTotalPaginasYRegistrosAsync() As Task(Of (totalPaginas As Integer, totalRegistros As Integer))

        Dim pagina As Integer = 1
        Dim totalPaginas As Integer = 0
        Dim totalRegistros As Integer = 0

        While True

            Dim dtPagina As DataTable = Await CargarPaginaAsync(pagina)

            If dtPagina Is Nothing Then
                Exit While
            End If

            totalPaginas += 1
            totalRegistros += dtPagina.Rows.Count

            pagina += 1
        End While

        Return (totalPaginas, totalRegistros)

    End Function

    Private Async Function CargarTodasLasPaginasAsync() As Task(Of DataTable)

        ' 1. Obtener total de páginas y registros
        Dim info = Await ObtenerTotalPaginasYRegistrosAsync()
        Dim totalPaginas = info.totalPaginas
        Dim totalRegistros = info.totalRegistros

        If totalPaginas = 0 Then
            Return Nothing
        End If

        ' 2. Configurar barra de progreso
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = totalPaginas
        ProgressBar1.Value = 0

        lblPaginas.Text = $"Páginas cargadas: 0 / {totalPaginas}"
        'lblRegistros.Text = $"Registros totales: 0 / {totalRegistros}"

        ' 3. Cargar todas las páginas
        Dim tablaFinal As New DataTable()
        Dim primeraVez As Boolean = True
        Dim pagina As Integer = 1
        Dim registrosAcumulados As Integer = 0

        While pagina <= totalPaginas

            Dim dtPagina As DataTable = Await CargarPaginaAsync(pagina)

            If dtPagina Is Nothing Then
                Exit While
            End If

            If primeraVez Then
                tablaFinal = dtPagina.Clone()
                primeraVez = False
            End If

            For Each fila As DataRow In dtPagina.Rows
                tablaFinal.ImportRow(fila)
            Next

            registrosAcumulados += dtPagina.Rows.Count

            ' Actualizar UI
            ProgressBar1.Value = pagina
            lblPaginas.Text = $"Páginas cargadas: {pagina} / {totalPaginas}"
            lblRegistros.Text = $"Registros totales: {registrosAcumulados} / {totalRegistros}"

            pagina += 1
        End While

        Return tablaFinal

    End Function

    Private Function GenerarEncabezadoYDetalle(dtOriginal As DataTable) As (Encabezado As DataTable, Detalle As DataTable)

        ' ============================
        ' 1. Crear estructura ENCABEZADO
        ' ============================
        Dim dtEncabezado As New DataTable("Encabezado")

        dtEncabezado.Columns.Add("f350_id_cia", GetType(Integer))
        dtEncabezado.Columns.Add("f350_id_tipo_docto", GetType(String))
        dtEncabezado.Columns.Add("f350_consec_docto", GetType(Integer))
        dtEncabezado.Columns.Add("f350_fecha", GetType(String))
        dtEncabezado.Columns.Add("f350_notas", GetType(String))
        dtEncabezado.Columns.Add("f200_nit_fact", GetType(String))
        dtEncabezado.Columns.Add("f200_razon_social_fact", GetType(String))
        dtEncabezado.Columns.Add("f461_id_sucursal_fact", GetType(String))
        dtEncabezado.Columns.Add("f200_nit_vendedor", GetType(String))
        dtEncabezado.Columns.Add("f200_razon_social_vendedor", GetType(String))

        ' ============================
        ' 2. Crear estructura DETALLE
        ' ============================
        Dim dtDetalle As New DataTable("Detalle")

        dtDetalle.Columns.Add("f350_id_cia", GetType(Integer))
        dtDetalle.Columns.Add("f350_id_tipo_docto", GetType(String))
        dtDetalle.Columns.Add("f350_consec_docto", GetType(Integer))
        dtDetalle.Columns.Add("f120_id", GetType(String))
        dtDetalle.Columns.Add("f120_referencia", GetType(String))
        dtDetalle.Columns.Add("f120_descripcion", GetType(String))
        dtDetalle.Columns.Add("f470_cant_1", GetType(Decimal))
        dtDetalle.Columns.Add("f470_id_unidad_medida", GetType(String))
        dtDetalle.Columns.Add("f470_factor", GetType(Decimal))

        ' ============================
        ' 3. Llenar ENCABEZADO (valores únicos)
        ' ============================
        Dim encabezadosUnicos = dtOriginal.AsEnumerable().
        GroupBy(Function(r) New With {
            Key .cia = r("f350_id_cia"),
            Key .tipo = r("f350_id_tipo_docto"),
            Key .consec = r("f350_consec_docto"),
            Key .fecha = r("f350_fecha"),
            Key .notas = r("f350_notas"),
            Key .nitFact = r("f200_nit_fact"),
            Key .razonFact = r("f200_razon_social_fact"),
            Key .sucursal = r("f461_id_sucursal_fact"),
            Key .nitVend = r("f200_nit_vendedor"),
            Key .razonVend = r("f200_razon_social_vendedor")
        }).Select(Function(g) g.First())

        For Each row In encabezadosUnicos
            dtEncabezado.Rows.Add(
            row("f350_id_cia"),
            row("f350_id_tipo_docto"),
            row("f350_consec_docto"),
            row("f350_fecha"),
            row("f350_notas"),
            row("f200_nit_fact"),
            row("f200_razon_social_fact"),
            row("f461_id_sucursal_fact"),
            row("f200_nit_vendedor"),
            row("f200_razon_social_vendedor")
        )
        Next

        ' ============================
        ' 4. Llenar DETALLE
        ' ============================
        For Each row As DataRow In dtOriginal.Rows
            dtDetalle.Rows.Add(
            row("f350_id_cia"),
            row("f350_id_tipo_docto"),
            row("f350_consec_docto"),
            row("f120_id"),
            row("f120_referencia"),
            row("f120_descripcion"),
            row("f470_cant_1"),
            row("f470_id_unidad_medida"),
            row("f470_factor")
        )
        Next

        Return (dtEncabezado, dtDetalle)

    End Function

    Private Function GenerarEncabezadoYDetalleLINQ(dtOriginal As DataTable) As (Encabezado As DataTable, Detalle As DataTable)

        ' ============================
        ' 1. ENCABEZADO: valores únicos por combinación de campos
        ' ============================
        Dim encabezadoQuery = dtOriginal.AsEnumerable().
        GroupBy(Function(r) New With {
            Key .cia = r("f350_id_cia"),
            Key .tipo = r("f350_id_tipo_docto"),
            Key .consec = r("f350_consec_docto"),
            Key .fecha = r("f350_fecha"),
            Key .notas = r("f350_notas"),
            Key .nitFact = r("f200_nit_fact"),
            Key .razonFact = r("f200_razon_social_fact"),
            Key .sucursal = r("f461_id_sucursal_fact"),
            Key .nitVend = r("f200_nit_vendedor"),
            Key .razonVend = r("f200_razon_social_vendedor")
        }).
        Select(Function(g) g.First())

        Dim dtEncabezado As DataTable = encabezadoQuery.CopyToDataTable()

        ' ============================
        ' 2. DETALLE: todas las líneas con campos específicos
        ' ============================
        ' Crear estructura del DataTable Detalle
        Dim dtDetalle As New DataTable("Detalle")

        dtDetalle.Columns.Add("f350_id_cia", GetType(Integer))
        dtDetalle.Columns.Add("f350_id_tipo_docto", GetType(String))
        dtDetalle.Columns.Add("f350_consec_docto", GetType(Integer))
        dtDetalle.Columns.Add("f120_id", GetType(String))
        dtDetalle.Columns.Add("f120_referencia", GetType(String))
        dtDetalle.Columns.Add("f120_descripcion", GetType(String))
        dtDetalle.Columns.Add("f470_cant_1", GetType(Decimal))
        dtDetalle.Columns.Add("f470_id_unidad_medida", GetType(String))
        dtDetalle.Columns.Add("f470_factor", GetType(Decimal))

        ' Llenar usando LINQ + LoadDataRow (más rápido que Rows.Add)
        dtOriginal.AsEnumerable().
    Select(Function(r) dtDetalle.LoadDataRow(New Object() {
        r("f350_id_cia"),
        r("f350_id_tipo_docto"),
        r("f350_consec_docto"),
        r("f120_id"),
        r("f120_referencia"),
        r("f120_descripcion"),
        r("f470_cant_1"),
        r("f470_id_unidad_medida"),
        r("f470_factor")
    }, False)).ToList()

        Return (dtEncabezado, dtDetalle)

    End Function

    Private Async Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim dt As DataTable = Await CargarTodasLasPaginasAsync()

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron registros en ninguna página.")
            Exit Sub
        End If

        Dim resultado = GenerarEncabezadoYDetalle(dt)

        Dim dtEncabezado As DataTable = resultado.Encabezado
        Dim dtDetalle As DataTable = resultado.Detalle

        ' Mostrar en DataGridView
        DataGridView1.DataSource = dtEncabezado
        DataGridView2.DataSource = dtDetalle

        ' Mostrar total de registros del encabezado
        lblRegistros.Text = $"Registros totales (encabezado): {dtEncabezado.Rows.Count}"



    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataSource = Nothing
    End Sub
End Class
