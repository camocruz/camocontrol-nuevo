-- Materialized View: camocontrol.vi0600_compras_acciones

-- DROP MATERIALIZED VIEW camocontrol.vi0600_compras_acciones;

CREATE MATERIALIZED VIEW camocontrol.vi0600_compras_acciones AS 
 SELECT tb0600_acciones.f0600_id_accion AS vi_id_accion,
    (tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion) || '-'::text AS vi_path,
    sum(tb0305_items_solicitados.f0305_costo_total_planificado) AS vi_costo
   FROM camocontrol.tb0600_acciones
     JOIN camocontrol.tb0304_solicitud_compra ON tb0600_acciones.f0600_id_accion = tb0304_solicitud_compra.f0304_id_accion
     JOIN camocontrol.tb0305_items_solicitados ON tb0304_solicitud_compra.f0304_id_solicitud = tb0305_items_solicitados.f0305_id_solicitud_compra
  WHERE tb0305_items_solicitados.f0305_id_factura_compras IS NOT NULL
  GROUP BY tb0600_acciones.f0600_path::text || tb0600_acciones.f0600_id_accion, tb0600_acciones.f0600_id_accion
WITH DATA;

ALTER TABLE camocontrol.vi0600_compras_acciones
  OWNER TO postgres;
