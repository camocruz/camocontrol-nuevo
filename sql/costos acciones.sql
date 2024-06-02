copy (
SELECT f0305_id_item_solicitud, f0305_id_solicitud_compra, 
       f0305_id_accion, replace(replace(f0600_titulo, chr(10),'.  '), chr(13), '') as titulo, f0600_id_accion_principal,
       f0600_nivel_cumplimiento as cumplimiento, f0602_descriptor_tipo as t_accion,
       f0305_id_item, f0300_descripcion_item, 
       replace(replace(f0305_ampliacion_item, chr(10),'.  '), chr(13), '') as ampliacion_item, 
       replace(replace(f0305_anotacion_item, chr(10),'.  '), chr(13), '') as anotacion_compra,
       f0302_descripcion_tipo_item, 
       f0305_cantidad, f0305_cantidad_stock, f0305_cantidad_aprobada, 
       f0305_costo_unitario_planificado, f0305_costo_total_planificado, 
       tb0100_estructura_mantenimiento.f0100_nombre || ' -- { ' || tb0100_estructura_mantenimiento.f0100_codigo || ' }' as descripcion_nombre,
       maquina.f0100_nombre || ' -- { ' || maquina.f0100_codigo || ' }' as descripcion_maquina,
       f0305_iva, f0305_descuento, 
       f0305_id_factura_compras, to_char(f0307_fecha_factura, 'YYYY-MM-DD') as fecha_factura,
       replace(replace(f0200_nombres, chr(10),'.  '), chr(13), '') as proveedor,
       f0307_numero_factura, f0307_aprobada as fact_aprobada, 
       to_char(f0307_fecha_factura, 'YYYY-MM') as mes_factura, f0006_descripcion_c_costo as c_costo
  FROM camocontrol.tb0305_items_solicitados
  join camocontrol.tb0307_facturas_compras
       on f0307_id_factura_compras = f0305_id_factura_compras
  left join camocontrol.tb0600_acciones
       on f0600_id_accion = f0305_id_accion
  left join camocontrol.tb0602_tipos_acciones
       on f0600_id_tipo_accion = f0602_id_tipo_accion
  left join camocontrol.tb0304_solicitud_compra
       on f0304_id_solicitud = f0305_id_solicitud_compra
  join camocontrol.tb0006_centro_costo
       on f0006_id_c_costo = f0304_id_centro_costo
  left join camocontrol.tb0100_estructura_mantenimiento
       on f0304_id_estructura = f0100_id_estructura
  join camocontrol.tb0300_items
       on f0300_id_item = f0305_id_item
  join camocontrol.tb0302_tipos_items
       on f0302_id_tipo_item = f0300_id_tipo_item
  left join camocontrol.tb0100_estructura_mantenimiento as maquina
       on maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
  left join camocontrol.tb0200_terceros
       on f0200_id_tercero = f0307_id_tercero
  --where f0305_factura_c_aprov = 'S'
) to 'C:/dsfc/costos.txt' header csv delimiter '	';