-- COPIAR LOS DATOS DE LA TABLA FACTURA A RECEPCIONES, POR EL MOMENTO TENDRAN LOS MISMOS DATOS DE INICIO
INSERT INTO camocontrol.tb0320_recepciones_compras 
select * from camocontrol.tb0307_facturas_compras*;
     
-- Cambiar el consecutivo de la tabla de recepciones para evitar confuciones ya que la informacion se esta clonando.
ALTER SEQUENCE camocontrol.tb0320_recepciones_compras_f0320_id_recepcion_compras_seq 
restart 50000;

-- Copiar el numero de registro de factura en el campo de recepcion en los movimientos items, para el arranque sera el mismo.
update camocontrol.tb0309_items_movimientos set f0309_id_recep_compras = f0309_id_factura_costo;

--  datos del datagrid ST-0300-49

-- Actualizo los numeros de OC en los registros de moviiento de inventarios, ahora los movimientos de entrada se 
-- deben relacionar con la OC a la que pertenecen.
with tb_pend_fact as (
select f0309_id_mov_item, f0305_id_oc
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0305_items_solicitados
     on f0309_id_item_solicitud = f0305_id_item_solicitud
   join camocontrol.tb0319_ordenes_compra
     on f0305_id_oc = f0319_id_oc
--where f0309_id_solicitud_compra = 30407 and f0319_id_tercero='00003137' and f0309_id_factura_costo = 0
)
update camocontrol.tb0309_items_movimientos set 
  f0309_id_oc = tb_pend_fact.f0305_id_oc
from tb_pend_fact
where tb_pend_fact.f0309_id_mov_item = tb0309_items_movimientos.f0309_id_mov_item;

----------------------------------------------------------------------------------------------------------------
-- Borro el registro de factura para simular el proceso de registro de factura.
update camocontrol.tb0309_items_movimientos set f0309_id_factura_costo = 0, f0309_id_doc_ref = ''
where f0309_id_item_solicitud = 60017;  -- recepcion 27172

-- Busco todas la recepciones que se han realizado para un determinado item solicitado que aun no tengan registro de factura
--select f0309_id_mov_item, f0309_id_recep_compras as id_recepcion, 
--       f0309_id_documento as entrada, f0309_entrada as cantidad
select * --f0309_id_mov_item
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0305_items_solicitados
     on f0309_id_item_solicitud = f0305_id_item_solicitud
   join camocontrol.tb0319_ordenes_compra
     on f0305_id_oc = f0319_id_oc
--where f0309_id_item_solicitud = 60017 and f0309_id_factura_costo = 0
where f0309_id_solicitud_compra = 30407 and f0319_id_tercero='00003137' and f0309_id_factura_costo = 0

-- PARA CREAR UNA FUNCION EN POSTGRES
-- Asigno los items recibidos de una solicitud de compra a un registro de recepcion de factura.
with tb_pend_fact as (
select f0309_id_mov_item
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0305_items_solicitados
     on f0309_id_item_solicitud = f0305_id_item_solicitud
   join camocontrol.tb0319_ordenes_compra
     on f0305_id_oc = f0319_id_oc
where f0309_id_solicitud_compra = 30407 and f0319_id_tercero='00003137' and f0309_id_factura_costo = 0
)
update camocontrol.tb0309_items_movimientos set 
  f0309_id_factura_costo = 27172,
  f0309_id_doc_ref = 'FCP-' || 27172
from tb_pend_fact
where tb_pend_fact.f0309_id_mov_item = tb0309_items_movimientos.f0309_id_mov_item;

-- Asigno los items recibidos de un determinado item de una solicitud a un registro de recepcion de factura
with tb_pend_fact as (
select f0309_id_mov_item
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0305_items_solicitados
     on f0309_id_item_solicitud = f0305_id_item_solicitud
   join camocontrol.tb0319_ordenes_compra
     on f0305_id_oc = f0319_id_oc
where f0309_id_item_solicitud = 60016 and f0319_id_tercero='00003137' and f0309_id_factura_costo = 0
)
update camocontrol.tb0309_items_movimientos set 
  f0309_id_factura_costo = 27172,
  f0309_id_doc_ref = 'FCP-' || 27172
from tb_pend_fact
where tb_pend_fact.f0309_id_mov_item = tb0309_items_movimientos.f0309_id_mov_item;

-- Asigno los items recibidos de una orden de compra a un registro de recepcion de factura
with tb_pend_fact as (
select f0309_id_mov_item
from camocontrol.tb0309_items_movimientos
   join camocontrol.tb0305_items_solicitados
     on f0309_id_item_solicitud = f0305_id_item_solicitud
   join camocontrol.tb0319_ordenes_compra
     on f0305_id_oc = f0319_id_oc
where f0309_id_oc = 1510 and f0319_id_tercero='00003137' and f0309_id_factura_costo = 0 and f0305_anulado = 'N'
)
update camocontrol.tb0309_items_movimientos set 
  f0309_id_factura_costo = 27172,
  f0309_id_doc_ref = 'FCP-' || 27172
from tb_pend_fact
where tb_pend_fact.f0309_id_mov_item = tb0309_items_movimientos.f0309_id_mov_item;


-- prueba de funcion
select * from camocontrol.fnc_300_04_asignar_items_recepcionados_a_factura(
	3,      --tipo integer,
	1510,  --codigo integer,
	'00003137',  --tercero character,
	27172       --factura integer
	)

select * from camocontrol.tb0309_items_movimientos
--where f0309_id_item_solicitud = 60016
where f0309_id_solicitud_compra = 30407

select f0309_id_recep_compras as id_recepcion, 
       f0309_id_documento as entrada, f0309_entrada as cantidad
from camocontrol.tb0309_items_movimientos
where f0309_id_item_solicitud = 60016

-- Busco todos los items de docuemntos de entrada y recepciones que se encuentran registrados en una determinada factura
select f0309_id_recep_compras as id_recepcion, f0309_id_factura_costo,
           f0309_id_documento as entrada, f0309_entrada as cantidad
from camocontrol.tb0309_items_movimientos
where f0309_id_factura_costo = 27172

-- Lo anterior pero con todos los datos del datagrid ST-0300-49
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
	 
select f0305_id_solicitud_compra, f0305_estado, 
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
		f0305_costo_unitario_planificado as costo_unitario, 
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


-- Asignar a una factura las entradas realizadas por una Solicitud de compra asignada a un proveeedor segun OC.
select * from camocontrol.tb0305_items_solicitados
where f0305_id_solicitud_compra = '30407' and f0305_anulado = 'N'

