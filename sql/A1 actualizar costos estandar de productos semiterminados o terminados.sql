-- consulto los items cosnumidos y producidos en un rp
SELECT f0309_id_item, f0300_id_tipo_item, 
       f0309_id_bodega, f0309_id_documento, f0309_entrada, f0309_salida, 
       f0309_inventario,  
       f0309_costo_tot, f0309_costo_tot_promedio, f0309_costo_tot_estandar, 
       f0309_costo_unit_estandar, f0309_mes_asignable
  FROM camocontrol.tb0309_items_movimientos
join camocontrol.tb0310_documentos_movimientos_inventarios
  on f0309_id_documento = f0310_id_documento
join camocontrol.tb0300_items
  on f0309_id_item = f0300_id_item
where f0310_id_documento_origen = 'RP-17075'
      and f0309_anulado = 'N' and f0309_id_cia = '00000001';
      
-- PASO 1
--Actualizo los costos de los movimientos de items de acuerdo al costo promedio de las compras del mes del movimiento. Datos de compras
WITH otb_costos_compras as (
   SELECT f0305_id_item, to_char(f0307_fecha_factura,'YYYY-MM') as ofecha, AVG(f0305_costo_unitario_planificado) as costo_promedio, avg(f0300_ultimo_costo) as ult_costo
   FROM camocontrol.tb0305_items_solicitados
      JOIN camocontrol.tb0307_facturas_compras
        ON f0307_id_factura_compras = f0305_id_factura_compras
      join camocontrol.tb0300_items
        on f0305_id_item = f0300_id_item 
   WHERE f0305_id_factura_compras IS NOT NULL and f0305_anulado = 'N' and (f0300_id_tipo_item = 1 or f0300_id_tipo_item = 2) -- f0305_id_item = 2152 --
   GROUP BY f0305_id_item, to_char(f0307_fecha_factura,'YYYY-MM')
   ORDER BY f0305_id_item, ofecha
)
update camocontrol.tb0309_items_movimientos set
       f0309_costo_tot = coalesce(case when f0309_costo_tot = 0 then 
                                    (case when f0309_salida = 0 then 
                                        f0309_entrada 
                                     else 
                                        f0309_salida 
                                     end * otb_costos_compras.ult_costo) 
                                   end, 0),
       f0309_costo_tot_promedio = coalesce(case when f0309_costo_tot_promedio = 0 then (case when f0309_salida = 0 then f0309_entrada else f0309_salida end * otb_costos_compras.ult_costo) end, 0),
       f0309_costo_tot_estandar = coalesce(case when f0309_costo_tot_estandar = 0 then (case when f0309_salida = 0 then f0309_entrada else f0309_salida end * otb_costos_compras.ult_costo) end, 0), 
       f0309_costo_unit_estandar = coalesce(case when f0309_costo_unit_estandar = 0 then otb_costos_compras.costo_promedio end, 0)
from otb_costos_compras
where f0309_id_item = otb_costos_compras.f0305_id_item and f0309_fecha_movimiento > '2018-01-01'
and to_char(f0309_fecha_movimiento,'YYYY-MM') = otb_costos_compras.ofecha
and f0309_anulado = 'N';

-- identifico los items que tienen costo promedio y costo ultima compra muy desviados.
select f0300_id_item, f0300_descripcion_item, f0300_ultimo_costo/f0300_costo_promedio as crit1
from camocontrol.tb0300_items
where f0300_costo_promedio <> 0 and (f0300_id_tipo_item = 1 or f0300_id_tipo_item = 2)
order by crit1;

-- identifico los movimientos con costos exagerados
SELECT f0309_id_mov_item, f0309_id_item, f0300_descripcion_item, f0302_descripcion_tipo_item,
       f0309_id_documento, f0309_fecha_movimiento, f0309_entrada, f0309_salida, f0309_anulado,
       f0309_inventario, 
       f0309_id_doc_ref, f0309_id_factura_costo, f0309_costo_tot, f0309_costo_unit_estandar
FROM camocontrol.tb0309_items_movimientos
join camocontrol.tb0300_items
        on f0309_id_item = f0300_id_item
join camocontrol.tb0302_tipos_items
     on f0302_id_tipo_item = f0300_id_tipo_item
where f0309_anulado = 'N' and f0309_costo_tot > 100000000 AND f0309_fecha_movimiento > '2018-01-01'
order by f0302_descripcion_tipo_item, f0309_fecha_movimiento, f0309_id_item, f0309_costo_tot desc;


--PASO 2  EJECUTAR 20 VECES
--Calculo el costo estandar de los items de productos que tienen formulacion tomando el costo promedio desde la tabla items
-- con esto actualizo la tabla items.
WITH otb_costos AS (
   select f0350_id_item, --f0300_id_tipo_item, --f0310_id_tipo_documento,
        sum(
          case when f0300_id_tipo_item = 1 
                 then f0300_ultimo_costo
                      --(case when f0300_costo_estandar = 0 
                          --then f0300_costo_promedio 
                         -- else
                         -- f0300_costo_estandar
                      -- end) 
           end * f0351_cantidad / f0350_produccion_x_bache
           ) 
           as costo_mp,
        sum(
          case when f0300_id_tipo_item = 2
                 then f0300_ultimo_costo
                      --(case when f0300_costo_estandar = 0 
                       --   then f0300_costo_promedio 
                       --   else
                       --   f0300_costo_estandar
                       --end) 
           end * f0351_cantidad / f0350_produccion_x_bache
           ) 
           as costo_me,
        sum(
          case when f0300_id_tipo_item = 25
                 then f0300_ultimo_costo
                       --(case when f0300_costo_estandar = 0 
                        --  then f0300_costo_promedio 
                        --  else
                       --   f0300_costo_estandar
                      -- end) 
           end * f0351_cantidad / f0350_produccion_x_bache
           ) 
           as costo_prod_semiterm,
        sum(
          case when f0300_id_tipo_item = 24
                 then f0300_costo_promedio
                     --  (case when f0300_costo_estandar = 0 
                     --     then f0300_costo_promedio 
                     --     else
                     --     f0300_costo_estandar
                     --  end) 
           end * f0351_cantidad / f0350_produccion_x_bache
           ) 
           as costo_mano_obra,
        sum(
          case when f0300_id_tipo_item <> 1 
                     and f0300_id_tipo_item <> 2 
                     and f0300_id_tipo_item <> 25
                     and f0300_id_tipo_item <> 24
                 then f0300_ultimo_costo
                     --  (case when f0300_costo_estandar = 0 
                     --     then f0300_costo_promedio 
                     --     else
                     --     f0300_costo_estandar
                     --  end) 
           end * f0351_cantidad / f0350_produccion_x_bache
           ) 
           as costo_otros
   from camocontrol.tb0351_elementos
      join camocontrol.tb0300_items
        on f0351_id_item = f0300_id_item   
      join camocontrol.tb0350_plantillas
        on f0350_id_plantilla = f0351_id_plantilla
   where f0350_id_cia = '00000001' 
         and f0350_anulado = 'N' and f0350_activa = 'S' and f0351_anulado = 'N'
         --and f0350_id_item = 2657
   group by f0350_id_item  --, f0300_id_tipo_item
   order by f0350_id_item
)
--Actualizo los costos en la tabla items con los costos calculados desde las formulaciones
update camocontrol.tb0300_items
  set f0300_costo_mp = coalesce(otb_costos.costo_mp, 0),
      f0300_costo_me = coalesce(otb_costos.costo_me, 0),
      f0300_costo_mano_obra = coalesce(otb_costos.costo_mano_obra, 0),
      f0300_costo_prod_semiterm = coalesce(otb_costos.costo_prod_semiterm, 0),
      f0300_costo_otros = coalesce(otb_costos.costo_otros, 0),
      f0300_costo_promedio = coalesce(otb_costos.costo_mp, 0)+coalesce(otb_costos.costo_me, 0)+coalesce(otb_costos.costo_prod_semiterm, 0)
                             +coalesce(otb_costos.costo_otros, 0)+coalesce(otb_costos.costo_mano_obra, 0),
      f0300_costo_estandar = coalesce(otb_costos.costo_mp, 0)+coalesce(otb_costos.costo_me, 0)+coalesce(otb_costos.costo_prod_semiterm, 0)
                             +coalesce(otb_costos.costo_otros, 0)+coalesce(otb_costos.costo_mano_obra,0),
      f0300_ultimo_costo = coalesce(otb_costos.costo_mp, 0)+coalesce(otb_costos.costo_me, 0)+coalesce(otb_costos.costo_prod_semiterm, 0)
                             +coalesce(otb_costos.costo_otros, 0)+coalesce(otb_costos.costo_mano_obra,0)
from otb_costos
where otb_costos.f0350_id_item = f0300_id_item;




--PASO 3
-- Actualizo el costo unitario estandar de los reportes de produccion con el valor de la tabla items que se calculo con las formulaciones
update camocontrol.tb0402_reporte_produccion set
    f0402_costo_unitario_estandar = (select f0300_costo_estandar 
                                     from camocontrol.tb0300_items 
                                     where f0402_id_item = f0300_id_item);



--PASO 4
-- Actualizo la cantidad producida en cada ipp para poder sacar estadisticas esto se debe mejorar en el programa
WITH otb_prod_ipp AS (
   select ((regexp_split_to_array(f0402_tree_path,'-'))[3])::int as id_ipp_pp, 
       sum(f0402_cantidad_producida) as produccion_rp
   from camocontrol.tb0402_reporte_produccion
   WHERE f0402_anulado = 'N' and f0402_cantidad_producida <> 0
         and array_length(regexp_split_to_array(f0402_tree_path,'-'),1)=5
         --and ((regexp_split_to_array(f0402_tree_path,'-'))[3])::int = 14150
   group by (regexp_split_to_array(f0402_tree_path,'-'))[3]
)
update camocontrol.tb0401_items_prog_prod set
   f0401_cantidad_producida = otb_prod_ipp.produccion_rp
from otb_prod_ipp
where otb_prod_ipp.id_ipp_pp = f0401_id_ipp;   



--PASO 5
-- ACTUALIZO EL COSTO DE TODOS LOS MOVIMIENTOS DE INVENTARIO CALCULANDO EL VALOR CON LOS VALORES DE
-- LAS FORMULACIONES Y LOS COSTOS PROMEDIO DE LOS ITEMS

WITH otb_costos_mov AS (
   select f0350_id_item, f0300_ultimo_costo
   from camocontrol.tb0350_plantillas
      join camocontrol.tb0300_items
        on f0350_id_item = f0300_id_item   
   where f0350_id_cia = '00000001' 
         and f0350_anulado = 'N' and f0350_activa = 'S' and f0350_anulado = 'N'
   order by f0300_costo_promedio
)
update camocontrol.tb0309_items_movimientos
  set f0309_costo_tot = case when f0309_entrada = 0 then f0309_salida else f0309_entrada end * otb_costos_mov.f0300_ultimo_costo,
  f0309_costo_tot_promedio = case when f0309_entrada = 0 then f0309_salida else f0309_entrada end * otb_costos_mov.f0300_ultimo_costo,
  f0309_costo_tot_estandar = case when f0309_entrada = 0 then f0309_salida else f0309_entrada end * otb_costos_mov.f0300_ultimo_costo,
  f0309_costo_unit_estandar = otb_costos_mov.f0300_ultimo_costo
from otb_costos_mov
where otb_costos_mov.f0350_id_item = f0309_id_item --AND (f0309_id_item <> 2358 OR f0309_id_item <> 2359);




--PASO 6
-- REDEFINO EL ESTADO DE LOS REPORTES QUE ESTEN CERRADOS Y QUE TENGAN PRODUCCION IGUAL A CERO
update camocontrol.tb0402_reporte_produccion set
   f0402_estado = 'B'
where f0402_anulado = 'N' and f0402_cantidad_producida = 0 and f0402_estado = 'C';



--PASO 7
-- Redefino el estado de los reportes de produccion que esten cerrados y que no tengan movimientos de consumo.
WITH otb_reportes AS (
   select 
    f0402_id_rp as id, f0310_id_documento_origen, f0310_id_documento, f0310_id_tipo_documento
   from camocontrol.tb0402_reporte_produccion
       left join camocontrol.tb0310_documentos_movimientos_inventarios
           on f0310_id_documento_origen = 'RP-' || f0402_id_rp and f0310_anulado = 'N' and f0310_id_tipo_documento <> 4
WHERE f0402_anulado = 'N' and f0402_estado = 'C' 
        and f0310_id_documento_origen is null
order by f0402_id_rp
)
 update camocontrol.tb0402_reporte_produccion set
    f0402_estado = 'B'
 from otb_reportes
 where otb_reportes.id = f0402_id_rp ;  



--PASO 8
----- Actualizo el costo en los reportes de produccion que estan en estado B colocandoles el costo promedio definido en la tabla items
-- mas 2% en el costo.
with otb_costos_items as (
   select f0300_id_item,
          f0300_costo_mp,
          f0300_costo_me, 
          f0300_costo_prod_semiterm,
          f0300_costo_otros,
          f0300_costo_promedio,
          f0300_costo_mano_obra
   from camocontrol.tb0300_items
)
update camocontrol.tb0402_reporte_produccion set
  f0402_costo_mp = otb_costos_items.f0300_costo_mp * f0402_cantidad_producida * 1.02,
  f0402_costo_me = otb_costos_items.f0300_costo_me * f0402_cantidad_producida * 1.02,
  f0402_costo_mano_obra = otb_costos_items.f0300_costo_mano_obra * f0402_cantidad_producida * 1.02,
  f0402_costo_prod_semiterm = otb_costos_items.f0300_costo_prod_semiterm * f0402_cantidad_producida * 1.02,
  f0402_costo_otros = otb_costos_items.f0300_costo_otros * f0402_cantidad_producida * 1.02,
  f0402_costo_total = otb_costos_items.f0300_costo_promedio * f0402_cantidad_producida * 1.02,
  f0402_costo_unitario = otb_costos_items.f0300_costo_promedio * 1.02,
  f0402_costo_unitario_estandar = otb_costos_items.f0300_costo_promedio
from otb_costos_items
where f0402_anulado = 'N' and f0402_estado = 'B' and f0402_id_item = otb_costos_items.f0300_id_item;

        