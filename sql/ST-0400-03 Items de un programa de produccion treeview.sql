select tb0401_items_prog_prod.*, f0401_id_ipp as id_ipp, f0401_id_item as id_producto,
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as producto,
       f0002_unidad_medicion as unidad, cast(f0401_cantidad as int) as cantidad, f0401_anotacion as nota,
       f0401_cerrado as cerrado
from camocontrol.tb0401_items_prog_prod
    join camocontrol.tb0300_items
      on f0401_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
--where f0401_id_prog_prod = '7'
where substring(f0401_tree_path from 1 for char_length('-7-')) = '-7-' 
      and f0401_anulado = 'N'
order by f0401_id_ipp_padre, f0401_id_ipp