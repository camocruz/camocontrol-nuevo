using App.ApiClient.CS.DTOs;
using App.ApiClient.CS.DTOs.SpecificDtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace App.ApiClient.CS.Services.SpecificServices
{
    public class ItemsReferenciasApiService
    {
        private readonly SiesaApiServiceBase _base;

        public ItemsReferenciasApiService(SiesaApiServiceBase baseService)
        {
            _base = baseService;
        }

        public Task<List<ItemReferenciaDto>> ObtenerAsync(
            int idCompania,
            string filtro = "",
            int numeroPagina = 1,
            int tamanoPagina = 100,
            CancellationToken cancellationToken = default)
        {
            return _base.ConsultarAsync<ItemReferenciaDto>(
                idCompania,
                descripcion: "API_v2_ItemsReferencias",
                parametros: filtro,
                numeroPagina,
                tamanoPagina,
                cancellationToken
            );
        }
    }

}
