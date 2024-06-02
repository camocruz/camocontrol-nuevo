select f0305_id_item_solicitud as id_sc_item, 
       f0305_id_solicitud_compra as id_sc,
       f0305_estado as estado,
       to_char(f0305_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_solicitud,
       to_char(f0305_fecha_requerido, 'YYYY-MM-DD') as fecha_requiere,
       coalesce(tb_aprobado.f0200_apellido1 || ' ' || substring(tb_aprobado.f0200_nombres from 1 for 8), 'SIN APROBAR') as aprobo,
       to_char(f0305_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as f_aprobacion,
       coalesce(tb_tercero_oc.f0200_apellido1 || ' ' || tb_tercero_oc.f0200_nombres, 'SIN GESTION') as proveedor, 
       f0300_id_item as item,
       f0300_descripcion_item || ' ' || f0300_referencia as descripcion,
       f0305_ampliacion_item as descripcion_comp,
       f0305_anotacion_item as observacion,
       f0305_cantidad as cantidad,
       f0002_sigla_unidad_medicion as unid,
       --to_char(f0305_iva * 100,'00.99') || '%' as iva,
       --to_char(f0305_descuento * 100,'00.99') || '%' as descuento,
       --to_char(f0305_costo_unitario_planificado * (1 - f0305_descuento),'LFM999,999,999.00') as costo_unit,
       --to_char(f0305_cantidad * (f0305_costo_unitario_planificado * (1 - f0305_descuento)),'LFM999,999,999.00') as cost_tot,
       --to_char(f0305_costo_unitario_planificado * (1 + f0305_iva) * (1 - f0305_descuento),'LFM999,999,999.00') as cost_unit_iva,
       --to_char(f0305_costo_total_planificado,'LFM999,999,999.00') as costo_tot_iva,
       f0302_descripcion_tipo_item as tipo_item,
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
       end as maquina,
       coalesce(f0305_id_factura_compras, 0) as id_fcc,
       f0305_docto_mov_inventario as id_doc_inv
from camocontrol.tb0305_items_solicitados
    left join camocontrol.tb0200_terceros as tb_aprobado
      on f0305_usuario_aprobar = tb_aprobado.f0200_id_tercero
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
    left join camocontrol.tb0200_terceros as tb_tercero_oc
       on f0305_tercero_sol = tb_tercero_oc.f0200_id_tercero     
Where (f0600_id_cia = '00000001' and f0600_id_accion = '10856' and f0305_anulado = 'N') 
        or 
      (f0600_id_cia = '00000001' and substring(f0600_path from 1 for char_length('-10856-')) = '-10856-'  and f0305_anulado = 'N')
order by f0305_id_item_solicitud
