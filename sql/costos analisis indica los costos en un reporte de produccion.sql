SELECT f0402_id_rp, f0402_id_item, f0402_cantidad_producida, 
       f0402_estado, 
       f0402_costo_mp, f0402_costo_me, f0402_costo_mp_np, f0402_costo_me_np, 
       f0402_costo_mano_obra, 
       f0402_costo_prod_semiterm, f0402_costo_prod_semiterm_np, f0402_costo_otros, 
       f0402_costo_otros_np, f0402_costo_total, f0402_costo_unitario, 
       f0402_costo_unitario_estandar
  FROM camocontrol.tb0402_reporte_produccion
  WHERE f0402_id_rp = 6227
