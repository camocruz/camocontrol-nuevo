SELECT f0317_id_item_sol as id_itsalm, 'SALM-' || f0317_id_sol_alm as id_salm,  
       f0317_id_item as item, f0300_descripcion_item || ' (' || f0002_unidad_medicion || ')' as descripcion,
       f0317_cantidad_solicitada as cantidad, 
       f0317_cantidad_solicitada - f0317_cantidad_entregada as cant_pendiente,
       to_char(f0317_fecha_req_entrega, 'YYYY/MM/DD') as fecha_requerida,
       bod_solicita.f0005_descripcion_bodega as bodega_solicitante,
       bod_entrega.f0005_descripcion_bodega as bodega_entrega
  FROM $df001$.tb0317_solicitudes_almacen_detalle
    left join $df001$.tb0300_items
     on f0317_id_item = f0300_id_item
    left join $df001$.tb0002_unidades_medicion
     on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    left join $df001$.tb0005_bodegas as bod_solicita
     on f0317_bodega_solicita = bod_solicita.f0005_id_bodega
    left join $df001$.tb0005_bodegas as bod_entrega
     on f0317_bodega_entrega = bod_entrega.f0005_id_bodega
  where f0317_anulado = 'N' and f0317_id_cia = '$001$' 
        and f0317_bodega_entrega = '$002$' and f0317_estado = 'A'
  order by f0317_fecha_req_entrega, f0317_id_item_sol 