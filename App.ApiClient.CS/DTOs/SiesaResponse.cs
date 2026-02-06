using System.Collections.Generic;

namespace App.ApiClient.CS.DTOs
{
    public class SiesaResponse<T>
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }
        public SiesaDetalle<T> detalle { get; set; }
    }

    public class SiesaDetalle<T>
    {
        public List<T> Table { get; set; }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.ApiClient.CS.DTOs
//{
//    public class SiesaResponse
//    {
//        public int codigo { get; set; }
//        public string mensaje { get; set; }
//        public SiesaDetalle detalle { get; set; }
//    }

//    public class SiesaDetalle
//    {
//        public List<ProveedoresSiesaDto> Table { get; set; }
//    }

//}
