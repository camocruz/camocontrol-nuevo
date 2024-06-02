-- inicializar costos de un item
update camocontrol.tb0300_items set
   f0300_ultimo_costo = 0,
   f0300_id_ultima_factura = 0,
   f0300_costo_promedio = 0,
   f0300_costo_estandar = 0
where f0300_id_item = 2833