      
-- PASO 1
--Actualizo los costos de los movimientos de items de acuerdo al costo promedio de las compras del mes del movimiento. Datos de compras
WITH otb_costos_compras as (
   SELECT f0305_id_item, to_char(f0307_fecha_factura,'YYYY') as ofecha, AVG(f0305_costo_unitario_planificado) as costo_promedio, avg(f0300_ultimo_costo) as ult_costo
   FROM camocontrol.tb0305_items_solicitados
      JOIN camocontrol.tb0307_facturas_compras
        ON f0307_id_factura_compras = f0305_id_factura_compras
      join camocontrol.tb0300_items
        on f0305_id_item = f0300_id_item 
   WHERE f0305_id_factura_compras IS NOT NULL and f0305_anulado = 'N' and (f0300_id_tipo_item = 1 or f0300_id_tipo_item = 2) -- f0305_id_item = 2152 --
   GROUP BY f0305_id_item, to_char(f0307_fecha_factura,'YYYY')
   ORDER BY f0305_id_item, ofecha
)
update camocontrol.tb0309_items_movimientos set
       f0309_costo_unit_promedio = otb_costos_compras.costo_promedio
from otb_costos_compras
where f0309_id_item = otb_costos_compras.f0305_id_item and f0309_fecha_movimiento > '2017-01-01'
and to_char(f0309_fecha_movimiento,'YYYY') = otb_costos_compras.ofecha
and f0309_anulado = 'N';

