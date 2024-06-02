select *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga
from camocontrol.tb0351_elementos
    join camocontrol.tb0300_items
       on f0351_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join camocontrol.tb0302_tipos_items
       on f0302_id_tipo_item = f0300_id_tipo_item
    join camocontrol.tb0350_plantillas
       on f0351_id_plantilla = f0350_id_plantilla
where f0351_anulado = 'N' and f0350_activa = 'S'