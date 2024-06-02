--copy(
SELECT f0307_id_factura_compras as id_fcc, f0307_numero_factura as fac_num, to_char(f0307_fecha_factura, 'YYYY-MM-DD') as fecha_factura, 
       to_char(f0307_fecha_factura, 'YYYY') as ano_factura, to_char(f0307_fecha_factura, 'MM') as mes_factura,
       f0200_id as nit, f0200_nombres as razon_social,
       f0305_id_solicitud_compra as id_sc, f0305_id_item_solicitud as item_sc,

       f0302_descripcion_tipo_item as tipo_item, 
       f0305_id_item as id_item, f0300_descripcion_item as item, 

       f0305_cantidad as cantidad, f0002_unidad_medicion as unidad,
       'OC-' || f0305_id_oc as id_oc,
       f0305_docto_mov_inventario as id_doc_inv, 
       to_char(f0318_fecha_movimiento, 'YYYY-MM-DD') as fecha_mov, f0318_info_trazable as lote
  FROM camocontrol.tb0305_items_solicitados
    join camocontrol.tb0304_solicitud_compra
       on f0305_id_solicitud_compra = f0304_id_solicitud
    join camocontrol.tb0307_facturas_compras
       on f0305_id_factura_compras = f0307_id_factura_compras
    join camocontrol.tb0200_terceros
       on f0307_id_tercero = f0200_id_tercero
    join camocontrol.tb0300_items
       on f0305_id_item = f0300_id_item
    join camocontrol.tb0302_tipos_items
       on f0300_id_tipo_item = f0302_id_tipo_item
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    left join camocontrol.tb0318_trazabilidad_movimientos
       on f0318_id_documento = f0305_docto_mov_inventario and f0318_anulado = 'N'
where f0307_id_factura_compras is not null
    and (f0300_id_tipo_item = 1 or f0300_id_tipo_item = 2)
    and f0305_id_cia = '00000001'
    and f0307_fecha_factura BETWEEN '2018-06-01' and '2018-07-01'
-- ) to 'S:/dsfc/rh_asistencia/inf_comp.txt' WITH DELIMITER '|' CSV HEADER;