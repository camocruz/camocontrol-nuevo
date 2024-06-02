with inactivos as (
  select DISTINCT ON (f0022_id_usuario) f0022_id_usuario from $df001$.tb0022_usuarios_permiso
   join $df001$.tb0200_terceros
     on f0200_id_tercero = f0022_id_usuario
  where f0200_estado = 'I' and f0200_id_cia = '$001$'
)
DELETE FROM $df001$.tb0022_usuarios_permiso
 WHERE tb0022_usuarios_permiso.f0022_id_usuario = 
   (select f0022_id_usuario from inactivos where inactivos.f0022_id_usuario = tb0022_usuarios_permiso.f0022_id_usuario)
   

