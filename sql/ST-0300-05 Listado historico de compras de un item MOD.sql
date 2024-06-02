SELECT f0305_id_solicitud_compra as id_sc,
      f0305_id_factura_compras as id_fcc,
      f0200_id as nit, f0200_nombres as razon_social,
      f0305_factura_c_aprov as aprobada,
      f0307_doc_entrada as id_doc_inv,
      to_char(f0307_fecha_factura, 'YYYY-MM-DD HH12:MI AM') as fecha_factura,
      --to_char(f0305_costo_unitario_planificado,'LFM999,999,999.00') as c_unit,
      f0305_costo_unitario_planificado as c_unit,
      f0305_cantidad as cantidad,
      --to_char(f0305_costo_unitario_planificado * (1 + f0305_iva),'LFM999,999,999.00') as c_unit_iva,
      f0305_costo_unitario_planificado * (1 + f0305_iva) as c_unit_iva,
      --to_char(f0305_costo_total_planificado,'LFM999,999,999.00') as c_tot,
      f0305_costo_total_planificado as c_tot,
      f0305_iva * 100 || '%' as iva, f0305_descuento * 100 || '%' as descuento,
      f0002_unidad_medicion as unidad,
      f0305_ampliacion_item as ampliacion, f0305_anotacion_item as nota,
      to_char(f0307_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as fecha_aprobacion
FROM $df001$.tb0305_items_solicitados
    join $df001$.tb0300_items
        on f0300_id_item = f0305_id_item
    join $df001$.tb0002_unidades_medicion
        on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join $df001$.tb0307_facturas_compras
        on f0307_id_factura_compras = f0305_id_factura_compras
    join $df001$.tb0200_terceros
       on f0307_id_tercero = f0200_id_tercero
where f0305_id_item = '$001$' and f0305_id_cia = '$002$'
    order by f0307_fecha_factura desc