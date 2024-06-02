copy (
SELECT f0850_id_rm, to_char(f0850_fecha_documento,'yyyy-MM-dd') as fecha,
       to_char(f0850_fecha_documento,'yyyy-MM') as mes, f0850_codigo_tercero, 
       f0850_razon_social, f0850_ciudad_destino, f0850_nombre_vendedor,
       f0851_referencia_1,
       f0851_descripcion || ' - ' || f0851_referencia_2 as producto,  f0851_cantidad
  FROM camocontrol.tb0850_remisiones_cguno_encabezado
LEFT JOIN camocontrol.tb0851_remisiones_cguno_detalle
  ON f0850_id_rm = f0851_id_rm
) to 'S:/dsfc/rh_asistencia/rms.txt';