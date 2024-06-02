with estructura_planta as (
	SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id, 
	       temp1.f0100_nombre as planta
	 FROM $df001$.tb0100_estructura_mantenimiento
	 left join $df001$.tb0100_estructura_mantenimiento as temp1
	   on temp1.f0100_id_estructura = (string_to_array(tb0100_estructura_mantenimiento.f0100_path||tb0100_estructura_mantenimiento.f0100_id_estructura||'-','-'))[2]::int
	where tb0100_estructura_mantenimiento.f0100_id_cia = '00000001' and tb0100_estructura_mantenimiento.f0100_anulado = 'N'
	      and array_length(string_to_array(tb0100_estructura_mantenimiento.f0100_path,'-'), 1)>1
)
SELECT f0100_id_estructura as id, 
       f0100_nombre as nombre, 
       f0100_descripcion as descripcion, 
       f0100_codigo as codigo, 
       f0107_tipo_estructura as tipo, 
       f0100_id_item as id_item,
       coalesce(planta,f0100_nombre) as planta
 FROM $df001$.tb0100_estructura_mantenimiento
 left join $df001$.tb0107_tipos_estructura
      on f0107_id_tipo_estructura = tb0100_estructura_mantenimiento.f0100_id_tipo_estructura
 left join estructura_planta 
      on id = f0100_id_estructura
where tb0100_estructura_mantenimiento.f0100_id_cia = '$001$' and tb0100_estructura_mantenimiento.f0100_anulado = 'N'
order by planta, nombre
