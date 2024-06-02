select f0600_id_accion,
       tb0600_acciones.f0600_path || tb0600_acciones.f0600_id_accion || '-' as path_accion,
       coalesce(unit.vi_costo,0) as costo,
       sum(unif.vi_costo) as costo_acumulado
from camocontrol.tb0600_acciones
   left join camocontrol.vi0600_compras_acciones as unit
       on f0600_id_accion = unit.vi_id_accion
   left join camocontrol.vi0600_compras_acciones as unif
       on substring (unif.vi_path from 1 for char_length(tb0600_acciones.f0600_path || tb0600_acciones.f0600_id_accion || '-')) = tb0600_acciones.f0600_path || tb0600_acciones.f0600_id_accion || '-'
group by f0600_id_accion, path_accion, unit.vi_costo
order by path_accion


select f0305_id_accion, f0600_path || f0305_id_accion || '-' as path_accion, 
       sum(f0305_costo_unitario_planificado * f0305_cantidad) as c_unit
from camocontrol.tb0305_items_solicitados
join camocontrol.tb0600_acciones
  on f0305_id_accion = f0600_id_accion 

   join (select otb_compras_path.f0305_id_accion as id_acc_path, otb_acciones_path.f0600_path || otb_compras_path.f0305_id_accion || '-' as opath_accion, 
                 sum(otb_compras_path.f0305_costo_unitario_planificado * otb_compras_path.f0305_cantidad) as oc_unit
         from camocontrol.tb0305_items_solicitados as otb_compras_path
            join camocontrol.tb0600_acciones as otb_acciones_path
              on otb_compras_path.f0305_id_accion = otb_acciones_path.f0600_id_accion
         where otb_compras_path.f0305_anulado = 'N'
         group by otb_compras_path.f0305_id_accion, otb_acciones_path.f0600_path || otb_compras_path.f0305_id_accion || '-'
        ) as otb_path
      on substring (otb_path.opath_accion from 1 for char_length(f0600_path || f0305_id_accion || '-')) = f0600_path || f0305_id_accion || '-'

where f0305_anulado = 'N' and f0305_id_accion = 10856
group by f0305_id_accion, f0600_path || f0305_id_accion || '-'
order by f0305_id_accion


