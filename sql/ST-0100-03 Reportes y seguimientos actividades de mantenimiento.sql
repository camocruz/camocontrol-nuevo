select f0600_id_accion as id_acc,
     tb0100_estructura_mantenimiento.f0100_codigo as codigo,
     tb0100_estructura_mantenimiento.f0100_nombre as estructura,
     COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) as elemento_primario,
     f0600_descripcion as descripcion,
     f0603_descriptor_estado as estado,
     f0602_descriptor_tipo as t_actividad,
     f0606_id_seguimiento_accion as id_seg_acc,
     f0606_seguimiento_accion as seguimiento,
     tb0200_terceros.f0200_apellido1 || ' ' || tb0200_terceros.f0200_apellido2 || ' ' || tb0200_terceros.f0200_nombres as funcionario,
     to_number(f0606_nivel_cumplimiento, '999') || '%' as cumplimiento,
     to_char(f0606_fecha_inicio, 'YYYY-MM-DD HH12:MI AM') as fecha_inicio,
     to_char(f0606_fecha_fin, 'YYYY-MM-DD HH12:MI AM') as fecha_fin,
     to_char(f0606_fecha_inicio, 'YYYY-MM-DD HH12:MI AM') || ' a ' || to_char(f0606_fecha_fin, 'YYYY-MM-DD HH12:MI AM') ||
             ' ---- Restar: ' || f0607_tiempo_restar || ' minutos' || ' ---- ' ||
             EXTRACT(DAY FROM f0606_fecha_fin - f0606_fecha_inicio) || ' dias ' ||
             EXTRACT(HOUR FROM f0606_fecha_fin - f0606_fecha_inicio) || ' horas ' ||
             EXTRACT(MINUTE FROM f0606_fecha_fin - f0606_fecha_inicio) || ' minutos' as tiempo_reportado,
     f0600_path || f0600_id_accion || '-' as path
from camocontrol.tb0600_acciones
     join camocontrol.tb0100_estructura_mantenimiento
        on f0100_id_estructura = f0600_id_estructura
     left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
        on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     join camocontrol.tb0002_unidades_medicion
        on f0600_unidad_duracion = f0002_id_unidad_medicion
     join camocontrol.tb0603_estados_acciones
        on f0600_id_estado_accion = f0603_id_estado_accion
     join camocontrol.tb0602_tipos_acciones
        on f0600_id_tipo_accion = f0602_id_tipo_accion
     join camocontrol.tb0606_seguimientos_acciones
        on f0600_id_accion = f0606_id_documento
     join camocontrol.tb0607_seg_acc_personal
        on f0606_id_seguimiento_accion = f0607_id_seguimiento_accion
     join camocontrol.tb0200_terceros
        on f0607_id_tercero = f0200_id_tercero
where f0606_tipo_nota = 'ACC' and f0600_id_cia = '00000001' and f0600_id_tipo_registro = '03' and f0600_anulado = 'N' 
     and f0606_fecha_fin BETWEEN '2015-07-01' AND '2015-08-08' 
     and f0606_id_tipo_seguimiento = f0606_id_tipo_seguimiento 
     and substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' 
                   from 1 for char_length('46-')) = '46-'
     order by f0606_fecha_inicio