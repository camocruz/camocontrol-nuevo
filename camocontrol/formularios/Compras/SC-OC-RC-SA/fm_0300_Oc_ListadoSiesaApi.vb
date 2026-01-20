Imports System.Net.Http
Imports App.ApiClient.CS.Exceptions
Imports App.ApiClient.CS.Http
Imports App.ApiClient.CS.Interfaces
Imports App.ApiClient.CS.Services
Imports App.ApiClient.CS.Services.SpecificServices
Imports App.ApiClient.CS.Helpers
Imports System.Linq
Imports App.ApiClient.CS.DTOs.SpecificDtos
Imports App.ApiClient.CS.Helpers.Commons


Public Class fm_0300_Oc_ListadoSiesaApi
    Private _ordenes As List(Of OrdenCompraDto)
    Private _encabezados As DataTable
    Private _detalles As DataTable


    Private Sub fm_0300_Oc_ListadoSiesaApi_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargar_proveedores_siesa()
    End Sub

    Private Async Sub cargar_proveedores_siesa()
        Dim baseService = App.ApiClient.CS.AppServices.SiesaFactory.CreateBaseService()
        Dim servicio = New OrdenCompraApiService(baseService)

        Dim ordenes = Await servicio.ObtenerOrdenesCompraAsync(9174, "f420_rowid > 7")

        'Dim dt As DataTable = ordenes.ToDataTable()
        'cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Ordenes de Compra", {}, dt,,,,,,, "N")

    End Sub



    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim baseUrl As String = "https://api.siesacloud.com/"
            Dim conniKey As String = "ff96a448b64d3a764b2501749fd6e354"
            Dim conniToken As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjNiZjFiNGE5LTY3ZDUtNGU5MC1iYmI1LWJiMjRiNGJjY2U5NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjZiY2FhMDAwLTRkNTYtNGMwYS1iODRmLTcxY2JhMWM5NWNjMCJ9.6mqPMJgJwaUU2VCjdvTfIx_TXJGVOy2AZN6d7pZXo-Y"
            Dim clientId As String = "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0"

            Dim http = HttpClientFactory.Crear(baseUrl, conniKey, conniToken, clientId)

            Dim apiClient As New SiesaApiClient(http)
            ' Crear servicio base
            Dim baseService As New SiesaApiServiceBase(apiClient)

            ' Crear servicio específico
            Dim servicio As New OrdenCompraApiService(baseService)


            ' Llamar la API con un filtro libre
            Dim ordenes As List(Of OrdenCompraDto) =
                Await servicio.ObtenerOrdenesCompraAsync(
                idCompania:=9174,
                filtro:="f420_rowid > 0"
            )
            If ordenes Is Nothing Then
                MsgBox("ORDENES ES NULL")
            Else
                'MsgBox("ORDENES TIENE " & ordenes.Count & " ELEMENTOS")
            End If

            dgvEncabezado.DataSource = ordenes

            MsgBox($"Se cargaron {ordenes.Count} registros de órdenes de compra.")

        Catch ex As SiesaApiException
            MessageBox.Show(ex.Message, "Error de negocio Siesa")

        Catch ex As HttpRequestException
            MessageBox.Show("Error HTTP: " & ex.Message)

        Catch ex As Exception
            MessageBox.Show("Error inesperado: " & ex.Message)

        Finally
            'btnCargar.Enabled = True
        End Try

    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


    End Sub
End Class
