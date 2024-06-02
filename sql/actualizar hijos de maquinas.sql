WITH maquinas AS (
    select * from camocontrol.tb0100_estructura_mantenimiento
    where f0100_id_tipo_estructura = '00000003' and f0100_id_cia = '00000001'
)
update camocontrol.tb0100_estructura_mantenimiento set
   f0100_id_maquina_padre = maquinas.f0100_id_estructura,
   f0100_codigo = maquinas.f0100_codigo || '-' || tb0100_estructura_mantenimiento.f0100_id_estructura
from maquinas
where substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' from 1 for length(maquinas.f0100_path || maquinas.f0100_id_estructura || '-' )) = maquinas.f0100_path || maquinas.f0100_id_estructura || '-' 
and tb0100_estructura_mantenimiento.f0100_id_tipo_estructura <> '00000003';