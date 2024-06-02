select f0504_id_documento_padre, f0504_id_documento_hijo,
       otb_padres.f0501_codigo_documento || '  <=>  ' || otb_padres.f0501_titulo_documento as padres_titulo,
       otb_hijos.f0501_codigo_documento || '  <=>  ' || otb_hijos.f0501_titulo_documento as hijos_titulo
from $df001$.tb0504_documentos_interrelaciones
   join $df001$.tb0501_documentos as otb_padres on otb_padres.f0501_id_documento = f0504_id_documento_padre
   join $df001$.tb0501_documentos as otb_hijos on otb_hijos.f0501_id_documento = f0504_id_documento_hijo
where f0504_id_cia = '$001$' 
      and (f0504_id_documento_padre = '$002$' or  f0504_id_documento_hijo = '$002$')