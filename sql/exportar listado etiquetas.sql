	copy(
SELECT f0421_id_etiqueta, f0300_referencia, f0300_descripcion_item
	FROM camocontrol.tb0421_etiquetas
		join camocontrol.tb0420_orden_imp_etiquetas
			on f0420_id_impresion = f0421_id_impresion
		join camocontrol.tb0300_items
			on f0300_id_item = f0420_id_producto
where f0421_anulado = 'N'  and f0421_fr >=  current_date - interval '14 month' 
	) to 'D:\umpr4015\CsvInfEtiq.csv' DELIMITER '	'  CSV HEADER;
