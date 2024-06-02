with otb_edicion as (
     select f0501_codigo_documento, f0501_id_documento, 
            max(f0502_ed) as edicion, f0502_id_ed
        from camocontrol.tb0501_documentos
           left join camocontrol.tb0502_documentos_ed on f0501_id_documento = f0502_id_documento
        where f0501_id_cia = '00000001' and f0501_codigo_documento = 'FOR-130'
           group by f0501_codigo_documento, f0501_id_documento, f0502_id_ed
     order by f0501_codigo_documento
)
select tb0501_documentos.f0501_codigo_documento as codigo, 
      f0503_path || f0503_nombre_archivo || '-' || f0503_ed || f0503_extension as path
from camocontrol.tb0501_documentos
      left join otb_edicion on otb_edicion.f0501_id_documento = tb0501_documentos.f0501_id_documento
      join camocontrol.tb0500_tipos_documentos on f0500_id_tipo_documento = f0501_id_tipo_documento
      join camocontrol.tb0007_varibles_config on f0007_id_variable = f0500_config_archivos || '-001'
      join camocontrol.tb0503_archivos_asociados on f0503_nombre_archivo = f0007_valor_variable || '-' || lpad(otb_edicion.f0502_id_ed::text, 8, '0')
where f0503_id_cia = '00000001'
      and tb0501_documentos.f0501_codigo_documento = 'FOR-130'
      and f0503_id_tipo_archivo = 2
      and f0503_anulado = 'N'
order by tb0501_documentos.f0501_codigo_documento
