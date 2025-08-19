-- Cargo nuevos datos de registros en las tablas temporales.
--D:\umpr4015
--C:\dat_temp
DELETE FROM camocontrol.tb0321_oc_doc_compras_encabezado_temp;
copy camocontrol.tb0321_oc_doc_compras_encabezado_temp from 'C:\dat_temp\oc1.csv';
DELETE FROM camocontrol.tb0322_oc_doc_compras_detalles_temp;
copy camocontrol.tb0322_oc_doc_compras_detalles_temp from 'C:\dat_temp\oc2.csv';

--Borrar de las tabla encabezadoregistros que se vuelvan a cargar
--Bomo hay una relacion entre tablas tambien se borraran los detalles.
DELETE FROM camocontrol.tb0323_oc_doc_compras_encabezado
WHERE f0323_cod_doc IN (SELECT DISTINCT 'MA-005-MM-' || campo2 
FROM camocontrol.tb0321_oc_doc_compras_encabezado_temp);

-- Inserto los registros
insert into camocontrol.tb0323_oc_doc_compras_encabezado
SELECT 'MA-005-MM-' || campo2 as mm, campo3::DATE, campo4, campo5,
    campo6::numeric, campo7::numeric, campo8::numeric
from camocontrol.tb0321_oc_doc_compras_encabezado_temp;
-- on conflict do nothing;  --No se requiere porque estoy borrando los registros antes

insert into camocontrol.tb0324_oc_doc_compras_detalles
(f0324_cod_doc, f0324_referencia, f0324_descripcion, f0324_localizacion, 
 f0324_cantidad, f0324_um, f0324_valor_bruto, f0324_impuestos, f0324_total)
select 'MA-005-MM-' || campo2, campo3 , campo4, campo5, campo6::numeric, campo7,
   campo8::numeric, campo9::numeric, campo10::numeric
from camocontrol.tb0322_oc_doc_compras_detalles_temp;