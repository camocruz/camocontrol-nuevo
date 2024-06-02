select f0301_id_bodega as id, f0301_inventario_actual as inventario,
   f0301_inventario_min as inv_min, 
   f0301_inventario_max as inv_max, f0301_consumo_diario as consumo_dia,
   f0005_descripcion_bodega as bodega, f0005_cod_bodega as cod_bodega,
   f0301_ubicacion as ubicacion
from $df001$.tb0301_items_inventario_x_bodega
  join $df001$.tb0005_bodegas
     on f0301_id_bodega = f0005_id_bodega
where f0301_id_cia = '$001$' and f0301_id_item = '$002$'