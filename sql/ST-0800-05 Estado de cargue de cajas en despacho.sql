select f0300_id_item as id,
(f0300_descripcion_item || ' ( ' || f0300_referencia_empaque || ' )') as producto, 
to_char(sum(f0851_cantidad), 'FM99999999.0') as ped, coalesce(to_char(sum(cargado.cant), 'FM99999999.0'),'0') as car
from camocontrol.tb0851_remisiones_cguno_detalle
     join camocontrol.tb0300_items
        on f0851_id_item = f0300_id_item
     join camocontrol.tb0850_remisiones_cguno_encabezado
        on f0851_id_rm = f0850_id_rm
     left join (
            select f0421_id_despacho, f0420_id_producto, count(f0420_id_producto) as cant
            from camocontrol.tb0421_etiquetas
               left join camocontrol.tb0420_orden_imp_etiquetas
                 on f0421_id_impresion = f0420_id_impresion
            where f0421_id_despacho = '987'
            group by f0421_id_despacho, f0420_id_producto
           ) as cargado
        on f0850_id_despacho = f0421_id_despacho and f0851_id_item = f0420_id_producto
where f0850_id_despacho = '987'
group by f0300_id_item, producto, cargado.cant order by producto

