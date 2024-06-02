
INSERT INTO camocontrol.tb0301_items_inventario_x_bodega 
            (f0301_id_item, f0301_id_bodega, 
            f0301_costo_promedio,
            f0301_ubicacion, f0301_inventario_actual, 
            f0301_id_cia, f0301_usuario_crear, 
            f0301_usuario_modificar)
    VALUES (5, 4, 
            15000,
            'casa', 10000,
            '00000001', '00000001', 
            '00000001')
    ON CONFLICT (f0301_id_item, f0301_id_bodega) DO UPDATE SET 
    f0301_ubicacion = 'carlos', 
    f0301_inventario_actual = 200,
    f0301_costo_promedio = 20000,
    f0301_fm = current_timestamp,
    f0301_usuario_modificar = '00000001'