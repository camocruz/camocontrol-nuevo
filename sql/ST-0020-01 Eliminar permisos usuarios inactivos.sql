with inactivos as (
  select DISTINCT ON (f0022_id_usuario) f0022_id_usuario from camocontrol.tb0022_usuarios_permiso
   join camocontrol.tb0200_terceros
     on f0200_id_tercero = f0022_id_usuario
  where f0200_estado = 'I' and f0200_id_cia = '00000001'
)
DELETE FROM camocontrol.tb0022_usuarios_permiso
 WHERE tb0022_usuarios_permiso.f0022_id_usuario = 
   (select f0022_id_usuario from inactivos where inactivos.f0022_id_usuario = tb0022_usuarios_permiso.f0022_id_usuario)
   

