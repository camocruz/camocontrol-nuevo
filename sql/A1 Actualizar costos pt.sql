-- actualizando todos los rp a partir de una fecha
select * from camocontrol.fnc_400_01_calcular_costos_produccion('2018-05-01', '00000001','00000001')

-- actualizando solo los rp de un item a partir de una fecha
select * from camocontrol.fnc_400_02_calcular_costos_produccion_un_item(2657, '2018-04-01', '00000001','00000001')

-- cuantos movimientos tiene el item
select f0309_id_item from camocontrol.tb0309_items_movimientos
where f0309_fecha_movimiento > '2018-04-01' and f0309_id_item = 2657

-- costo unitario calculado en cada rp
select f0402_id_rp, f0402_id_item, f0402_costo_unitario 
from camocontrol.tb0402_reporte_produccion
--where f0402_id_rp = 19426
WHERE f0402_fecha_produccion > '2018-01-01' AND f0402_anulado = 'N' 
      AND f0402_cantidad_producida > 0 AND f0402_estado = 'C'
      --AND f0402_id_item = 6282
ORDER BY f0402_id_rp

-- costo unitario de entrada en los mov de inventario de un RP
select f0310_id_documento, f0309_id_item, f0309_costo_unit_entrada
        from camocontrol.tb0309_items_movimientos
          join camocontrol.tb0310_documentos_movimientos_inventarios
            on f0310_id_documento = f0309_id_documento 
        where f0310_id_tipo_documento = 4
            and f0310_anulado = 'N'
            and f0310_id_documento_origen = 'RP-19401'
        order by f0309_fecha_movimiento

-- costo por tipo de item de un rp
select f0300_id_tipo_item, f0300_id_item, f0300_descripcion_item, f0309_costo_unit_promedio, f0309_salida, sum(f0309_costo_unit_promedio * f0309_salida) as costo
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0310_documentos_movimientos_inventarios
      on f0310_id_documento = f0309_id_documento
   join camocontrol.tb0300_items
      on f0300_id_item = f0309_id_item
where f0310_id_documento_origen = 'RP-19401'
      and f0309_salida > 0
      and f0310_anulado = 'N'
group by f0300_id_tipo_item, f0300_id_item, f0309_costo_unit_promedio, f0300_descripcion_item, f0309_salida
 
