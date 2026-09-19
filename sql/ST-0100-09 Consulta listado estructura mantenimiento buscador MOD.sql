WITH estructura_planta AS (
    SELECT e.f0100_id_estructura AS id,
       p.f0100_nombre AS planta
FROM $df001$.tb0100_estructura_mantenimiento e
LEFT JOIN $df001$.tb0100_estructura_mantenimiento p
       ON p.f0100_id_estructura = split_part(e.f0100_path, '-', 2)::integer
WHERE e.f0100_id_cia = '$001$'
  AND e.f0100_anulado = 'N'
  AND split_part(e.f0100_path, '-', 2) <> ''
)
SELECT tb0100_estructura_mantenimiento.f0100_id_estructura AS id,
    tb0100_estructura_mantenimiento.f0100_nombre AS nombre,
    COALESCE(estructura_planta.planta, tb0100_estructura_mantenimiento.f0100_nombre) AS planta
   FROM $df001$.tb0100_estructura_mantenimiento
     LEFT JOIN $df001$.tb0107_tipos_estructura ON tb0107_tipos_estructura.f0107_id_tipo_estructura = tb0100_estructura_mantenimiento.f0100_id_tipo_estructura
     LEFT JOIN estructura_planta ON estructura_planta.id = tb0100_estructura_mantenimiento.f0100_id_estructura
  	 LEFT JOIN $df001$.tb0100_estructura_mantenimiento otb_maquina ON otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
  WHERE tb0100_estructura_mantenimiento.f0100_id_cia = '$001$'::bpchar AND tb0100_estructura_mantenimiento.f0100_anulado = 'N'::bpchar
  ORDER BY (COALESCE(estructura_planta.planta, tb0100_estructura_mantenimiento.f0100_nombre)), tb0100_estructura_mantenimiento.f0100_nombre;
