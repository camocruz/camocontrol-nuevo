using System;

namespace App.ApiClient.CS.DTOs.SpecificDtos
{
    public class ItemReferenciaDto
    {
        public DateTime? f120_ts { get; set; }
        public int? f120_id_cia { get; set; }
        public int? f120_id { get; set; }
        public int? f120_rowid { get; set; }
        public string f120_referencia { get; set; }
        public string f120_descripcion { get; set; }

        public DateTime? f124_ts { get; set; }
        public string f124_referencia { get; set; }
    }
}

