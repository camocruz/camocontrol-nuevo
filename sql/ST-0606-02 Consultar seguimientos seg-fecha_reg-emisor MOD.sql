SELECT f0606_id_seguimiento_accion as id_sgmnto, f0606_seguimiento_accion as seguimiento,
       to_char(f0606_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_reg,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor
FROM $df001$.tb0606_seguimientos_acciones
    join $df001$.tb0200_terceros
        on f0606_usuario_crear = f0200_id_tercero
where f0606_id_cia = '$001$' and f0606_anulado = 'N' and
      f0606_id_documento = '$002$' and f0606_tipo_nota = '$003$'
      and f0606_usuario_crear = $004$
order by f0606_fr desc