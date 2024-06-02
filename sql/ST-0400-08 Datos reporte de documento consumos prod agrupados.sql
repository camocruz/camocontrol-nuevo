SELECT 
       tb_bodega.f0005_descripcion_bodega as bodega,
       otb_prim.f0310_id_documento as id_doc_inv, otb_prim.f0310_id_documento_origen as docto_origen,
       f0311_documento as tipo,
       otb_prim.f0310_documento_contabilidad as docto_cg, otb_prim.f0310_fecha as fecha_docto,
       otb_prim.f0310_fr as fecha_registro, 
       tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable,
       case when otb_prim.f0310_anulado = 'S' then 'ANULADO' end as estado,
       case when otb_prim.f0310_anulado = 'S' then
         tb_anulo.f0200_apellido1 || ' ' || tb_anulo.f0200_apellido2 || ' ' || tb_anulo.f0200_nombres
       end  as anula,
       id_item, item, entrada, salida, unidad, sigla_unidad
 FROM camocontrol.tb0310_documentos_movimientos_inventarios as otb_prim
    join 
(
 select otb_movimiento.f0310_id_documento as id_doc_inv, f0309_id_item as id_item,  
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
       0 as entrada,
       coalesce(sum(f0309_salida) - sum(f0309_entrada),0) as salida,
       f0002_unidad_medicion as unidad,
       f0002_sigla_unidad_medicion as sigla_unidad
from camocontrol.tb0310_documentos_movimientos_inventarios as otb_movimiento
       join camocontrol.tb0310_documentos_movimientos_inventarios as otb_ref
         on otb_movimiento.f0310_id_documento = otb_ref.f0310_id_documento_ref01
       join camocontrol.tb0309_items_movimientos
         on otb_ref.f0310_id_documento = f0309_id_documento
       join camocontrol.tb0300_items
         on f0309_id_item = f0300_id_item
       join camocontrol.tb0002_unidades_medicion
         on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where otb_movimiento.f0310_id_documento='DAC-00000002'
group by id_doc_inv, f0309_id_item, item, entrada, unidad, sigla_unidad
order by item
) as otb_items
      on otb_items.id_doc_inv = otb_prim.f0310_id_documento
    join camocontrol.tb0005_bodegas as tb_bodega
      on otb_prim.f0310_id_bodega = tb_bodega.f0005_id_bodega
    join camocontrol.tb0200_terceros as tb_responsable
      on otb_prim.f0310_usuario_crear = tb_responsable.f0200_id_tercero
    left join camocontrol.tb0200_terceros as tb_anulo
      on otb_prim.f0310_usuario_anular = tb_anulo.f0200_id_tercero
    join camocontrol.tb0311_tipos_doc_mov_inventarios
      on otb_prim.f0310_id_tipo_documento = f0311_id_tipo_doc
 where otb_prim.f0310_id_cia = '00000001' and otb_prim.f0310_id_documento = 'DAC-00000002'
 order by item
