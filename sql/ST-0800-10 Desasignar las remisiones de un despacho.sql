UPDATE camocontrol.tb0850_remisiones_cguno_encabezado
   SET f0850_id_despacho=NULL, f0850_fecha_asignacion_despacho=NULL, f0850_usuario_asigna_despacho='',
   f0850_anulado = 'S', f0850_usuario_anular = '00000001', f0850_fm = now()
 WHERE f0850_id_despacho='987'
