-- exportar informacion de las ventas
copy (
SELECT f0850_id_rm as id_rm, f0850_rm as rm, f0850_id_despacho as id_despacho, 
       to_char(f0850_fecha_documento,'yyyy-MM-dd') as fecha,
       to_char(f0850_fecha_documento,'yyyy-MM') as mes, f0850_codigo_tercero as tercero, 
       f0850_razon_social as razon_social, f0850_ciudad_destino as destino, f0850_nombre_vendedor as vendedor,
       coalesce(f0851_referencia_1,'ND') as ref_1,
       coalesce(f0851_cantidad, 0) as cantidad,
       coalesce(f0300_id_item,0) as id_item, 
       coalesce((f0300_descripcion_item || ' ( ' || f0300_contenido_x_empaque || ')' || '(' || f0300_referencia || ' )'),'ND') as producto,
       f0303_descripcion_linea_item as linea,
       f0300_peso_neto * coalesce(f0851_cantidad, 0) as peso_neto,
       f0800_guia_transportadora as guia_transp, f0200_nombres as transportadora
       
  FROM camocontrol.tb0850_remisiones_cguno_encabezado
    LEFT JOIN camocontrol.tb0851_remisiones_cguno_detalle
       ON f0850_id_rm = f0851_id_rm
    LEFT JOIN camocontrol.tb0300_items
       ON f0851_referencia_1 = f0300_referencia
    left join camocontrol.tb0303_lineas_items
       on f0303_id_linea_item = f0300_id_linea
    left join camocontrol.tb0800_despachos_comercial
       on f0850_id_despacho = f0800_id_despacho
    join camocontrol.tb0200_terceros
       on f0800_transportadora = f0200_id_tercero
where f0850_anulado = 'N' -- and f0850_fecha_documento > '2016-01-01'
) to 'S:/dsfc/rh_asistencia/rms.txt' DELIMITER '|' CSV HEADER; --'S:/dsfc/rh_asistencia/rms.txt';


-- exportar informacion de inventarios
copy (
select f0309_id_item as id_item, 
   f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item,
   sum(f0309_entrada - f0309_salida) as inv_item, f0002_unidad_medicion as unidad,
   f0302_descripcion_tipo_item as tipo_item, f0005_descripcion_bodega as bodega, f0005_cod_bodega as cod_bodega
from camocontrol.tb0309_items_movimientos 
   join camocontrol.tb0300_items
     on f0309_id_item = f0300_id_item
   join camocontrol.tb0302_tipos_items
     on f0300_id_tipo_item = f0302_id_tipo_item
   join camocontrol.tb0002_unidades_medicion
     on f0300_id_unidad_medicion = f0002_id_unidad_medicion
   join camocontrol.tb0005_bodegas
     on f0309_id_bodega = f0005_id_bodega
where f0309_anulado = 'N' and f0309_id_cia = '00000001'
group by f0309_id_item, item, f0302_descripcion_tipo_item, f0002_unidad_medicion,
         f0005_descripcion_bodega, f0005_cod_bodega
order by item
) to 'S:/dsfc/rh_asistencia/inf_inv.txt' DELIMITER '|' CSV HEADER;

-- exportar informacion programa de produccion
Copy(
SELECT f0400_nombre as programa, f0401_id_ipp as id_ipp, f0401_id_item as id_item, 
       (f0300_descripcion_item || ' ( ' || f0300_contenido_x_empaque || ')' || '(' || f0300_referencia || ' )') as producto, 
       f0300_referencia as ref_1, f0401_cantidad as cantidad, f0303_descripcion_linea_item as linea,
       f0300_peso_neto * coalesce(f0401_cantidad, 0) as peso_neto
  FROM camocontrol.tb0401_items_prog_prod
     join camocontrol.tb0400_programa_produccion
       on f0401_id_prog_prod = f0400_id_pp
     join camocontrol.tb0300_items
       on f0401_id_item = f0300_id_item
     join camocontrol.tb0303_lineas_items
       on f0303_id_linea_item = f0300_id_linea
) to 'S:/dsfc/rh_asistencia/prog_prod.txt' DELIMITER '|' CSV HEADER;  --'S:/dsfc/rh_asistencia/prog_prod.txt';

-- exportar informacion reportes de produccion
copy(
select f0400_nombre as prog_prod,
    (regexp_split_to_array(f0402_tree_path,'-'))[3] as id_ipp_padre,
    'RP-' || f0402_id_rp as rep_produccion, 
    f0402_id_item as id_item_rp,
    otb_item_rp.f0300_referencia as ref_1_rp,
    otb_linea_rp.f0303_descripcion_linea_item as linea_rp, 
    otb_item_ipp.f0300_referencia as ref_1_ipp,
    otb_item_rp.f0300_descripcion_item || ' (' || otb_item_rp.f0300_referencia || ') (' || otb_item_rp.f0300_contenido_x_empaque || ' <' || f0002_unidad_medicion || '> )' as producto_rp,
    otb_item_ipp.f0300_descripcion_item || ' (' || otb_item_ipp.f0300_referencia || ') (' || otb_item_ipp.f0300_contenido_x_empaque || '> )' as producto_ipp,
    otb_linea_ipp.f0303_descripcion_linea_item as linea_ipp,
    f0002_unidad_medicion as unidad_rp,
    f0401_cantidad_producida as produccion_ipp, 
    f0402_cantidad_producida as produccion_rp, 
    to_char(f0402_fecha_produccion, 'YYYY-MM-DD') as fecha_prod_rp,
    to_char(f0402_fecha_produccion,'yyyy-MM') as mes_rp, 
    EXTRACT(WEEK FROM f0402_fecha_produccion) as semana, 
    to_char(f0402_fecha_produccion,'dd') as dia_rp ,
    f0302_descripcion_tipo_item as tipo_item_rp, 
    otb_item_rp.f0300_peso_neto * f0402_cantidad_producida as peso_neto_rp, 
    f0402_estado as estado,
    case when f0402_horas_hombre = 1000 then 1 else f0402_horas_hombre end as h_hombre, 
    f0402_lote as lote,
    f0402_num_funcionarios as personas,
    round(f0402_costo_unitario, 0) as costo_unitario,
    f0402_costo_unitario_estandar as costo_unitario_estandar,
    f0402_productividad as productividad,
    planta.f0100_nombre as planta_prod
from camocontrol.tb0402_reporte_produccion
    join camocontrol.tb0300_items as otb_item_rp
      on f0402_id_item = otb_item_rp.f0300_id_item
    join camocontrol.tb0303_lineas_items as otb_linea_rp
       on otb_linea_rp.f0303_id_linea_item = otb_item_rp.f0300_id_linea
    join camocontrol.tb0002_unidades_medicion
      on otb_item_rp.f0300_id_unidad_medicion=f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
      on otb_item_rp.f0300_id_tipo_item = f0302_id_tipo_item
    join camocontrol.tb0401_items_prog_prod
      on f0401_id_ipp = ((regexp_split_to_array(f0402_tree_path,'-'))[3])::int
    join camocontrol.tb0300_items as otb_item_ipp
      on f0401_id_item = otb_item_ipp.f0300_id_item
    join camocontrol.tb0303_lineas_items as otb_linea_ipp
       on otb_linea_ipp.f0303_id_linea_item = otb_item_ipp.f0300_id_linea
    join camocontrol.tb0400_programa_produccion
      on f0400_id_pp = f0402_id_prog_prod
    left join camocontrol.tb0100_estructura_mantenimiento as planta
      on planta.f0100_id_estructura = f0402_planta_produccion
WHERE f0402_anulado = 'N' and f0402_cantidad_producida <> 0
      --and ((regexp_split_to_array(f0402_tree_path,'-'))[3])::int = 14150
order by f0401_id_ipp, f0402_fecha_produccion asc
) to 'S:/dsfc/rh_asistencia/prod_rp.txt' DELIMITER '|' CSV HEADER; -- 'S:/dsfc/rh_asistencia/prod_rp.txt'

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
       case when f0309_entrada = 0 then f0309_salida * f0309_costo_unit_promedio
         else f0309_entrada * f0309_costo_unit_promedio
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
--where f0310_id_documento_origen = 'RP-12965'     
where substring(f0310_id_documento_origen from 1 for 3) = 'RP-'
   and f0309_anulado = 'N'
-- and f0310_id_tipo_documento <> 4
   and f0402_fecha_produccion > '2017-08-01'
order by otb_items_consumos.f0300_descripcion_item
--) to 'S:/dsfc/rh_asistencia/inf_consumos_rp.txt' DELIMITER '|'  CSV HEADER; 
) to 'S:/dsfc/rh_asistencia/inf_consumos_rp.txt' DELIMITER '|'  CSV HEADER;  

-- Informacion de las compras
copy(
SELECT f0304_id_solicitud as id_sc, f0305_id_item_solicitud as id_item_sol, to_char(f0304_fr, 'YYYY-MM-DD') as fecha_sol_compra,
       f0307_id_factura_compras as id_fcc, f0307_numero_factura as fac_num, to_char(f0307_fecha_factura, 'YYYY-MM-DD') as fecha_factura, 
       to_char(f0307_fecha_factura, 'YYYY') as ano_factura, to_char(f0307_fecha_factura, 'MM') as mes_factura,
       to_char(f0307_fecha_factura, 'DD') as dia_factura,
       f0305_factura_c_aprov as factura_aprobada, 
       to_char(f0307_fecha_aprobacion, 'YYYY') as ano_aprobacion, to_char(f0307_fecha_aprobacion, 'MM') as mes_aprobacion,
       to_char(f0307_fecha_aprobacion, 'DD') as dia_aprobacion,
       f0200_id as nit, f0200_nombres as razon_social,
       f0600_id_estructura as id_estructura, tb_estructura_general.f0100_nombre as estructura,
       coalesce(tb_estructura_primaria.f0100_nombre, tb_estructura_primaria.f0100_nombre, tb_estructura_general.f0100_nombre) as maquina,
       f0305_id_accion as id_acc, f0302_descripcion_tipo_item as tipo_item, 
       f0305_id_item as id_item, f0300_descripcion_item as item,
       replace(replace(f0305_ampliacion_item, chr(10),'.  '), chr(13), '') as ampliacion_item,
       replace(replace(f0305_anotacion_item, chr(10),'.  '), chr(13), '') as nota_item, 
       f0305_cantidad as cantidad, f0002_unidad_medicion as unidad,
       f0305_costo_unitario_planificado as costo_unit, 
       f0305_costo_unitario_planificado * f0305_cantidad as costo_tot_sin_iva,
       f0305_costo_total_planificado as costo_tot_iva,
       f0300_costo_promedio as costo_promedio, f0305_costo_unit_estandar as costo_unit_estandar,
       f0600_path || f0600_id_accion as path,
       coalesce((string_to_array(f0600_path || f0600_id_accion, '-'))[2],'0') as raiz,
       coalesce((string_to_array(tb_estructura_general.f0100_path || tb_estructura_general.f0100_id_estructura, '-'))[2],'0') as raiz_maquina
       
  FROM camocontrol.tb0305_items_solicitados
    join camocontrol.tb0304_solicitud_compra
       on f0305_id_solicitud_compra = f0304_id_solicitud
    join camocontrol.tb0307_facturas_compras
       on f0305_id_factura_compras = f0307_id_factura_compras
    join camocontrol.tb0200_terceros
       on f0307_id_tercero = f0200_id_tercero
    join camocontrol.tb0300_items
       on f0305_id_item = f0300_id_item
    join camocontrol.tb0302_tipos_items
       on f0300_id_tipo_item = f0302_id_tipo_item
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    left join camocontrol.tb0600_acciones
       on f0304_id_accion = f0600_id_accion
    left join camocontrol.tb0100_estructura_mantenimiento as tb_estructura_general
       on f0600_id_estructura = tb_estructura_general.f0100_id_estructura
    left join camocontrol.tb0100_estructura_mantenimiento as tb_estructura_primaria
       on tb_estructura_general.f0100_id_maquina_padre = tb_estructura_primaria.f0100_id_estructura
--where f0305_factura_c_aprov = 'S'
) to 'S:/dsfc/rh_asistencia/inf_comp.txt' DELIMITER '|'  CSV HEADER;

-- exportar informacion ajustes de inventario
copy(
SELECT f0309_id_item as id_item,
       f0300_descripcion_item as item_ajustado,
       f0302_descripcion_tipo_item as tipo_item,
       to_char(f0309_fecha_movimiento,'yyyy-MM-dd') as fecha_mov,
       to_char(f0309_fecha_movimiento,'yyyy_MM') as mes_mov, 
       f0005_descripcion_bodega as bodega,
       f0310_id_documento as doc_consumo,
       case when f0309_entrada = 0 then f0309_salida
         else f0309_entrada
       end as cantidad,
       f0309_entrada as entrada, 
       f0309_salida as salida,
       f0002_unidad_medicion as unidad, 
       f0309_costo_tot as costo_mov_ult_compra,
       case when f0309_entrada = 0 then f0309_salida * f0309_costo_unit_promedio
         else f0309_entrada * f0309_costo_unit_promedio
       end as costo_mov_promedio
  FROM camocontrol.tb0310_documentos_movimientos_inventarios
  join camocontrol.tb0309_items_movimientos
     on f0310_id_documento = f0309_id_documento
  join camocontrol.tb0005_bodegas
     on f0005_id_bodega = f0310_id_bodega
  join camocontrol.tb0311_tipos_doc_mov_inventarios
     on f0310_id_tipo_documento = f0311_id_tipo_doc
  join camocontrol.tb0300_items
     on f0309_id_item = f0300_id_item
  join camocontrol.tb0002_unidades_medicion
     on f0300_id_unidad_medicion=f0002_id_unidad_medicion
  join camocontrol.tb0302_tipos_items
     on f0300_id_tipo_item = f0302_id_tipo_item
where f0309_anulado = 'N'
   and f0310_id_tipo_documento = 3
   order by f0309_fecha_movimiento
) to 'S:/dsfc/rh_asistencia/inf_ajustes.txt' DELIMITER '|'  CSV HEADER;  

-- Exportar informacion de ubicacion fisica de items de inventario.

copy (
select f0301_id_item as id_item, to_char(f0301_fecha_ubicacion,'yyyy-MM-dd') as fecha,
       f0300_descripcion_item as item, f0302_descripcion_tipo_item as tipo_item, 
       f0005_cod_bodega as bodega, f0301_ubicacion as ubicacion
  from camocontrol.tb0301_items_inventario_x_bodega
    join camocontrol.tb0300_items on f0300_id_item = f0301_id_item
    join camocontrol.tb0302_tipos_items on f0302_id_tipo_item = f0300_id_tipo_item
    join camocontrol.tb0005_bodegas on f0005_id_bodega = f0301_id_bodega
where f0301_fecha_ubicacion is not null and f0301_anulado = 'N' and f0300_anulado = 'N'
order by f0301_ubicacion
) to 'S:/dsfc/rh_asistencia/evo_inventario.txt' DELIMITER '|' CSV HEADER; --'S:/dsfc/rh_asistencia/rms.txt';

-- Exportar listado de maquinaria
copy (
SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id, tb0100_estructura_mantenimiento.f0100_nombre as nombre, 
       --tb0100_estructura_mantenimiento.f0100_descripcion as descripcion, 
       tb0100_estructura_mantenimiento.f0100_codigo as codigo, f0107_tipo_estructura as tipo,
       coalesce((string_to_array(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura, '-'))[2],'0') as raiz_maquina
 FROM camocontrol.tb0100_estructura_mantenimiento
 join camocontrol.tb0107_tipos_estructura
   on f0107_id_tipo_estructura = f0100_id_tipo_estructura
 order by tb0100_estructura_mantenimiento.f0100_nombre
) to 'S:/dsfc/rh_asistencia/inf_estructura_manto.txt' DELIMITER '|'  CSV HEADER;

-- exportar listado de reclamaciones de los clientes
copy (
SELECT f0800_id_despacho as id_pdd, 
     coalesce(trim(both ' ' from tercero_ped.f0200_apellido1 || ' ' || tercero_ped.f0200_apellido2 || ' ' || tercero_ped.f0200_nombres),
              trim(both ' ' from tercero_acc.f0200_apellido1 || ' ' || tercero_acc.f0200_apellido2 || ' ' || tercero_acc.f0200_nombres)) as tercero,
     coalesce(tercero_ped.f0200_id, tercero_acc.f0200_id) as nit, otb_mef.f0609_mef as reclamo_mef, otb_causa.f0609_mef as causa_raiz,
     f0800_docto_devolucion as id_doc_inv,
     f0605_descriptor_tipo_registro as tipo,
     f0600_id_accion as id_accion, f0600_path || f0600_id_accion as path,
     f0603_descriptor_estado as estado,
     to_char(f0600_fr, 'YYYY-MM-DD') as f_reporte, to_char(f0600_fr, 'YYYY') as ano, to_char(f0600_fr, 'YYYY-MM') as mes,
     trim(both ' ' from tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres) as responsable,
     trim(both ' ' from tb_emisor.f0200_apellido1 || ' ' || tb_emisor.f0200_apellido2 || ' ' || tb_emisor.f0200_nombres) as emisor,
     trim(both ' ' from tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres) as evaluador,
     trim(both ' ' from transportadora.f0200_apellido1 || ' ' || transportadora.f0200_apellido2 || ' ' || transportadora.f0200_nombres) as transportadora
FROM camocontrol.tb0600_acciones
    Join camocontrol.tb0603_estados_acciones
       on f0600_id_estado_accion = f0603_id_estado_accion
    join camocontrol.tb0200_terceros as tb_responsable
       on f0600_responsable = tb_responsable.f0200_id_tercero
    join camocontrol.tb0200_terceros as tb_emisor
       on f0600_emisor = tb_emisor.f0200_id_tercero
    join camocontrol.tb0200_terceros as tb_evaluador
       on f0600_evaluador = tb_evaluador.f0200_id_tercero
    left join camocontrol.tb0800_despachos_comercial
       on f0600_id_accion = f0800_id_accion
    left join camocontrol.tb0200_terceros as tercero_ped
       on tercero_ped.f0200_id_tercero = f0800_cliente
    left join camocontrol.tb0200_terceros as transportadora
       on transportadora.f0200_id_tercero = f0800_transportadora
    left join camocontrol.tb0200_terceros as tercero_acc
       on tercero_acc.f0200_id_tercero = f0600_tercero_relacionado
    Join camocontrol.tb0605_tipos_registro_acciones
       on f0600_id_tipo_registro = f0605_id_tipo_registro
    left join camocontrol.tb0609_modos_efectos_falla as otb_mef
       on otb_mef.f0609_id_mef = f0600_id_mef
    left join camocontrol.tb0609_modos_efectos_falla as otb_causa
       on otb_causa.f0609_id_mef = f0600_id_mef_causa
where f0600_id_fuente_accion = '00000004' and f0605_id_tipo_registro = '01'
    and f0600_fr > '2017-01-01'
order by tipo desc, f0600_id_accion
) to 'S:/dsfc/rh_asistencia/inf_reclam.txt' DELIMITER '|' CSV HEADER;

-- exportar informacion de compras asociadas a las acciones

copy (
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
) to 'S:/dsfc/rh_asistencia/inf_compras_acciones.txt' DELIMITER '|' CSV HEADER;
