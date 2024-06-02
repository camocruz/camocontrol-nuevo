select * from camocontrol.tb0309_items_movimientos
where f0309_id_cia = '00000001' and f0309_id_item = '1375' and f0309_anulado = 'N'
      and f0309_id_bodega = '1' and f0309_fecha_movimiento >= '2015-01-06'
order by f0309_fecha_movimiento asc, f0309_id_mov_item asc;