WITH otb_inventarios as 
(
   select f0309_id_item, f0309_id_bodega, f0309_id_cia,
      sum(f0309_entrada - f0309_salida) as inv_item, '00000001' as usuario
   from camocontrol.tb0309_items_movimientos 
      join camocontrol.tb0300_items
        on f0309_id_item = f0300_id_item
   where f0309_anulado = 'N' and f0309_id_cia = '00000001' and f0309_id_item = '35'
   group by f0309_id_item, f0309_id_bodega, f0309_id_cia, usuario
   ORDER BY f0309_id_item
)
insert into camocontrol.tb0301_items_inventario_x_bodega
(f0301_id_cia, f0301_id_item, f0301_id_bodega, f0301_inventario_actual, 
 f0301_usuario_crear, f0301_usuario_modificar)
select otb_inventarios.f0309_id_cia, otb_inventarios.f0309_id_item,
       otb_inventarios.f0309_id_bodega, otb_inventarios.inv_item,
       otb_inventarios.usuario, otb_inventarios.usuario
       from otb_inventarios
ON CONFLICT (f0301_id_item, f0301_id_bodega) DO UPDATE SET 
f0301_inventario_actual = (select otb_inventarios.inv_item from otb_inventarios 
                           where tb0301_items_inventario_x_bodega.f0301_id_item = otb_inventarios.f0309_id_item and
                                  tb0301_items_inventario_x_bodega.f0301_id_bodega = otb_inventarios.f0309_id_bodega),
f0301_fm = now()
                                  