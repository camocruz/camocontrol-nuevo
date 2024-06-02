select f0300_id_item, coalesce((select array[f0300_ultimo_costo , 
                                f0300_ultimo_costo]), array[0,0]) as costo_unit
from camocontrol.tb0300_items
order by f0300_id_item
-- retorna un arreglo con el costo unitario