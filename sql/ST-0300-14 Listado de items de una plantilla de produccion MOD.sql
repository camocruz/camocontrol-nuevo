select *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga
from $df001$.tb0351_elementos
    join $df001$.tb0300_items
       on f0351_id_item = f0300_id_item
    join $df001$.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join $df001$.tb0302_tipos_items
       on f0302_id_tipo_item = f0300_id_tipo_item
    join $df001$.tb0350_plantillas
       on f0351_id_plantilla = f0350_id_plantilla
where f0351_anulado = 'N' and f0351_id_plantilla = '$001$'