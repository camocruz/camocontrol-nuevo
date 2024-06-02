SELECT f0200_id_tercero as id_tercero, f0200_id || '-' ||f0200_dig_ver_nit nit, 
       trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2) as razon_social
  FROM camocontrol.tb0200_terceros
  where f0200_id_cia = '00000001' and f0200_ind_proveedor = 'S'
       and f0200_ind_principal = 'S'
  order by razon_social;
