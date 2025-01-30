with tb_pistoleado as 
	(SELECT f0421_id_despacho, count(f0421_id_despacho) as pistoleo,
		sum(case when f0421_unidades_englobadas > 1 then f0421_unidades_englobadas else 1 end) as unid
		FROM $df001$.tb0421_etiquetas
		group by f0421_id_despacho
	),
	tb_volumen as
	(select f0850_id_despacho, 
	sum(f0851_cantidad) as ped,
	sum(f0804_volumen * f0851_cantidad) as volumen
	from $df001$.tb0851_remisiones_cguno_detalle
     	left join $df001$.tb0850_remisiones_cguno_encabezado
        	on f0851_id_rm = f0850_id_rm
		left join $df001$.tb0408_items_cg
			on f0408_referencia = f0851_referencia_1
		left join $df001$.tb0804_especificaciones_cajas_pt
			on f0804_id_caja = f0408_id_caja_corrugado
group by f0850_id_despacho ),
	tb_dtos_cajas as
	(select f0850_id_despacho as despachovalidcaj,
	case when (
				sum(case when (f0804_volumen) > 0 then 0 else 1 end)
			  ) = 0 then 1 else 0 end as factor
	from $df001$.tb0851_remisiones_cguno_detalle
     	left join $df001$.tb0850_remisiones_cguno_encabezado
        	on f0851_id_rm = f0850_id_rm
		left join $df001$.tb0408_items_cg
			on f0408_referencia = f0851_referencia_1
		left join $df001$.tb0804_especificaciones_cajas_pt
			on f0804_id_caja = f0408_id_caja_corrugado
group by f0850_id_despacho  )
select f0800_id_despacho as id_pdd, coalesce(f0005_cod_bodega, 'ND') as bodega,
      trim(both ' ' from tb_asesor.f0200_apellido1 || ' ' || tb_asesor.f0200_apellido2 || ' ' || tb_asesor.f0200_nombres) as asesor,
      trim(both ' ' from tb_cliente.f0200_apellido1 || ' ' || tb_cliente.f0200_apellido2 || ' ' || tb_cliente.f0200_nombres) as cliente,
      tb_cliente.f0200_id as nit, f0052_ciudad || ' - ' || f0051_departamento as destino, f0800_direccion_destino as direccion,
      to_char(f0800_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_pedido, 
	  f0800_tot_cajas_aprobadas as ped, pistoleo, f0800_tot_cajas_despachadas as guia, round(volumen * factor ,2) as m3
from $df001$.tb0800_despachos_comercial
     left join $df001$.tb0200_terceros as tb_asesor
        on f0800_vendedor = tb_asesor.f0200_id_tercero
     join $df001$.tb0200_terceros as tb_cliente
        on f0800_cliente = tb_cliente.f0200_id_tercero
     left join $df001$.tb0052_ciudades
        on tb0800_despachos_comercial.f0800_id_ciudad_destino = f0052_codigo_ciudad
     left join $df001$.tb0051_departamentos
        on f0051_codigo_departamento = f0052_codigo_departamento
	 left join $df001$.tb0005_bodegas
	 	on f0005_id_bodega = f0800_id_bodega
	 left join tb_pistoleado
	 	on tb_pistoleado.f0421_id_despacho = f0800_id_despacho
	 left join tb_volumen
	 	on f0850_id_despacho = f0800_id_despacho
	 left join tb_dtos_cajas
	 	on f0850_id_despacho = despachovalidcaj
where f0800_anulado = 'N'
     and f0800_guia_registrada = 'N'
order by f0800_id_despacho
