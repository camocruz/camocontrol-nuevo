
-- 1. BORRO los registros f0402_id_ipp hijos que no tienen rp asociado
delete from camocontrol.tb0401_items_prog_prod
where f0401_id_ipp in (
-- identifico los registros f0402_id_ipp hijos que no tienen rp asociado
with tb_rps as (
	select f0402_id_ipp as id_ipp_rps, count(f0402_id_rp) as rps
	from camocontrol.tb0402_reporte_produccion
	group by f0402_id_ipp
	order by f0402_id_ipp desc)
select f0401_id_ipp
from camocontrol.tb0401_items_prog_prod
  left join tb_rps on id_ipp_rps = f0401_id_ipp
where rps is null and f0401_id_ipp_padre is not null
order by f0401_id_ipp desc
);

-- 2. BORROS LOS IPP QUE NO TIENEN HIJOS

delete from camocontrol.tb0401_items_prog_prod
where f0401_id_ipp in (
with tb_hijos as (
-- En esta consula identifico los registros hijos
SELECT f0401_id_ipp as hijo, f0401_id_ipp_padre as padre
FROM camocontrol.tb0401_items_prog_prod
WHERE f0401_id_ipp_padre is not null
-- and f0401_id_prog_prod = 157 --f0401_id_ipp IN (78611, 78614)
ORDER BY f0401_id_ipp DESC
)
-- En esta consulta identifico los registros padre sin hijos
SELECT f0401_id_ipp
FROM camocontrol.tb0401_items_prog_prod
   left join tb_hijos
     on f0401_id_ipp = padre
WHERE f0401_id_ipp_padre is null and hijo is null
-- and f0401_id_prog_prod = 157 --f0401_id_ipp IN (78611, 78614)
ORDER BY f0401_id_ipp DESC
);

-- 3. BORRO LOS PROGRAMAS DE PRODUCCION VACIOS
DELETE FROM camocontrol.tb0400_programa_produccion
WHERE f0400_id_pp IN (
with tb_hijos as (
SELECT f0401_id_prog_prod, COUNT(f0401_id_prog_prod) AS cant
FROM camocontrol.tb0401_items_prog_prod
group by f0401_id_prog_prod
ORDER BY f0401_id_prog_prod DESC
)
SELECT f0400_id_pp
FROM camocontrol.tb0400_programa_produccion
LEFT JOIN tb_hijos ON f0401_id_prog_prod = f0400_id_pp
WHERE cant is null
ORDER BY f0400_id_pp DESC
);
