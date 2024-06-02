select *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga
from camocontrol.tb0352_elementos_equivalentes
    join camocontrol.tb0300_items
       on f0352_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
       on f0302_id_tipo_item = f0300_id_tipo_item
where f0352_anulado = 'N' and f0352_id_plantilla = '1'