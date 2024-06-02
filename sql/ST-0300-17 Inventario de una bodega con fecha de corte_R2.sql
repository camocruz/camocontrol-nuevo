select f0309_id_item as id_item, f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
   sum(f0309_entrada - f0309_salida) as inv_item, f0002_unidad_medicion as unidad,
   f0302_descripcion_tipo_item as tipo_item
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0300_items
      on f0309_id_item = f0300_id_item
   join camocontrol.tb0302_tipos_items
     on f0300_id_tipo_item = f0302_id_tipo_item
   join camocontrol.tb0002_unidades_medicion
     on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where f0309_id_cia = '00000001' and f0309_id_bodega = '01' and f0309_anulado = 'N' and f0309_fecha_movimiento <= '2016-06-27'
group by f0309_id_item, item, unidad, tipo_item
order by item