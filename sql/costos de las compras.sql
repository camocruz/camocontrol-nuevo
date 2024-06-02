--copy(
SELECT f0304_id_solicitud as id_sc, to_char(f0304_fr, 'YYYY-MM-DD') as fecha_sol_compra,
       f0307_id_factura_compras as id_fcc, f0307_numero_factura as fac_num, to_char(f0307_fecha_factura, 'YYYY-MM-DD') as fecha_factura, 
       to_char(f0307_fecha_factura, 'YYYY') as ano_factura, to_char(f0307_fecha_factura, 'MM') as mes_factura,
       to_char(f0307_fecha_factura, 'DD') as dia_factura,
       f0305_factura_c_aprov as factura_aprobada,
       f0200_id as nit, f0200_nombres as razon_social,
       f0305_id_item_solicitud as item, f0305_id_solicitud_compra as id_item_sc, 
       f0600_id_estructura as id_estructura, tb_estructura_general.f0100_nombre as estructura,
       tb_estructura_primaria.f0100_nombre as maquina,
       f0305_id_accion as id_acc, f0302_descripcion_tipo_item as tipo_item, 
       f0305_id_item as id_item, f0300_descripcion_item as item,
       replace(replace(f0305_ampliacion_item, chr(10),'.  '), chr(13), '') as ampliacion_item,
       replace(replace(f0305_anotacion_item, chr(10),'.  '), chr(13), '') as nota_item, 
       f0305_cantidad as cantidad, f0002_unidad_medicion as unidad,
       f0305_costo_unitario_planificado as costo_unit, 
       f0305_costo_unitario_planificado * f0305_cantidad as costo_tot_sin_iva,
       f0305_costo_total_planificado as costo_tot_iva
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
--) to 'S:/dsfc/rh_asistencia/inf_comp.txt' DELIMITER '|'  CSV HEADER;