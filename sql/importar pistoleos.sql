--Copio los datos del archivo
copy camocontrol.tb0424_etiquetas_pistoleo_temp from 'E:\area_trabajo\ConteoDigital\Datos\borrar.txt';

insert into camocontrol.tb0423_etiquetas_pistoleo
	select * from camocontrol.tb0424_etiquetas_pistoleo_temp
ON CONFLICT DO NOTHING;

DELETE FROM camocontrol.tb0424_etiquetas_pistoleo_temp

SELECT * FROM camocontrol.tb0423_etiquetas_pistoleo
ORDER BY f0423_id ASC, f0423_fr ASC 

--DELETE FROM camocontrol.tb0423_etiquetas_pistoleo