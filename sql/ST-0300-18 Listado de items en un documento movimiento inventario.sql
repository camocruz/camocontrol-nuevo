select *,
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as descripcion_larga
from camocontrol.tb0309_items_movimientos
    join camocontrol.tb0300_items
       on f0309_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    left join camocontrol.tb0312_clasificadores_movimientos
       on f0309_id_clasificador = f0312_id_clasificador
where f0309_id_documento = 'TRI-00000247' and f0309_anulado = 'N' and f0309_id_cia = '00000001'
order by f0309_fecha_movimiento asc, f0309_id_mov_item asc;