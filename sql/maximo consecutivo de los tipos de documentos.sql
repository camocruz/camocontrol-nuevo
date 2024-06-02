select max(right(f0310_id_documento , 8)) as actual
from camocontrol.tb0310_documentos_movimientos_inventarios
  join camocontrol.tb0311_tipos_doc_mov_inventarios
    on f0310_id_tipo_documento = f0311_id_tipo_doc
where f0310_id_tipo_documento = 3 and 
substring(f0310_id_documento from 1 for char_length(f0311_documento || '-')) = f0311_documento || '-'