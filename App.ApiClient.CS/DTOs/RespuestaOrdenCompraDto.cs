using System.Collections.Generic;

namespace App.ApiClient.CS.DTOs
{
    public class RespuestaOrdenCompraDto
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }
        public DetalleRespuesta detalle { get; set; }
    }

    public class DetalleRespuesta
    {
        public List<OrdenCompraDto> Table { get; set; }
    }
}