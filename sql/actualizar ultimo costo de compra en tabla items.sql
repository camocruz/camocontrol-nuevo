update camocontrol.tb0300_items as otb1
set f0300_ultimo_costo = otb_costos.costo_unit,
    f0300_fecha_ultima_factura = otb_costos.f0307_fecha_factura,
    f0300_id_ultima_factura = coalesce(otb_costos.f0307_id_factura_compras,0)
from 
(
with todas_compras as (select f0305_id_item, f0305_costo_unitario_planificado, f0305_iva, f0307_fecha_factura,
                              f0307_id_factura_compras 
                        from camocontrol.tb0305_items_solicitados
                          Join camocontrol.tb0307_facturas_compras
                             on f0305_id_factura_compras = f0307_id_factura_compras
                        where f0305_factura_c_aprov = 'S'
                       )
select f0300_id_item, coalesce((select f0305_costo_unitario_planificado as costo_unit --* (1 + f0305_iva) as costo_unit_iva 
                                from todas_compras 
                                where f0305_id_item = f0300_id_item 
                                order by f0307_fecha_factura desc
                                limit 1
                               ), 0) as costo_unit,
                               (select f0307_fecha_factura 
                                from todas_compras 
                                where f0305_id_item = f0300_id_item 
                                order by f0307_fecha_factura desc
                                limit 1),
                               (select f0307_id_factura_compras 
                                from todas_compras 
                                where f0305_id_item = f0300_id_item 
                                order by f0307_fecha_factura desc
                                limit 1)
from camocontrol.tb0300_items
order by f0300_id_item
) as otb_costos
where otb1.f0300_id_item = otb_costos.f0300_id_item

