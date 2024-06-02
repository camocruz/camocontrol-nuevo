select (f0300_descripcion_item || ' ( ' || f0300_referencia_empaque || ' )') as producto,
f0420_id_impresion as id_imp_etiq, f0420_id_op as op1, f0420_op_alterna as op2,
f0420_lote as lote,
to_char(f0420_fr, 'YYYY-MM-DD') as f_prod,
to_char(f0420_fecha_vence, 'YYYY-MM-DD') as f_ven,
f0421_id_etiqueta as id_caja,
to_char(f0421_fecha_despacho, 'YYYY-MM-DD HH12:MI:SS AM') as f_cargue
from camocontrol.tb0420_orden_imp_etiquetas
   join camocontrol.tb0421_etiquetas
     on f0420_id_impresion = f0421_id_impresion
   join camocontrol.tb0300_items
     on f0420_id_producto = f0300_id_item
where f0421_id_despacho = '987' and f0420_id_producto = '2567'

