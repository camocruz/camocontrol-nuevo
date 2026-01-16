using System;
using System.Windows.Forms;
using App.ApiClient.CS.Http;
using App.ApiClient.CS.Services;
using App.ApiClient.CS.Exceptions;

namespace Camocontrol.WinForms.CS.FormsC
{
    public partial class FormOrdenesOC : Form
    {
        public FormOrdenesOC()
        {
            InitializeComponent();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                // Datos reales que ya usas en Postman
                var baseUrl = "https://api.siesacloud.com/";
                var conniKey = "ff96a448b64d3a764b2501749fd6e354";
                var conniToken = "TU_TOKEN_AQUI";
                var clientId = "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0";

                // Crear HttpClient con headers
                var http = HttpClientFactory.Crear(baseUrl, conniKey, conniToken, clientId);

                // Crear servicio de órdenes
                var servicio = new OrdenCompraApiService(http);

                // Llamar API con paginación automática
                var lista = await servicio.ObtenerOrdenesAsync(7);

                // Mostrar datos en la grilla
                dgvOrdenes.DataSource = lista;

                // Mostrar total
                lblTotal.Text = $"Total: {lista.Count} órdenes";
            }
            catch (SiesaApiException ex)
            {
                MessageBox.Show("Error Siesa: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
    }
}
