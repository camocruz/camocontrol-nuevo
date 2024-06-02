SELECT 
      f0300_id_item as id_item,
      f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga,
      f0002_unidad_medicion as unidad,
      f0302_descripcion_tipo_item as tipo_item, f0300_peso_neto as peso_neto, f0300_referencia as referencia_cg,
      f0300_codigo_cguno as codigo_cg
FROM camocontrol.tb0300_items
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
       on f0300_id_tipo_item = f0302_id_tipo_item
where f0300_id_cia = '00000001' and f0300_anulado = 'N'
order by f0300_descripcion_item
