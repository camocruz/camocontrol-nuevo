SELECT f0400_id_pp as id_prog_prod, f0400_nombre as nombre, to_char(f0400_fecha_inicio, 'YYYY-MM-DD') as f_ini, 
       to_char(f0400_fecha_final, 'YYYY-MM-DD') as f_fin, f0400_cerrado as cerrado
  FROM camocontrol.tb0400_programa_produccion
  where f0400_id_cia = '00000001' and f0400_anulado = 'N' and f0400_dosificacion = 'N'
  order by f0400_id_pp desc
