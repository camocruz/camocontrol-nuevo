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


-- Informacion de las compras
copy(
with estructura_planta as (
	SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id, 
	       temp1.f0100_nombre as planta
	 FROM camocontrol.tb0100_estructura_mantenimiento
	 left join camocontrol.tb0100_estructura_mantenimiento as temp1
	   on temp1.f0100_id_estructura = (string_to_array(tb0100_estructura_mantenimiento.f0100_path||tb0100_estructura_mantenimiento.f0100_id_estructura||'-','-'))[2]::int
	where tb0100_estructura_mantenimiento.f0100_id_cia = '00000001' and tb0100_estructura_mantenimiento.f0100_anulado = 'N'
	      and array_length(string_to_array(tb0100_estructura_mantenimiento.f0100_path,'-'), 1)>1
)
SELECT f0307_id_factura_compras as id_fcc, f0307_numero_factura as fac_num, to_char(f0307_fecha_factura, 'YYYY-MM-DD') as fecha_factura, 
       to_char(f0307_fecha_factura, 'YYYY') as ano_factura, to_char(f0307_fecha_factura, 'MM') as mes_factura,
       f0305_factura_c_aprov as fac_aprov,
       f0200_id as nit, f0200_nombres as razon_social,
       f0305_id_solicitud_compra as id_sc, f0305_id_item_solicitud as item_sc,
       f0305_id_estructura as id_estructura, tb_estructura_general.f0100_nombre as estructura,
       coalesce(tb_estructura_primaria.f0100_nombre, tb_estructura_general.f0100_nombre) as maquina,
       f0305_id_accion as id_acc, tb_estado_accion.f0603_descriptor_estado as estado_acc,
       coalesce(tb_acciones.f0600_id_accion_principal,f0305_id_accion) as acc_raiz,    
       coalesce(tb_estado_accion_raiz.f0603_descriptor_estado,tb_estado_accion.f0603_descriptor_estado) as estado_acc_raiz,
       
       f0302_descripcion_tipo_item as tipo_item, 
       f0305_id_item as id_item, f0300_descripcion_item as item, 
       --f0305_ampliacion_item as ampliacion_item, 
       --f0305_anotacion_item as nota_item, 
       f0305_cantidad as cantidad, f0002_unidad_medicion as unidad,
       f0305_costo_unitario_planificado as costo_unit, 
       f0305_costo_unitario_planificado * f0305_cantidad as costo_tot_sin_iva,
       f0305_costo_total_planificado as costo_tot_iva,
       'OC-' || f0305_id_oc as id_oc,
       f0305_docto_mov_inventario as id_doc_inv,
       to_char(f0310_fecha, 'YYYY-MM-DD') as fecha_recepcion,
       to_char(f0310_fecha, 'YYYY') as ano_recepcion,
       to_char(f0310_fecha, 'MM') as mes_recepcion,
       coalesce(planta,tb_estructura_general.f0100_nombre) as planta
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
       
    left join camocontrol.tb0600_acciones as tb_acciones
       on f0304_id_accion = tb_acciones.f0600_id_accion
    left join camocontrol.tb0603_estados_acciones as tb_estado_accion
       on tb_estado_accion.f0603_id_estado_accion = tb_acciones.f0600_id_estado_accion

    left join camocontrol.tb0310_documentos_movimientos_inventarios
       on f0310_id_documento = f0305_docto_mov_inventario
       
    left join camocontrol.tb0600_acciones as tb_acciones_raiz
       on tb_acciones.f0600_id_accion_principal = tb_acciones_raiz.f0600_id_accion
    left join camocontrol.tb0603_estados_acciones as tb_estado_accion_raiz
       on tb_estado_accion_raiz.f0603_id_estado_accion = tb_acciones_raiz.f0600_id_estado_accion



    left join camocontrol.tb0100_estructura_mantenimiento as tb_estructura_general
       on f0305_id_estructura = tb_estructura_general.f0100_id_estructura
    left join camocontrol.tb0100_estructura_mantenimiento as tb_estructura_primaria
       on tb_estructura_general.f0100_id_maquina_padre = tb_estructura_primaria.f0100_id_estructura
    left join estructura_planta
       on id = f0305_id_estructura
where f0305_id_cia = '00000001' 
      and f0307_fecha_factura BETWEEN '2019-01-01' and '2020-07-01'
      and f0305_docto_mov_inventario <> '' 
--      and coalesce(f0600_id_accion_principal,0) = 14776
order by f0305_id_item_solicitud
) to 'S:/dsfc/rh_asistencia/InfoCompras.csv' DELIMITER '	'  CSV HEADER;

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
with estructura_planta as (
	SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id, 
	       temp1.f0100_nombre as planta
	 FROM camocontrol.tb0100_estructura_mantenimiento
	 left join camocontrol.tb0100_estructura_mantenimiento as temp1
	   on temp1.f0100_id_estructura = (string_to_array(tb0100_estructura_mantenimiento.f0100_path||tb0100_estructura_mantenimiento.f0100_id_estructura||'-','-'))[2]::int
	where tb0100_estructura_mantenimiento.f0100_id_cia = '00000001' and tb0100_estructura_mantenimiento.f0100_anulado = 'N'
	      and array_length(string_to_array(tb0100_estructura_mantenimiento.f0100_path,'-'), 1)>1
)
SELECT f0100_id_estructura as id, 
       f0100_nombre as nombre, 
       f0100_descripcion as descripcion, 
       f0100_codigo as codigo, 
       f0107_tipo_estructura as tipo, 
       f0100_id_item as id_item,
       coalesce(planta,f0100_nombre) as planta
 FROM camocontrol.tb0100_estructura_mantenimiento
 left join camocontrol.tb0107_tipos_estructura
      on f0107_id_tipo_estructura = tb0100_estructura_mantenimiento.f0100_id_tipo_estructura
 left join estructura_planta 
      on id = f0100_id_estructura
where tb0100_estructura_mantenimiento.f0100_id_cia = '00000001' and tb0100_estructura_mantenimiento.f0100_anulado = 'N'
order by planta, nombre
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

