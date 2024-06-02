-- Exportar listado de seguimientos de actividades de mantenemiento
copy (
  SELECT json_agg(row_to_json(info_act_manto)):: text FROM (
    select f0600_id_accion, f0600_id_cia, f0600_id_tipo_registro,f0600_descripcion from camocontrol.tb0600_acciones
    where f0600_id_accion > 21050
  ) info_act_manto
)to 'E:/pruebas/info_act_manto.json';

