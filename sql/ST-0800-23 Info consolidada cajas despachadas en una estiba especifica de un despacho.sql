with tb_estibas as (
select DISTINCT f0421_estiba, f0300_referencia, count(f0420_id_producto) as cant
from camocontrol.tb0420_orden_imp_etiquetas
	join camocontrol.tb0421_etiquetas
     	on f0420_id_impresion = f0421_id_impresion
	left join camocontrol.tb0300_items
        on f0420_id_producto = f0300_id_item
where f0421_id_despacho = '51961'
group by f0421_estiba,f0300_referencia, f0420_id_producto
order by f0421_estiba desc)

select sum(cant) as cantcajas, count(f0300_referencia) as cantprod
from tb_estibas
where f0421_estiba = '1'