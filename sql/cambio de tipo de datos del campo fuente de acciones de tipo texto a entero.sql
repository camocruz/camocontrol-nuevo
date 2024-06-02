-- Agrego la nueva columna
ALTER TABLE IF EXISTS camocontrol.tb0600_acciones
    ADD COLUMN f0600_id_subfuente integer default 0;

-- Primero borro las vistas relacionadas
DROP VIEW camocontrol.vi0600_listado_acciones;
DROP VIEW camocontrol.vi0600_programacion_mantenimiento_0100_06;

-- Cambio el tipo de datos de las tablas
ALTER TABLE camocontrol.tb0600_acciones
    ALTER COLUMN f0600_id_fuente_accion set data TYPE integer USING f0600_id_fuente_accion::integer;
	
ALTER TABLE camocontrol.tb0601_fuentes_acciones
    ALTER COLUMN f0601_id_fuente set data TYPE integer USING f0601_id_fuente::integer;
	
-- View: camocontrol.vi0600_listado_acciones

-- 

CREATE OR REPLACE VIEW camocontrol.vi0600_listado_acciones
 AS
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
    (((((((((((replace(replace(tb0600_acciones.f0600_titulo::text, chr(10), '.  '::text), chr(13), ''::text) || ' => '::text) || replace(replace(tb0600_acciones.f0600_descripcion, chr(10), '.  '::text), chr(13), ''::text)) || ' ('::text) || tb0600_acciones.f0600_path::text) || tb0600_acciones.f0600_id_accion) || '-'::text) || ')'::text) || ' {'::text) || upper(tb0602_tipos_acciones.f0602_descriptor_tipo::text)) || ' = '::text) || upper(tb0601_fuentes_acciones.f0601_descriptor_fuente::text)) || '}'::text AS tit_descripcion,
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
    tb0600_acciones.f0600_presupuesto AS presupuesto
   FROM camocontrol.tb0600_acciones
     LEFT JOIN camocontrol.tb0601_fuentes_acciones ON tb0600_acciones.f0600_id_fuente_accion = tb0601_fuentes_acciones.f0601_id_fuente
     JOIN camocontrol.tb0100_estructura_mantenimiento ON tb0100_estructura_mantenimiento.f0100_id_estructura = tb0600_acciones.f0600_id_estructura
     LEFT JOIN camocontrol.tb0107_tipos_estructura ON tb0100_estructura_mantenimiento.f0100_id_tipo_estructura = tb0107_tipos_estructura.f0107_id_tipo_estructura
     LEFT JOIN camocontrol.tb0100_estructura_mantenimiento otb_maquina ON otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     LEFT JOIN camocontrol.tb0002_unidades_medicion ON tb0600_acciones.f0600_unidad_duracion = tb0002_unidades_medicion.f0002_id_unidad_medicion
     LEFT JOIN camocontrol.tb0603_estados_acciones ON tb0600_acciones.f0600_id_estado_accion = tb0603_estados_acciones.f0603_id_estado_accion
     LEFT JOIN camocontrol.tb0602_tipos_acciones ON tb0600_acciones.f0600_id_tipo_accion = tb0602_tipos_acciones.f0602_id_tipo_accion
     LEFT JOIN camocontrol.tb0200_terceros tb_responsable ON tb0600_acciones.f0600_responsable = tb_responsable.f0200_id_tercero
     LEFT JOIN camocontrol.tb0200_terceros tb_evaluador ON tb0600_acciones.f0600_evaluador = tb_evaluador.f0200_id_tercero
     LEFT JOIN camocontrol.vi0600_proyectos_mantenimiento ON vi0600_proyectos_mantenimiento.id_acc = tb0600_acciones.f0600_id_accion_principal
     LEFT JOIN camocontrol.vi0100_idestructura_planta ON vi0100_idestructura_planta.id = tb0600_acciones.f0600_id_estructura
  WHERE (tb0600_acciones.f0600_id_tipo_registro = ANY (ARRAY['01'::bpchar, '03'::bpchar])) AND tb0600_acciones.f0600_anulado = 'N'::bpchar
  ORDER BY tb0600_acciones.f0600_fecha_inicio;

ALTER TABLE camocontrol.vi0600_listado_acciones
    OWNER TO camo;
	
-- 

CREATE OR REPLACE VIEW camocontrol.vi0600_programacion_mantenimiento_0100_06
 AS
 SELECT tb0600_acciones.f0600_id_accion AS id_acc,
    COALESCE(tb0600_acciones.f0600_id_accion_principal, 0) AS plan_accion,
    tb0100_estructura_mantenimiento.f0100_codigo AS codigo,
    tb0100_estructura_mantenimiento.f0100_nombre AS estructura,
    COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) AS elemento_primario,
    replace(replace(tb0600_acciones.f0600_titulo::text, chr(10), '.  '::text), chr(13), ''::text) AS titulo,
    replace(replace(tb0600_acciones.f0600_descripcion, chr(10), '.  '::text), chr(13), ''::text) AS descripcion,
    "substring"(tb0603_estados_acciones.f0603_descriptor_estado::text, 1, 3) AS estado,
    tb0602_tipos_acciones.f0602_descriptor_tipo AS t_actividad,
    to_char(tb0600_acciones.f0600_fecha_inicio, 'YYYY-MM-DD'::text) AS f_inicio,
    to_char(tb0600_acciones.f0600_fecha_inicio, 'HH12:MI AM'::text) AS h_inicio,
    to_char(tb0600_acciones.f0600_fecha_inicio, 'YYYY'::text) AS "año_inicio",
    to_char(tb0600_acciones.f0600_fecha_inicio, 'YYYY-MM'::text) AS mes_inicio,
    date_part('week'::text, tb0600_acciones.f0600_fecha_inicio::date) AS semana_inicio,
    tb0600_acciones.f0600_duracion AS duracion,
    tb0002_unidades_medicion.f0002_unidad_medicion AS und,
    to_char(tb0600_acciones.f0600_fecha_limite, 'YYYY-MM-DD'::text) AS f_fin,
    to_char(tb0600_acciones.f0600_fecha_limite, 'HH12:MI AM'::text) AS h_fin,
    (tb_responsable.f0200_apellido1::text || ' '::text) || "substring"(tb_responsable.f0200_nombres::text, 1, 8) AS responsable,
    (((tb_evaluador.f0200_apellido1::text || ' '::text) || tb_evaluador.f0200_apellido2::text) || ' '::text) || tb_evaluador.f0200_nombres::text AS evaluador,
    tb0600_acciones.f0600_nivel_cumplimiento::text || '%'::text AS avance,
    tb0107_tipos_estructura.f0107_tipo_estructura AS tipo_elemento,
    (tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text AS path,
    to_char(tb0600_acciones.f0600_fecha_emision, 'YYYY-MM-DD'::text) AS f_emision,
    to_char(tb0600_acciones.f0600_fecha_emision, 'YYYY-MM'::text) AS mes_emision,
        CASE COALESCE(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0)
            WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre::text
            WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre::text
            ELSE (otb_maquina.f0100_nombre::text || ' =>> '::text) || tb0100_estructura_mantenimiento.f0100_nombre::text
        END AS estructura_maquina,
    (((((((((((replace(replace(tb0600_acciones.f0600_titulo::text, chr(10), '.  '::text), chr(13), ''::text) || ' => '::text) || replace(replace(tb0600_acciones.f0600_descripcion, chr(10), '.  '::text), chr(13), ''::text)) || ' ('::text) || tb0600_acciones.f0600_path::text) || tb0600_acciones.f0600_id_accion) || '-'::text) || ')'::text) || ' {'::text) || upper(tb0602_tipos_acciones.f0602_descriptor_tipo::text)) || ' = '::text) || upper(tb0601_fuentes_acciones.f0601_descriptor_fuente::text)) || '}'::text AS tit_descripcion,
    upper(tb0601_fuentes_acciones.f0601_descriptor_fuente::text) AS fuente,
    COALESCE(vi0100_idestructura_planta.planta, tb0100_estructura_mantenimiento.f0100_nombre) AS planta,
    tb0600_acciones.f0600_proyinfra AS proyinfra,
    tb0600_acciones.f0600_proy_tip_act AS clp
   FROM camocontrol.tb0600_acciones
     LEFT JOIN camocontrol.tb0601_fuentes_acciones ON tb0600_acciones.f0600_id_fuente_accion = tb0601_fuentes_acciones.f0601_id_fuente
     JOIN camocontrol.tb0100_estructura_mantenimiento ON tb0100_estructura_mantenimiento.f0100_id_estructura = tb0600_acciones.f0600_id_estructura
     LEFT JOIN camocontrol.tb0107_tipos_estructura ON tb0100_estructura_mantenimiento.f0100_id_tipo_estructura = tb0107_tipos_estructura.f0107_id_tipo_estructura
     LEFT JOIN camocontrol.tb0100_estructura_mantenimiento otb_maquina ON otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
     LEFT JOIN camocontrol.tb0002_unidades_medicion ON tb0600_acciones.f0600_unidad_duracion = tb0002_unidades_medicion.f0002_id_unidad_medicion
     LEFT JOIN camocontrol.tb0603_estados_acciones ON tb0600_acciones.f0600_id_estado_accion = tb0603_estados_acciones.f0603_id_estado_accion
     LEFT JOIN camocontrol.tb0602_tipos_acciones ON tb0600_acciones.f0600_id_tipo_accion = tb0602_tipos_acciones.f0602_id_tipo_accion
     LEFT JOIN camocontrol.tb0200_terceros tb_responsable ON tb0600_acciones.f0600_responsable = tb_responsable.f0200_id_tercero
     LEFT JOIN camocontrol.tb0200_terceros tb_evaluador ON tb0600_acciones.f0600_evaluador = tb_evaluador.f0200_id_tercero
     LEFT JOIN camocontrol.vi0100_idestructura_planta ON vi0100_idestructura_planta.id = tb0100_estructura_mantenimiento.f0100_id_estructura
  WHERE tb0600_acciones.f0600_id_cia = '00000001'::bpchar AND tb0600_acciones.f0600_anulado = 'N'::bpchar AND tb0600_acciones.f0600_id_tipo_registro = '03'::bpchar AND tb0600_acciones.f0600_id_estructura IS NOT NULL AND tb0600_acciones.f0600_fecha_inicio > '2018-01-01 00:00:00'::timestamp without time zone AND "substring"((tb0100_estructura_mantenimiento.f0100_path::text || tb0100_estructura_mantenimiento.f0100_id_estructura) || '-'::text, 1, char_length('46-'::text)) = '46-'::text
  ORDER BY tb0600_acciones.f0600_fecha_inicio;

ALTER TABLE camocontrol.vi0600_programacion_mantenimiento_0100_06
    OWNER TO camo;