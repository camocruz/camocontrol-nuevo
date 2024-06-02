select f0305_id_item, f0307_fecha_factura,
coalesce (to_char(f0305_costo_unitario_planificado,'LFM999,999,999.00'), '0') as c_unit_ult_compra,
to_char(f0305_costo_unitario_planificado * (1 + f0305_iva),'LFM999,999,999.00') as c_unit_iva_ult_compra
from camocontrol.tb0305_items_solicitados
   join camocontrol.tb0307_facturas_compras
     on f0305_id_factura_compras = f0307_id_factura_compras
where f0305_id_item = 10 
order by f0307_fecha_factura desc
limit 1



select f0305_id_item,
to_char(f0307_fecha_factura, 'YYYY-MM') as mes
from camocontrol.tb0305_items_solicitados
   join camocontrol.tb0307_facturas_compras
     on f0305_id_factura_compras = f0307_id_factura_compras
where f0305_id_item = 10 and to_char(f0307_fecha_factura, 'YYYY-MM') <= '2015-03'
group by f0305_id_item, mes
order by mes


-- calcular el ultimo costo con IVA de todos los items

with todas_compras as (select f0305_id_item, f0305_costo_unitario_planificado, f0305_iva, f0307_fecha_factura 
                        from camocontrol.tb0305_items_solicitados
                          Join camocontrol.tb0307_facturas_compras
                             on f0305_id_factura_compras = f0307_id_factura_compras
                        where f0305_factura_c_aprov = 'S'
                       )
select f0300_id_item, coalesce((select f0305_costo_unitario_planificado * (1 + f0305_iva) as costo_unit_iva from todas_compras 
                        where f0305_id_item = f0300_id_item 
                        order by f0307_fecha_factura desc
                        limit 1
                       ), 0) as costo_unit_iva
from camocontrol.tb0300_items
order by f0300_id_item


select f0305_id_item, f0305_costo_unitario_planificado, f0305_iva, f0307_fecha_factura 
                        from camocontrol.tb0305_items_solicitados
                          Join camocontrol.tb0307_facturas_compras
                             on f0305_id_factura_compras = f0307_id_factura_compras
where f0305_id_item = 1439 and f0305_factura_c_aprov = 'S'
