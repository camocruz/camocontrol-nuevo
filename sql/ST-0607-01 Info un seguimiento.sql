SELECT f0606_id_seguimiento_accion as id_seguimiento,
       f0606_tipo_nota || '-' || f0606_id_documento as documento,
       f0606_id_documento as id_documento,
       f0606_tipo_nota as tipo_documento,  
       f0606_nivel_cumplimiento as nivel_cumplimiento,
       to_char(f0606_fecha_inicio,'yyyy-MM-dd HH24:mm:ss') as fecha_anotacion,
       tb_emisor.f0200_apellido1 || ' ' || tb_emisor.f0200_apellido2 || ' ' || tb_emisor.f0200_nombres as emisor,
       f0606_seguimiento_accion as seguimiento
  FROM camocontrol.tb0606_seguimientos_acciones
   left join camocontrol.tb0200_terceros as tb_emisor
      on f0606_usuario_crear = tb_emisor.f0200_id_tercero
  where f0606_id_cia = '00000001' and f0606_id_seguimiento_accion = '46125'
