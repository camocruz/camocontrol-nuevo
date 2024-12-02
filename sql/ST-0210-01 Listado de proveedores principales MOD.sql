SELECT f0200_id_tercero as id_tercero, f0200_id || '-' ||f0200_dig_ver_nit nit, 
       trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2 || '- ' || f0200_id) as razon_social
  FROM $df001$.tb0200_terceros
  where f0200_id_cia = '$001$' and f0200_ind_proveedor = 'S'
       and f0200_ind_principal = 'S'
  order by razon_social;
