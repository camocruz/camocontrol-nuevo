select f0309_id_item as id_item, f0300_codigo_cguno as cod_cg_uno, f0300_referencia as referencia, 
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0002_unidad_medicion || ')' as descripcion_larga,
       coalesce(sum(f0309_salida) - sum(f0309_entrada),0) as salida, f0005_cod_bodega as bodega
       --trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as creador
from camocontrol.tb0309_items_movimientos
         join camocontrol.tb0310_documentos_movimientos_inventarios
           on f0310_id_documento = f0309_id_documento
         join camocontrol.tb0005_bodegas
           on f0309_id_bodega = f0005_id_bodega
         join camocontrol.tb0300_items
           on f0309_id_item = f0300_id_item
         join camocontrol.tb0002_unidades_medicion
           on f0300_id_unidad_medicion = f0002_id_unidad_medicion
         join camocontrol.tb0200_terceros
           on f0310_usuario_crear = f0200_id_tercero
where f0310_id_documento_ref01='DAC-00000002' -- f0300_id_tipo_item <> 15 and f0300_id_tipo_item <> 25 and 
group by f0309_id_item, f0300_codigo_cguno, f0300_referencia, descripcion_larga, bodega
order by descripcion_larga
