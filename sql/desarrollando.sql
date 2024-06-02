-- exportar informacion consumos de acuerdo a reportes de produccion
copy(
SELECT f0402_id_item as id_item_producido,
       otb_items_producidos.f0300_descripcion_item || ' (' || otb_items_producidos.f0300_referencia || ') (' || otb_items_producidos.f0300_contenido_x_empaque || ' <' || otb_unid_producidos.f0002_unidad_medicion || '> )' as producto_producido,
       otb_tipo_item_producidos.f0302_descripcion_tipo_item as tipo_item_producido,
       to_char(f0402_fecha_produccion,'yyyy-MM') as mes_prod, 
       f0310_id_bodega as bod_consumo,
       f0005_descripcion_bodega as bodega,
       f0311_documento as tipo_consumo,
       f0310_id_tipo_documento as id_t_consumo, 
       f0310_id_documento as doc_consumo,
       f0402_id_ipp as id_prog_prod, 
       f0310_id_documento_origen as rep_produccion, 
       otb_items_consumos.f0300_descripcion_item as producto,
       f0309_id_item as id_item,
       case when f0309_entrada = 0 then f0309_salida
         else f0309_entrada
       end as cantidad,
       f0309_entrada as entrada, 
       f0309_salida as salida,
       otb_unid_consumidos.f0002_unidad_medicion as unidad, 
       otb_tipo_item_consumido.f0302_descripcion_tipo_item as tipo_item,
       --otb_items_consumos.f0300_ultimo_costo as costo_unit,
       --case when f0309_entrada = 0 then f0309_salida * otb_items_consumos.f0300_ultimo_costo
         --else f0309_entrada * otb_items_consumos.f0300_ultimo_costo
       --end as costo_ult_comp,
       f0309_costo_tot as costo_mov_ult_compra,
       case when f0309_costo_tot_promedio = 0 then f0309_costo_tot
         --else f0309_entrada * otb_items_consumos.f0300_ultimo_costo
       end as costo_mov_promedio,
       f0309_costo_tot_estandar as costo_mov_estandar
  FROM camocontrol.tb0310_documentos_movimientos_inventarios
  join camocontrol.tb0309_items_movimientos
     on f0310_id_documento = f0309_id_documento
  join camocontrol.tb0005_bodegas
     on f0005_id_bodega = f0310_id_bodega
  join camocontrol.tb0311_tipos_doc_mov_inventarios
     on f0310_id_tipo_documento = f0311_id_tipo_doc
  join camocontrol.tb0300_items as otb_items_consumos
     on f0309_id_item = otb_items_consumos.f0300_id_item
  join camocontrol.tb0002_unidades_medicion as otb_unid_consumidos
     on otb_items_consumos.f0300_id_unidad_medicion=f0002_id_unidad_medicion
  join camocontrol.tb0302_tipos_items as otb_tipo_item_consumido
     on otb_items_consumos.f0300_id_tipo_item = otb_tipo_item_consumido.f0302_id_tipo_item
  join camocontrol.tb0402_reporte_produccion
     on 'RP-' || f0402_id_rp = f0310_id_documento_origen

  join camocontrol.tb0300_items as otb_items_producidos
     on f0402_id_item = otb_items_producidos.f0300_id_item
  join camocontrol.tb0002_unidades_medicion as otb_unid_producidos
     on otb_items_producidos.f0300_id_unidad_medicion=otb_unid_producidos.f0002_id_unidad_medicion
  join camocontrol.tb0302_tipos_items as otb_tipo_item_producidos
     on otb_items_producidos.f0300_id_tipo_item = otb_tipo_item_producidos.f0302_id_tipo_item
where f0310_id_documento_origen = 'RP-12965'     
--where substring(f0310_id_documento_origen from 1 for 3) = 'RP-'
   and f0309_anulado = 'N'
-- and f0310_id_tipo_documento <> 4
   and f0402_fecha_produccion > '2017-08-01'
order by otb_items_consumos.f0300_descripcion_item
--) to 'S:/dsfc/rh_asistencia/inf_consumos_rp.txt' DELIMITER '|'  CSV HEADER; 
) to 'C:/dsfc/inf_consumos_rp.txt' DELIMITER '|'  CSV HEADER;   


-- exportar informacion reportes de produccion
copy(
select 'RP-' || f0402_id_rp as rep_produccion, f0402_id_item as id_item, f0300_referencia as ref_1,
    f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ' <' || f0002_unidad_medicion || '> )' as producto,
    f0002_unidad_medicion as unidad, f0402_cantidad_producida as produccion, to_char(f0402_fecha_produccion, 'YYYY-MM-DD') as fecha_prod,
    to_char(f0402_fecha_produccion,'yyyy-MM') as mes, to_char(f0402_fecha_produccion,'dd') as dia ,
    f0302_descripcion_tipo_item as tipo_item, 
    f0300_peso_unitario * f0402_cantidad_producida as peso_bruto, f0402_estado as estado,
    f0402_horas_hombre as h_hombre, f0402_lote as lote,
    f0402_costo_mp as costo_insumos,
    f0402_costo_mano_obra as costo_mano_obra,
    f0402_costo_mp + f0402_costo_me + f0402_costo_mp_np + f0402_costo_me_np + f0402_costo_mano_obra as costo_total,
    
      case when 
        (f0402_costo_mp + f0402_costo_me + f0402_costo_mp_np + f0402_costo_me_np + f0402_costo_mano_obra) = 0 
         then 0
      else
        (f0402_costo_mp + f0402_costo_me + f0402_costo_mp_np + f0402_costo_me_np + f0402_costo_mano_obra) / f0402_cantidad_producida
      end as costo_unit
      
from camocontrol.tb0402_reporte_produccion
    join camocontrol.tb0300_items
      on f0402_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
      on f0300_id_tipo_item = f0302_id_tipo_item
WHERE f0402_anulado = 'N' and f0402_cantidad_producida <> 0
order by f0402_fecha_produccion asc
) to 'C:/dsfc/prod_rp.txt' DELIMITER '|' CSV HEADER; -- 'S:/dsfc/rh_asistencia/prod_rp.txt'

