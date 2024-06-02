SELECT f0309_id_documento as id_doc_inv, f0310_documento_contabilidad as docto_cg, f0310_id_documento_origen as docto_origen,
       f0309_entrada as entrada, f0309_salida as salida, 
       f0309_inventario as inventario, f0312_clasificador as clasificador, to_char(f0309_fecha_movimiento, 'YYYY-MM-DD HH12:MI:ss AM') as fecha
  FROM $df001$.tb0309_items_movimientos
  join $df001$.tb0310_documentos_movimientos_inventarios
     on f0309_id_documento = f0310_id_documento
  left join $df001$.tb0312_clasificadores_movimientos
     on f0309_id_clasificador = f0312_id_clasificador
where f0309_id_cia = '$001$' and f0309_id_item = '$002$' and f0309_id_bodega = '$003$' and f0309_anulado = 'N'
order by f0309_fecha_movimiento asc, f0309_id_mov_item asc
