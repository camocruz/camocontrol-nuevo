with movimientos as (select f0309_id_mov_item, f0309_id_bodega, f0309_fecha_movimiento,
                            f0309_entrada, f0309_salida, f0309_costo_unit_promedio
                     from camocontrol.tb0309_items_movimientos
                     where f0309_id_item = 1369
                           and f0309_fecha_movimiento < '2018-02-19'
                           and f0309_anulado = 'N' 
                           and f0309_id_cia = '00000001'
                     )
                           
select otb_ppal.f0309_id_bodega, coalesce(sum(otb_ppal.f0309_entrada) - sum(otb_ppal.f0309_salida),0) as inventario,
       (coalesce((select otb_costo.f0309_costo_unit_promedio
                  from movimientos otb_costo
                  where otb_costo.f0309_id_bodega = otb_ppal.f0309_id_bodega 
                  order by otb_costo.f0309_fecha_movimiento desc, otb_costo.f0309_id_mov_item desc
                  limit 1
                  ), 0)) costo
from movimientos otb_ppal
group by f0309_id_bodega





