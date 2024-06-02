SELECT tb0300_items.*, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga,
      f0002_unidad_medicion
FROM $df001$.tb0300_items
    join $df001$.tb0002_unidades_medicion
       on f0300_id_unidad_medicion = f0002_id_unidad_medicion
where f0300_id_cia = '$001$'