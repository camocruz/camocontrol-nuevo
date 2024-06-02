select f0600_id_accion as id_acc,  f0600_path || f0600_id_accion || '-' as path,
      COALESCE(f0600_id_accion_principal, f0600_id_accion) as plan_accion,
      CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre || ' =>> ' || tb0100_estructura_mantenimiento.f0100_nombre
       end as estructura_maquina,
       tb_responsable.f0200_apellido1 || ' ' || substring(tb_responsable.f0200_nombres from 1 for 8) as responsable,
       f0600_nivel_cumplimiento as avance,
       substring(f0603_descriptor_estado from 1 for 3) as estado,
       replace(replace(f0600_titulo, chr(10),'.  '), chr(13), '') || ' => ' ||
       replace(replace(f0600_descripcion, chr(10),'.  '), chr(13), '') ||
       ' (' || f0600_path || f0600_id_accion || '-' || ')' ||
       ' {' || upper(f0602_descriptor_tipo) || ' = ' || upper(f0601_descriptor_fuente) ||
       '}' as tit_descripcion,
       to_char(f0600_fecha_inicio, 'YYYY-MM-DD') as f_inicio,
       to_char(f0600_fecha_limite, 'YYYY-MM-DD') as f_fin
from $df001$.tb0600_acciones
     left join $df001$.tb0601_fuentes_acciones
          on f0600_id_fuente_accion = f0601_id_fuente
     join $df001$.tb0100_estructura_mantenimiento
          on tb0100_estructura_mantenimiento.f0100_id_estructura = f0600_id_estructura
     join $df001$.tb0107_tipos_estructura
          on tb0100_estructura_mantenimiento.f0100_id_tipo_estructura = f0107_id_tipo_estructura
     left join $df001$.tb0100_estructura_mantenimiento as otb_maquina
          on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     join $df001$.tb0002_unidades_medicion
          on f0600_unidad_duracion = f0002_id_unidad_medicion
     join $df001$.tb0603_estados_acciones
          on f0600_id_estado_accion = f0603_id_estado_accion
     join $df001$.tb0602_tipos_acciones
          on f0600_id_tipo_accion = f0602_id_tipo_accion
     join $df001$.tb0200_terceros as tb_responsable
          on f0600_responsable = tb_responsable.f0200_id_tercero
     join $df001$.tb0200_terceros as tb_evaluador
          on f0600_evaluador = tb_evaluador.f0200_id_tercero
where 
-- primero las que inician entre las fechas definidas
      (
        f0600_id_cia = '$001$' and f0600_anulado = 'N' and
        f0600_id_tipo_registro = '03' and
        f0600_id_estructura is not null and
        f0600_fecha_inicio BETWEEN '$002$' AND '$003$' and
        substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' 
                  from 1 for char_length('$004$')) = '$004$'
       )
    or
-- segundo las que inician antes de las fecha pero terminan entre las fechas
       (
        f0600_id_cia = '$001$' and f0600_anulado = 'N' and
        f0600_id_tipo_registro = '03' and
        f0600_id_estructura is not null and
        f0600_fecha_limite BETWEEN '$002$' AND '$003$' and
        f0600_fecha_inicio < '$002$' and
        substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' 
                  from 1 for char_length('$004$')) = '$004$'
       )
    or
-- tercero las que inician antes de la fecha inicial y terminan despues de la fecha final
       (
        f0600_id_cia = '$001$' and f0600_anulado = 'N' and
        f0600_id_tipo_registro = '03' and
        f0600_id_estructura is not null and
        f0600_fecha_inicio < '$002$' AND f0600_fecha_limite > '$003$' and
        substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' 
                  from 1 for char_length('$004$')) = '$004$'
       )
order by f0600_fecha_inicio