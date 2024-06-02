
	DELETE FROM camocontrol.tb0408_items_cg_temp;
	
	copy camocontrol.tb0408_items_cg_temp from 'E:\ProductosFaltantes.txt';


	INSERT INTO camocontrol.tb0408_items_cg SELECT *,
		0.01, 'MNF', 'MNF', 'PT'
	FROM camocontrol.tb0408_items_cg_temp
	ON CONFLICT DO NOTHING;
	
	select * from camocontrol.tb0408_items_cg where f0408_referencia = '3-40';
	
	copy (
          select * from camocontrol.vi0400_items_prod_cg --camocontrol.tb0408_items_cg
         ) to 'D:/umpr4015/it_cg.csv' DELIMITER '	'  CSV HEADER;
