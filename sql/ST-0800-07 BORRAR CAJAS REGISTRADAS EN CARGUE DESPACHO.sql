UPDATE camocontrol.tb0421_etiquetas
   SET f0421_id_despacho = null, 
       f0421_fecha_despacho = null, f0421_usuario_despacho = ''
   from camocontrol.tb0420_orden_imp_etiquetas
 WHERE f0420_id_impresion = f0421_id_impresion
       and f0421_id_despacho = '987' and f0420_id_producto = '2567'
