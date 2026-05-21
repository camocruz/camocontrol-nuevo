using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.ApiClient.CS.Helpers.Commons;

namespace App.ApiClient.CS.DTOs.SpecificDtos
{
    public class OrdenCompraDto
    {
        // ============================
        // ENCABEZADO DE ORDEN
        // ============================

        [ColumnIgnore]
        public int? f420_rowid { get; set; }

        [ColumnOrder(1)]
        [DisplayName("Compañía")]
        public int? f420_id_cia { get; set; }

        [ColumnIgnore]
        public string f420_id_co { get; set; }

        [ColumnOrder(4)]
        [DisplayName("TipoDocumento")]
        public string f420_id_tipo_docto { get; set; }

        [ColumnOrder(5)]
        [DisplayName("Consecutivo")]
        public int? f420_consec_docto { get; set; }

        [ColumnOrder(6)]
        [DisplayName("FechaOrden")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? f420_fecha { get; set; }

        [ColumnIgnore]
        public int? f420_id_clase_docto { get; set; }

        [ColumnIgnore]
        public string f420_desc_clase_docto { get; set; }

        [ColumnOrder(9)]
        [DisplayName("Estado")]
        public string f420_desc_estado { get; set; }

        [ColumnIgnore]
        public int? f420_ind_estado { get; set; }

        [ColumnIgnore]
        public int? f420_ind_impresion { get; set; }

        [ColumnIgnore]
        public int? f420_nro_impresiones { get; set; }


        // ============================
        // COMPRADOR
        // ============================

        [ColumnIgnore]
        public int? f200_id_comprador { get; set; }

        [ColumnIgnore]
        public string f200_nit_comprador { get; set; }

        [ColumnOrder(12)]
        [DisplayName("Comprador")]
        public string f200_razon_social_comprador { get; set; }

        [ColumnIgnore]
        public string f202_id_sucursal_comprador { get; set; }

        [ColumnIgnore]
        public string f202_descripcion_sucursal_comprador { get; set; }


        // ============================
        // PROVEEDOR
        // ============================

        [ColumnIgnore]
        public string f200_id_prov { get; set; }

        [ColumnOrder(16)]
        [DisplayName("NIT_Proveedor")]
        public string f200_nit_prov { get; set; }

        [ColumnOrder(17)]
        [DisplayName("RazónSocialProveedor")]
        public string f200_razon_social_prov { get; set; }

        [ColumnOrder(18)]
        [DisplayName("SucursalProveedor")]
        public string f202_id_sucursal_prov { get; set; }

        [ColumnIgnore]
        public string f202_descripcion_sucursal_prov { get; set; }


        // ============================
        // MONEDA Y TASAS
        // ============================

        [ColumnOrder(20)]
        [DisplayName("Condición_de_Pago")]
        public string f420_id_cond_pago { get; set; }

        [ColumnOrder(21)]
        [DisplayName("MonedaDocumento")]
        public string f420_id_moneda_docto { get; set; }

        [ColumnIgnore]
        public string f420_id_moneda_conv { get; set; }

        [ColumnIgnore]
        public decimal? f420_tasa_conv { get; set; }

        [ColumnIgnore]
        public string f420_id_moneda_local { get; set; }

        [ColumnIgnore]
        public decimal? f420_tasa_local { get; set; }

        [ColumnIgnore]
        public int? f420_ind_tasa { get; set; }

        [ColumnIgnore]
        public decimal? f420_tasa_dscto_global1 { get; set; }

        [ColumnIgnore]
        public decimal? f420_tasa_dscto_global2 { get; set; }


        // ============================
        // FECHAS DE PROCESO
        // ============================

        [ColumnIgnore]
        public DateTime? f420_ts { get; set; }

        [ColumnIgnore]
        public DateTime? f420_fecha_ts_creacion { get; set; }

        [ColumnIgnore]
        public DateTime? f420_fecha_ts_actualizacion { get; set; }

        [ColumnIgnore]
        public DateTime? f420_fecha_ts_anulacion { get; set; }

        [ColumnIgnore]
        public DateTime? f420_fecha_ts_aprobacion { get; set; }

        [ColumnIgnore]
        public DateTime? f420_fecha_ts_parcial { get; set; }

        [ColumnIgnore]
        public DateTime? f420_fecha_ts_cumplido { get; set; }


        // ============================
        // USUARIOS
        // ============================

        [ColumnIgnore]
        public string f420_usuario_creacion { get; set; }

        [ColumnIgnore]
        public string f420_usuario_actualizacion { get; set; }

        [ColumnIgnore]
        public string f420_usuario_anulacion { get; set; }

        [ColumnIgnore]
        public string f420_usuario_aprobacion { get; set; }

        [ColumnIgnore]
        public string f420_usuario_parcial { get; set; }

        [ColumnIgnore]
        public string f420_usuario_cumplido { get; set; }


        // ============================
        // OTROS CAMPOS ENCABEZADO
        // ============================

        [ColumnOrder(26)]
        [DisplayName("Notas")]
        public string f420_notas { get; set; }

        [ColumnOrder(27)]
        [DisplayName("DocumentoReferencia")]
        public string f420_num_docto_referencia { get; set; }


        // ============================
        // ITEM / PRODUCTO
        // ============================

        [ColumnIgnore]
        [DisplayName("ID_Producto")]
        public int? f120_id { get; set; }

        [ColumnOrder(29)]
        [DisplayName("Referencia")]
        public string f120_referencia { get; set; }

        [ColumnOrder(30)]
        [DisplayName("DescripciónProducto")]
        public string f120_descripcion { get; set; }

        [ColumnIgnore]
        public string f121_id_ext1_detalle { get; set; }

        [ColumnIgnore]
        public string f121_id_ext2_detalle { get; set; }


        // ============================
        // LÍNEA / DETALLE
        // ============================

        [ColumnOrder(31)]
        [DisplayName("FechaEntrega")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? f421_fecha_entrega { get; set; }

        [ColumnOrder(32)]
        [DisplayName("CantidadPedida")]
        public decimal? f421_cant_pedida { get; set; }

        [ColumnOrder(33)]
        [DisplayName("CantidadEntrada")]
        public decimal? f421_cant_entrada { get; set; }

        [ColumnOrder(34)]
        [DisplayName("PrecioUnitario")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? f421_precio_unitario { get; set; }

        [ColumnOrder(35)]
        [DisplayName("ValorNeto")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? f421_vlr_neto { get; set; }

        [ColumnOrder(36)]
        [DisplayName("NotasDetalle")]
        public string f421_notas { get; set; }

        // Campos técnicos del detalle
        [ColumnIgnore] public DateTime? f421_ts { get; set; }
        [ColumnIgnore] public int? f421_rowid { get; set; }
        [ColumnIgnore] public int? f421_id_cia { get; set; }
        [ColumnIgnore] public DateTime? f421_fecha { get; set; }
        [ColumnIgnore] public int? f421_id_concepto { get; set; }
        [ColumnIgnore] public string f421_id_motivo { get; set; }
        [ColumnIgnore] public int? f421_ind_obsequio { get; set; }
        [ColumnIgnore] public string f421_id_co_movto { get; set; }
        [ColumnIgnore] public string f421_id_ccosto { get; set; }
        [ColumnIgnore] public string f421_desc_ccosto { get; set; }
        [ColumnIgnore] public string f421_id_unidad_medida { get; set; }
        [ColumnIgnore] public decimal? f421_factor { get; set; }
        [ColumnIgnore] public decimal? f421_cant_pedida_base { get; set; }
        [ColumnIgnore] public decimal? f421_cant_entrada_base { get; set; }
        [ColumnIgnore] public int? f421_ind_estado { get; set; }
        [ColumnIgnore] public string f421_cod_item_prov { get; set; }
        [ColumnIgnore] public string f421_detalle { get; set; }
        [ColumnIgnore] public string f421_id_un_movto { get; set; }
        [ColumnIgnore] public decimal? f421_vlr_bruto { get; set; }
        [ColumnIgnore] public decimal? f421_vlr_dscto_linea { get; set; }
        [ColumnIgnore] public decimal? f421_vlr_dscto_global { get; set; }
        [ColumnIgnore] public decimal? f421_vlr_imp { get; set; }
        [ColumnIgnore] public DateTime? f421_hora_entrega { get; set; }
        [ColumnIgnore] public decimal? f421_cant_importacion { get; set; }
        [ColumnIgnore] public decimal? f421_cant_importacion_base { get; set; }
        [ColumnIgnore] public decimal? f421_cant_contrato_oc { get; set; }
        [ColumnIgnore] public decimal? f421_cant_contrato_oc_base { get; set; }
        [ColumnIgnore] public decimal? f421_valor_acum_entrada { get; set; }
        [ColumnIgnore] public decimal? f421_precio_unitario_min { get; set; }
        [ColumnIgnore] public decimal? f421_precio_unitario_max { get; set; }
    }
}


//using System;

//namespace App.ApiClient.CS.DTOs.SpecificDtos
//{
//    public class OrdenCompraDto
//    {
//        public DateTime? f420_ts { get; set; }
//        public int? f420_rowid { get; set; }
//        public int? f420_id_cia { get; set; }
//        public string f420_id_co { get; set; }
//        public string f420_id_tipo_docto { get; set; }
//        public int? f420_consec_docto { get; set; }
//        public DateTime? f420_fecha { get; set; }
//        public int? f420_id_clase_docto { get; set; }
//        public string f420_desc_clase_docto { get; set; }
//        public int? f420_ind_estado { get; set; }
//        public string f420_desc_estado { get; set; }
//        public int? f420_ind_impresion { get; set; }
//        public int? f420_nro_impresiones { get; set; }

//        public int? f200_id_comprador { get; set; }
//        public string f200_nit_comprador { get; set; }
//        public string f200_razon_social_comprador { get; set; }
//        public string f202_id_sucursal_comprador { get; set; }
//        public string f202_descripcion_sucursal_comprador { get; set; }

//        public string f200_id_prov { get; set; }
//        public string f200_nit_prov { get; set; }
//        public string f200_razon_social_prov { get; set; }
//        public string f202_id_sucursal_prov { get; set; }
//        public string f202_descripcion_sucursal_prov { get; set; }

//        public string f420_id_cond_pago { get; set; }
//        public int? f420_ind_tasa { get; set; }
//        public string f420_id_moneda_docto { get; set; }
//        public string f420_id_moneda_conv { get; set; }
//        public decimal? f420_tasa_conv { get; set; }
//        public string f420_id_moneda_local { get; set; }
//        public decimal? f420_tasa_local { get; set; }
//        public decimal? f420_tasa_dscto_global1 { get; set; }
//        public decimal? f420_tasa_dscto_global2 { get; set; }

//        public DateTime? f420_fecha_ts_creacion { get; set; }
//        public DateTime? f420_fecha_ts_actualizacion { get; set; }
//        public DateTime? f420_fecha_ts_anulacion { get; set; }
//        public DateTime? f420_fecha_ts_aprobacion { get; set; }
//        public DateTime? f420_fecha_ts_parcial { get; set; }
//        public DateTime? f420_fecha_ts_cumplido { get; set; }

//        public string f420_usuario_creacion { get; set; }
//        public string f420_usuario_actualizacion { get; set; }
//        public string f420_usuario_anulacion { get; set; }
//        public string f420_usuario_aprobacion { get; set; }
//        public string f420_usuario_parcial { get; set; }
//        public string f420_usuario_cumplido { get; set; }

//        public string f420_notas { get; set; }
//        public string f420_num_docto_referencia { get; set; }

//        public int? f120_id { get; set; }
//        public string f120_referencia { get; set; }
//        public string f120_descripcion { get; set; }
//        public string f121_id_ext1_detalle { get; set; }
//        public string f121_id_ext2_detalle { get; set; }

//        public string f150_id { get; set; }
//        public string f150_descripcion { get; set; }

//        public DateTime? f421_ts { get; set; }
//        public int? f421_rowid { get; set; }
//        public int? f421_id_cia { get; set; }
//        public DateTime? f421_fecha { get; set; }
//        public int? f421_id_concepto { get; set; }
//        public string f421_id_motivo { get; set; }
//        public int? f421_ind_obsequio { get; set; }
//        public string f421_id_co_movto { get; set; }
//        public string f421_id_ccosto { get; set; }
//        public string f421_desc_ccosto { get; set; }
//        public string f421_id_unidad_medida { get; set; }
//        public decimal? f421_factor { get; set; }
//        public decimal? f421_cant_pedida { get; set; }
//        public decimal? f421_cant_entrada { get; set; }
//        public decimal? f421_cant_pedida_base { get; set; }
//        public decimal? f421_cant_entrada_base { get; set; }
//        public DateTime? f421_fecha_entrega { get; set; }
//        public int? f421_ind_estado { get; set; }
//        public string f421_cod_item_prov { get; set; }
//        public decimal? f421_precio_unitario { get; set; }
//        public string f421_notas { get; set; }
//        public string f421_detalle { get; set; }
//        public string f421_id_un_movto { get; set; }
//        public decimal? f421_vlr_bruto { get; set; }
//        public decimal? f421_vlr_dscto_linea { get; set; }
//        public decimal? f421_vlr_dscto_global { get; set; }
//        public decimal? f421_vlr_imp { get; set; }
//        public decimal? f421_vlr_neto { get; set; }
//        public DateTime? f421_hora_entrega { get; set; }
//        public decimal? f421_cant_importacion { get; set; }
//        public decimal? f421_cant_importacion_base { get; set; }
//        public decimal? f421_cant_contrato_oc { get; set; }
//        public decimal? f421_cant_contrato_oc_base { get; set; }
//        public decimal? f421_valor_acum_entrada { get; set; }
//        public decimal? f421_precio_unitario_min { get; set; }
//        public decimal? f421_precio_unitario_max { get; set; }
//    }
//}