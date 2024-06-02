--copy(
with estructura_planta as (
	SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id, 
	       temp1.f0100_nombre as planta
	 FROM $df001$.tb0100_estructura_mantenimiento
	 left join $df001$.tb0100_estructura_mantenimiento as temp1
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
  FROM $df001$.tb0305_items_solicitados
    join $df001$.tb0304_solicitud_compra
       on f0305_id_solicitud_compra = f0304_id_solicitud
    join $df001$.tb0307_facturas_compras
       on f0305_id_factura_compras = f0307_id_factura_compras
    join $df001$.tb0200_terceros
       on f0307_id_tercero = f0200_id_tercero
    join $df001$.tb0300_items
       on f0305_id_item = f0300_id_item
    join $df001$.tb0302_tipos_items
       on f0300_id_tipo_item = f0302_id_tipo_item
    join $df001$.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
       
    left join $df001$.tb0600_acciones as tb_acciones
       on f0304_id_accion = tb_acciones.f0600_id_accion
    left join $df001$.tb0603_estados_acciones as tb_estado_accion
       on tb_estado_accion.f0603_id_estado_accion = tb_acciones.f0600_id_estado_accion
       
    left join $df001$.tb0600_acciones as tb_acciones_raiz
       on tb_acciones.f0600_id_accion_principal = tb_acciones_raiz.f0600_id_accion
    left join $df001$.tb0603_estados_acciones as tb_estado_accion_raiz
       on tb_estado_accion_raiz.f0603_id_estado_accion = tb_acciones_raiz.f0600_id_estado_accion

    left join $df001$.tb0310_documentos_movimientos_inventarios
       on f0310_id_documento = f0305_docto_mov_inventario

    left join $df001$.tb0100_estructura_mantenimiento as tb_estructura_general
       on f0305_id_estructura = tb_estructura_general.f0100_id_estructura
    left join $df001$.tb0100_estructura_mantenimiento as tb_estructura_primaria
       on tb_estructura_general.f0100_id_maquina_padre = tb_estructura_primaria.f0100_id_estructura
    left join estructura_planta
       on id = f0305_id_estructura
where f0305_id_cia = '$001$' 
      and f0307_fecha_factura BETWEEN '$002$' and '$003$'
      and f0305_docto_mov_inventario <> ''
--      and coalesce(f0600_id_accion_principal,0) = 14776
order by f0305_id_item_solicitud
--) to 'C:/dsfc/rh_asistencia/inf_comp_consolidado.csv' WITH DELIMITER '	' CSV HEADER;