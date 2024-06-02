select f0600_id_accion as id_acc, 
       replace(replace(replace(f0600_descripcion,chr(10),''),chr(11),' - '),chr(13),' - ') as accion,
       replace(replace(replace(f0600_titulo,chr(10),''),chr(11),' - '),chr(13),' - ') as titulo,
       f0600_path || f0600_id_accion as path,
       f0603_descriptor_estado as estado,
       f0305_id_solicitud_compra as id_sc, 
       f0305_id_item_solicitud as id_item_sc, 
       f0305_id_item as id_item, f0300_descripcion_item as item,
       replace(replace(replace(f0305_ampliacion_item,chr(10),''),chr(11),' - '),chr(13),' - ') as item_descripcion,
       f0305_cantidad as cantidad,
       f0002_unidad_medicion as unidad, 
       f0305_id_oc as id_oc, f0305_id_factura_compras as id_fcc, 
       f0305_docto_mov_inventario as id_doc_inv,
       case when f0305_docto_mov_inventario <> '' 
          then f0305_costo_unitario_planificado * f0305_cantidad else 0 
       end as costo_tot_sin_iva,
       case when f0305_docto_mov_inventario <> '' 
          then f0305_costo_total_planificado else 0 
       end as costo_tot_iva
from camocontrol.tb0600_acciones
  left join camocontrol.tb0305_items_solicitados on f0305_id_accion = f0600_id_accion
  join camocontrol.tb0300_items on f0305_id_item = f0300_id_item
  join camocontrol.tb0002_unidades_medicion on f0300_id_unidad_medicion = f0002_id_unidad_medicion
  left join camocontrol.tb0603_estados_acciones on f0600_id_estado_accion = f0603_id_estado_accion
where f0600_id_accion  > 10000
