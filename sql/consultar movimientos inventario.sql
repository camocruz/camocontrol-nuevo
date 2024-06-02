SELECT f0309_id_mov_item, f0309_id_cia, f0309_id_mov_docto, f0309_id_item, 
       f0309_id_bodega, f0309_id_documento, f0309_entrada, f0309_salida, 
       f0309_inventario, f0309_teorico, f0309_id_clasificador, f0309_fecha_movimiento, 
       f0309_fm, f0309_fr, f0309_usuario_crear, f0309_usuario_modificar, 
       f0309_anulado, f0309_usuario_anular
  FROM camocontrol.tb0309_items_movimientos
where f0309_id_item = 35 and f0309_id_bodega = 1 and f0309_anulado = 'N'
order by f0309_fecha_movimiento asc, f0309_id_mov_item asc
