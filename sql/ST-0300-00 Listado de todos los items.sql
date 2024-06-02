SELECT tb0300_items.*, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga,
      f0002_unidad_medicion
FROM camocontrol.tb0300_items
    join camocontrol.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where f0300_id_cia = '00000001'