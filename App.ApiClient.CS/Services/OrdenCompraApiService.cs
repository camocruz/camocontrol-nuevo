

//Si más adelante quieres usar otras APIs del mismo sitio, solo creas otros servicios similares que construyan su relativeUrl cambiando descripcion, parametros, etc., y reutilizas el mismo SiesaApiClient y HttpClient.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using App.ApiClient.CS.DTOs;
using App.ApiClient.CS.Exceptions;
using App.ApiClient.CS.Interfaces;

namespace App.ApiClient.CS.Services
{
    public class OrdenCompraApiService : IOrdenCompraApiService
    {
        private readonly SiesaApiClient _apiClient;

        public OrdenCompraApiService(SiesaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<OrdenCompraDto>> ObtenerOrdenesCompraAsync(
            int idCompania,
            int numeroPagina,
            int tamanoPagina,
            int rowidMinimo,
            CancellationToken cancellationToken = default)
        {
            var resultado = new List<OrdenCompraDto>();
            int paginaActual = numeroPagina;

            while (true)
            {
                string descripcion = "API_v2_Compras_Ordenes";
                string paginacion = $"numPag={paginaActual}|tamPag={tamanoPagina}";
                string parametros = $"f420_rowid > {rowidMinimo}";

                string relativeUrl =
                    $"connekta/siesa/estandar/consulta/v3" +
                    $"?idCompania={idCompania}" +
                    $"&descripcion={descripcion}" +
                    $"&paginacion={paginacion}" +
                    $"&parametros={parametros}";

                string json = await _apiClient.GetAsync(relativeUrl, cancellationToken);

                var respuesta = JsonConvert.DeserializeObject<RespuestaOrdenCompraDto>(json);

                if (respuesta == null)
                    throw new SiesaApiException(0, "Respuesta inválida del servidor");

                if (respuesta.codigo != 0)
                    throw new SiesaApiException(respuesta.codigo, respuesta.mensaje);

                var pagina = respuesta.detalle?.Table ?? new List<OrdenCompraDto>();

                resultado.AddRange(pagina);

                // Si la página tiene menos registros que el tamaño → no hay más páginas
                if (pagina.Count < tamanoPagina)
                    break;

                paginaActual++;
            }

            return resultado;
        }
    }
}