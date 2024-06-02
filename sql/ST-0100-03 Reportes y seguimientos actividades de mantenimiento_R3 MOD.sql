with asistencia_personal as (
select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre,
       f0211_codigo_empleado, to_char(f0211_fecha, 'YYYY-MM-DD') as dia, 
       min(f0211_fecha) as minfecha, max(f0211_fecha) as maxfecha,
       extract(epoch from max(f0211_fecha) - min(f0211_fecha)) / 3600 as h
FROM $df001$.tb0211_personal_registros_reloj
     left join $df001$.tb0200_terceros
        on f0211_codigo_empleado = f0200_codigo_empleado
where f0211_fecha BETWEEN '$003$' AND '$004$' 
group by f0200_id_tercero, nombre, f0211_codigo_empleado, dia
order by f0211_codigo_empleado, dia)

select f0600_id_accion as id_acc,
     f0600_path || f0600_id_accion || '-' as path,
     otb_tercero_resp.f0200_apellido1 || ' ' || otb_tercero_resp.f0200_apellido2 || ' ' || otb_tercero_resp.f0200_nombres as responsable,
     tb0100_estructura_mantenimiento.f0100_codigo as codigo,
     tb0100_estructura_mantenimiento.f0100_nombre as estructura,
     COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) as elemento_primario,
     f0600_descripcion as descripcion,
     f0603_descriptor_estado as estado,
     f0602_descriptor_tipo as t_actividad,
     f0606_id_seguimiento_accion as id_seg_acc,
     f0606_seguimiento_accion as seguimiento,
     otb_tercero_act.f0200_apellido1 || ' ' || otb_tercero_act.f0200_apellido2 || ' ' || otb_tercero_act.f0200_nombres as funcionario,
     to_number(f0606_nivel_cumplimiento, '999') || '%' as cumplimiento,
     to_char(f0606_fecha_inicio, 'YYYY-MM-DD HH12:MI AM') as fecha_inicio,
     to_char(f0606_fecha_fin, 'YYYY-MM-DD HH12:MI AM') as fecha_fin,
     to_char(f0606_fecha_inicio, 'YYYY') as año,
     to_char(f0606_fecha_inicio, 'YYYY-MM') as mes,
     to_char(f0606_fecha_inicio, 'YYYY-MM-DD') as dia,
     extract(week from f0606_fecha_inicio::date) as semana,
     round((EXTRACT(epoch FROM f0606_fecha_fin - f0606_fecha_inicio)/3600 - f0607_tiempo_restar/60)::decimal, 2) as t_h_intervencion,
     round(f0607_tiempo_extra/60.0 , 2) as h_extras,
     f0607_extra_dominical as extras_dom,
     minfecha as ent_reloj, maxfecha as sal_reloj, round(h::decimal , 2) as t_reloj
from $df001$.tb0600_acciones
     join $df001$.tb0200_terceros as otb_tercero_resp
        on f0600_responsable = otb_tercero_resp.f0200_id_tercero
     join $df001$.tb0100_estructura_mantenimiento
        on f0100_id_estructura = f0600_id_estructura
     left join $df001$.tb0100_estructura_mantenimiento as otb_maquina
        on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     join $df001$.tb0002_unidades_medicion
        on f0600_unidad_duracion = f0002_id_unidad_medicion
     join $df001$.tb0603_estados_acciones
        on f0600_id_estado_accion = f0603_id_estado_accion
     join $df001$.tb0602_tipos_acciones
        on f0600_id_tipo_accion = f0602_id_tipo_accion
        
     join $df001$.tb0606_seguimientos_acciones
        on f0600_id_accion = f0606_id_documento
     join $df001$.tb0607_seg_acc_personal
        on f0606_id_seguimiento_accion = f0607_id_seguimiento_accion and f0607_anulado = 'N'
     join $df001$.tb0200_terceros as otb_tercero_act
        on f0607_id_tercero = otb_tercero_act.f0200_id_tercero
     left join asistencia_personal
        on f0607_id_tercero = asistencia_personal.f0200_id_tercero 
           and to_char(f0606_fecha_inicio, 'YYYY-MM-DD') = asistencia_personal.dia

where f0606_tipo_nota = '$001$' and f0600_id_cia = '$002$' and f0600_id_tipo_registro = '03' and f0600_anulado = 'N' 
     and f0606_fecha_fin BETWEEN '$003$' AND '$004$' 
     and f0606_id_tipo_seguimiento = $005$ 
     and substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' 
                   from 1 for char_length('$006$')) = '$006$'
     order by f0606_fecha_inicio