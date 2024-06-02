-- Function: camocontrol.fnc_auditoria()

-- DROP FUNCTION camocontrol.fnc_auditoria();

CREATE OR REPLACE FUNCTION camocontrol.fnc_300_01_actualizar_inventarios_movimientos()
  RETURNS trigger AS
$BODY$
BEGIN
  update camocontrol.tb0309_items_movimientos set f0309_inventario = 100;
    --(select coalesce(sum(f0309_entrada) - sum(f0309_salida),0) as inventario
    --   from camocontrol.tb0309_items_movimientos
    -- where f0309_id_bodega = NEW.f0309_id_bodega and f0309_id_item = NEW.f0309_id_item
    --   and f0309_fecha_movimiento < NEW.f0309_fecha_movimiento
    --   and f0309_anulado = 'N');
  RETURN NEW;
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION camocontrol.fnc_300_01_actualizar_inventarios_movimientos()
  OWNER TO camo;


