copy (
SELECT f0850_id_rm, to_char(f0850_fecha_documento,'yyyy-MM-dd') as fecha,
       to_char(f0850_fecha_documento,'yyyy-MM') as mes, f0850_codigo_tercero, 
       f0850_razon_social, f0850_ciudad_destino, f0850_nombre_vendedor,
       f0851_referencia_1,
       f0851_descripcion || ' - ' || f0851_referencia_2 as producto,  f0851_cantidad,
       f0300_id_item, 
       (f0300_descripcion_item || ' ( ' || f0300_contenido_x_empaque || ')' || '(' || f0300_referencia || ' )') as producto
  FROM camocontrol.tb0850_remisiones_cguno_encabezado
LEFT JOIN camocontrol.tb0851_remisiones_cguno_detalle
  ON f0850_id_rm = f0851_id_rm
LEFT JOIN camocontrol.tb0300_items
  ON f0851_referencia_1 = f0300_referencia
) to 'S:/dsfc/rh_asistencia/rms.txt';

-- exportar informacion programa de produccion
Copy(
SELECT f0400_nombre, f0401_id_ipp, f0401_id_item, f0300_descripcion_item, 
       f0300_referencia, f0401_cantidad
  FROM camocontrol.tb0401_items_prog_prod
     join camocontrol.tb0400_programa_produccion
       on f0401_id_prog_prod = f0400_id_pp
     join camocontrol.tb0300_items
       on f0401_id_item = f0300_id_item
) to 'S:/dsfc/rh_asistencia/prog_prod.txt';

-- exportar informacion reportes de produccion
copy(
select f0402_id_rp as id_rp, f0402_id_item, f0300_referencia,
    f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ' <' || f0002_unidad_medicion || '> )' as producto,
    f0002_unidad_medicion as unidad, f0402_cantidad_producida as produccion, to_char(f0402_fecha_produccion, 'YYYY-MM-DD') as fecha_prod,
    to_char(f0402_fecha_produccion,'yyyy-MM') as mes, f0302_descripcion_tipo_item as tipo_item, 
    f0300_peso_unitario * f0402_cantidad_producida as peso_kg, f0402_turno as turno, 
    f0402_clasificador as clasificador, f0402_horas_hombre as h_hombre
from camocontrol.tb0402_reporte_produccion
    join camocontrol.tb0300_items
      on f0402_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
      on f0300_id_tipo_item = f0302_id_tipo_item
order by f0402_fecha_produccion asc
) to 'S:/dsfc/rh_asistencia/prod_rp.txt' DELIMITER ';' CSV HEADER;