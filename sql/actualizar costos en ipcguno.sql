with tbcalculos as (
 SELECT 
    tb0406_det_prod_ip_cg_umpr4015_9.f0406_ip_num as ip,
    tb0406_det_prod_ip_cg_umpr4015_9.f0406_referencia as referencia,
    (string_to_array(f0405_hh,':'))[1]::dec + ((string_to_array(f0405_hh,':'))[1]::dec)/60 as horas_h,
    ((string_to_array(f0405_hh,':'))[1]::dec + ((string_to_array(f0405_hh,':'))[1]::dec)/60) / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as horas_h_unit,
    f0405_cost_mo as cost_mo,
    f0405_cost_mo / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as cost_mo_unit,
    f0405_costos_variables as cost_variables,
    f0405_costos_variables / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as cost_variables_unit, 
    f0405_costo_subcontrat as cost_subcontratos,
    f0405_costo_subcontrat / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as cost_subcontratos_unit,
    f0405_costo_tot_transf as subtotcost_transf,
    f0405_costo_tot_transf / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as subtotcost_transf_unit,
    f0405_costo_mpme as cost_mpme,
    f0405_costo_mpme / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as cost_mpme_unit,
    tb0405_encabezado_ip_cg_umpr4015_9.f0405_costo_total / (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) AS cost_total_unit,
    (tb0406_det_prod_ip_cg_umpr4015_9.f0406_cant_prod * tb0408_items_cg.f0408_peso) as cant_kg,
    f0405_fecha as fecha
   FROM camocontrol.tb0406_det_prod_ip_cg_umpr4015_9
     LEFT JOIN camocontrol.tb0405_encabezado_ip_cg_umpr4015_9 ON tb0405_encabezado_ip_cg_umpr4015_9.f0405_ip_num::text = tb0406_det_prod_ip_cg_umpr4015_9.f0406_ip_num::text
     LEFT JOIN camocontrol.tb0408_items_cg ON tb0408_items_cg.f0408_referencia::text = tb0406_det_prod_ip_cg_umpr4015_9.f0406_referencia::text
   where f0406_costo_prod > 0
   order by cost_total_unit
   )

   update camocontrol.tb0406_det_prod_ip_cg_umpr4015_9 set
       horas_hombre = horas_h,
       horas_hombre_unit = horas_h_unit,
       costo_mo = cost_mo,
       costo_mo_unit = cost_mo_unit,
       costo_variable = cost_variables,
       costo_variable_unit = cost_variables_unit,
       costo_subcontratos = cost_subcontratos,
       costo_subcontratos_unit = cost_subcontratos_unit,
       costo_transformacion = subtotcost_transf,
       costo_transformacion_unit = subtotcost_transf_unit,
       costo_mpme = cost_mpme,
       costo_mpme_unit = cost_mpme_unit,
       costo_prod_unit = cost_total_unit,
       cant_prod_kg = cant_kg,
       fecha_ip = fecha
   from tbcalculos where f0406_ip_num = ip and f0406_referencia = referencia


 -- Eliminamos la vasura de los lotes en produccion y consumos

 update camocontrol.tb0406_det_prod_ip_cg_umpr4015_9 set
    f0406_lote = ''
 where substring(f0406_lote from 1 for 5) <> 'Lote:' and f0406_lote <> '';
  update camocontrol.tb0407_det_cons_ip_cg_umpr4015_9 set
    f0407_lote = ''
 where substring(f0407_lote from 1 for 5) <> 'Lote:' and f0407_lote <> '';


 select f0406_lote from camocontrol.tb0406_det_prod_ip_cg_umpr4015_9
 where substring(f0406_lote from 1 for 5) = 'Lote:'