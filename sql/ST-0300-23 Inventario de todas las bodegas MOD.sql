select f0309_id_item as id_item, 
   f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
   sum(f0309_entrada - f0309_salida) as inventario, f0002_unidad_medicion as unidad,
   f0302_descripcion_tipo_item as tipo_item, f0005_descripcion_bodega as bodega, f0005_cod_bodega as cod_bodega
from $df001$.tb0309_items_movimientos 
   join $df001$.tb0300_items
     on f0309_id_item = f0300_id_item
   join $df001$.tb0302_tipos_items
     on f0300_id_tipo_item = f0302_id_tipo_item
   join $df001$.tb0002_unidades_medicion
     on f0300_id_unidad_medicion = f0002_id_unidad_medicion
   join $df001$.tb0005_bodegas
     on f0309_id_bodega = f0005_id_bodega
where f0309_anulado = 'N' and f0309_id_cia = '$001$' and f0309_fecha_movimiento <= '$002$'
group by f0309_id_item, item, f0302_descripcion_tipo_item, f0002_unidad_medicion,
         f0005_descripcion_bodega, f0005_cod_bodega
order by item