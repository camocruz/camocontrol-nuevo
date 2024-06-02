$VERDADERO$



select f0600_id_accion as id_accion,
      f0600_titulo as titulo,
      f0600_descripcion as descripcion,
      f0602_descriptor_tipo as t_actividad,
      f0603_descriptor_estado as estado,
      f0601_descriptor_fuente as fuente
from $df001$.tb0600_acciones
     join $df001$.tb0602_tipos_acciones
        on f0600_id_tipo_accion = f0602_id_tipo_accion
     join $df001$.tb0601_fuentes_acciones
        on f0600_id_fuente_accion = f0601_id_fuente
     join $df001$.tb0603_estados_acciones
        on f0600_id_estado_accion = f0603_id_estado_accion
where f0600_responsable = '$001$' and
     (f0600_id_estado_accion = '01' or f0600_id_estado_accion = '02')
order by f0600_id_accion