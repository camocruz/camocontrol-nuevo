
--PASO1
-- Calculo el costo clasificado el total de insumos consumidos en los reportes de produccion de acuerdo a los movimientos de los items, tomando el valor
-- del costo promedio registrado en cada movimiento.
WITH otb_costos AS (
   select f0310_id_documento_origen,  --f0300_id_tipo_item, f0310_id_tipo_documento,
        sum(
          case when f0310_id_tipo_documento = 1 and f0300_id_tipo_item = 1 
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_mp,
        sum(
          case when f0310_id_tipo_documento = 1 and f0300_id_tipo_item = 2 
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_me,
        sum( 
          case when f0310_id_tipo_documento = 7 and f0300_id_tipo_item = 1 
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_mp_np,
        Sum(
          case when f0310_id_tipo_documento = 7 and f0300_id_tipo_item = 2 
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_me_np, 
        sum(
          case when f0310_id_tipo_documento = 1 and f0300_id_tipo_item = 25
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_prod_semiterm,
        sum( 
          case when f0310_id_tipo_documento = 7 and f0300_id_tipo_item = 25
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_prod_semiterm_np, 
        sum(
          case when f0310_id_tipo_documento = 1 and f0300_id_tipo_item <> 1 
                     and f0300_id_tipo_item <> 2 and f0300_id_tipo_item <> 25
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_otros, 
        sum(
          case when f0310_id_tipo_documento = 7 and f0300_id_tipo_item <> 1 
                     and f0300_id_tipo_item <> 2 and f0300_id_tipo_item <> 25
                 then (case when f0309_costo_tot_promedio = 0 
                          then f0309_costo_tot 
                          else f0309_costo_tot_promedio
                       end) 
           end
           ) 
           as costo_otros_np
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
      --and f0402_fecha_produccion BETWEEN '2017-02-01' AND '2017-03-01' 
      --and f0310_id_documento_origen = 'RP-14600'
      and f0309_anulado = 'N' 
   group by f0310_id_documento_origen --, f0310_id_tipo_documento, f0300_id_tipo_item
   order by f0310_id_documento_origen
)
-- actualizo el costo en reporte de produccion
update camocontrol.tb0402_reporte_produccion
  set f0402_costo_mp = coalesce(otb_costos.costo_mp, 0),
      f0402_costo_me = coalesce(otb_costos.costo_me, 0),
      f0402_costo_mp_np = coalesce(otb_costos.costo_mp_np, 0),
      f0402_costo_me_np = coalesce(otb_costos.costo_me_np, 0),
      f0402_costo_prod_semiterm = coalesce(otb_costos.costo_prod_semiterm, 0),
      f0402_costo_prod_semiterm_np = coalesce(otb_costos.costo_prod_semiterm_np, 0),
      f0402_costo_otros = coalesce(otb_costos.costo_otros, 0),
      f0402_costo_otros_np = coalesce(otb_costos.costo_otros_np, 0),
      f0402_costo_mano_obra = case when f0402_horas_hombre = 1000 then 0 else coalesce(6154 * f0402_horas_hombre, 0) end,
      f0402_costo_total = coalesce(otb_costos.costo_mp, 0)+coalesce(otb_costos.costo_me, 0)
                          +coalesce(otb_costos.costo_mp_np, 0)+coalesce(otb_costos.costo_me_np, 0)
                          +coalesce(otb_costos.costo_prod_semiterm, 0)+coalesce(otb_costos.costo_prod_semiterm_np, 0)
                          +coalesce(otb_costos.costo_otros, 0)+coalesce(otb_costos.costo_otros_np, 0)
                          +case when f0402_horas_hombre = 1000 then 0 else coalesce(6154 * f0402_horas_hombre, 0) end,
      f0402_costo_unitario = (coalesce(otb_costos.costo_mp, 0)+coalesce(otb_costos.costo_me, 0)
                               +coalesce(otb_costos.costo_mp_np, 0)+coalesce(otb_costos.costo_me_np, 0)
                               +coalesce(otb_costos.costo_prod_semiterm, 0)+coalesce(otb_costos.costo_prod_semiterm_np, 0)
                               +coalesce(otb_costos.costo_otros, 0)+coalesce(otb_costos.costo_otros_np, 0)
                               +case when f0402_horas_hombre = 1000 then 0 else coalesce(6154 * f0402_horas_hombre, 0) end
                              )/f0402_cantidad_producida
from otb_costos
where otb_costos.f0310_id_documento_origen = 'RP-' || f0402_id_rp
      and f0402_cantidad_producida > 0;



-- PASO 2
-- Actualizo el costo DE LOS PRODUCTOS FABRICADOS en los movimientos de inventario segun el costo de los reportes de produccion entre un rango de fechas
-- Cuando el costo unitario calculado excede en un 20% del costo promedio entonces quiere decir que la formulacion esta mal
-- Calculo el valor con el costo promedio + 2%
WITH otb_costos AS (
   select f0402_id_item,
        avg(
          case when (f0402_costo_total/f0402_cantidad_producida) > (f0300_costo_promedio * 1.2)
                  then f0300_costo_promedio * 1.02
               when (f0402_costo_total/f0402_cantidad_producida) < (f0300_costo_promedio * 0.8)
                  then f0300_costo_promedio * 1.02
               else (f0402_costo_total/f0402_cantidad_producida)
          end
          ) as costo_unitario_total,
          avg(f0300_costo_estandar) as costo_unitario_estandar
   from camocontrol.tb0402_reporte_produccion
      join camocontrol.tb0300_items
        on f0402_id_item = f0300_id_item
   where f0402_id_cia = '00000001' --and f0310_id_tipo_documento <> 4
      and f0402_fecha_produccion BETWEEN '2017-02-01' AND '2017-03-01' 
      and f0402_cantidad_producida > 0 and f0402_estado = 'C'
      --and f0310_id_documento_origen = 'RP-14600'
      and f0402_anulado = 'N' -- and substring(f0310_id_documento_origen from 1 for 3) = 'RP-'
   group by f0402_id_item
)
update camocontrol.tb0309_items_movimientos set
      f0309_costo_tot = otb_costos.costo_unitario_total * 
                        case when f0309_salida = 0 then f0309_entrada else f0309_salida end,
                          
      f0309_costo_tot_promedio = otb_costos.costo_unitario_total * 
                        case when f0309_salida = 0 then f0309_entrada else f0309_salida end,
      -- estos valores se deben calcular con la informacion de la plantilla                  
      f0309_costo_tot_estandar = otb_costos.costo_unitario_estandar * 
                        case when f0309_salida = 0 then f0309_entrada else f0309_salida end,
      f0309_costo_unit_estandar = otb_costos.costo_unitario_estandar                         
from otb_costos
where f0309_mes_asignable = '2017-02' and otb_costos.f0402_id_item = f0309_id_item;     




