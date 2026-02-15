using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.ApiClient.CS.DTOs;
using Newtonsoft.Json;

namespace App.ApiClient.CS.Services
{
    public class SiesaApiServiceBase
    {
        private readonly SiesaApiClient _apiClient;

        public SiesaApiServiceBase(SiesaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<T>> ConsultarAsync<T>(
            int idCompania,
            string descripcion,
            string parametros,
            int numeroPagina = 1,
            int tamanoPagina = 100,
            CancellationToken cancellationToken = default)
        {
            var resultado = new List<T>();
            int paginaActual = numeroPagina;

            while (true)
            {
                string paginacion = $"numPag={paginaActual}|tamPag={tamanoPagina}";

                string relativeUrl =
                    $"connekta/siesa/estandar/consulta/v3" +
                    $"?idCompania={idCompania}" +
                    $"&descripcion={descripcion}" +
                    $"&paginacion={paginacion}" +
                    $"&parametros={parametros}";

                string json = await _apiClient.GetAsync(relativeUrl, cancellationToken);

                var respuesta = JsonConvert.DeserializeObject<SiesaResponse<T>>(json);

                if (respuesta == null)
                    throw new Exception("La respuesta de Siesa es NULL");

                if (respuesta.detalle?.Table == null)
                    break;

                var pagina = respuesta.detalle.Table;

                resultado.AddRange(pagina);

                if (pagina.Count < tamanoPagina)
                    break;

                paginaActual++;
            }

            return resultado;
        }
    }
}

//using App.ApiClient.CS.DTOs;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace App.ApiClient.CS.Services
//{
//    public class SiesaApiServiceBase
//    {
//        private readonly SiesaApiClient _apiClient;

//        public SiesaApiServiceBase(SiesaApiClient apiClient)
//        {
//            _apiClient = apiClient;
//        }

//        public async Task<List<T>> ConsultarAsync<T>(
//    int idCompania,
//    string descripcion,
//    string parametros,
//    int numeroPagina,
//    int tamanoPagina,
//    CancellationToken cancellationToken = default)
//        {
//            var resultado = new List<T>();
//            int paginaActual = numeroPagina;

//            while (true)
//            {
//                string paginacion = $"numPag={paginaActual}|tamPag={tamanoPagina}";

//                string relativeUrl =
//                    $"connekta/siesa/estandar/consulta/v3" +
//                    $"?idCompania={idCompania}" +
//                    $"&descripcion={descripcion}" +
//                    $"&paginacion={paginacion}" +
//                    $"&parametros={parametros}";

//                string json = await _apiClient.GetAsync(relativeUrl, cancellationToken);

//                //Console.WriteLine("JSON RECIBIDO:");
//                //Console.WriteLine(json);

//                var respuesta = JsonConvert.DeserializeObject<RespuestaSiesaDto<T>>(json);

//                // 🔥 VALIDACIONES DETALLADAS
//                if (respuesta == null)
//                    throw new Exception("respuesta es NULL");

//                if (respuesta.detalle == null)
//                {
//                    Console.WriteLine("detalle es NULL, creando lista vacía");
//                    return resultado; // no hay datos
//                }

//                if (respuesta.detalle.Table == null)
//                {
//                    Console.WriteLine("detalle.Table es NULL, creando lista vacía");
//                    return resultado; // no hay datos
//                }

//                // 🔥 AQUI NO PUEDE HABER NULL
//                List<T> pagina = respuesta.detalle.Table;

//                if (pagina == null)
//                {
//                    Console.WriteLine("pagina es NULL, creando lista vacía");
//                    pagina = new List<T>();
//                }

//                // 🔥 ESTA LÍNEA YA NO PUEDE FALLAR
//                resultado.AddRange(pagina);

//                if (pagina.Count < tamanoPagina)
//                    break;

//                paginaActual++;
//            }

//            return resultado;
//        }
//    }
//}