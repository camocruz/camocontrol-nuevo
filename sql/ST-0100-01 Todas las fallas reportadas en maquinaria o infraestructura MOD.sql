select f0600_id_accion as id_rpf, f0600_path || f0600_id_accion || '-' as path, 
      f0600_id_accion_principal as id_rpf_ppal,
      tb0100_estructura_mantenimiento.f0100_codigo as codigo,
      tb0100_estructura_mantenimiento.f0100_nombre as estructura,
      COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) as elemento_primario,
      f0600_descripcion as descripcion,
      f0609_mef as mef,
      f0603_descriptor_estado as estado,
      to_char(f0600_fecha_emision, 'YYYY-MM-DD HH12:MI AM') as fecha_registro,
      to_char(coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision), 'YYYY-MM-DD HH12:MI AM') as fecha_ocurrencia,
      to_char(f0600_fecha_reporte_encargado, 'YYYY-MM-DD HH12:MI AM') as fecha_reporte,
      to_char(f0600_fecha_inicio_correctivo, 'YYYY-MM-DD HH12:MI AM') as fecha_ini_correctivo,
      to_char(f0600_fecha_cierre_correctivo, 'YYYY-MM-DD HH12:MI AM') as fecha_fin_correctivo,
      to_char(f0600_fecha_limite, 'YYYY-MM-DD HH12:MI AM') as fecha_limite,
      to_char(f0600_fecha_cierre, 'YYYY-MM-DD HH12:MI AM') as fecha_cierre,
      to_char(coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision), 'YYYY') as año,
      to_char(coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision), 'YYYY-MM') as mes,
      to_char(coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision), 'YYYY-MM-DD') as dia,
      extract(week from coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)::date) as semana,
      EXTRACT(epoch FROM coalesce(f0600_fecha_cierre_correctivo, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)) 
              - coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision))/3600 as t_perdido,
      tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable,
      tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador,
      f0600_nivel_cumplimiento || '%' as avance,
      f0107_tipo_estructura as tipo_elemento
from $df001$.tb0600_acciones
     join $df001$.tb0100_estructura_mantenimiento
        on f0100_id_estructura = f0600_id_estructura
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
     join $df001$.tb0609_modos_efectos_falla
        on f0600_id_mef = f0609_id_mef
where f0600_id_cia = '$001$' and f0600_anulado = 'N' and f0600_id_tipo_registro = '01' and
     f0600_id_fuente_accion = '$002$' and f0603_estado = $003$ and
     substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' from 1 for 
               char_length('$004$')) = '$004$'
order by f0600_fecha_ocurrencia_evento
