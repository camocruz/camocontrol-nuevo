select f0600_id_accion as id_acc,
      replace(replace(f0600_descripcion, chr(10),'.  '), chr(13), '') as descripcion,
      f0603_descriptor_estado as estado,
      to_char(f0600_fecha_ocurrencia_evento, 'YYYY-MM-DD HH12:MI AM') as f_inicio,
      to_char(f0600_fecha_cierre_correctivo, 'YYYY-MM-DD HH12:MI AM') as f_fin,
      round(extract('epoch' from f0600_fecha_cierre_correctivo - f0600_fecha_ocurrencia_evento)/60) AS minutos,
      tb_responsable.f0200_apellido1 || ' ' || substring(tb_responsable.f0200_nombres from 1 for 1) as responsable,
      f0600_nivel_cumplimiento || '%' as avance
from camocontrol.tb0600_acciones
     join camocontrol.tb0603_estados_acciones
          on f0600_id_estado_accion = f0603_id_estado_accion
     join camocontrol.tb0602_tipos_acciones
          on f0600_id_tipo_accion = f0602_id_tipo_accion
     join camocontrol.tb0200_terceros as tb_responsable
          on f0600_responsable = tb_responsable.f0200_id_tercero
where 
  f0600_id_cia = '00000001' and f0600_tipo_docto_padre = 'RP' and f0600_id_docto_padre = '7039'
order by f0600_fecha_inicio