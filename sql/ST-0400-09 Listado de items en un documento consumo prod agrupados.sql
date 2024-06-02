select f0309_id_item as id_item,  
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
       coalesce(sum(f0309_salida) - sum(f0309_entrada),0) as salida,
       f0002_sigla_unidad_medicion as und
from camocontrol.tb0310_documentos_movimientos_inventarios as otb_movimiento
       join camocontrol.tb0310_documentos_movimientos_inventarios as otb_ref
         on otb_movimiento.f0310_id_documento = otb_ref.f0310_id_documento_ref01
       join camocontrol.tb0309_items_movimientos
         on otb_ref.f0310_id_documento = f0309_id_documento
       join camocontrol.tb0300_items
         on f0309_id_item = f0300_id_item
       join camocontrol.tb0002_unidades_medicion
         on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where otb_movimiento.f0310_id_cia = '00000001'  and otb_movimiento.f0310_id_documento='DAC-00000002'
group by f0309_id_item, item, und
order by item;

