-- crear tabla temporal
-- DROP TABLE camocontrol.tbtempo;

CREATE TABLE camocontrol.tbtempo
(
  f1 character varying(300) NOT NULL DEFAULT ''::character varying,
  f2 character varying(300) DEFAULT ''::character varying,
  f3 character varying(300) DEFAULT ''::character varying,
  f4 character varying(300) DEFAULT ''::character varying,
  CONSTRAINT pk_tbtemp PRIMARY KEY (f1)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE camocontrol.tbtempo
  OWNER TO camo;

  
--Listado de items clasificados por tipo
copy (
select f0300_id_item, 
       --f0300_descripcion_item,
       case when f0300_id_item_new is null then f0300_descripcion_item else f0300_descripcion_item || ' (UNIF = ' || f0300_id_item_new || ')' end as f0300_descripcion_item, 
       --array_agg(f0005_cod_bodega || '=> ' || round(f0301_inventario_actual, 1)) as inventarios,
       --f0301_ubicacion, 
       f0300_id_tipo_item
       --case when f0300_id_item_new is null then 0 else 1 end as unificado
 from camocontrol.tb0300_items
   left join camocontrol.tb0301_items_inventario_x_bodega on f0301_id_item = f0300_id_item and f0301_inventario_actual > 0
   left join camocontrol.tb0005_bodegas on f0005_id_bodega = f0301_id_bodega
   left join camocontrol.tb0302_tipos_items on f0302_id_tipo_item = f0300_id_tipo_item
where f0300_id_tipo_item <> 1 and f0300_id_tipo_item <> 2 --and f0300_id_item = 7698
group by f0300_id_item,f0300_descripcion_item
order by f0300_id_tipo_item, f0300_descripcion_item
) to 'C:/dsfc/info_items_manto.txt' DELIMITER '|' CSV HEADER ENCODING 'UTF-8'; --'S:/dsfc/rh_asistencia/rms.txt';

-- Listado de tipos de items
copy (
select f0302_id_tipo_item, f0302_descripcion_tipo_item
  from camocontrol.tb0302_tipos_items
) to 'C:/dsfc/info_tipos_items.txt' DELIMITER '|' CSV HEADER; --'S:/dsfc/rh_asistencia/rms.txt'; 

-- borrar todos los datos de temporal
DELETE FROM camocontrol.tbtempo;
-- copiar datos en tabla temporal
COPY camocontrol.tbtempo FROM 'U:/PUB_MACDULCES/output.txt' DELIMITER '|' ENCODING 'LATIN1';


-- Actualizar la tabla items con los datos del archivo plano
update camocontrol.tb0300_items set
  f0300_descripcion_item = rtrim((select f2 from camocontrol.tbtempo where f0300_id_item = f1::int),' '),
  f0300_id_tipo_item = (select f3::INT from camocontrol.tbtempo where f0300_id_item = f1::int)
where (select f2 from camocontrol.tbtempo where f0300_id_item = f1::int) <> ''

