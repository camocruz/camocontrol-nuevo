-- Cargo nuevos datos de registros.
DELETE FROM camocontrol.tb0858_inventarios_pt_temp;
copy camocontrol.tb0858_inventarios_pt_temp from 'C:\dat_temp\borrar.txt';

-- Inserto los registros
insert into camocontrol.tb0858_inventarios_pt
SELECT * from camocontrol.tb0858_inventarios_pt_temp
on conflict do nothing