DELETE FROM camocontrol.tb0850_remisiones_cguno_encabezado
	WHERE f0850_id_rm > 94595;

UPDATE camocontrol.tb0200_terceros
	SET f0200_id_sucursal_unoee = null
	where f0200_id_sucursal_unoee is not null;

select * from camocontrol.tb0200_terceros
where f0200_id_sucursal_unoee is not null