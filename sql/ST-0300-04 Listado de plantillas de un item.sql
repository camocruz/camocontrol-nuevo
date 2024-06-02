SELECT f0350_id_plantilla as id_exmtp, f0350_descripcion as descripcion,
       f0350_produccion_x_bache as prod_bache, f0002_unidad_medicion as unid, f0350_activa as activa, f0350_anulado as anulada
FROM camocontrol.tb0350_plantillas
     join camocontrol.tb0300_items
        on f0350_id_item = f0300_id_item
     join camocontrol.tb0002_unidades_medicion
        on f0300_id_unidad_medicion = f0002_id_unidad_medicion
WHERE f0350_id_cia = '00000001' AND f0350_id_item = '3365'
order by f0350_anulado, f0350_id_plantilla