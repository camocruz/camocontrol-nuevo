select trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre,
       f0200_id as identificacion, f0200_codigo_empleado as codigo, f0200_estado as estado,
       f0240_cargo as cargo
from camocontrol.tb0200_terceros
  LEFT JOIN camocontrol.tb0240_cargos_compania ON f0240_id_cargo = f0200_id_cargo
where f0200_id_cia = '00000001' and f0200_ind_empleado = 'S'
order by f0200_codigo_empleado
