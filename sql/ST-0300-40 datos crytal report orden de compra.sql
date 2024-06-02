select 'OC-' || to_char(f0319_id_oc, 'FM099999MI') as id_oc, 'NIT: ' || tb_proveedor.f0200_id || ' - ' || 
       trim(both ' ' from tb_proveedor.f0200_nombres || ' ' || tb_proveedor.f0200_apellido1 || ' ' || tb_proveedor.f0200_apellido2) as razon_social, 
       tb_proveedor.f0200_id as nit,
       f0305_id_solicitud_compra as id_solicitud,

       f0305_id_item_solicitud as id, f0300_id_item as id_item, f0300_codigo_cguno as cod_cguno,

       case when f0305_anotacion_item = '' then f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0305_ampliacion_item
          else f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0305_ampliacion_item || E'\n'|| 'Observacion: '
               || f0305_anotacion_item
       end as descripcion,
       
       f0305_cantidad as cantidad, 
       f0002_sigla_unidad_medicion as unid,

       f0305_costo_unitario_planificado as costo_unit,
       f0305_iva as iva,
       f0305_descuento as descuento,
       f0305_costo_unitario_planificado * (1 - f0305_descuento) * f0305_cantidad as subtotal,
       
       f0305_costo_total_planificado as costo_total,
       case when f0319_aprobada = 'S' 
            then tb_aprobado.f0200_apellido1 || ' ' || substring(tb_aprobado.f0200_nombres from 1 for 8)
            else 'SIN APROBAR!!!!'
       end as aprobo,
       to_char(f0319_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as f_aprobacion
from camocontrol.tb0305_items_solicitados
    join camocontrol.tb0304_solicitud_compra
      on f0305_id_solicitud_compra = f0304_id_solicitud
    join camocontrol.tb0319_ordenes_compra
      on f0319_id_oc = f0305_id_oc
    left join camocontrol.tb0200_terceros as tb_aprobado
      on f0319_usuario_aprobar = tb_aprobado.f0200_id_tercero
    join camocontrol.tb0200_terceros as tb_proveedor
      on tb_proveedor.f0200_id_tercero = f0319_id_tercero
    join camocontrol.tb0300_items
      on f0305_id_item = f0300_id_item
    join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion = f0002_id_unidad_medicion
    left join camocontrol.tb0600_acciones
      on f0305_id_accion = f0600_id_accion
    left join camocontrol.tb0100_estructura_mantenimiento
      on f0304_id_estructura = f0100_id_estructura
    left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
      on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre  
Where f0319_id_cia = '00000001' and f0319_id_oc = '1' and f0305_anulado = 'N'