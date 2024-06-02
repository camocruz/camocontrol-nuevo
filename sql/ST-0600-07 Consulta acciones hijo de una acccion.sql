select f0600_id_accion,
       f0600_path,
       f0600_path || f0600_id_accion || '-' as path_completo,
       elemento.f0100_codigo,
       elemento.f0100_nombre,
       elemento.f0100_codigo || ' -- { ' || elemento.f0100_nombre || ' }' as descripcion_codigo,
       CASE coalesce(elemento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN elemento.f0100_nombre
          WHEN elemento.f0100_id_estructura THEN elemento.f0100_nombre 
          else
          maquina.f0100_nombre || ' =>> ' || elemento.f0100_nombre
       end as estructura,
       f0600_titulo,
       f0600_descripcion,
       f0600_nivel_cumplimiento,
       upper(f0603_descriptor_estado) as f0603_descriptor_estado,
       f0600_id_tipo_registro,
       upper(f0605_descriptor_tipo_registro) as f0605_descriptor_tipo_registro,
       f0600_id_tipo_accion,
       upper(f0602_descriptor_tipo) as f0602_descriptor_tipo,
       to_char(f0600_fecha_ocurrencia_evento, 'YYYY-MM-DD HH12:MI AM') as f_ocurrencia,
       to_char(f0600_fecha_inicio, 'YYYY-MM-DD HH12:MI AM') as f_inicio,
       f0600_duracion as duracion,
       f0002_unidad_medicion as und,
       to_char(f0600_fecha_limite, 'YYYY-MM-DD HH12:MI AM') as f_fin,
       tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable,
       tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador
from camocontrol.tb0600_acciones
    left join camocontrol.tb0100_estructura_mantenimiento as elemento
      on f0600_id_estructura = elemento.f0100_id_estructura
   left join camocontrol.tb0100_estructura_mantenimiento as maquina
      on maquina.f0100_id_estructura = elemento.f0100_id_maquina_padre
    left join camocontrol.tb0002_unidades_medicion
       on f0600_unidad_duracion = f0002_id_unidad_medicion
    left join camocontrol.tb0603_estados_acciones
       on f0600_id_estado_accion = f0603_id_estado_accion
    left join camocontrol.tb0602_tipos_acciones
       on f0600_id_tipo_accion = f0602_id_tipo_accion
    left join camocontrol.tb0605_tipos_registro_acciones
       on f0605_id_tipo_registro = f0600_id_tipo_registro
    left join camocontrol.tb0200_terceros as tb_responsable
       on f0600_responsable = tb_responsable.f0200_id_tercero
    left join camocontrol.tb0200_terceros as tb_evaluador
       on f0600_evaluador = tb_evaluador.f0200_id_tercero
where f0600_id_cia = '00000001' and f0600_anulado = 'N' and
    substring(f0600_path from 1 for char_length('-8757-')) = '-8757-'
order by f0600_fecha_inicio, f0600_id_tipo_registro desc, f0600_id_accion

--order by path_completo, f0600_id_tipo_registro desc, f0600_fecha_inicio, f0600_id_accion