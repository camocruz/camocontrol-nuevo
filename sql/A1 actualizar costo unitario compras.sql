
WITH otb_costos_compras as (
   SELECT f0305_id_item, f0305_costo_unitario_planificado, f0305_id_factura_compras, 
       f0305_docto_mov_inventario
  FROM camocontrol.tb0305_items_solicitados
  where f0305_id_factura_compras is not null and f0305_anulado = 'N'
)

update camocontrol.tb0309_items_movimientos set
  f0309_costo_unit_entrada = COALESCE((select otb_costos_compras.f0305_costo_unitario_planificado FROM otb_costos_compras
                              where otb_costos_compras.f0305_id_item = f0309_id_item and
                                'FCP-' || otb_costos_compras.f0305_id_factura_compras = f0309_id_doc_ref limit 1),0)
Where f0309_id_doc_ref <> ''    

