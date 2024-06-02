SELECT f0100_id_estructura, f0100_nombre
  FROM camocontrol.tb0100_estructura_mantenimiento
where f0100_anulado = 'N' and f0100_id_cia = '00000001'
      and f0100_id_tipo_estructura = '00000001'
      and array_length(string_to_array(f0100_path, '-'),1)=2
order by f0100_nombre
