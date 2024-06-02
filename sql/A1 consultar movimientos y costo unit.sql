SELECT f0309_id_mov_item, f0309_id_item, 
       f0309_id_bodega, f0309_id_documento, f0309_entrada, f0309_salida, 
       f0309_inventario, f0309_costo_unit_entrada, f0309_costo_unit_promedio, f0309_fecha_movimiento, 
       f0309_id_doc_ref, f0309_id_factura_costo, 
       f0309_id_item_solicitud, 
       f0309_id_solicitud_compra, f0309_id_mov_item_correl
  FROM camocontrol.tb0309_items_movimientos
  where f0309_anulado = 'N' and f0309_fecha_movimiento > '2018-01-20'
       and f0309_id_item = 1369 --and f0309_id_bodega = 2 
  order by f0309_fecha_movimiento, f0309_id_mov_item;

UPDATE camocontrol.tb0309_items_movimientos set
       f0309_costo_unit_entrada = 3000
       --f0309_entrada = 1000
where f0309_id_mov_item = 207872

select * from camocontrol.fnc_300_03_recalcular_inventarios_costos_movimientos(
    1369,
    2,
    '2018-01-20',
    '00000001',
    '00000001')