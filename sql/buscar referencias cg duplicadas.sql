with items as (
SELECT f0300_referencia, count(f0300_referencia) as cantidad 
	from camocontrol.tb0300_items
where f0300_referencia <> '' group by f0300_referencia
order by f0300_referencia
	), conteo as (
	select * from items where cantidad > 1)
	
--select * from conteo

UPDATE camocontrol.tb0300_items SET
   f0300_referencia = 'CM-' || f0300_id_item,
   f0300_codigo_cguno = 'CM-' || f0300_id_item
   from conteo
   where tb0300_items.f0300_referencia = conteo.f0300_referencia;
   
UPDATE camocontrol.tb0300_items SET
   f0300_referencia = 'CM-' || f0300_id_item,
   f0300_codigo_cguno = 'CM-' || f0300_id_item
where f0300_referencia = '';

ALTER TABLE camocontrol.tb0300_items
    ADD CONSTRAINT uk_referencia UNIQUE (f0300_referencia, f0300_id_cia);


-- DROP FUNCTION camocontrol.fnc_300_referenciacg_codigocg_items();

CREATE FUNCTION camocontrol.fnc_300_referenciacg_codigocg_items()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
DECLARE
    
BEGIN

   if new.f0300_referencia='' THEN new.f0300_referencia = 'CM-' || new.f0300_id_item;
   end if;
   if new.f0300_codigo_cguno='' THEN new.f0300_codigo_cguno = 'CM-' || new.f0300_id_item;
   end if;

RETURN NEW;    -- return final result

END;
$BODY$;

ALTER FUNCTION camocontrol.fnc_300_referenciacg_codigocg_items()
    OWNER TO camo;
	

CREATE TRIGGER tg_garantizar_referenciacg
    BEFORE INSERT
    ON camocontrol.tb0300_items
    FOR EACH ROW
    EXECUTE FUNCTION camocontrol.fnc_300_referenciacg_codigocg_items();
	
	