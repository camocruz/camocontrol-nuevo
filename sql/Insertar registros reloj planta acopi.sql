-- Cargo nuevos datos de registros.
DELETE FROM camocontrol.tb0212_temp_registros_reloj;
copy camocontrol.tb0212_temp_registros_reloj from 'D:\umpr4015\borrar.txt';

-- Inserto los registros

insert into camocontrol.tb0211_personal_registros_reloj(
            f0211_codigo_empleado, f0211_fecha, f0211_planta, f0211_c1, f0211_c2, f0211_c3)
select * from camocontrol.tb0212_temp_registros_reloj
where tb0212_temp_registros_reloj.a = '6' 
	  and tb0212_temp_registros_reloj.fecha > 
	      (select max(tb0211_personal_registros_reloj.f0211_fecha) 
		   from camocontrol.tb0211_personal_registros_reloj 
		   where f0211_planta = '6');
