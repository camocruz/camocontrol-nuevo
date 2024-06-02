with todas_compras as (select f0305_id_item, f0305_costo_unitario_planificado, f0305_iva, f0307_fecha_factura 
                        from camocontrol.tb0305_items_solicitados
                          Join camocontrol.tb0307_facturas_compras
                             on f0305_id_factura_compras = f0307_id_factura_compras
                        where f0305_factura_c_aprov = 'S'
                       )
select f0300_id_item, coalesce((select array[f0305_costo_unitario_planificado , 
                                f0305_costo_unitario_planificado * (1 + f0305_iva)] as costo_unit
                        from todas_compras 
                        where f0305_id_item = f0300_id_item 
                        order by f0307_fecha_factura desc
                        limit 1
                       ), array[0,0]) as costo_unit
from camocontrol.tb0300_items
order by f0300_id_item
-- retorna un arreglo con el costo unitario y el costo + iva