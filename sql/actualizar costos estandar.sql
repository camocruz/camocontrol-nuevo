WITH otb_costos AS (
  SELECT f0305_id_item, avg(f0305_costo_unitario_planificado) * 1.01 as cost_calc
  FROM camocontrol.tb0305_items_solicitados
  join camocontrol.tb0307_facturas_compras
    on f0307_id_factura_compras = f0305_id_factura_compras
  where f0305_id_factura_compras is not null and f0305_anulado = 'N'
        and f0305_id_cia = '00000001'
        and f0307_fecha_factura > '2017-01-01'
  group by f0305_id_item
  order by f0305_id_item
)

update camocontrol.tb0300_items
  set f0300_costo_estandar = otb_costos.cost_calc
from otb_costos
where otb_costos.f0305_id_item = f0300_id_item