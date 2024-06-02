insert into camocontrol.tb0408_items_cg
SELECT distinct f0406_referencia, f0406_descripcion, f0406_unidad, 0, 'ND','ND'
from camocontrol.tb0406_det_prod_ip_cg_umpr4015_9
on conflict do nothing

update camocontrol.tb0408_items_cg set
f0408_peso = 1
where f0408_unid_medida = 'KG'
