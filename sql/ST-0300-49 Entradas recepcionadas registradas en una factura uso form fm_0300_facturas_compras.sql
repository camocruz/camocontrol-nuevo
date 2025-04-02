-- Se usa en el formulario fm_0300_facturas_compras para mostrar las entradas recepcionadas registradas en
-- una factura
with estructura_planta as 
    ( 
	   SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id, temp1.f0100_nombre as planta 
	   FROM camocontrol.tb0100_estructura_mantenimiento 
	     left join camocontrol.tb0100_estructura_mantenimiento as temp1 
		    on temp1.f0100_id_estructura = (string_to_array(tb0100_estructura_mantenimiento.f0100_path
			                                                ||tb0100_estructura_mantenimiento.f0100_id_estructura
													         ||'-','-'))[2]::int 
	    where tb0100_estructura_mantenimiento.f0100_id_cia = '00000001' 
		  and tb0100_estructura_mantenimiento.f0100_anulado = 'N' 
		  and array_length(string_to_array(tb0100_estructura_mantenimiento.f0100_path,'-'), 1)>1
	 )
	 
select f0309_id_mov_item, f0305_id_solicitud_compra, f0305_estado, 
        f0305_id_item_solicitud, f0305_id_oc, f0305_oc_aprov, f0305_oc_uno, 
		--f0305_docto_mov_inventario
		f0309_id_documento, f0305_cantidad, 
		f0309_entrada, -- La cantidad recibida en el documento EAR
		f0305_chkinventario,
		f0305_inventario, f0305_var_cost_prom, f0305_descuento, f0305_iva,
		f0305_anotacion_item, 
		f0300_id_item, f0300_codigo_cguno, f0300_descripcion_item 
		|| ' - ' || f0300_referencia || ' - '|| f0300_contenido_x_empaque as descripcion, 
		f0305_ampliacion_item as descripcion_comp, f0002_sigla_unidad_medicion, 
		f0305_costo_unitario_planificado, 
		f0305_costo_unitario_planificado * f0309_entrada as costo_subtotal, 
		(f0305_costo_total_planificado*f0309_entrada/f0305_cantidad) / f0309_entrada as costo_unit_iva, 
		(f0305_costo_total_planificado*f0309_entrada/f0305_cantidad) as costo_total, 
		f0305_id_solicitud_compra as id_solic, 
		COALESCE(otb_estructura_madre.f0100_codigo || ' -- { ' || otb_estructura_madre.f0100_nombre 
		         || ' }'
				 , otb_estructura_referida.f0100_codigo || ' -- { ' 
				 || otb_estructura_referida.f0100_nombre || ' }') as descripcion_codigo, 
		f0305_id_accion, coalesce(f0600_id_accion_principal,0) as acc_raiz, 
		coalesce(planta, otb_estructura_referida.f0100_nombre) as planta 
from camocontrol.tb0309_items_movimientos
    join camocontrol.tb0305_items_solicitados
	  on f0305_id_item_solicitud = f0309_id_item_solicitud
    join camocontrol.tb0300_items on f0305_id_item = f0300_id_item 
	join camocontrol.tb0002_unidades_medicion on f0300_id_unidad_medicion = f0002_id_unidad_medicion 
	join camocontrol.tb0304_solicitud_compra on f0305_id_solicitud_compra = f0304_id_solicitud 
	left join camocontrol.tb0100_estructura_mantenimiento as otb_estructura_referida 
	   on f0305_id_estructura = otb_estructura_referida.f0100_id_estructura 
	left join camocontrol.tb0100_estructura_mantenimiento as otb_estructura_madre 
	   on otb_estructura_referida.f0100_id_maquina_padre = otb_estructura_madre.f0100_id_estructura 
	left join estructura_planta on id = f0305_id_estructura 
	left join camocontrol .tb0600_acciones on f0305_id_accion = f0600_id_accion 
where f0309_id_factura_costo = '27172' AND f0309_anulado = 'N'
