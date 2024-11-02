----- prueba
-- Identifico todos los items que fueron despachados por pistoleo o por remision
with tb_union_items_desp as 
((select f0421_id_despacho as id_desp, f0420_id_producto as id_prod
	from camocontrol.tb0421_etiquetas
		left join camocontrol.tb0420_orden_imp_etiquetas
			on f0420_id_impresion = f0421_id_impresion
where f0421_id_despacho is not null and f0421_id_despacho = 68702
group by f0421_id_despacho, f0420_id_producto order by f0420_id_producto
)
union
(select f0850_id_despacho, f0851_id_item
    from camocontrol.tb0851_remisiones_cguno_detalle
        left join camocontrol.tb0850_remisiones_cguno_encabezado
            on f0851_id_rm = f0850_id_rm
where f0850_id_despacho is not null and f0850_id_despacho = 68702
group by f0850_id_despacho, f0851_id_item order by f0851_id_item
)),
tb_info_trazable as 
(select distinct f0420_lote as lote, to_char(f0420_fecha_vence, 'YYYY-MM-DD') as f_vence, 
 f0421_id_despacho as id_despacho, f0420_id_producto as id_producto
	from camocontrol.tb0421_etiquetas
		left join camocontrol.tb0420_orden_imp_etiquetas
         on f0420_id_impresion = f0421_id_impresion
	where f0421_id_despacho is not null
)

select id_desp, id_prod, lote 
	from tb_union_items_desp
		left join tb_info_trazable
         on id_despacho = id_desp and id_prod = id_producto
group by id_desp, id_prod, lote






-- Identifico todos los items que fueron despachados por pistoleo o por remision
with tb_union_items_desp as 
((select f0421_id_despacho as id_desp, f0420_id_producto as id_prod
	from camocontrol.tb0421_etiquetas
		left join camocontrol.tb0420_orden_imp_etiquetas
			on f0420_id_impresion = f0421_id_impresion
where f0421_id_despacho is not null and f0421_id_despacho = 68702
group by f0421_id_despacho, f0420_id_producto order by f0420_id_producto
)
union
(select f0850_id_despacho, f0851_id_item
    from camocontrol.tb0851_remisiones_cguno_detalle
        left join camocontrol.tb0850_remisiones_cguno_encabezado
            on f0851_id_rm = f0850_id_rm
where f0850_id_despacho is not null and f0850_id_despacho = 68702
group by f0850_id_despacho, f0851_id_item order by f0851_id_item
))

SELECT f0800_id_despacho as id_pdd, to_char(f0800_fecha_despacho, 'YYYY-MM-DD') as f_despacho, f0300_id_item as id_item, 
       f0300_referencia as referencia,
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item, 
       f0420_lote, to_char(f0420_fecha_vence, 'YYYY-MM-DD') as f_vence,
       trim(both ' ' from tb0200_terceros.f0200_apellido1 || ' ' || tb0200_terceros.f0200_apellido2 || ' ' || tb0200_terceros.f0200_nombres) as cliente,
       f0200_id as nit, f0052_ciudad as ciudad, f0051_departamento as departamento
  FROM camocontrol.tb0800_despachos_comercial
       join tb_union_items_desp
	   	  on tb_union_items_desp.id_desp = f0800_id_despacho
  	   left join camocontrol.tb0300_items
         on f0300_id_item = tb_union_items_desp.id_prod


		 
       left join camocontrol.tb0421_etiquetas
         on f0421_id_despacho = f0800_id_despacho
       left join camocontrol.tb0420_orden_imp_etiquetas
         on f0420_id_impresion = f0421_id_impresion
       
       left join camocontrol.tb0200_terceros
         on f0200_id_tercero = f0800_cliente
	   left join camocontrol.tb0052_ciudades
	     on f0800_id_ciudad_destino = f0052_codigo_ciudad
	   left join camocontrol.tb0051_departamentos
	     on f0052_codigo_departamento = f0051_codigo_departamento
  where f0800_id_cia = '00000001' and f0800_anulado = 'N' 
       and f0800_id_despacho = 68702
       and f0800_fecha_despacho BETWEEN '2024-04-01' AND '2024-08-08'
  group by f0800_id_despacho, f_despacho, id_item, item, f0300_referencia,
       f0300_descripcion_item, f0420_lote, f_vence,cliente,
       f0200_id, f0052_ciudad, f0051_departamento
  order by f0300_referencia, f0420_lote