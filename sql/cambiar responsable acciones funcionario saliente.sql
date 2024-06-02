UPDATE camocontrol.tb0600_acciones
   SET f0600_responsable='00000735', f0600_id_estado_accion='01' -- 01 estado sin notificar
 WHERE f0600_responsable='00000012' and f0600_id_estado_accion <> '08' -- 08 estado cerrado
