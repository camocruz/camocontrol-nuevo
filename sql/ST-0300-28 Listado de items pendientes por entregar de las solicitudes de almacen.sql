SELECT f0317_id_item_sol as id_itsalm, 'SALM-' || f0317_id_sol_alm as id_salm,  
       f0317_id_item as item, f0300_descripcion_item || ' (' || f0002_unidad_medicion || ')' as descripcion,
       f0317_cantidad_solicitada as cantidad, 
       f0317_cantidad_solicitada - f0317_cantidad_entregada as cant_pendiente,
       to_char(f0317_fecha_req_entrega, 'YYYY/MM/DD') as fecha_requerida
  FROM camocontrol.tb0317_solicitudes_almacen_detalle
    left join camocontrol.tb0300_items
     on f0317_id_item = f0300_id_item
    left join camocontrol.tb0002_unidades_medicion
     on f0300_id_unidad_medicion = f0002_id_unidad_medicion
  where f0317_anulado = 'N' and f0317_id_cia = '00000001' 
        and f0317_bodega_solicita = '4'
        and f0317_bodega_entrega = '2' and f0317_estado = 'A'
  order by f0317_fecha_req_entrega, f0317_id_item_sol 