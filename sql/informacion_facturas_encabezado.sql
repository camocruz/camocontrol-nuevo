copy(
SELECT f0852_id_factura, f0852_factura, f0852_remision, 
       f0852_fecha_documento, f0852_subtotal_factura, f0852_descuento_factura,
       round(case when f0852_total_factura <> 0 then f0852_descuento_factura/f0852_total_factura * 100
       else 0 end, 1) as porc_decuento,
       f0852_iva_factura, f0852_total_factura, f0852_anulada_cg,
       f0850_nombre_vendedor, f0850_id_despacho,
       substring(f0852_fecha_documento from 1 for 4) as año,
       substring(f0852_fecha_documento from 6 for 2) as mes,
       f0200_nombres as razon_social, f0200_id as nit
FROM camocontrol.tb0852_facturas_cguno_encabezado
   left join camocontrol.tb0850_remisiones_cguno_encabezado
      on f0852_remision = f0850_rm and f0850_anulado = 'N'
   left join camocontrol.tb0800_despachos_comercial
      on f0850_id_despacho = f0800_id_despacho
   left join camocontrol.tb0200_terceros
      on f0800_cliente = f0200_id_tercero
) to 'C:/dsfc/enc_facturas.txt' DELIMITER '|' csv header;

copy(
SELECT f0853_id_fact_det, f0853_id_factura, f0853_id_cia, f0853_referencia_1, 
       f0853_referencia_2, f0853_descripcion, f0853_cantidad, f0853_subtotal_producto, 
       f0853_descuento_producto, f0853_iva_producto, f0853_total_producto,
       round(case when f0853_total_producto <> 0 then f0853_descuento_producto/f0853_total_producto * 100
       else 0 end , 1) as porc_decuento, round(f0853_total_producto/f0853_cantidad,0) as valor_unit_final,
       f0853_id_item, f0852_factura, f0850_nombre_vendedor, f0850_id_despacho,
       substring(f0852_fecha_documento from 1 for 4) as año,
       substring(f0852_fecha_documento from 6 for 2) as mes,
       f0200_nombres as razon_social, f0200_id as nit
  FROM camocontrol.tb0853_facturas_cguno_detalle
    LEFT JOIN camocontrol.tb0852_facturas_cguno_encabezado
      ON f0853_id_factura = f0852_id_factura
    left join camocontrol.tb0850_remisiones_cguno_encabezado
      on f0852_remision = f0850_rm and f0850_anulado = 'N'
   left join camocontrol.tb0800_despachos_comercial
      on f0850_id_despacho = f0800_id_despacho
   left join camocontrol.tb0200_terceros
      on f0800_cliente = f0200_id_tercero
) to 'C:/dsfc/det_facturas.txt' DELIMITER '|' csv header;

