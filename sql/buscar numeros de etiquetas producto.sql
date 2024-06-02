select f0421_id_etiqueta, f0421_id_despacho 
from camocontrol.tb0421_etiquetas
   join camocontrol.tb0420_orden_imp_etiquetas
     on f0421_id_impresion = f0420_id_impresion
where f0420_id_producto = '2366'
order by f0421_id_etiqueta desc
  