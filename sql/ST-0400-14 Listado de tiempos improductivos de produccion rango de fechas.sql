select f0600_id_accion as id_acc, f0600_id_docto_padre as id_rp,
round(extract('epoch' from f0402_fecha_programada_fin_prod - f0402_fecha_programada_ini_prod)/3600) AS h_programadas,
f0402_produccion_programada as prod_programada,
      f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as producto,
      f0402_cantidad_producida as produccion, f0002_unidad_medicion as unidad,    
      replace(replace(f0600_descripcion, chr(10),'.  '), chr(13), '') as descripcion,
      f0603_descriptor_estado as estado,
      to_char(f0600_fecha_ocurrencia_evento, 'YYYY-MM-DD HH12:MI AM') as f_inicio,
      to_char(f0600_fecha_cierre_correctivo, 'YYYY-MM-DD HH12:MI AM') as f_fin,
      round(extract('epoch' from f0600_fecha_cierre_correctivo - f0600_fecha_ocurrencia_evento)/60) AS minutos_parada,
      tb_responsable.f0200_apellido1 || ' ' || substring(tb_responsable.f0200_nombres from 1 for 1) as responsable,
      f0600_nivel_cumplimiento || '%' as avance,
      CASE coalesce(elemento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN elemento.f0100_nombre
          WHEN elemento.f0100_id_estructura THEN elemento.f0100_nombre 
          else
          maquina.f0100_nombre || ' =>> ' || elemento.f0100_nombre
       end as estructura_acc,
      maquina_rp.f0100_nombre as maquina_rp,
      tb_modo_falla.f0609_mef as modo_falla,
      tb_causa_falla.f0609_mef as causa_falla
from camocontrol.tb0600_acciones
     join camocontrol.tb0603_estados_acciones
          on f0600_id_estado_accion = f0603_id_estado_accion
     join camocontrol.tb0602_tipos_acciones
          on f0600_id_tipo_accion = f0602_id_tipo_accion
     left join camocontrol.tb0100_estructura_mantenimiento as elemento
          on f0600_id_estructura = elemento.f0100_id_estructura
     left join camocontrol.tb0100_estructura_mantenimiento as maquina
          on maquina.f0100_id_estructura = elemento.f0100_id_maquina_padre
     left join camocontrol.tb0200_terceros as tb_responsable
          on f0600_responsable = tb_responsable.f0200_id_tercero
     left join camocontrol.tb0402_reporte_produccion
          on f0402_id_rp = f0600_id_docto_padre
     join camocontrol.tb0300_items
          on f0300_id_item = f0402_id_item
     join camocontrol.tb0002_unidades_medicion
          on f0002_id_unidad_medicion = f0300_id_unidad_medicion
     left join camocontrol.tb0100_estructura_mantenimiento as maquina_rp
          on f0402_id_maquina = maquina_rp.f0100_id_estructura
     left join camocontrol.tb0609_modos_efectos_falla as tb_modo_falla
          on tb_modo_falla.f0609_id_mef = f0600_id_mef
     left join camocontrol.tb0609_modos_efectos_falla as tb_causa_falla
          on tb_causa_falla.f0609_id_mef = f0600_id_mef_causa
where 
  f0600_id_cia = '00000001' and f0600_tipo_docto_padre = 'RP'
  and coalesce(f0600_fecha_ocurrencia_evento, f0600_fr) BETWEEN '2019-10-01' and '2020-10-31'
order by f0600_id_accion