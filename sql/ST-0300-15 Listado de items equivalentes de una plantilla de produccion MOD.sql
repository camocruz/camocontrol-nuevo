select *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga
from $df001$.tb0352_elementos_equivalentes
    join $df001$.tb0300_items
       on f0352_id_item = f0300_id_item
    join $df001$.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join $df001$.tb0302_tipos_items
       on f0302_id_tipo_item = f0300_id_tipo_item
where f0352_anulado = 'N' and f0352_id_plantilla = '$001$'