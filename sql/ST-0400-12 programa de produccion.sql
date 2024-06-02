SELECT f0401_id_ipp as id_ipp, to_char(f0401_fecha_inicio, 'YYYY-MM-DD') as f_ini,
       to_char(f0401_fecha_final, 'YYYY-MM-DD') as f_fin,
       extract(DOY from f0401_fecha_inicio::date) || to_char(f0401_fecha_inicio, 'MMYYYY') as lote, 
       f0401_id_item as id_producto,
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as producto,
       f0002_unidad_medicion as unidad, round(f0401_cantidad,2) as cantidad, 
       round(f0401_cantidad / f0350_produccion_x_bache,2) as baches,
       f0302_descripcion_tipo_item as tipo
FROM camocontrol.tb0401_items_prog_prod
    join camocontrol.tb0300_items
      on f0401_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
      on f0300_id_tipo_item = f0302_id_tipo_item
    left join camocontrol.tb0350_plantillas
      on f0401_id_item = f0350_id_item and f0350_activa = 'S'
where f0401_anulado = 'N' and f0401_id_cia = '00000001'
      --and array_length(string_to_array(f0401_tree_path, '-'),1)=4 
      and (f0401_fecha_inicio BETWEEN '2017-04-01' AND '2017-04-04' or
           f0401_fecha_final BETWEEN '2017-04-01' AND '2017-04-04')
