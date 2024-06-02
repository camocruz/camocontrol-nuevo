SELECT f0850_id_despacho, sum(f0851_cantidad) as ped
  FROM camocontrol.tb0850_remisiones_cguno_encabezado
    join camocontrol.tb0851_remisiones_cguno_detalle
      on f0850_id_rm = f0851_id_rm
where f0850_id_despacho = '4558' and f0850_anulado = 'N' and f0851_anulado = 'N'
group by f0850_id_despacho
