DELETE FROM camocontrol.tb0212_temp_registros_reloj;
copy camocontrol.tb0212_temp_registros_reloj from 'F:/0422142100029_attlog.dat';

insert into camocontrol.tb0211_personal_registros_reloj(
            f0211_codigo_empleado, f0211_fecha, f0211_planta, f0211_c1, f0211_c2, f0211_c3)
select * from camocontrol.tb0212_temp_registros_reloj
where tb0212_temp_registros_reloj.a = '2' and tb0212_temp_registros_reloj.fecha > (select max(tb0211_personal_registros_reloj.f0211_fecha) from camocontrol.tb0211_personal_registros_reloj where f0211_planta = '2');

DELETE FROM camocontrol.tb0212_temp_registros_reloj;
copy camocontrol.tb0212_temp_registros_reloj from 'F:/0422140800359_attlog.dat';

insert into camocontrol.tb0211_personal_registros_reloj(
            f0211_codigo_empleado, f0211_fecha, f0211_planta, f0211_c1, f0211_c2, f0211_c3)
select * from camocontrol.tb0212_temp_registros_reloj
where tb0212_temp_registros_reloj.a = '5' and tb0212_temp_registros_reloj.fecha > (select max(tb0211_personal_registros_reloj.f0211_fecha) from camocontrol.tb0211_personal_registros_reloj where f0211_planta = '5');

DELETE FROM camocontrol.tb0212_temp_registros_reloj;
copy camocontrol.tb0212_temp_registros_reloj from 'F:/CEXJ202160167_attlog.dat';

insert into camocontrol.tb0211_personal_registros_reloj(
            f0211_codigo_empleado, f0211_fecha, f0211_planta, f0211_c1, f0211_c2, f0211_c3)
select * from camocontrol.tb0212_temp_registros_reloj
where tb0212_temp_registros_reloj.a = '1' and tb0212_temp_registros_reloj.fecha > (select max(tb0211_personal_registros_reloj.f0211_fecha) from camocontrol.tb0211_personal_registros_reloj where f0211_planta = '1');


copy (
SELECT f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre,
       f0211_id_registro, f0211_codigo_empleado, to_char(f0211_fecha, 'YYYY-MM-DD') as dia, f0211_fecha, f0211_planta, 
       f0211_c1, f0211_c2, f0211_c3, f0211_fr
FROM camocontrol.tb0211_personal_registros_reloj
     left join camocontrol.tb0200_terceros
        on f0211_codigo_empleado = f0200_codigo_empleado
where f0211_fecha > '2020/10/28'
order by f0211_codigo_empleado, f0211_fecha
) to 'S:/dsfc/rh_asistencia/tabla1.txt';

copy (
select f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre,
       f0211_codigo_empleado, to_char(f0211_fecha, 'YYYY-MM-DD') as dia, 
       min(f0211_fecha) as minfecha, max(f0211_fecha) as maxfecha,
       extract(epoch from max(f0211_fecha) - min(f0211_fecha)) / 3600 as h, f0211_planta as planta
FROM camocontrol.tb0211_personal_registros_reloj
     left join camocontrol.tb0200_terceros
        on f0211_codigo_empleado = f0200_codigo_empleado
where f0211_fecha > '2020/10/28'
group by nombre, f0211_codigo_empleado, dia, f0211_planta
order by f0211_codigo_empleado, dia
) to 'S:/dsfc/rh_asistencia/tabla2.txt';