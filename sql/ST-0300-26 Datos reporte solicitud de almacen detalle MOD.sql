SELECT f0317_id_item_sol as id_item_sol, f0317_id_sol_alm as id_solicitud,
       f0317_id_item as id_item, 
       f0300_descripcion_item || ' (' || f0002_unidad_medicion || ')' as descripcion,
       f0317_cantidad_solicitada as cant_solicitada,
       f0005_descripcion_bodega as bodega_entrega,
       f0317_fecha_req_entrega as fecha_requerida
  FROM $df001$.tb0317_solicitudes_almacen_detalle
    left join $df001$.tb0005_bodegas
     on f0317_bodega_entrega = f0005_id_bodega
    left join $df001$.tb0300_items
     on f0317_id_item = f0300_id_item
    left join $df001$.tb0002_unidades_medicion
     on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where f0317_id_cia = '$001$' and f0317_id_sol_alm = '$002$'


