select f0600_id_accion as id_acc, f0605_descriptor_tipo_registro as tipo_accion,
      f0601_descriptor_fuente as fuente,
      COALESCE(f0600_id_accion_principal, 0) as plan_accion,
      tb0100_estructura_mantenimiento.f0100_codigo as codigo,
      tb0100_estructura_mantenimiento.f0100_nombre as estructura,
      COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) as elemento_primario,
      replace(replace(f0600_titulo, chr(10),'.  '), chr(13), '') as titulo,
      replace(replace(f0600_descripcion, chr(10),'.  '), chr(13), '') as descripcion,
      f0603_descriptor_estado as estado,
      f0602_descriptor_tipo as t_actividad,
      case when f0600_fecha_inicio is not null 
          then to_char(f0600_fecha_inicio, 'YYYY-MM-DD')
          else to_char(f0600_fecha_emision, 'YYYY-MM-DD')
      end as f_inicio,
      case when f0600_fecha_inicio is not null 
          then to_char(f0600_fecha_inicio, 'HH12:MI AM')
          else to_char(f0600_fecha_emision, 'HH12:MI AM')
      end as h_inicio,      
      case when f0600_fecha_inicio is not null 
          then to_char(f0600_fecha_inicio, 'YYYY')
          else to_char(f0600_fecha_emision, 'YYYY')
      end as año_inicio,  
      case when f0600_fecha_inicio is not null 
          then to_char(f0600_fecha_inicio, 'YYYY-MM')
          else to_char(f0600_fecha_emision, 'YYYY-MM')
      end as mes_inicio, 
      case when f0600_fecha_inicio is not null 
          then extract(week from f0600_fecha_inicio::date)
          else extract(week from f0600_fecha_emision::date)
      end as semana_inicio, 
      f0600_duracion as duracion,
      f0002_unidad_medicion as und,
      to_char(f0600_fecha_limite, 'YYYY-MM-DD') as f_fin,
      to_char(f0600_fecha_limite, 'HH12:MI AM') as h_fin,
      tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_nombres as responsable,
      tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador,
      f0600_nivel_cumplimiento || '%' as avance,
      f0107_tipo_estructura as tipo_elemento, f0600_path || f0600_id_accion || '-' as path,
      to_char(f0600_fecha_emision, 'YYYY-MM-DD') as f_emision,
      to_char(f0600_fecha_emision, 'YYYY-MM') as mes_emision
from $df001$.tb0600_acciones
     left join $df001$.tb0100_estructura_mantenimiento
          on tb0100_estructura_mantenimiento.f0100_id_estructura = f0600_id_estructura
     left join $df001$.tb0107_tipos_estructura
          on tb0100_estructura_mantenimiento.f0100_id_tipo_estructura = f0107_id_tipo_estructura
     left join $df001$.tb0100_estructura_mantenimiento as otb_maquina
          on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     left join $df001$.tb0601_fuentes_acciones
          on f0601_id_fuente = f0600_id_fuente_accion
     left join $df001$.tb0605_tipos_registro_acciones
          on f0605_id_tipo_registro = f0600_id_tipo_registro
     left join $df001$.tb0002_unidades_medicion
          on f0600_unidad_duracion = f0002_id_unidad_medicion
     left join $df001$.tb0603_estados_acciones
          on f0600_id_estado_accion = f0603_id_estado_accion
     left join $df001$.tb0602_tipos_acciones
          on f0600_id_tipo_accion = f0602_id_tipo_accion
     left join $df001$.tb0200_terceros as tb_responsable
          on f0600_responsable = tb_responsable.f0200_id_tercero
     left join $df001$.tb0200_terceros as tb_evaluador
          on f0600_evaluador = tb_evaluador.f0200_id_tercero
where 
-- primero las que inician entre las fechas definidas
      (
        f0600_id_cia = '$001$' and f0600_anulado = 'N' and
        f0600_id_tipo_registro <> '04' and f0600_id_tipo_registro <> '02' and
        f0600_fecha_inicio BETWEEN '$002$' AND '$003$' 
       )
    or
-- segundo las que inician antes de las fecha pero terminan entre las fechas
       (
        f0600_id_cia = '$001$' and f0600_anulado = 'N' and
        f0600_id_tipo_registro <> '04' and f0600_id_tipo_registro <> '02' and
        f0600_fecha_limite BETWEEN '$002$' AND '$003$' 
        and f0600_fecha_inicio < '$002$' 
       )
    or
-- tercero las que inician antes de la fecha inicial y terminan despues de la fecha final
       (
        f0600_id_cia = '$001$' and f0600_anulado = 'N' and
        f0600_id_tipo_registro <> '04' and f0600_id_tipo_registro <> '02' and
        --f0600_id_estructura is not null and
        f0600_fecha_inicio < '$002$' AND f0600_fecha_limite > '$003$' 
       )
     or
-- cuarto las acciones que se emitieron
      (
       f0600_fecha_ocurrencia_evento BETWEEN '$002$' AND '$003$'
      )
order by f0600_fecha_inicio, f0600_id_accion