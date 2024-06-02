-- identifico los menus principales
select * from camocontrol.tb0020_opciones_control
where char_length(f0020_codigo) = 4 order by f0020_codigo

-- identifico los submenus
select * from camocontrol.tb0020_opciones_control
where f0020_codigo LIKE '010709%' 
--and char_length(f0020_codigo) = 8
order by f0020_codigo;

-- agrego el nuevo menu
INSERT INTO camocontrol.tb0020_opciones_control(
	f0020_codigo, f0020_menu_sn, 
	f0020_descripcion, f0020_formulario, 
	f0020_control, f0020_codigo_padre, f0020_contexto)
	VALUES ('010709', 'S', 
			'PRODUCCION MANUFACTURA CGUNO', 'formulario_inicio', 
			'mi_produccion_manufactura_cguno', '0107', '');

INSERT INTO camocontrol.tb0020_opciones_control(
	f0020_codigo, f0020_menu_sn, 
	f0020_descripcion, f0020_formulario, 
	f0020_control, f0020_codigo_padre, f0020_contexto)
	VALUES ('01070901', 'S', 
			'CARGAR IP CG-UNO', 'formulario_inicio', 
			'mi_cargar_ip_cguno', '010709', '');
			
INSERT INTO camocontrol.tb0020_opciones_control(
	f0020_codigo, f0020_menu_sn, 
	f0020_descripcion, f0020_formulario, 
	f0020_control, f0020_codigo_padre, f0020_contexto)
	VALUES ('01070903', 'S', 
			'ACTUALIZAR LOTE IP CG-UNO', 'formulario_inicio', 
			'mi_actualizar_lotes_ip_cguno', '010709', '');

INSERT INTO camocontrol.tb0020_opciones_control(
	f0020_codigo, f0020_menu_sn, 
	f0020_descripcion, f0020_formulario, 
	f0020_control, f0020_codigo_padre, f0020_contexto)
	VALUES ('01050502', 'N', 
			'GENERAR LISTADO FLETES TRANSPORTADORAS', 'fm_0800_perfil_transportadora', 
			'bt_listado_fletes', '010505', '');

-- actualizo un menu
UPDATE camocontrol.tb0020_opciones_control
	SET f0020_menu_sn=?, f0020_descripcion=?, f0020_formulario=?, f0020_control=?, f0020_codigo_padre=?, f0020_contexto=?
	WHERE f0020_codigo=?;
