select f0305_id_solicitud_compra as id_solicitud, f0305_id_accion as id_accion,
       'Actividad/Accion: ' || substring(coalesce(f0600_descripcion, '') from 1 for 200)
       || chr(13) || chr(10) || chr(13) || chr(10) || 'Nota Solicitud: ' || coalesce(f0304_anotacion,'') as nota_solicitud,
       
       tb0100_estructura_mantenimiento.f0100_codigo as cod_estructura, 
       tb0100_estructura_mantenimiento.f0100_codigo || ' -- ' ||
       CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre || ' =>> ' || tb0100_estructura_mantenimiento.f0100_nombre
       end as nombre_estructura,

       f0304_fr as f_registro, f0304_fm as f_modificacion,
       tb_solicitado.f0200_apellido1 || ' ' || substring(tb_solicitado.f0200_nombres from 1 for 8) as nombre,
       f0305_id_item_solicitud as id, f0300_id_item as id_item, f0300_codigo_cguno as cod_cguno,

       case when f0305_anotacion_item = '' then f0300_descripcion_item || ' ' || ' ' || f0305_ampliacion_item
          else f0300_descripcion_item || ' ' || ' ' || f0305_ampliacion_item || E'\n'|| 'Observacion: '
               || f0305_anotacion_item
       end || ' <=> I: ' || round(f0305_inventario,0)  as descripcion,
       
       round(f0305_cantidad,1) as cantidad, 
       f0305_cantidad_stock as stock, 
       f0002_sigla_unidad_medicion as unid,

       f0305_costo_unitario_planificado / (1 - f0305_descuento) as costo_unit,
       f0305_iva as iva,
       f0305_descuento as descuento,
       f0305_costo_unitario_planificado * f0305_cantidad as subtotal,

       
       f0305_costo_total_planificado as costo_total,
       f0600_path || f0600_id_accion as path_accion,
       case when f0305_estado = 'A' 
            then tb_aprobado.f0200_apellido1 || ' ' || substring(tb_aprobado.f0200_nombres from 1 for 8)
            else 'SIN APROBAR!!!!'
       end as aprobo,
       to_char(f0305_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as f_aprobacion
from camocontrol.tb0305_items_solicitados
    join camocontrol.tb0304_solicitud_compra
      on f0305_id_solicitud_compra = f0304_id_solicitud
    join camocontrol.tb0300_items
      on f0305_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    join camocontrol.tb0200_terceros as tb_solicitado
      on f0304_usuario_crear = tb_solicitado.f0200_id_tercero
    left join camocontrol.tb0200_terceros as tb_aprobado
      on f0305_usuario_aprobar = tb_aprobado.f0200_id_tercero
    left join camocontrol.tb0600_acciones
      on f0305_id_accion = f0600_id_accion
    left join camocontrol.tb0100_estructura_mantenimiento
      on f0304_id_estructura = f0100_id_estructura
    left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
          on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre  
    -- esta parte es para la estructura por items solicitado
    left join camocontrol.tb0100_estructura_mantenimiento as otb_estructura_referida
      on f0305_id_estructura = otb_estructura_referida.f0100_id_estructura
    left join camocontrol.tb0100_estructura_mantenimiento as otb_estructura_madre
      on otb_estructura_referida.f0100_id_maquina_padre = otb_estructura_madre.f0100_id_estructura
Where f0305_id_solicitud_compra = '23919' and f0305_anulado = 'N'