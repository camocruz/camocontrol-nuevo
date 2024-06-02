SELECT f0200_codigo_empleado as id, f0402_id_rp as id_rp, f0403_horas as hh, 
       f0402_clasificador as clas, f0300_descripcion_item as producto, 
       to_char(f0402_fecha_produccion, 'YYYY-MM-DD') as fecha_prod,
       to_char(f0402_fecha_produccion, 'YYYY-MM') as mes,
       coalesce(f0005_descripcion_bodega,'ND') as bp
  FROM $df001$.tb0403_personal_rp
  join $df001$.tb0402_reporte_produccion
    on f0403_id_rp = f0402_id_rp
  join $df001$.tb0300_items
    on f0300_id_item = f0402_id_item
  join $df001$.tb0200_terceros
    on f0200_id_tercero = f0403_id_tercero
  left join $df001$.tb0005_bodegas
    on f0005_id_bodega = f0402_id_bodega_consumo_insumos
where f0403_anulado='N' and f0402_anulado='N' and f0403_id_cia = '$001$'
      and f0402_fecha_produccion BETWEEN '$002$' and '$003$'
order by f0200_codigo_empleado
