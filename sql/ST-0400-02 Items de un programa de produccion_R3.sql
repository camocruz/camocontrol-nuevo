SELECT f0401_id_ipp as id_ipp, f0401_id_item as id_producto, f0300_referencia as referencia,
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as producto,
       f0002_unidad_medicion as unidad, round(f0401_cantidad,2) as cantidad, f0401_anotacion as nota,
       f0401_cerrado as cerrado, 
       case when f0350_id_plantilla is null then  'FND' else 'FD' end as formula,
       cast((
         select sum(f0402_cantidad_producida)
            from camocontrol.tb0402_reporte_produccion
         where f0402_id_item = f0401_id_item and f0402_id_prog_prod = f0401_id_prog_prod and f0402_anulado='N'
       ) as int) as Produccion,
       round(((
         select sum(f0402_cantidad_producida)
            from camocontrol.tb0402_reporte_produccion
         where f0402_id_item = f0401_id_item and f0402_id_prog_prod = f0401_id_prog_prod and f0402_anulado='N'
               ) / f0401_cantidad) * 100, 2) as cumpl,
       round(f0300_peso_neto,2) as peso_unit_net,
       f0303_descripcion_linea_item as linea
  FROM camocontrol.tb0401_items_prog_prod
    join camocontrol.tb0300_items
      on f0401_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
    join camocontrol.tb0303_lineas_items
      on f0303_id_linea_item = f0300_id_linea
    left join camocontrol.tb0350_plantillas
      on f0401_id_item = f0350_id_item and f0350_activa = 'S'
  where f0401_anulado = 'N' and f0401_id_ipp_padre is null and f0401_id_prog_prod = 108
order by producto