SELECT f0310_id_tipo_documento, f0309_id_item, f0300_id_tipo_item,
       f0309_id_bodega, f0309_id_documento, f0309_entrada, f0309_salida, 
        f0309_costo_tot, f0309_costo_tot_promedio, f0309_costo_tot_estandar, 
       f0309_costo_unit_estandar
  FROM camocontrol.tb0309_items_movimientos
  join camocontrol.tb0310_documentos_movimientos_inventarios
      on f0309_id_documento = f0310_id_documento
  join camocontrol.tb0300_items
      on f0300_id_item = f0309_id_item
  where f0310_id_documento_origen = 'RP-6819'
