-- View: camocontrol.vi0600_compras

-- DROP VIEW camocontrol.vi0600_compras;

CREATE OR REPLACE VIEW camocontrol.vi0600_compras
 AS
 WITH estructura_planta AS (
         SELECT tb0100_estructura_mantenimiento.f0100_id_estructura AS id,
            temp1.f0100_nombre AS planta
           FROM camocontrol.tb0100_estructura_mantenimiento
             LEFT JOIN camocontrol.tb0100_estructura_mantenimiento temp1 ON temp1.f0100_id_estructura = (string_to_array((tb0100_estructura_mantenimiento.f0100_path::text || tb0100_estructura_mantenimiento.f0100_id_estructura) || '-'::text, '-'::text))[2]::integer
          WHERE tb0100_estructura_mantenimiento.f0100_id_cia = '00000001'::bpchar AND tb0100_estructura_mantenimiento.f0100_anulado = 'N'::bpchar AND array_length(string_to_array(tb0100_estructura_mantenimiento.f0100_path::text, '-'::text), 1) > 1
        ), proyectos AS (
         SELECT tb0600_acciones.f0600_id_accion AS id_proyecto
           FROM camocontrol.tb0600_acciones
          WHERE tb0600_acciones.f0600_proyinfra = 'S'::bpchar
        )
 SELECT tb0307_facturas_compras.f0307_id_factura_compras AS id_fcc,
    tb0307_facturas_compras.f0307_numero_factura AS fac_num,
    to_char(tb0307_facturas_compras.f0307_fecha_factura, 'YYYY-MM-DD'::text) AS fecha_factura,
    to_char(tb0307_facturas_compras.f0307_fecha_factura, 'YYYY'::text) AS ano_factura,
    to_char(tb0307_facturas_compras.f0307_fecha_factura, 'MM'::text) AS mes_factura,
    tb0305_items_solicitados.f0305_factura_c_aprov AS fac_aprov,
    tb0200_terceros.f0200_id AS nit,
    tb0200_terceros.f0200_nombres AS razon_social,
    tb0305_items_solicitados.f0305_id_solicitud_compra AS id_sc,
    tb0305_items_solicitados.f0305_id_item_solicitud AS item_sc,
    tb0305_items_solicitados.f0305_id_estructura AS id_estructura,
    tb_estructura_general.f0100_nombre AS estructura,
    COALESCE(tb_estructura_primaria.f0100_nombre, tb_estructura_general.f0100_nombre) AS maquina,
    tb0305_items_solicitados.f0305_id_accion AS id_acc,
    tb_estado_accion.f0603_descriptor_estado AS estado_acc,
    COALESCE(tb_acciones.f0600_id_accion_principal, tb0305_items_solicitados.f0305_id_accion) AS acc_raiz,
    COALESCE(tb_estado_accion_raiz.f0603_descriptor_estado, tb_estado_accion.f0603_descriptor_estado) AS estado_acc_raiz,
    COALESCE(tb_acciones_raiz.f0600_proyinfra, tb_acciones.f0600_proyinfra) AS clasproy,
    tb0302_tipos_items.f0302_descripcion_tipo_item AS tipo_item,
    tb0305_items_solicitados.f0305_id_item AS id_item,
    tb0300_items.f0300_descripcion_item AS item,
    round(tb0305_items_solicitados.f0305_cantidad, 2) AS cantidad,
    tb0002_unidades_medicion.f0002_unidad_medicion AS unidad,
    round(tb0305_items_solicitados.f0305_costo_unitario_planificado, 2) AS costo_unit,
    round(tb0305_items_solicitados.f0305_costo_unitario_planificado * tb0305_items_solicitados.f0305_cantidad, 2) AS costo_tot_sin_iva,
    round(tb0305_items_solicitados.f0305_costo_total_planificado, 2) AS costo_tot_iva,
    'OC-'::text || tb0305_items_solicitados.f0305_id_oc AS id_oc,
    tb0305_items_solicitados.f0305_docto_mov_inventario AS id_doc_inv,
    to_char(tb0310_documentos_movimientos_inventarios.f0310_fecha, 'YYYY-MM-DD'::text) AS fecha_recepcion,
    to_char(tb0310_documentos_movimientos_inventarios.f0310_fecha, 'YYYY'::text) AS ano_recepcion,
    to_char(tb0310_documentos_movimientos_inventarios.f0310_fecha, 'MM'::text) AS mes_recepcion,
    COALESCE(tb0305_items_solicitados.f0305_planta_compra, tb_estructura_general.f0100_nombre) AS planta,
    tb0305_items_solicitados.f0305_chkinventario AS p_inventario,
    proyectos.id_proyecto,
    replace(replace(tb0305_items_solicitados.f0305_ampliacion_item, chr(10), '.  '::text), chr(13), ''::text) AS descripcion_item
   FROM camocontrol.tb0305_items_solicitados
     JOIN camocontrol.tb0304_solicitud_compra ON tb0305_items_solicitados.f0305_id_solicitud_compra = tb0304_solicitud_compra.f0304_id_solicitud
     JOIN camocontrol.tb0307_facturas_compras ON tb0305_items_solicitados.f0305_id_factura_compras = tb0307_facturas_compras.f0307_id_factura_compras
     JOIN camocontrol.tb0200_terceros ON tb0307_facturas_compras.f0307_id_tercero = tb0200_terceros.f0200_id_tercero
     JOIN camocontrol.tb0300_items ON tb0305_items_solicitados.f0305_id_item = tb0300_items.f0300_id_item
     JOIN camocontrol.tb0302_tipos_items ON tb0300_items.f0300_id_tipo_item = tb0302_tipos_items.f0302_id_tipo_item
     JOIN camocontrol.tb0002_unidades_medicion ON tb0300_items.f0300_id_unidad_medicion::bpchar = tb0002_unidades_medicion.f0002_id_unidad_medicion
     LEFT JOIN camocontrol.tb0600_acciones tb_acciones ON tb0304_solicitud_compra.f0304_id_accion = tb_acciones.f0600_id_accion
     LEFT JOIN camocontrol.tb0603_estados_acciones tb_estado_accion ON tb_estado_accion.f0603_id_estado_accion = tb_acciones.f0600_id_estado_accion
     LEFT JOIN camocontrol.tb0310_documentos_movimientos_inventarios ON tb0310_documentos_movimientos_inventarios.f0310_id_documento::text = tb0305_items_solicitados.f0305_docto_mov_inventario::text
     LEFT JOIN camocontrol.tb0600_acciones tb_acciones_raiz ON tb_acciones.f0600_id_accion_principal = tb_acciones_raiz.f0600_id_accion
     LEFT JOIN camocontrol.tb0603_estados_acciones tb_estado_accion_raiz ON tb_estado_accion_raiz.f0603_id_estado_accion = tb_acciones_raiz.f0600_id_estado_accion
     LEFT JOIN proyectos ON COALESCE(tb_acciones.f0600_id_accion_principal, tb0305_items_solicitados.f0305_id_accion) = proyectos.id_proyecto
     LEFT JOIN camocontrol.tb0100_estructura_mantenimiento tb_estructura_general ON tb0305_items_solicitados.f0305_id_estructura = tb_estructura_general.f0100_id_estructura
     LEFT JOIN camocontrol.tb0100_estructura_mantenimiento tb_estructura_primaria ON tb_estructura_general.f0100_id_maquina_padre = tb_estructura_primaria.f0100_id_estructura
     LEFT JOIN estructura_planta ON estructura_planta.id = tb0305_items_solicitados.f0305_id_estructura
  WHERE tb0305_items_solicitados.f0305_id_cia = '00000001'::bpchar AND tb0307_facturas_compras.f0307_fecha_factura >= '2021-01-01 00:00:00'::timestamp without time zone AND tb0305_items_solicitados.f0305_docto_mov_inventario::text <> ''::text
  ORDER BY tb0305_items_solicitados.f0305_id_item_solicitud;

ALTER TABLE camocontrol.vi0600_compras
    OWNER TO camo;

