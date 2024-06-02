copy (
SELECT f0022_codigo as codigo, f0021_nombre_completo as usuario, f0020_descripcion as descripcion,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre
  FROM camocontrol.tb0022_usuarios_permiso
join camocontrol.tb0021_usuarios
 on f0021_id_usuario = f0022_id_usuario
join camocontrol.tb0020_opciones_control
 on f0020_codigo = f0022_codigo
join camocontrol.tb0200_terceros
 on f0200_id_tercero = f0022_id_usuario
order by f0021_nombre_completo,f0022_codigo
) to 'S:/dsfc/rh_asistencia/perm.txt' DELIMITER '	' CSV HEADER; --'S:/dsfc/rh_asistencia/rms.txt';

