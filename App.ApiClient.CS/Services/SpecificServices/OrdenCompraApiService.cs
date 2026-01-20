using App.ApiClient.CS.DTOs.SpecificDtos;
using App.ApiClient.CS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.ApiClient.CS.Services.SpecificServices
// 1. Crear el Dto que almacena los datos.

// 2. Plantilla del Servicio Base Genérico
//    (Este se crea una sola vez en todo el proyecto) Ya esta creado.

// 3. Plantilla del Servicio Específico
//    (Cada nueva API necesita esta clase)

// 4. Plantilla de la Interfaz del Servicio Específico
//    (Cada nueva API necesita esta clase)
{
    public class OrdenCompraApiService : IOrdenCompraApiService
    {
        private readonly SiesaApiServiceBase _base;

        public OrdenCompraApiService(SiesaApiServiceBase baseService)
        {
            _base = baseService;
        }

        public async Task<List<OrdenCompraDto>> ObtenerOrdenesCompraAsync(
     int idCompania,
     string filtro,
     int numeroPagina = 1,
     int tamanoPagina = 100,
     CancellationToken cancellationToken = default)
        {
            try
            {
                return await _base.ConsultarAsync<OrdenCompraDto>(
                    idCompania,
                    descripcion: "API_v2_Compras_Ordenes",
                    parametros: filtro,
                    numeroPagina,
                    tamanoPagina,
                    cancellationToken
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR EN SERVICIO ESPECÍFICO: " + ex.ToString());
                throw;
            }
        }
    }
}
