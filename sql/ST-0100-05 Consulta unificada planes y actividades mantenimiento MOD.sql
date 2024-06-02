select f0605_descriptor_tipo_registro as tipo,
       f0601_descriptor_fuente as fuente,
       f0600_id_accion as id_accion,
       f0600_path || f0600_id_accion || '-' as path,
       tb0100_estructura_mantenimiento.f0100_codigo as codigo,
       tb0100_estructura_mantenimiento.f0100_nombre as estructura,
       COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) as elemento_primario,
       case f0600_titulo when '' then f0609_mef else f0600_titulo end as titulo,
       f0600_descripcion as descripcion,
       f0603_descriptor_estado as estado,
       f0602_descriptor_tipo as t_actividad,
       to_char(coalesce(f0600_fecha_inicio, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)), 'YYYY-MM-DD HH12:MI AM') as f_inicio,
       to_char(coalesce(f0600_fecha_inicio, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)), 'YYYY-MM-DD') as dia_inicio,
       to_char(coalesce(f0600_fecha_inicio, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)), 'HH12:MI AM') as h_inicio,
       to_char(coalesce(f0600_fecha_inicio, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)), 'YYYY') as año_inicio,
       to_char(coalesce(f0600_fecha_inicio, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision)), 'YYYY-MM') as mes_inicio,
       extract(week from coalesce(f0600_fecha_inicio, coalesce(f0600_fecha_ocurrencia_evento, f0600_fecha_emision))::date) as semana_inicio,
       to_char(f0600_fecha_limite, 'YYYY-MM-DD HH12:MI AM') as f_fin,
       tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable,
       tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador,
       f0600_nivel_cumplimiento || '%' as avance,
       f0107_tipo_estructura as tipo_elemento
from $df001$.tb0600_acciones
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
       join $df001$.tb0601_fuentes_acciones
            on f0600_id_fuente_accion = f0601_id_fuente
       join $df001$.tb0605_tipos_registro_acciones
            on f0600_id_tipo_registro = f0605_id_tipo_registro
       join $df001$.tb0609_modos_efectos_falla
            on f0600_id_mef = f0609_id_mef
       join $df001$.tb0200_terceros as tb_responsable
            on f0600_responsable = tb_responsable.f0200_id_tercero
       join $df001$.tb0200_terceros as tb_evaluador
            on f0600_evaluador = tb_evaluador.f0200_id_tercero
where f0600_id_cia = '$001$' and f0600_anulado = 'N' and
       f0603_estado = $002$ AND
       (f0600_id_tipo_registro = '01' or f0600_id_tipo_registro = '03') and
       substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' 
                 from 1 for char_length('$003$')) = '$003$'
order by f0600_fecha_inicio