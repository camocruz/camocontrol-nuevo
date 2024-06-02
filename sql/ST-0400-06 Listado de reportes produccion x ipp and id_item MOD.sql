select *
from $df001$.tb0402_reporte_produccion
    join $df001$.tb0401_items_prog_prod
      on f0401_id_ipp = f0402_id_ipp
    join $df001$.tb0300_items
      on f0401_id_item = f0300_id_item
    join $df001$.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
where substring(f0401_tree_path from 1 for char_length('$001$')) = '$001$' 
      and f0401_anulado = 'N' and f0402_anulado = 'N'
order by f0402_fecha_produccion, f0402_turno