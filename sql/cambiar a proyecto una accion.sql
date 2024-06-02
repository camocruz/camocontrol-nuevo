-- Convertir en raiz una accion
  update camocontrol.tb0600_acciones set
       f0600_id_accion_padre = null,
       f0600_id_accion_principal = null,
       f0600_path = '-'
    where f0600_id_accion = 13764

-- Cambiar el evaluador de una accion.
update camocontrol.tb0600_acciones set
	f0600_evaluador = '00000004'
where f0600_id_accion = 21617

-- Convertir en proyecto una accion
UPDATE camocontrol.tb0600_acciones
   SET f0600_proyinfra = 'S' -- estado cerrada
 WHERE f0600_id_accion = 22190


-- CoLOCARLE TITULO A UN PROYECTO
UPDATE camocontrol.tb0600_acciones
   SET f0600_titulo = 'CAMBIO DE FORMATO CANDY4 A 25 MM CON CANAL CENTRAL' 
 WHERE f0600_id_accion = 22013