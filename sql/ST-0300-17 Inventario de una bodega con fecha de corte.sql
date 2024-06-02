select DISTINCT f0309_id_item as id_item, f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
             (
              select coalesce(sum(f0309_entrada) - sum(f0309_salida),0) as inventario
                  from camocontrol.tb0309_items_movimientos as otb2
               where otb2.f0309_id_bodega = otb1.f0309_id_bodega and otb2.f0309_id_item = otb1.f0309_id_item
                     and otb2.f0309_anulado = 'N' and f0309_fecha_movimiento <= '2016-06-27'
             )
from camocontrol.tb0309_items_movimientos as otb1
     join camocontrol.tb0300_items
        on otb1.f0309_id_item = f0300_id_item
where otb1.f0309_id_bodega = '11' and  otb1.f0309_id_cia = '00000001' and f0309_fecha_movimiento <= '2016-06-27'