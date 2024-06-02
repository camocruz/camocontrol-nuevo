select f0310_id_documento as id_doc_inv, f0310_documento_contabilidad as doc_cg,
       to_char(f0310_fecha, 'YYYY-MM-DD HH12:MI AM') as fecha_docto,
       to_char(f0310_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_registro, 
       tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable
from $df001$.tb0310_documentos_movimientos_inventarios
  join $df001$.tb0200_terceros as tb_responsable
      on f0310_usuario_crear = tb_responsable.f0200_id_tercero
where f0310_documento_contabilidad = '' and f0310_anulado = 'N' 
  and f0310_id_tipo_documento = 6
order by f0310_id_documento desc