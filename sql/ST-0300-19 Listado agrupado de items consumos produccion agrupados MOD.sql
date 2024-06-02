select f0309_id_item as id_item, f0300_referencia as referencia, f0300_codigo_cguno as cod_cg,
      f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga,
      coalesce(sum(f0309_entrada) - sum(f0309_salida),0) as inventario
from $df001$.tb0309_items_movimientos
   join $df001$.tb0310_documentos_movimientos_inventarios
     on f0309_id_documento = f0310_id_documento
   join $df001$.tb0005_bodegas as tb_bodega
      on f0310_id_bodega = tb_bodega.f0005_id_bodega
   join $df001$.tb0200_terceros as tb_responsable
      on f0310_usuario_crear = tb_responsable.f0200_id_tercero
   join $df001$.tb0311_tipos_doc_mov_inventarios
      on f0310_id_tipo_documento = f0311_id_tipo_doc
   join $df001$.tb0300_items
      on f0309_id_item = f0300_id_item
 where f0310_id_documento_ref01 = '$002$' 
   and f0309_anulado = 'N' and f0309_id_cia = '$001$'
 group by f0309_id_item, referencia, cod_cg, descripcion_larga
 order by descripcion_larga
