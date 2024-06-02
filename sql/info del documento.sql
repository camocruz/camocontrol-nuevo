

SELECT f0501_id_documento as id_documento, f0500_tipo_documento as tipo, 
       f0501_codigo_documento as codigo, 
       f0501_titulo_documento as titulo, 
       f0060_nombre_proceso as proceso, f0501_conservacion as conservacion
  FROM camocontrol.tb0501_documentos
    join camocontrol.tb0500_tipos_documentos on f0501_id_tipo_documento = f0500_id_tipo_documento
    left join camocontrol.tb0060_procesos_compania on f0060_id_proceso = f0501_proceso
where f0501_id_cia = '00000001' and f0501_id_documento = '8'

select f0502_id_documento as id_documento, f0502_ed as ed, f0502_descripcion_ed as cambio, 
       to_char(f0502_fecha_aprobacion,'YYYY-MM-DD') as fecha
from camocontrol.tb0502_documentos_ed
where f0502_id_documento = '8'


select f0505_id_documento as id_documento,
       f0240_id_cargo as copia,
       f0240_cargo as cargo, 
       trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre,
       f0505_ubicacion as ubicacion,
       case when f0505_impreso = 'S' then true else false end as cc,
       case when f0505_digital = 'S' then true else false end as cd
from camocontrol.tb0505_copias_controladas_cargos
  join camocontrol.tb0200_terceros on f0200_id_cargo = f0505_id_cargo
  join camocontrol.tb0240_cargos_compania on f0240_id_cargo = f0505_id_cargo
where f0505_id_cia = '00000001' and f0505_id_documento = '8'
union
select f0506_id_documento as id_documento, 
       f0240_id_cargo as copia,
       f0240_cargo as cargo, 
       trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre,
       f0506_ubicacion as ubicacion,
       case when f0506_impreso = 'S' then true else false end as cc,
       case when f0506_digital = 'S' then true else false end as cd
from camocontrol.tb0506_copias_controladas_funcionarios
   join camocontrol.tb0200_terceros on f0200_id_tercero = f0506_id_tercero
   join camocontrol.tb0240_cargos_compania on f0240_id_cargo = f0200_id_cargo
where f0506_id_cia = '00000001' and f0506_id_documento = '8'
order by cargo, nombre