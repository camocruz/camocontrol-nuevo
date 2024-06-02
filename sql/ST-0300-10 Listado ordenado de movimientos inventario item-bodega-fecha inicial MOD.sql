select * from $df001$.tb0309_items_movimientos
where f0309_id_cia = '$001$' and f0309_id_item = '$002$' and f0309_anulado = 'N'
      and f0309_id_bodega = '$003$' and f0309_fecha_movimiento >= '$004$'
order by f0309_fecha_movimiento asc, f0309_id_mov_item asc;