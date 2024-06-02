UPDATE camocontrol.tb0600_acciones as tb1
   SET f0600_tercero_relacionado = tb2.f0800_cliente
   from camocontrol.tb0800_despachos_comercial as tb2
 WHERE tb2.f0800_id_accion = tb1.f0600_id_accion;
