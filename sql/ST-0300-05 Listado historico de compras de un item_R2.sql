SELECT f0305_id_solicitud_compra as id_sc,
      f0305_id_factura_compras as id_fcc,
	  f0305_docto_mov_inventario as id_doc_inv,
      f0305_id_oc as id_oc, 
      to_char(f0305_fr, 'YYYY-MM-DD HH12:MI AM') as fecha,
      --to_char(f0305_costo_unitario_planificado,'LFM999,999,999.00') as c_unit,
      f0305_costo_unitario_planificado as c_unit,
      f0305_cantidad as cantidad,
      --to_char(f0305_costo_unitario_planificado * (1 + f0305_iva),'LFM999,999,999.00') as c_unit_iva,
      f0305_costo_unitario_planificado * (1 + f0305_iva) as c_unit_iva,
      --to_char(f0305_costo_total_planificado,'LFM999,999,999.00') as c_tot,
      f0305_costo_total_planificado as c_tot,
      f0305_iva * 100 || '%' as iva, f0305_descuento * 100 || '%' as descuento,
      f0002_unidad_medicion as unidad,
      f0305_ampliacion_item as ampliacion, f0305_anotacion_item as nota
FROM camocontrol.tb0305_items_solicitados
    join camocontrol.tb0300_items
        on f0300_id_item = f0305_id_item
    join camocontrol.tb0002_unidades_medicion
        on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where f0305_id_item = '35' and f0305_id_cia = '00000001' and (f0305_id_factura_compras is not null or f0305_id_oc is not null)
    order by f0305_fr desc