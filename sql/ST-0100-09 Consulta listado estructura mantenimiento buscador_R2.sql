WITH estructura_planta AS (
    SELECT e.f0100_id_estructura AS id,
           p.f0100_nombre AS planta
    FROM camocontrol.tb0100_estructura_mantenimiento e
    LEFT JOIN camocontrol.tb0100_estructura_mantenimiento p
           ON p.f0100_id_estructura = split_part(e.f0100_path, '-', 2)::integer
    WHERE e.f0100_id_cia = '00000001'
      AND e.f0100_anulado = 'N'
      AND split_part(e.f0100_path, '-', 2) <> ''
)
SELECT t.f0100_id_estructura AS id,
       t.f0100_codigo AS codigo,
       t.f0100_nombre AS nombre,
       COALESCE(ep.planta, t.f0100_nombre) AS planta
FROM camocontrol.tb0100_estructura_mantenimiento t
LEFT JOIN camocontrol.tb0107_tipos_estructura te
       ON te.f0107_id_tipo_estructura = t.f0100_id_tipo_estructura
LEFT JOIN estructura_planta ep
       ON ep.id = t.f0100_id_estructura
LEFT JOIN camocontrol.tb0100_estructura_mantenimiento otb_maquina
       ON otb_maquina.f0100_id_estructura = t.f0100_id_maquina_padre
WHERE t.f0100_id_cia = '00000001'::bpchar
  AND t.f0100_anulado = 'N'::bpchar
ORDER BY COALESCE(ep.planta, t.f0100_nombre),
         t.f0100_nombre;
