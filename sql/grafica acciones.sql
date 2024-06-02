-- Listado de Proyectos
Copy(
SELECT * from camocontrol.vi0600_proyectos_mantenimiento
) to 'E:\area_trabajo\DAT\CSVLstdoPryctos.txt' DELIMITER '	'  CSV HEADER;

copy (
select * from camocontrol.vi0600_listado_acciones
) to 'E:\area_trabajo\DAT\CSVLstdoActvPryctos.txt' DELIMITER '	'  CSV HEADER;

copy (
	select * from camocontrol.vi0600_compras
) to 'E:\area_trabajo\DAT\CSVComprasManto.txt' DELIMITER '	'  CSV HEADER;

