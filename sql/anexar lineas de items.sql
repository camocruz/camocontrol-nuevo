-- inserto los datos en la tabla temporal
delete from camocontrol.tb0303_temp;
copy camocontrol.tb0303_temp from 'E:\borrar.txt';

-- inserto los datos en la tabla de lineas
insert into camocontrol.tb0303_lineas_items
  (f0303_id_cia, f0303_id_linea_item, f0303_descripcion_linea_item, 
   f0303_usuario_crear, f0303_usuario_modificar, 
   f0303_id_padre, f0303_nivel, f0303_raiz, f0303_path
   )
   (
	SELECT '00000001', tf0303_id_linea_item, tf0303_descripcion_linea_item, 
	   '00000001', '00000001',
	   tf0303_id_padre, tf0303_nivel, tf0303_raiz, tf0303_path
	FROM camocontrol.tb0303_temp
   )
