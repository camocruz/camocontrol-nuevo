using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.ApiClient.CS.DTOs.SpecificDtos;

namespace App.ApiClient.CS.Interfaces
{
    public interface IOrdenCompraApiService
    {
        Task<List<OrdenCompraDto>> ObtenerOrdenesCompraAsync(
            int idCompania,
            string filtro,
            int numeroPagina = 1,
            int tamanoPagina = 100,
            CancellationToken cancellationToken = default);
    }
}