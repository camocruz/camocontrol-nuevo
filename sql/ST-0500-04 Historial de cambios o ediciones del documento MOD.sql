select f0502_id_documento as id_documento, f0502_ed as ed, f0502_descripcion_ed as cambio, 
       to_char(f0502_fecha_aprobacion,'YYYY-MM-DD') as fecha
from $df001$.tb0502_documentos_ed
where f0502_id_cia = '$001$' and f0502_id_documento = '$002$'