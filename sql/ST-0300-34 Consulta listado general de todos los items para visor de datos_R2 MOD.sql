SELECT f0300_id_item as id_item,
      f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga,
      f0002_unidad_medicion as unidad,
      f0302_descripcion_tipo_item as tipo_item, f0300_peso_neto as peso_neto, f0300_referencia as referencia_cg,
      f0300_codigo_cguno as codigo_cg,
      array_to_string(array_agg(f0301_ubicacion), ' ', '*') as ubicaciones
FROM $df001$.tb0300_items
    join $df001$.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join $df001$.tb0302_tipos_items
       on f0300_id_tipo_item = f0302_id_tipo_item
    left join camocontrol.tb0301_items_inventario_x_bodega on f0301_id_item = f0300_id_item --and f0301_inventario_actual > 0
    left join camocontrol.tb0005_bodegas on f0005_id_bodega = f0301_id_bodega
where f0300_id_cia = '$001$' and f0300_anulado = 'N'
group by f0300_id_item, f0002_unidad_medicion, f0302_descripcion_tipo_item
order by f0300_descripcion_item
