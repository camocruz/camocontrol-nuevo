SELECT f0421_id_etiqueta as numero_tiquete, 
       (f0300_descripcion_item || ' ( ' || f0300_referencia_empaque || ' )' || ' Ref: ( ' || f0300_referencia || ' ) ') as producto,
       f0420_id_op as op, 
       f0420_op_alterna as clv, f0420_lote as lote, to_char(f0420_fecha_vence, 'YYYY-MM-DD') as f_vence, f0420_cantidad as tot_etiquetas, 
       to_char(f0420_fr, 'YYYY-MM-DD HH12:MI AM') as f_impresion,
       f0421_id_despacho as id_pdd, to_char(f0421_fecha_despacho, 'YYYY-MM-DD') as f_despacho, 
       f0421_unidades_englobadas as unidades_englobe
  FROM camocontrol.tb0421_etiquetas
  join camocontrol.tb0420_orden_imp_etiquetas
    on f0421_id_impresion = f0420_id_impresion
  join camocontrol.tb0300_items
    on f0420_id_producto = f0300_id_item
  where f0421_id_etiqueta::int = 45000
