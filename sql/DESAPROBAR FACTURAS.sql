UPDATE camocontrol.tb0307_facturas_compras
   SET f0307_aprobada='N', f0307_fecha_aprobacion=null, 
       f0307_recepcion_aprobada='N',
       f0307_usuario_aprobar=''
 WHERE f0307_id_factura_compras=14026;

UPDATE camocontrol.tb0305_items_solicitados
   SET f0305_factura_c_aprov='N'
WHERE f0305_id_factura_compras=14026;
