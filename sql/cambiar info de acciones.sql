--CAMBIAR LA FUENTE DE ACCION
UPDATE camocontrol.tb0600_acciones
   SET f0600_id_fuente_accion = '00000011'
 WHERE f0600_id_accion = 12832


-- CAMBIAR TIPO DE ACCION
--07 ALISTAMIENTOS PRODUCTIVOS

UPDATE camocontrol.tb0600_acciones
   SET f0600_id_tipo_accion = '07'
 WHERE f0600_id_accion = 21844