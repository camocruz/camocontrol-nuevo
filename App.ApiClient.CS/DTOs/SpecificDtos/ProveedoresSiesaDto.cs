using System;

namespace App.ApiClient.CS.DTOs.SpecificDtos
{
    public class ProveedoresSiesaDto
    {
        public int? f200_id_cia { get; set; }
        public string f200_id { get; set; }
        public string f200_nit { get; set; }

        public string f202_id_sucursal { get; set; }
        public string f202_descripcion_sucursal { get; set; }
        public int? f202_ind_estado { get; set; }
        public string f202_id_moneda { get; set; }

        public string f202_id_clase_proveedor { get; set; }
        public string f202_id_cond_pago { get; set; }

        public int? f202_dias_gracia { get; set; }
        public decimal? f202_cupo_credito { get; set; }

        public string f202_id_tipo_prov { get; set; }
        public int? f202_id_cpto_imp_iva { get; set; }
        public int? f202_id_cpto_imp_rf { get; set; }
        public int? f202_id_cpto_imp_ica { get; set; }

        public string f202_notas { get; set; }

        public DateTime? f202_fecha_ingreso { get; set; }
        public decimal? f202_porcentaje_exceso_compra { get; set; }
        public decimal? f202_monto_anual_compra { get; set; }

        public DateTime? f202_ts { get; set; }

        public decimal? f202_porcentaje_fijo_rete { get; set; }
        public decimal? f202_vlr_prom_salud_ant_ano { get; set; }
        public decimal? f202_vlr_salud_prepagada { get; set; }
        public decimal? f202_vlr_int_vivienda { get; set; }
        public decimal? f202_vlr_dependientes { get; set; }

        public string f202_id_llave_ret_indep { get; set; }

        public int? f200_rowid { get; set; }
    }
}

