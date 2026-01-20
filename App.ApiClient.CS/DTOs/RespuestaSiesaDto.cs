using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApiClient.CS.DTOs
// 1. Crear un DTO genérico para la respuesta
// Esto permite deserializar cualquier tabla de cualquier API SIESA.
{
    public class RespuestaSiesaDto<T>
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }
        public DetalleSiesaDto<T> detalle { get; set; }
    }

    public class DetalleSiesaDto<T>
    {
        public List<T> Table { get; set; }
    }


}
