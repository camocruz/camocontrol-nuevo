select id,
(f0300_descripcion_item || ' ( ' || f0300_referencia_empaque || ' )') as producto, 
to_char(sum(ped), 'FM99999999') as ped,
to_char(sum(car), 'FM99999999') as car from
((select f0851_id_item as id,
sum(f0851_cantidad) ped, 0 as car
from camocontrol.tb0851_remisiones_cguno_detalle
     left join camocontrol.tb0850_remisiones_cguno_encabezado
        on f0851_id_rm = f0850_id_rm
where f0850_id_despacho = '1157'
group by f0851_id_item order by f0851_id_item)
union 
(select f0420_id_producto as id, 0 as ped, sum(f0421_unidades_englobadas) as car
from camocontrol.tb0421_etiquetas
   join camocontrol.tb0420_orden_imp_etiquetas
      on f0421_id_impresion = f0420_id_impresion
where f0421_id_despacho = '1157'
group by f0420_id_producto order by f0420_id_producto)) as a
left join camocontrol.tb0300_items
        on id = f0300_id_item
group by id, producto
order by producto
