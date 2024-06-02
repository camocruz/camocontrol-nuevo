select tb0304_solicitud_compra.*, f0600_path || f0600_id_accion || '-' as path_accion,
       tb0306_estados_compras.*,
       CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre || ' =>> ' || tb0100_estructura_mantenimiento.f0100_nombre
       end as nombre_estructura
  from camocontrol.tb0304_solicitud_compra
      join camocontrol.tb0306_estados_compras
        on f0304_id_estado = f0306_id_estado_compras
      left join camocontrol.tb0600_acciones
        on f0600_id_accion = f0304_id_accion
      left join camocontrol.tb0100_estructura_mantenimiento
        on f0304_id_estructura = f0100_id_estructura
      left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
        on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre 
Where (f0600_id_cia = '00000001' and f0600_id_accion = '10856' and f0304_anulado = 'N') 
        or 
      (f0600_id_cia = '00000001' and substring(f0600_path from 1 for char_length('-10856-')) = '-10856-'  and f0304_anulado = 'N')
order by f0304_id_solicitud desc