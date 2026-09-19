WITH estructura_planta AS (
    SELECT e.f0100_id_estructura AS id,
           p.f0100_nombre AS planta
    FROM camocontrol.tb0100_estructura_mantenimiento e
    CROSS JOIN LATERAL string_to_array(e.f0100_path, '-') AS arr
    LEFT JOIN camocontrol.tb0100_estructura_mantenimiento p
           ON p.f0100_id_estructura = NULLIF(arr[2], '')::integer
    WHERE e.f0100_id_cia = '00000001'
      AND e.f0100_anulado = 'N'
      AND array_length(arr, 1) > 1
)
SELECT tb0100_estructura_mantenimiento.f0100_id_estructura AS id,
    tb0100_estructura_mantenimiento.f0100_nombre || ' (' || tb0100_estructura_mantenimiento.f0100_id_estructura || ')' AS nombre,
    replace(replace(tb0100_estructura_mantenimiento.f0100_descripcion::text, chr(10), '.  '::text), chr(13), ''::text) AS descripcion,
    tb0107_tipos_estructura.f0107_tipo_estructura AS tipo,
	COALESCE(otb_maquina.f0100_nombre, tb0100_estructura_mantenimiento.f0100_nombre) AS elemento_primario,
    COALESCE(estructura_planta.planta, tb0100_estructura_mantenimiento.f0100_nombre) AS planta,
    tb0100_estructura_mantenimiento.f0100_path
   FROM camocontrol.tb0100_estructura_mantenimiento
     LEFT JOIN camocontrol.tb0107_tipos_estructura ON tb0107_tipos_estructura.f0107_id_tipo_estructura = tb0100_estructura_mantenimiento.f0100_id_tipo_estructura
     LEFT JOIN estructura_planta ON estructura_planta.id = tb0100_estructura_mantenimiento.f0100_id_estructura
  	 LEFT JOIN camocontrol.tb0100_estructura_mantenimiento otb_maquina ON otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
  WHERE tb0100_estructura_mantenimiento.f0100_id_cia = '00000001'::bpchar AND tb0100_estructura_mantenimiento.f0100_anulado = 'N'::bpchar
  ORDER BY (COALESCE(estructura_planta.planta, tb0100_estructura_mantenimiento.f0100_nombre)), tb0100_estructura_mantenimiento.f0100_nombre;
