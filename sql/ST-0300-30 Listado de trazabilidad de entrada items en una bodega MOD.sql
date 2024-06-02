SELECT f0318_id_documento as id_doc_inv, f0309_entrada as cant_entrada,
       to_char(f0318_fecha_movimiento, 'YYYY/MM/DD HH12:MI AM') as fecha_movimiento, f0318_info_trazable as inf_lote
FROM $df001$.tb0318_trazabilidad_movimientos
JOIN $df001$.tb0309_items_movimientos
  ON f0309_id_mov_item = f0318_id_mov_item AND f0309_entrada > 0 and f0309_anulado = 'N'
where f0318_id_cia = '$001$' and f0318_id_bodega = $002$ and f0318_id_item = $003$
       and f0318_anulado = 'N'
order by f0318_fecha_movimiento desc