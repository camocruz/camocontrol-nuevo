select f0600_id_accion as id_acc, f0600_path || f0600_id_accion || '-' as path, 
      tb0100_estructura_mantenimiento.f0100_codigo as codigo,
      tb0100_estructura_mantenimiento.f0100_nombre as estructura,
      COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) as elemento_primario,
      f0600_titulo as titulo,
      f0600_descripcion as descripcion,
      f0603_descriptor_estado as estado,
      f0602_descriptor_tipo as t_actividad,
      to_char(f0600_fecha_inicio, 'YYYY-MM-DD') as f_inicio,
      to_char(f0600_fecha_inicio, 'HH12:MI AM') as h_inicio,
      to_char(f0600_fecha_inicio, 'YYYY') as año_inicio,
      to_char(f0600_fecha_inicio, 'YYYY-MM') as mes_inicio,
      extract(week from f0600_fecha_inicio::date) as semana_inicio,
      f0600_duracion as duracion,
      f0002_unidad_medicion as und,
      to_char(f0600_fecha_limite, 'YYYY-MM-DD') as f_fin,
      to_char(f0600_fecha_limite, 'HH12:MI AM') as h_fin,
      tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable,
      tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador,
      f0600_nivel_cumplimiento || '%' as avance,
      f0107_tipo_estructura as tipo_elemento,
	  f0601_descriptor_fuente as fuente
from camocontrol.tb0600_acciones
    join camocontrol.tb0100_estructura_mantenimiento
        on tb0100_estructura_mantenimiento.f0100_id_estructura = f0600_id_estructura
    join camocontrol.tb0107_tipos_estructura
        on tb0100_estructura_mantenimiento.f0100_id_tipo_estructura = f0107_id_tipo_estructura
    left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
        on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
    join camocontrol.tb0002_unidades_medicion
        on f0600_unidad_duracion = f0002_id_unidad_medicion
    join camocontrol.tb0603_estados_acciones
        on f0600_id_estado_accion = f0603_id_estado_accion
    join camocontrol.tb0602_tipos_acciones
        on f0600_id_tipo_accion = f0602_id_tipo_accion
    join camocontrol.tb0200_terceros as tb_responsable
        on f0600_responsable = tb_responsable.f0200_id_tercero
    join camocontrol.tb0200_terceros as tb_evaluador
        on f0600_evaluador = tb_evaluador.f0200_id_tercero
	left join camocontrol.tb0601_fuentes_acciones
          on f0600_id_fuente_accion = f0601_id_fuente
where f0600_id_cia = '00000001' and
     f0603_estado = 'A' and f0600_anulado = 'N' and
     f0600_id_tipo_registro = '03' and
     substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' from 1 for
               char_length('46-')) = '46-'
order by f0600_path, f0600_fecha_inicio
