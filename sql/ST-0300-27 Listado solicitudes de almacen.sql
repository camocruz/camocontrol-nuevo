SELECT 'SALM-' || f0316_id_sol_alm as id_salm, bod_solicita.f0005_descripcion_bodega as bodega_solicitante,
       bod_entrega.f0005_descripcion_bodega as bodega_entrega,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as usuario_solicita,
       to_char(f0316_fr, 'YYYY/MM/DD HH12:MI:SS AM') as fecha_solicitud
  FROM camocontrol.tb0316_solicitudes_almacen_encabezado
  left join camocontrol.tb0005_bodegas as bod_solicita
     on f0316_bodega_solicita = bod_solicita.f0005_id_bodega
  left join camocontrol.tb0200_terceros
     on f0316_usuario_crear = f0200_id_tercero
  left join camocontrol.tb0317_solicitudes_almacen_detalle
     on f0316_id_sol_alm = f0317_id_sol_alm
  left join camocontrol.tb0005_bodegas as bod_entrega
     on f0317_bodega_entrega = bod_entrega.f0005_id_bodega
where f0316_id_cia = '00000001' 
      and f0316_fr BETWEEN '2017-01-19' and '2017-12-31'
group by f0316_id_sol_alm, bodega_solicitante, bodega_entrega,
         usuario_solicita, fecha_solicitud
