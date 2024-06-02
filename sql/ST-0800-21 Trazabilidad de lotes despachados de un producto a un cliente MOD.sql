SELECT f0800_id_despacho as id_pdd, to_char(f0800_fecha_despacho, 'YYYY-MM-DD') as f_despacho, f0300_id_item as id_item, 
       f0300_referencia as referencia,
       f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item, 
       f0420_lote as lote, to_char(f0420_fecha_vence, 'YYYY-MM-DD') as f_vence
  FROM $df001$.tb0800_despachos_comercial
       left join $df001$.tb0421_etiquetas
         on f0421_id_despacho = f0800_id_despacho
       left join $df001$.tb0420_orden_imp_etiquetas
         on f0420_id_impresion = f0421_id_impresion
       left join $df001$.tb0300_items
         on f0300_id_item = f0420_id_producto
       left join $df001$.tb0200_terceros
         on f0200_id_tercero = f0800_cliente
  where f0800_id_cia = '$001$' and f0800_anulado = 'N' 
       and f0300_id_item = '$002$' and f0200_id = '$003$'
  group by f0800_id_despacho, f_despacho, id_item, item, f0300_referencia,
       f0300_descripcion_item, f0420_lote, f_vence
  order by f0800_fecha_despacho desc, f0420_lote
