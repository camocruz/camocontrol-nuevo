using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.ApiClient.CS.DTOs;

namespace App.ApiClient.CS.Interfaces
{
    public interface IOrdenCompraApiService
    {
        Task<List<OrdenCompraDto>> ObtenerOrdenesCompraAsync(
            int idCompania,
            int numeroPagina,
            int tamanoPagina,
            int rowidMinimo,
            CancellationToken cancellationToken = default);
    }
}