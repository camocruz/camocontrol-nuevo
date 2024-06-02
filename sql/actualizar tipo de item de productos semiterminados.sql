WITH otb AS (
SELECT f0300_id_item as it, f0302_descripcion_tipo_item, f0300_descripcion_item
FROM camocontrol.tb0300_items
JOIN camocontrol.tb0302_tipos_items
  ON f0302_id_tipo_item = f0300_id_tipo_item
JOIN camocontrol.tb0350_plantillas
   ON f0300_id_item = f0350_id_item
ORDER BY f0300_id_tipo_item, f0300_id_item
)

UPDATE camocontrol.tb0300_items SET
       f0300_id_tipo_item = 25
from otb
WHERE f0300_id_tipo_item <> 15 AND f0300_id_tipo_item <> 25
      AND f0300_id_item = otb.it