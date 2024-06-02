-- CAMBIO DE ESTADO DE UNA ACCION
UPDATE camocontrol.tb0600_acciones
   SET f0600_id_estado_accion='08',
   f0600_repetitiva = 'S',
   f0600_repeticion_programada = 'S'
 WHERE f0600_id_accion = 19039

 --WHERE f0600_nivel_cumplimiento <> '100' and f0600_id_estado_accion='06'

UPDATE camocontrol.tb0600_acciones
   SET f0600_id_estado_accion='14', -- 03 IMPLEMENTACION, 06 SEG CIERRE, 08 CERRADA, 09 ANULADA, 14 CANCELADA
   f0600_nivel_cumplimiento='000'
 WHERE f0600_id_accion = 15632

-- CAMBIAR LA FECHA LIMITE DE UNA ACCION
UPDATE camocontrol.tb0600_acciones SET
   f0600_id_estado_accion='03',
   f0600_fecha_limite = '2021-07-31'
 WHERE f0600_id_accion = 14776
