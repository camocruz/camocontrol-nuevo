SELECT f0316_id_sol_alm as id_solicitud, f0005_descripcion_bodega as bodega_solicitante,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as usuario_solicita,
       f0316_fr as fecha_solicitud, f0316_id_accion as id_accion
  FROM camocontrol.tb0316_solicitudes_almacen_encabezado
  left join camocontrol.tb0005_bodegas
     on f0316_bodega_solicita = f0005_id_bodega
  left join camocontrol.tb0200_terceros
     on f0316_usuario_crear = f0200_id_tercero
where f0316_id_sol_alm = '1' and f0316_id_cia = '00000001'
