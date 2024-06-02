copy(
SELECT f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
       f0402_id_rp as id_rp,
       to_char(f0402_fecha_produccion,'yyyy-MM-dd') as fecha, 
       f0402_id_item as id_item, f0402_cantidad_producida as cantidad, 
       f0002_unidad_medicion as unidad,
       to_char(f0402_fecha_produccion,'yyyy-MM') as mes,
       to_char(f0402_fecha_produccion,'dd') as dia 
  FROM camocontrol.tb0402_reporte_produccion
  join camocontrol.tb0300_items
      on f0402_id_item = f0300_id_item
  join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
 ) to 'C:/dsfc/produccion.txt' DELIMITER ';' CSV HEADER;
