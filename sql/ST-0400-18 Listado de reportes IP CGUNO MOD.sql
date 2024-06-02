SELECT f0402_id_rp as id_rp,
       f0402_co_cguno as co_cguno, 
       f0402_ip_cguno as ip_cguno,
       f0402_id_item as id_item, 
       f0300_referencia as referencia,
       case when f0402_lote_ip = '' then f0402_lote else f0402_lote_ip end as lote, 
       f0300_descripcion_item || ' (' || f0300_contenido_x_empaque || ')' as producto, 
       round(f0402_cantidad_producida,2) as produccion,
       f0002_unidad_medicion as unidad,  
       to_char(f0402_fecha_produccion, 'YYYY-MM-DD') as fecha_prod,
       to_char(f0402_fecha_produccion,'yyyy-MM') as mes, 
       EXTRACT(WEEK FROM f0402_fecha_produccion) as semana,
       to_char(f0402_fecha_produccion,'dd') as dia, 
       f0402_horas_hombre,
       to_char(f0402_fecha_vence, 'YYYY-MM-DD') as fecha_vence, 
       f0402_costo_mp, 
       f0402_costo_mano_obra, 
       f0402_productividad, 
       f0402_costo_otros, 
       f0402_costo_total, 
       f0402_costo_unitario, 
       f0402_ip_cg_codigo as cod_ip,
       f0014_descripcion_co as descripcion_co
  FROM $df001$.tb0402_reporte_produccion
     left join $df001$.tb0300_items on f0402_id_item = f0300_id_item
     left join $df001$.tb0002_unidades_medicion on f0300_id_unidad_medicion=f0002_id_unidad_medicion
     left join $df001$.tb0014_centros_operacionales on f0014_co_cg = f0402_co_cguno and f0402_id_cia = f0014_id_cia
  where f0402_id_cia = '$001$'  
      and f0402_fecha_produccion BETWEEN '$002$' and '$003$' 
      --and f0402_ip_cg_codigo is not null 
      and f0402_anulado = 'N'
  order by f0300_descripcion_item, f0402_fecha_produccion asc;