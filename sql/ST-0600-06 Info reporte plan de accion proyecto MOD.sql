SELECT f0600_id_accion as id_actividad, f0600_path || f0600_id_accion || '-' as path,
       CASE coalesce(elemento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN elemento.f0100_nombre
          WHEN elemento.f0100_id_estructura THEN elemento.f0100_nombre 
          else
          maquina.f0100_nombre || ' =>> ' || elemento.f0100_nombre
       end as estructura, f0600_id_fuente_accion as id_fuente,
       upper(f0601_descriptor_fuente) as fuente,
       tb0609_modos_efectos_falla.f0609_mef as mef,
       tb_mef_causa.f0609_mef as mef_causa,
       f0600_titulo as titulo, f0600_descripcion as descripcion,
       f0600_nivel_cumplimiento || '%' as cumplimiento, upper(f0603_descriptor_estado) as estado,
       f0600_id_tipo_registro as id_tipo_registro, f0605_descriptor_tipo_registro as tipo_registro,
       f0600_id_tipo_accion as id_tipo_accion, upper(f0602_descriptor_tipo) as tipo_accion,
       f0600_duracion as duracion, f0002_unidad_medicion as unidad_duracion,
       f0600_fecha_emision as f_emision, f0600_fecha_inicio as f_inicio, f0600_fecha_limite as f_limite,
       f0600_fecha_reporte_encargado as f_reporte_encargado, f0600_fecha_ocurrencia_evento as f_ocurrencia,
       f0600_fecha_cierre_correctivo as f_cierre_correctivo,
       tb_quien.f0200_apellido1 || ' ' || tb_quien.f0200_apellido2 || ' ' || tb_quien.f0200_nombres as quien,
       tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador,
       tb_emisor.f0200_apellido1 || ' ' || tb_emisor.f0200_apellido2 || ' ' || tb_emisor.f0200_nombres as emisor
  FROM $df001$.tb0600_acciones
   left join $df001$.tb0100_estructura_mantenimiento as elemento
      on f0600_id_estructura = elemento.f0100_id_estructura
   left join $df001$.tb0100_estructura_mantenimiento as maquina
      on maquina.f0100_id_estructura = elemento.f0100_id_maquina_padre
   left join $df001$.tb0601_fuentes_acciones
      on f0600_id_fuente_accion = f0601_id_fuente
   left join $df001$.tb0603_estados_acciones
      on f0600_id_estado_accion = f0603_id_estado_accion
   left join $df001$.tb0605_tipos_registro_acciones
      on f0600_id_tipo_registro = f0605_id_tipo_registro
   left join $df001$.tb0602_tipos_acciones
      on f0600_id_tipo_accion = f0602_id_tipo_accion
   left join $df001$.tb0002_unidades_medicion
      on f0600_unidad_duracion = f0002_id_unidad_medicion
   left join $df001$.tb0200_terceros as tb_quien
      on f0600_responsable = tb_quien.f0200_id_tercero
   left join $df001$.tb0200_terceros as tb_evaluador
      on f0600_evaluador = tb_evaluador.f0200_id_tercero
   left join $df001$.tb0200_terceros as tb_emisor
      on f0600_emisor = tb_emisor.f0200_id_tercero
   left join $df001$.tb0609_modos_efectos_falla
      on f0600_id_mef = tb0609_modos_efectos_falla.f0609_id_mef
   left join $df001$.tb0609_modos_efectos_falla as tb_mef_causa
     on f0600_id_mef_causa = tb_mef_causa.f0609_id_mef
  where f0600_id_cia = '$001$' and f0600_id_accion = '$002$'
