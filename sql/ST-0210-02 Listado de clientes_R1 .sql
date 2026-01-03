SELECT f0200_id_tercero as id_tercero, 
	f0200_id nit, 
    btrim((( (f0200_apellido1 || ' ') 
	       || tb0200_terceros.f0200_apellido2) || ' ') 
		   || tb0200_terceros.f0200_nombres, ' ')
		   || ' - ' || f0200_id
		   as razon_social,
	(tb0052_ciudades.f0052_ciudad::text || ' - '::text) 
	|| tb0051_departamentos.f0051_departamento::text ciudad,
	f0200_direccion_residencia as direccion,
  f0200_nombre_sucursal nombre_sucursal, f0200_id_sucursal_unoee id_sucursal_unoee
  FROM camocontrol.tb0200_terceros
  	 JOIN camocontrol.tb0052_ciudades ON f0200_ciudad_residencia = tb0052_ciudades.f0052_codigo_ciudad
     JOIN camocontrol.tb0051_departamentos ON tb0051_departamentos.f0051_codigo_departamento = tb0052_ciudades.f0052_codigo_departamento
 where f0200_id_cia = '00000001' and f0200_ind_cliente = 'S'
 order by razon_social;
