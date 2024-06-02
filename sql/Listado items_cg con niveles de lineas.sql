WITH tb_lineas as (
	SELECT f0303_id_linea_item, f0303_descripcion_linea_item, 
 	f0303_id_padre, f0303_nivel, 
	f0303_raiz, f0303_path
	FROM camocontrol.tb0303_lineas_items
)
 SELECT tb0408_items_cg.f0408_referencia,
    tb0408_items_cg.f0408_descripcion,
    tb0408_items_cg.f0408_unid_medida,
    tb0408_items_cg.f0408_peso,
    tb0408_items_cg.f0408_planta,
    tb0408_items_cg.f0408_tip_produccion,
    tb0408_items_cg.f0408_tip_producto,
	-- Linea de primer nivel
	CASE WHEN f0303_raiz is null 
		THEN f0303_descripcion_linea_item
		ELSE (SELECT tb_lineas.f0303_descripcion_linea_item FROM tb_lineas
			  WHERE tb0303_lineas_items.f0303_raiz = tb_lineas.f0303_id_linea_item )
    END as f0303_descripcion_linea_item,
    tb0408_items_cg.f0408_factor_empaque,
    tb0408_items_cg.f0408_factor_cobertura,
    tb0408_items_cg.f0408_costo_estandar,
    tb0408_items_cg.f0408_tip_venta,
	-- Linea de segundo nivel
	CASE WHEN f0303_raiz is null 
		THEN 'NA'
		ELSE (SELECT tb_lineas.f0303_descripcion_linea_item FROM tb_lineas
			  WHERE tb0303_lineas_items.f0303_id_padre = tb_lineas.f0303_id_linea_item )
    END as linea_item_2_nivel,
	-- Linea de tercer nivel
	CASE WHEN f0303_raiz is null 
		THEN 'NA'
		ELSE (SELECT tb_lineas.f0303_descripcion_linea_item FROM tb_lineas
			  WHERE tb0303_lineas_items.f0303_id_linea_item = tb_lineas.f0303_id_linea_item )
    END as linea_item_3_nivel
   FROM camocontrol.tb0408_items_cg
     LEFT JOIN camocontrol.tb0303_lineas_items 
	 	ON tb0303_lineas_items.f0303_id_linea_item = tb0408_items_cg.f0408_id_linea
   where tb0408_items_cg.f0408_referencia = '3-34';
