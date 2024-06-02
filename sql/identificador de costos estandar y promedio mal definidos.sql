SELECT f0300_id_item, f0300_descripcion_item, f0300_costo_promedio, 
       f0300_costo_estandar, (f0300_costo_promedio/f0300_costo_estandar) * 100 as rel_prom_est,
       f0300_ultimo_costo, (f0300_ultimo_costo/f0300_costo_promedio) * 100 as ult_costo
  FROM camocontrol.tb0300_items
  where f0300_costo_estandar > 0 and (f0300_id_tipo_item = 1 or f0300_id_tipo_item = 2)
order by (f0300_ultimo_costo/f0300_costo_promedio);


update camocontrol.tb0300_items set f0300_costo_promedio = 6538 where f0300_id_item = 7124;
update camocontrol.tb0300_items set f0300_costo_promedio = 40000 where f0300_id_item = 4171;
update camocontrol.tb0300_items set f0300_costo_estandar = 1127 where f0300_id_item = 2208;
update camocontrol.tb0300_items set f0300_costo_promedio = 3950 where f0300_id_item = 7123;
update camocontrol.tb0300_items set f0300_costo_estandar = 1939 where f0300_id_item = 1478;
update camocontrol.tb0300_items set f0300_costo_promedio = 115 where f0300_id_item = 6718;
update camocontrol.tb0300_items set f0300_costo_estandar = 120 where f0300_id_item = 6718;
update camocontrol.tb0300_items set f0300_costo_promedio = 125 where f0300_id_item = 6717;
update camocontrol.tb0300_items set f0300_costo_estandar = 126 where f0300_id_item = 6717;
update camocontrol.tb0300_items set f0300_costo_estandar = 2184 where f0300_id_item = 1867;
update camocontrol.tb0300_items set f0300_costo_estandar = 62620 where f0300_id_item = 1695;
update camocontrol.tb0300_items set f0300_costo_estandar = 3464 where f0300_id_item = 1439;
update camocontrol.tb0300_items set f0300_ultimo_costo = 125 where f0300_id_item = 6717;
update camocontrol.tb0300_items set f0300_ultimo_costo = 126 where f0300_id_item = 1983;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 126,
   f0305_cantidad = f0305_costo_total_planificado / 126   
where f0305_id_item_solicitud = 34125;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 126,
   f0305_cantidad = f0305_costo_total_planificado / 126   
where f0305_id_item_solicitud = 32857;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 1276,
   f0305_cantidad = f0305_costo_total_planificado / 1276   
where f0305_id_item_solicitud = 25381;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 1920,
   f0305_cantidad = f0305_costo_total_planificado / 1920   
where f0305_id_item_solicitud = 29194;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 115,
   f0305_cantidad = f0305_costo_total_planificado / 115   
where f0305_id_item_solicitud = 33961;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 125,
   f0305_cantidad = f0305_costo_total_planificado / 125   
where f0305_id_item_solicitud = 33960;

update camocontrol.tb0305_items_solicitados set
   f0305_costo_unitario_planificado = 2163,
   f0305_cantidad = f0305_costo_total_planificado / 2163   
where f0305_id_item_solicitud = 31837;