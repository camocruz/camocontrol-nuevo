SELECT f0310_id_documento as id_doc_inv, 
       to_char(f0310_fecha, 'YYYY-MM-DD HH12:MI AM') as fecha_registro
  FROM camocontrol.tb0310_documentos_movimientos_inventarios
where f0310_id_tipo_documento = 14 and f0310_anulado = 'N'
      and f0310_id_documento_origen = 'ACC-10856'
