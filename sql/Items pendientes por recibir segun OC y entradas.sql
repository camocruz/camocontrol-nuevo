-- Items pendientes por recibir por proveedor
with otb1 as (
   select f0319_id_tercero,
          f0305_id_item,
          f0305_id_item_solicitud, f0305_id_solicitud_compra,
		  f0305_id_oc, f0305_oc_uno,
		  to_char(f0319_fecha_aprobacion, 'YYYY-MM-DD') as f_oc_Aprov,
		  to_char(f0305_fecha_requerido, 'YYYY-MM-DD') as fecha_requiere,
		  f0305_cantidad,
          f0305_cantidad - coalesce(sum(f0309_entrada),0) as pendiente,
		  
		  f0305_id_estructura, f0305_id_accion
       from camocontrol.tb0305_items_solicitados
	      left join camocontrol.tb0309_items_movimientos
	         on f0309_id_item_solicitud = f0305_id_item_solicitud
	      left join camocontrol.tb0319_ordenes_compra
   	         on f0319_id_oc = f0305_id_oc
   where f0319_id_tercero = '00000242' and 
         f0319_aprobada = 'S' and f0319_cumplida = 'N'
   group by f0319_id_tercero, f0305_id_item, 
            f0305_id_item_solicitud, f0305_id_solicitud_compra, 
            f0305_cantidad, f0305_id_oc, f0305_oc_uno,
			f0319_fecha_aprobacion, fecha_requiere,
			f0305_id_estructura, f0305_id_accion
)
select otb1.*,
	   f0300_descripcion_item || ' <<CG:' || f0300_referencia || '>>' as descripcion,
       f0302_descripcion_tipo_item as tipo_item,
       f0300_id_item as id_item,
	   f0002_sigla_unidad_medicion as unid,
       trim (both ' ' from f0200_apellido1 || ' ' || f0200_nombres) as tercero,
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
	  left join camocontrol.tb0200_terceros
		 on f0200_id_tercero = f0319_id_tercero
      left join camocontrol.tb0100_estructura_mantenimiento
         on f0305_id_estructura = f0100_id_estructura
      left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
         on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
	  left join camocontrol.tb0600_acciones
         on f0600_id_accion = f0305_id_accion
	  join camocontrol.tb0300_items
         on f0305_id_item = f0300_id_item
      join camocontrol.tb0002_unidades_medicion
         on f0300_id_unidad_medicion = f0002_id_unidad_medicion
      join camocontrol.tb0302_tipos_items
         on f0302_id_tipo_item = f0300_id_tipo_item
where pendiente <> 0