SELECT f0606_id_seguimiento_accion as id_sgmnto, f0606_seguimiento_accion as seguimiento,
       to_number(f0606_nivel_cumplimiento, '999') || '%' as cumplimiento,
       to_char(f0606_fecha_fin, 'YYYY-MM-DD HH12:MI AM') as fecha_fin,
       EXTRACT(DAY FROM f0606_fecha_fin - f0606_fecha_inicio) || ' dias ' ||
       EXTRACT(HOUR FROM f0606_fecha_fin - f0606_fecha_inicio) || ' horas ' ||
       EXTRACT(MINUTE FROM f0606_fecha_fin - f0606_fecha_inicio) || ' minutos' as duracion,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor
FROM $df001$.tb0606_seguimientos_acciones
    join $df001$.tb0200_terceros
        on f0606_usuario_crear = f0200_id_tercero
where f0606_id_cia = '$001$' and f0606_anulado = 'N' and
      f0606_id_documento = '$002$' and f0606_tipo_nota = '$003$'
order by f0606_fecha_fin desc
