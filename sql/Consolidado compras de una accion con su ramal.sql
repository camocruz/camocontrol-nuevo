--copy(
SELECT --f0305_id_accion as id_acc, coalesce(f0600_id_accion_principal,0) as acc_raiz,
       --f0305_id_item_solicitud, f0307_fecha_factura,
       --(f0305_costo_unitario_planificado * f0305_cantidad) as costo_tot_sin_iva,
       --(f0305_costo_total_planificado) as costo_tot_iva
       sum(f0305_costo_unitario_planificado * f0305_cantidad) as costo_tot_sin_iva,
       sum(f0305_costo_total_planificado) as costo_tot_iva
  FROM camocontrol.tb0305_items_solicitados
    join camocontrol.tb0600_acciones
       on f0305_id_accion = f0600_id_accion
    join camocontrol.tb0307_facturas_compras
       on f0305_id_factura_compras = f0307_id_factura_compras
where f0305_docto_mov_inventario <> ''
      --and coalesce(f0600_id_accion_principal,0) = 14776
      and substring(f0600_path from 1 for char_length('-14776-')) = '-14776-'
--order by f0305_id_item_solicitud
--) to 'C:/dsfc/rh_asistencia/inf_comp_ramal.csv' WITH DELIMITER '	' CSV HEADER;