SELECT f0309_id_mov_item, f0309_id_documento,f0310_id_documento_origen,
  f0309_entrada,
  f0309_salida,
  f0309_costo_tot / case when f0309_entrada = 0 then f0309_salida else f0309_entrada end as costo_unitario,
  f0309_costo_tot,
  f0309_costo_tot_promedio,
  f0309_costo_tot_estandar,
  f0309_costo_unit_estandar,
  f0309_mes_asignable 
FROM camocontrol.tb0309_items_movimientos
   join camocontrol.tb0310_documentos_movimientos_inventarios
      on f0310_id_documento = f0309_id_documento
WHERE f0309_id_item = 3421
order by f0309_fecha_movimiento