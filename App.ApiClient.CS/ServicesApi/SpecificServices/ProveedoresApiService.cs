using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.ApiClient.CS.DTOs.SpecificDtos;

namespace App.ApiClient.CS.Services.SpecificServices
{
    public class ProveedoresApiService
    {
        private readonly SiesaApiServiceBase _base;

        public ProveedoresApiService(SiesaApiServiceBase baseService)
        {
            _base = baseService;
        }

        public Task<List<ProveedoresSiesaDto>> ObtenerAsync(
            int idCompania,
            string filtro = "",
            int numeroPagina = 1,
            int tamanoPagina = 100,
            CancellationToken cancellationToken = default)
        {
            return _base.ConsultarAsync<ProveedoresSiesaDto>(
                idCompania,
                descripcion: "API_v2_Proveedores",
                parametros: filtro,
                numeroPagina,
                tamanoPagina,
                cancellationToken
            );
        }
    }
}