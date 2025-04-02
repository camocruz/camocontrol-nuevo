-- ST-0300-50 Items compras recepcionados pero no facturados
-- Entradas pendientes por registrar en una factura de compras 
with otb1 as (
   select f0319_id_tercero, f0309_id_documento,
          f0309_id_mov_item, f0305_id_item,
          f0305_id_solicitud_compra, f0305_id_item_solicitud,
		  f0305_id_oc, f0305_oc_uno, f0309_id_recep_compras,
		  f0305_cantidad, f0309_entrada,
		  f0305_id_estructura, f0305_id_accion
       from $df001$.tb0305_items_solicitados
	      left join $df001$.tb0309_items_movimientos
	         on f0309_id_item_solicitud = f0305_id_item_solicitud
	      left join $df001$.tb0319_ordenes_compra
   	         on f0319_id_oc = f0305_id_oc
   where --f0319_id_tercero = '' and -- no quitar esta linea, la uso para cuando requiero la tabla filtrada por tercero
         f0319_aprobada = 'S' and f0319_cumplida = 'N'
		 and f0305_id_factura_compras is null
		 and f0309_id_documento is not null
)
select f0319_id_tercero as id_tercero, 
       trim (both ' ' from f0200_apellido1 || ' ' || f0200_nombres) as proveedor,
	   f0305_id_solicitud_compra as id_sc, f0305_id_item_solicitud as id_sc_item, 
	   f0305_id_oc as id_oc, f0305_oc_uno as oc_uno, f0309_id_recep_compras as id_recep,
	   otb1.f0309_id_documento as id_doc_inv, f0309_id_mov_item as id_mov_item,
	   f0300_descripcion_item || ' <<CG:' || f0300_referencia || '>>' as descripcion,
       f0300_id_item as id_item, f0309_entrada as cant,
	   f0002_sigla_unidad_medicion as unid,
	   f0305_id_accion as id_acc, 
       coalesce(f0600_id_accion_principal, coalesce(f0305_id_accion, 0)) as id_acc_ppal,
	   CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre || ' =>> ' || tb0100_estructura_mantenimiento.f0100_nombre
       end as nombre_estructura, 
       CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre
       end as maquina
   from otb1
	  left join $df001$.tb0200_terceros
		 on f0200_id_tercero = f0319_id_tercero
      left join $df001$.tb0100_estructura_mantenimiento
         on f0305_id_estructura = f0100_id_estructura
      left join $df001$.tb0100_estructura_mantenimiento as otb_maquina
         on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
	  left join $df001$.tb0600_acciones
         on f0600_id_accion = f0305_id_accion
	  join $df001$.tb0300_items
         on f0305_id_item = f0300_id_item
      join $df001$.tb0002_unidades_medicion
         on f0300_id_unidad_medicion = f0002_id_unidad_medicion
      join $df001$.tb0302_tipos_items
         on f0302_id_tipo_item = f0300_id_tipo_item
--where pendiente <> 0