UPDATE $df001$.tb0421_etiquetas
   SET f0421_id_despacho = null, 
       f0421_fecha_despacho = null, f0421_usuario_despacho = ''
   from $df001$.tb0420_orden_imp_etiquetas
 WHERE f0420_id_impresion = f0421_id_impresion
       and f0421_id_despacho = '$001$' and f0420_id_producto = '$002$'
