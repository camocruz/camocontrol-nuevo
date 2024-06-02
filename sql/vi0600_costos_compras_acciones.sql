-- Materialized View: camocontrol.vi0600_costos_compras_acciones

-- DROP MATERIALIZED VIEW camocontrol.vi0600_costos_compras_acciones;

CREATE MATERIALIZED VIEW camocontrol.vi0600_costos_compras_acciones AS 
 SELECT tb0600_acciones.f0600_id_accion AS fvi0600_id_accion,
    (tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text AS path_accion,
    COALESCE(unit.vi_costo, 0::numeric) AS costo_individual,
    sum(unif.vi_costo) AS costo_acumulado
   FROM camocontrol.tb0600_acciones
     LEFT JOIN camocontrol.vi0600_compras_acciones unit ON tb0600_acciones.f0600_id_accion = unit.vi_id_accion
     LEFT JOIN camocontrol.vi0600_compras_acciones unif ON "substring"(unif.vi_path, 1, char_length((tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text)) = ((tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text)
  GROUP BY tb0600_acciones.f0600_id_accion, (tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text, unit.vi_costo
  ORDER BY (tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text
WITH DATA;

ALTER TABLE camocontrol.vi0600_costos_compras_acciones
  OWNER TO postgres;
