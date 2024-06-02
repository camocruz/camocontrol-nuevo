select f0606_id_seguimiento_accion as id_seg, f0310_id_documento as id_doc_inv,
   f0606_seguimiento_accion as anotacion, f0606_fr as fecha,
   f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as responsable,
   f0606_id_seguimiento_accion || ' -- ' 
   || to_char(f0606_fr, 'YYYY-MM-DD HH12:MI:ss AM') ||
   ' -- ' || f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres || 
   chr(10) || chr(10) || f0606_seguimiento_accion as n_larga
from $df001$.tb0606_seguimientos_acciones
  join $df001$.tb0310_documentos_movimientos_inventarios
     on f0606_id_documento = f0310_id_doc and f0606_tipo_nota = 'INV'
  join $df001$.tb0200_terceros 
     on f0606_usuario_crear = f0200_id_tercero
where f0606_id_cia = '$001$' AND f0310_id_documento = '$002$'
order by f0606_id_seguimiento_accion