INSERT INTO camocontrol.tb0840_cotizaciones_cguno_encabezado
		(f0840_cv, f0840_codigo_vendedor, f0840_nit_cliente, f0840_razon_social, 
			f0840_fecha
		)
		SELECT f0840_cv, f0840_codigo_vendedor, f0840_nit_cliente, f0840_razon_social, 
				f0840_fecha
		FROM camocontrol.tb0840_cotizaciones_cguno_encabezado_temp
		ON CONFLICT (f0840_cv) DO NOTHING;
		
		
INSERT INTO camocontrol.tb0841_cotizaciones_cguno_detalle
		(f0841_cv, f0841_referencia, f0841_descripcion, f0841_bodega, 
			f0841_unidad, f0841_pedido, f0841_despachado, f0841_faltante, f0841_valor_cv
		)
		SELECT f0841_cv, f0841_referencia, f0841_descripcion, f0841_bodega, 
		f0841_unidad, f0841_pedido, f0841_despachado, f0841_faltante, f0841_valor_cv
		FROM camocontrol.tb0841_cotizaciones_cguno_detalle_temp
		ON CONFLICT (f0840_cv)
		;