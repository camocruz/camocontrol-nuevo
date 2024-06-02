update camocontrol.tb0305_items_solicitados set
  f0305_planta_compra = planta
  from camocontrol.vi0100_idestructura_planta
  where f0305_id_estructura = id AND f0305_planta_compra is null
  
-- Actualizar planta en compras antiguas
with tb as (
select f0600_id_accion, f0600_id_accion_principal
from camocontrol.tb0600_acciones
)

UPDATE camocontrol.tb0305_items_solicitados
	SET f0305_planta_compra='PLANTA 2'
from tb
WHERE f0305_id_accion = tb.f0600_id_accion and tb.f0600_id_accion_principal = 15527;