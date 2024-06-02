SELECT f0316_id_sol_alm as id_soalcc, 
   to_char(f0316_fr, 'YYYY-MM-DD HH12:MI AM') as fecha,
   f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor
  FROM $df001$.tb0316_solicitudes_almacen_encabezado 
    join $df001$.tb0200_terceros 
        on f0316_usuario_crear = f0200_id_tercero
where f0316_id_cia = '$001$' and f0316_id_accion = '$002$' and f0316_anulado = 'N';
