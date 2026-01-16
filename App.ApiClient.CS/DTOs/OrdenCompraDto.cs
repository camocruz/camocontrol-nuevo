using System;

namespace App.ApiClient.CS.DTOs
{
    public class OrdenCompraDto
    {
        public string f420_ts { get; set; }
        public int f420_rowid { get; set; }
        public int f420_id_cia { get; set; }
        public string f420_id_co { get; set; }
        public string f420_id_tipo_docto { get; set; }
        public int f420_consec_docto { get; set; }
        public string f420_fecha { get; set; }
        public int f420_id_clase_docto { get; set; }
        public string f420_desc_clase_docto { get; set; }
        public int f420_ind_estado { get; set; }
        public string f420_desc_estado { get; set; }
        public int f420_ind_impresion { get; set; }
        public int f420_nro_impresiones { get; set; }

        public string f200_id_comprador { get; set; }
        public string f200_nit_comprador { get; set; }
        public string f200_razon_social_comprador { get; set; }
        public string f202_id_sucursal_comprador { get; set; }
        public string f202_descripcion_sucursal_comprador { get; set; }

        public string f200_id_prov { get; set; }
        public string f200_nit_prov { get; set; }
        public string f200_razon_social_prov { get; set; }
        public string f202_id_sucursal_prov { get; set; }
        public string f202_descripcion_sucursal_prov { get; set; }

        public string f420_id_cond_pago { get; set; }
        public int f420_ind_tasa { get; set; }
        public string f420_id_moneda_docto { get; set; }
        public string f420_id_moneda_conv { get; set; }
        public decimal f420_tasa_conv { get; set; }
        public string f420_id_moneda_local { get; set; }
        public decimal f420_tasa_local { get; set; }
        public decimal f420_tasa_dscto_global1 { get; set; }
        public decimal f420_tasa_dscto_global2 { get; set; }

        public string f420_fecha_ts_creacion { get; set; }
        public string f420_fecha_ts_actualizacion { get; set; }
        public string f420_fecha_ts_anulacion { get; set; }
        public string f420_fecha_ts_aprobacion { get; set; }
        public string f420_fecha_ts_parcial { get; set; }
        public string f420_fecha_ts_cumplido { get; set; }

        public string f420_usuario_creacion { get; set; }
        public string f420_usuario_actualizacion { get; set; }
        public string f420_usuario_anulacion { get; set; }
        public string f420_usuario_aprobacion { get; set; }
        public string f420_usuario_parcial { get; set; }
        public string f420_usuario_cumplido { get; set; }

        public string f420_notas { get; set; }
        public string f420_num_docto_referencia { get; set; }

        public int f120_id { get; set; }
        public string f120_referencia { get; set; }
        public string f120_descripcion { get; set; }
        public string f121_id_ext1_detalle { get; set; }
        public string f121_id_ext2_detalle { get; set; }

        public string f150_id { get; set; }
        public string f150_descripcion { get; set; }

        // DETALLE (f421_...)
        public string f421_ts { get; set; }
        public int f421_rowid { get; set; }
        public int f421_id_cia { get; set; }
        public string f421_fecha { get; set; }
        public int f421_id_concepto { get; set; }
        public string f421_id_motivo { get; set; }
        public int f421_ind_obsequio { get; set; }
        public string f421_id_co_movto { get; set; }
        public string f421_id_ccosto { get; set; }
        public string f421_desc_ccosto { get; set; }
        public string f421_id_unidad_medida { get; set; }
        public decimal f421_factor { get; set; }
        public decimal f421_cant_pedida { get; set; }
        public decimal f421_cant_entrada { get; set; }
        public decimal f421_cant_pedida_base { get; set; }
        public decimal f421_cant_entrada_base { get; set; }
        public string f421_fecha_entrega { get; set; }
        public int f421_ind_estado { get; set; }
        public string f421_cod_item_prov { get; set; }
        public decimal f421_precio_unitario { get; set; }
        public string f421_notas { get; set; }
        public string f421_detalle { get; set; }
        public string f421_id_un_movto { get; set; }
        public decimal f421_vlr_bruto { get; set; }
        public decimal f421_vlr_dscto_linea { get; set; }
        public decimal f421_vlr_dscto_global { get; set; }
        public decimal f421_vlr_imp { get; set; }
        public decimal f421_vlr_neto { get; set; }
        public string f421_hora_entrega { get; set; }
        public decimal f421_cant_importacion { get; set; }
        public decimal f421_cant_importacion_base { get; set; }
        public decimal f421_cant_contrato_oc { get; set; }
        public decimal f421_cant_contrato_oc_base { get; set; }
        public decimal f421_valor_acum_entrada { get; set; }
        public decimal f421_precio_unitario_min { get; set; }
        public decimal f421_precio_unitario_max { get; set; }
    }
}