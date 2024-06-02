SELECT otb_estructura.*, otb_estructura.f0100_nombre || ' -- { ' || otb_estructura.f0100_codigo || ' }' as descripcion_nombre,
       otb_estructura.f0100_codigo || ' -- { ' || otb_estructura.f0100_nombre || ' }' || '( ' || otb_estructura.f0100_id_estructura || ' )' as
       descripcion_codigo, otb_primario.f0100_nombre || ' -- { ' || otb_primario.f0100_codigo || ' }' as descripcion_elemento_primario,
       otb_estructura.f0100_id_maquina_padre as id_primario, otb_estructura.f0100_id_estructura as id_estructura
FROM camocontrol.tb0100_estructura_mantenimiento as otb_estructura
   join camocontrol.tb0107_tipos_estructura
      on otb_estructura.f0100_id_tipo_estructura = f0107_id_tipo_estructura
   left join camocontrol.tb0100_estructura_mantenimiento as otb_primario
      on otb_estructura.f0100_id_maquina_padre = otb_primario.f0100_id_estructura 
where otb_estructura.f0100_id_estructura = '157'