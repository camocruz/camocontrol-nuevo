SELECT f0550_id_registro as id_rgtro, f0550_id_documento as registro, 
       to_char(f0550_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_subida
  FROM camocontrol.tb0550_registros
WHERE f0550_fecha_registro BETWEEN '2016-01-01' and '2019-03-01' 
order by f0550_id_documento, f0550_fecha_registro
