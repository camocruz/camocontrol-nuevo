 SELECT row_number() OVER (PARTITION BY vi0600_proyectos_mantenimiento.ndce ORDER BY tb0600_acciones.f0600_fecha_inicio) AS indice,
    tb0600_acciones.f0600_id_accion AS id_acc,
    (tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text AS path,
    COALESCE(tb0600_acciones.f0600_id_accion_principal, tb0600_acciones.f0600_id_accion) AS plan_accion,
        CASE COALESCE(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0)
            WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre::text
            WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre::text
            ELSE (otb_maquina.f0100_nombre::text || ' =>> '::text) || tb0100_estructura_mantenimiento.f0100_nombre::text
        END AS estructura_maquina,
    ("substring"(tb_responsable.f0200_apellido1::text, 1, 2) || '-'::text) || "substring"(tb_responsable.f0200_nombres::text, 1, 2) AS responsable,
    tb0600_acciones.f0600_nivel_cumplimiento::integer AS avance,
    "substring"(tb0603_estados_acciones.f0603_descriptor_estado::text, 1, 3) AS estado,
	case tb0600_acciones.f0600_id_tipo_registro
		when '02'::bpchar THEN 'Porque: '
		else ''
	end || (((((((((((replace(replace(tb0600_acciones.f0600_titulo::text, chr(10), '.  '::text), chr(13), ''::text) || ' => '::text) || replace(replace(tb0600_acciones.f0600_descripcion, chr(10), '.  '::text), chr(13), ''::text)) || ' ('::text) || tb0600_acciones.f0600_path::text) || tb0600_acciones.f0600_id_accion) || '-'::text) || ')'::text) || ' {'::text) || upper(tb0602_tipos_acciones.f0602_descriptor_tipo::text)) || ' = '::text) || upper(tb0601_fuentes_acciones.f0601_descriptor_fuente::text)) || '}'::text AS tit_descripcion,
    to_char(tb0600_acciones.f0600_fecha_inicio, 'DD-MM-YY HH:MI'::text)::timestamp without time zone AS fecha_inicio,
    to_char(tb0600_acciones.f0600_fecha_limite, 'DD-MM-YY HH:MI'::text)::timestamp without time zone AS fecha_final,
        CASE tb0600_acciones.f0600_id_estado_accion
            WHEN '01'::bpchar THEN 4
            WHEN '03'::bpchar THEN 3
            WHEN '07'::bpchar THEN 2
            WHEN '08'::bpchar THEN 1
            ELSE 4
        END AS kpiest,
    tb0600_acciones.f0600_id_tipo_registro,
    replace(replace(tb0600_acciones.f0600_titulo::text, chr(10), '.  '::text), chr(13), ''::text) AS titulo,
    replace(replace(tb0600_acciones.f0600_descripcion, chr(10), '.  '::text), chr(13), ''::text) AS descripcion,
    vi0100_idestructura_planta.planta,
    tb0600_acciones.f0600_presupuesto AS presupuesto,
    tb0600_acciones.f0600_id_fuente_accion as id_fuente,
    tb0601_fuentes_acciones.f0601_descriptor_fuente as fuente
   FROM camocontrol.tb0600_acciones
     LEFT JOIN camocontrol.tb0601_fuentes_acciones ON tb0600_acciones.f0600_id_fuente_accion = tb0601_fuentes_acciones.f0601_id_fuente
     left JOIN camocontrol.tb0100_estructura_mantenimiento ON tb0100_estructura_mantenimiento.f0100_id_estructura = tb0600_acciones.f0600_id_estructura
     LEFT JOIN camocontrol.tb0107_tipos_estructura ON tb0100_estructura_mantenimiento.f0100_id_tipo_estructura = tb0107_tipos_estructura.f0107_id_tipo_estructura
     LEFT JOIN camocontrol.tb0100_estructura_mantenimiento otb_maquina ON otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     LEFT JOIN camocontrol.tb0002_unidades_medicion ON tb0600_acciones.f0600_unidad_duracion = tb0002_unidades_medicion.f0002_id_unidad_medicion
     LEFT JOIN camocontrol.tb0603_estados_acciones ON tb0600_acciones.f0600_id_estado_accion = tb0603_estados_acciones.f0603_id_estado_accion
     LEFT JOIN camocontrol.tb0602_tipos_acciones ON tb0600_acciones.f0600_id_tipo_accion = tb0602_tipos_acciones.f0602_id_tipo_accion
     LEFT JOIN camocontrol.tb0200_terceros tb_responsable ON tb0600_acciones.f0600_responsable = tb_responsable.f0200_id_tercero
     LEFT JOIN camocontrol.tb0200_terceros tb_evaluador ON tb0600_acciones.f0600_evaluador = tb_evaluador.f0200_id_tercero
     LEFT JOIN camocontrol.vi0600_proyectos_mantenimiento ON vi0600_proyectos_mantenimiento.id_acc = tb0600_acciones.f0600_id_accion_principal
     LEFT JOIN camocontrol.vi0100_idestructura_planta ON vi0100_idestructura_planta.id = tb0600_acciones.f0600_id_estructura
  WHERE (tb0600_acciones.f0600_id_tipo_registro = ANY (ARRAY['01'::bpchar, '03'::bpchar, '02'::bpchar])) AND tb0600_acciones.f0600_anulado = 'N'::bpchar
  		AND COALESCE(tb0600_acciones.f0600_id_accion_principal, tb0600_acciones.f0600_id_accion)
		= 27442
  ORDER BY tb0600_acciones.f0600_fecha_inicio;