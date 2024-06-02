select f0505_id_documento as id_documento,
       f0240_id_cargo as copia,
       f0240_cargo as cargo, 
       trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre,
       f0505_ubicacion as ubicacion,
       case when f0505_impreso = 'S' then true else false end as cc,
       case when f0505_digital = 'S' then true else false end as cd,
       case when f0505_gest_registo = 'S' then true else false end as gr,
       case when f0505_cargo_referenciado = 'S' then true else false end as rf,
       f0021_nombre_completo as usuario
from $df001$.tb0505_copias_controladas_cargos
  join $df001$.tb0200_terceros on f0200_id_cargo = f0505_id_cargo and f0200_estado = 'A'
  join $df001$.tb0240_cargos_compania on f0240_id_cargo = f0505_id_cargo
  left join $df001$.tb0021_usuarios on f0021_id_usuario = f0200_id_tercero
where f0505_id_cia = '$001$' and f0505_id_documento = '$002$'
union
select f0506_id_documento as id_documento, 
       f0240_id_cargo as copia,
       f0240_cargo as cargo, 
       trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre,
       f0506_ubicacion as ubicacion,
       case when f0506_impreso = 'S' then true else false end as cc,
       case when f0506_digital = 'S' then true else false end as cd,
       case when f0506_gest_registo = 'S' then true else false end as gr,
       case when f0506_cargo_referenciado = 'S' then true else false end as rf,
       f0021_nombre_completo as usuario
from $df001$.tb0506_copias_controladas_funcionarios
   join $df001$.tb0200_terceros on f0200_id_tercero = f0506_id_tercero and f0200_estado = 'A'
   join $df001$.tb0240_cargos_compania on f0240_id_cargo = f0200_id_cargo
   left join $df001$.tb0021_usuarios on f0021_id_usuario = f0200_id_tercero
where f0506_id_cia = '$001$' and f0506_id_documento = '$002$'
order by cargo, nombre