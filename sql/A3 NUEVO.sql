-- Paso 1: inserto los productos y semiproductos en una tabla que tenga dichos items en cada mes.

with otb_item_mes as (
select t0001_mes, f0350_id_item, f0300_costo_estandar
from camocontrol.tb0350_plantillas
   join camocontrol.zotb_meses
      on t0001_id_cia = f0350_id_cia
   join camocontrol.tb0300_items
      on f0300_id_item = f0350_id_item
where f0350_anulado = 'N' and f0350_activa = 'S'
)
insert into camocontrol.zotb_items_plantilla select * from otb_item_mes
ON CONFLICT (t0002_mes, t0002_id_item) DO NOTHING;

-- Paso 2: calcular el costo de los reportes de produccion que esten en estado C y actualizar con dichos valores
-- la tabla temporal actualizada anteriormente. con esto tendre el costo promedio "Real" de cada item mensual para poder calcular con este valor el
-- costo de los productos terminados.
WITH otb_costos AS (
   select f0402_id_item,
          to_char(f0402_fecha_produccion,'YYYY-MM') as ofecha,
          sum(case when f0309_costo_tot_promedio = 0 
               then f0309_costo_tot
               else f0309_costo_tot_promedio
          end) as costo_tot
   from camocontrol.tb0309_items_movimientos
      join camocontrol.tb0310_documentos_movimientos_inventarios
        on f0310_id_documento = f0309_id_documento
      join camocontrol.tb0311_tipos_doc_mov_inventarios
        on f0310_id_tipo_documento = f0311_id_tipo_doc
      join camocontrol.tb0300_items
        on f0309_id_item = f0300_id_item
      join camocontrol.tb0402_reporte_produccion
        on f0310_id_documento_origen = 'RP-' || f0402_id_rp
   where f0309_id_cia = '00000001' and (f0310_id_tipo_documento = 1 or f0310_id_tipo_documento = 7)
      and f0402_estado = 'C'
      and f0402_fecha_produccion BETWEEN '2017-01-01' AND '2017-12-30' 
      --and f0310_id_documento_origen = 'RP-14600'
      --and f0402_id_item = 2657
      and f0309_anulado = 'N' 
   group by f0402_id_item, to_char(f0402_fecha_produccion,'YYYY-MM')
   order by costo_tot, f0402_id_item
)
update camocontrol.zotb_items_plantilla set
   t0002_costo = otb_costos.costo_tot
   from otb_costos
where t0002_id_item = otb_costos.f0402_id_item and otb_costos.ofecha = t0002_mes




--- Paso 3: Actualizo la cantidad producida en los reportes de produccion en la tabla temporal para poder calcular el costo real y le sumo el valor de mano de obra
with otb_cantidades_mes as (
select f0402_id_item,
          to_char(f0402_fecha_produccion,'YYYY-MM') as ofecha,
          sum(f0402_cantidad_producida) as cantidad,
          sum(f0402_horas_hombre) as total_horas
from camocontrol.tb0402_reporte_produccion
where f0402_estado = 'C' and f0402_anulado = 'N'
      and f0402_fecha_produccion BETWEEN '2017-01-01' AND '2017-12-30'
group by f0402_id_item, to_char(f0402_fecha_produccion,'YYYY-MM')
)
update camocontrol.zotb_items_plantilla set
   t0002_cantidad = otb_cantidades_mes.cantidad,
   t0002_costo = t0002_costo + (otb_cantidades_mes.total_horas * 6300) 
   from otb_cantidades_mes
where t0002_id_item = otb_cantidades_mes.f0402_id_item and otb_cantidades_mes.ofecha = t0002_mes


---- calculo el costo unitario
update camocontrol.zotb_items_plantilla set
  t0002_costo_unit = t0002_costo / t0002_cantidad
where t0002_cantidad > 0

-- con los valores temporales actualizo los movimientos del mes y lego vuelvo a actualizar temporales y nuevamente.

-- PASO 2
-- Actualizo el costo DE LOS PRODUCTOS FABRICADOS en los movimientos de inventario segun el costo de los reportes de produccion entre un rango de fechas
-- Cuando el costo unitario calculado excede en un 20% del costo promedio entonces quiere decir que la formulacion esta mal
-- Calculo el valor con el costo promedio + 2%
WITH otb_costos AS (
   select t0002_mes, t0002_id_item, t0002_costo_unit
   from camocontrol.zotb_items_plantilla
   order by t0002_costo_unit
 )
update camocontrol.tb0309_items_movimientos set
      f0309_costo_tot = case when otb_costos.t0002_costo_unit > (f0309_costo_unit_estandar * 1.2) then f0309_costo_unit_estandar else otb_costos.t0002_costo_unit end *
                        case when f0309_salida = 0 then f0309_entrada else f0309_salida end,
                          
      f0309_costo_tot_promedio = case when otb_costos.t0002_costo_unit > (f0309_costo_unit_estandar * 1.2) then f0309_costo_unit_estandar else otb_costos.t0002_costo_unit end * 
                        case when f0309_salida = 0 then f0309_entrada else f0309_salida end
from otb_costos
where to_char(f0309_fecha_movimiento,'YYYY-MM') = otb_costos.t0002_mes
and otb_costos.t0002_id_item = f0309_id_item and f0309_fecha_movimiento > '2017-01-01';     

-- PASO 3
-- ACTUALIZO LOS VALORES QUE MODIFIQUE A 0
update camocontrol.tb0309_items_movimientos set
    f0309_costo_tot = f0309_costo_tot_estandar,
    f0309_costo_tot_promedio = f0309_costo_tot_estandar
WHERE f0309_costo_tot = 0


