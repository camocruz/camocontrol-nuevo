insert into camocontrol.tb0318_trazabilidad_movimientos 
       (f0318_id_mov_item, f0318_id_cia, f0318_id_mov_docto,
       f0318_id_item, f0318_id_bodega, f0318_id_documento,
       f0318_fecha_movimiento, f0318_info_trazable, 
       f0318_fm, f0318_fr, f0318_usuario_crear, f0318_usuario_modificar)
SELECT f0309_id_mov_item, f0309_id_cia, f0309_id_mov_docto,
       f0309_id_item, f0309_id_bodega, f0309_id_documento,
       f0309_fecha_movimiento, f0402_lote || ' (RP-' || f0402_id_rp || ')',
       f0309_fm, f0309_fr,
       f0309_usuario_crear, f0309_usuario_modificar
  FROM camocontrol.tb0310_documentos_movimientos_inventarios
    join camocontrol.tb0309_items_movimientos
      on f0309_id_documento = f0310_id_documento
    join camocontrol.tb0402_reporte_produccion
      on 'RP-' || f0402_id_rp = f0310_id_documento_origen
where f0310_id_tipo_documento = 4
                 
