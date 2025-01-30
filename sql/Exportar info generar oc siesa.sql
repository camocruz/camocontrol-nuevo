COPY(
select
      left(
          left(
               left(
                   left(
                   'MA005OC' 
                   || replace(to_char(now(), 'YYYY-MM-DD'),'-','')
                   || tb_tercero_oc.f0200_id
                   || rpad('', 68, ' ')
                   , 70)
                   || 'CAMO'
                   || '                  '
                   || 'CAMO ' || 'OC-' || f0305_id_oc
                   || rpad('',263, ' ')
                ,265)  
		        || 'I'
		        || f0300_codigo_cguno
		        || rpad('',20,' ')
		     ,284)
			 || '005'
		     || '09'
			 || f0002_sigla_unidad_medicion
			 || rpad('',20,' ')
       ,301)
	   || '01'
	   || right(('000000000' || replace(to_char(f0305_cantidad,'999999999V999'),' ','')),12)
	   || right(('000000000' || replace(to_char(f0305_costo_unitario_planificado,'999999999V99'),' ','')),11)
	   || rpad('',26,' ')
	   || replace(to_char(now(), 'YYYY-MM-DD'),'-','') || '12'
	   || rpad('',10,' ')
	   || 'SC' || f0305_id_solicitud_compra || '-' || f0305_id_item_solicitud
	   || rpad('',207,' ')
	   as p1
from camocontrol.tb0305_items_solicitados
   join camocontrol.tb0304_solicitud_compra
      on f0305_id_solicitud_compra = f0304_id_solicitud
   join camocontrol.tb0300_items
      on f0305_id_item = f0300_id_item
   join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion = f0002_id_unidad_medicion
   left join camocontrol.tb0319_ordenes_compra
   	  on f0319_id_oc = f0305_id_oc
   left join camocontrol.tb0200_terceros as tb_tercero_oc
      on f0319_id_tercero = tb_tercero_oc.f0200_id_tercero 
Where f0305_anulado = 'N' and f0319_aprobada = 'S'
   and f0305_id_cia = '00000001'
   and f0319_id_oc = 1493
   --and f0305_fr BETWEEN '2024-01-01' and '2024-12-01'
   --and f0305_id_factura_compras is null 
order by f0300_descripcion_item, f0305_id_solicitud_compra
) to 'C:\dat_temp\borrar.txt' DELIMITER '	'  CSV;