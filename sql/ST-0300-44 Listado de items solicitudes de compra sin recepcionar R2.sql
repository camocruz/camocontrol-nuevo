select f0305_id_item_solicitud as id_sc_item, 
       f0305_id_solicitud_compra as id_sc,
       f0300_descripcion_item || ' ' || f0300_referencia as descripcion,
       f0302_descripcion_tipo_item as tipo_item,
       f0300_id_item as id_item,
       f0305_ampliacion_item as descripcion_comp,
       f0305_anotacion_item as observacion,
       f0305_cantidad as cantidad,
       f0002_sigla_unidad_medicion as unid,
       to_char(f0305_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_solicitud,
       to_char(f0305_fecha_requerido, 'YYYY-MM-DD') as fecha_requiere,
       coalesce(tb_aprobado.f0200_apellido1 || ' ' || substring(tb_aprobado.f0200_nombres from 1 for 8), 'SIN APROBAR') as aprobo,
       to_char(f0319_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as f_aprobacion,
       coalesce(f0305_id_oc, 0) as id_oc,
       case coalesce(f0305_id_factura_compras, 0)
          when 0 then trim( both ' ' from coalesce(tb_tercero_oc.f0200_apellido1 || ' ' || tb_tercero_oc.f0200_nombres, 'ND'))
          else
          trim( both ' ' from coalesce(tb_tercero_factura.f0200_apellido1 || ' ' || tb_tercero_factura.f0200_nombres, 'ND'))
       end as proveedor, 
       f0305_id_accion as id_acc, 
       coalesce(f0600_id_accion_principal, coalesce(f0305_id_accion, 0)) as id_acc_ppal,
       CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre || ' =>> ' || tb0100_estructura_mantenimiento.f0100_nombre
       end as nombre_estructura, 
       CASE coalesce(tb0100_estructura_mantenimiento.f0100_id_maquina_padre, 0) 
          WHEN 0 THEN tb0100_estructura_mantenimiento.f0100_nombre
          WHEN tb0100_estructura_mantenimiento.f0100_id_estructura THEN tb0100_estructura_mantenimiento.f0100_nombre
          else
          otb_maquina.f0100_nombre
       end as maquina
from camocontrol.tb0305_items_solicitados
   left join camocontrol.tb0307_facturas_compras
      on f0307_id_factura_compras = f0305_id_factura_compras
   left join camocontrol.tb0200_terceros as tb_tercero_factura
      on f0307_id_tercero = tb_tercero_factura.f0200_id_tercero 
   join camocontrol.tb0304_solicitud_compra
      on f0305_id_solicitud_compra = f0304_id_solicitud
   join camocontrol.tb0300_items
      on f0305_id_item = f0300_id_item
   join camocontrol.tb0002_unidades_medicion
      on f0300_id_unidad_medicion = f0002_id_unidad_medicion
   join camocontrol.tb0302_tipos_items
      on f0302_id_tipo_item = f0300_id_tipo_item
   left join camocontrol.tb0600_acciones
      on f0600_id_accion = f0305_id_accion
   left join camocontrol.tb0100_estructura_mantenimiento
      on f0305_id_estructura = f0100_id_estructura
   left join camocontrol.tb0100_estructura_mantenimiento as otb_maquina
      on otb_maquina.f0100_id_estructura = tb0100_estructura_mantenimiento.f0100_id_maquina_padre
   left join camocontrol.tb0319_ordenes_compra
   	  on f0319_id_oc = f0305_id_oc
   left join camocontrol.tb0200_terceros as tb_tercero_oc
      on f0319_id_tercero = tb_tercero_oc.f0200_id_tercero 
   left join camocontrol.tb0200_terceros as tb_aprobado
      on f0319_usuario_aprobar = tb_aprobado.f0200_id_tercero
Where f0305_anulado = 'N' and f0305_id_cia = '00000001'
   and f0305_fr BETWEEN '2024-01-01' and '2024-12-01'
   and f0305_id_factura_compras is null 
order by f0300_descripcion_item, f0305_id_solicitud_compra