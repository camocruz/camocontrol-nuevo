SELECT f0606_id_seguimiento_accion as id_sgmnto, f0606_seguimiento_accion as seguimiento,
       to_char(f0606_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_reg,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor
FROM camocontrol.tb0606_seguimientos_acciones
    join camocontrol.tb0200_terceros
        on f0606_usuario_crear = f0200_id_tercero
where f0606_id_documento = '6416' and f0606_tipo_nota = 'ACC'
      and f0606_usuario_crear = f0606_usuario_crear
order by f0606_fecha_fin desc