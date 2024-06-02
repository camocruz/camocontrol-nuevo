SELECT f0100_id_estructura,
       (string_to_array(f0100_path,'-')), 
       coalesce((string_to_array(f0100_path,'-'))[array_length((string_to_array(f0100_path,'-')),1) - 1]::int,0)
  FROM camocontrol.tb0100_estructura_mantenimiento
  order by f0100_id_estructura;


update camocontrol.tb0100_estructura_mantenimiento set
    f0100_estructura_padre = coalesce((string_to_array(f0100_path,'-'))[array_length((string_to_array(f0100_path,'-')),1) - 1]::int,0)
where f0100_id_cia = '00000001'
