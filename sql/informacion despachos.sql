
-- Copio los nnuevos datos al archivo de consulta
copy (
select * from camocontrol.vi0800_info_despachos
) to 'D:\umpr4015\CSVDespachos.csv' DELIMITER '	'  CSV HEADER;
-- where f0857_fecha >=  current_date - interval '4 month'

--Inserto causas de demoras
INSERT INTO camocontrol.tb0803_causas_demoras_despachos(
	f0803_demora, f0803_id_cia, f0803_usuario_crear, 
	f0803_usuario_modificar, f0803_anulado)
	VALUES ('NO GESTION DEL REGISTRO DE CIERRE DESPACHO',
			'00000001', '00000004', '00000004', 'N')
			RETURNING f0803_id_demora; *****


-- Asigno una causa de demora al despacho
UPDATE camocontrol.tb0800_despachos_comercial SET
	f0800_id_demora = 1
where f0800_id_despacho = 63553;
-- Listado de causas
SELECT f0803_id_demora, f0803_demora FROM camocontrol.tb0803_causas_demoras_despachos

-- Busco la informacion de un despacho
select * from camocontrol.tb0800_despachos_comercial
where f0800_id_despacho = 63358

select * from camocontrol.vi0800_info_despachos 
where id_pdd = 63358


-- Modifico la info de un despacho
UPDATE camocontrol.tb0800_despachos_comercial SET
	f0800_tot_cajas_registro_guia = 184984
where f0800_id_despacho = 63335




