with otb_edicion as (
     select f0501_codigo_documento, f0501_id_documento, 
            max(f0502_ed) as edicion, max(f0502_fecha_aprobacion) as f_aprovacion
        from $df001$.tb0501_documentos
           left join $df001$.tb0502_documentos_ed on f0501_id_documento = f0502_id_documento
           group by f0501_codigo_documento, f0501_id_documento
     order by f0501_codigo_documento
)
select tb0501_documentos.f0501_codigo_documento as cod_doc, 
       tb0501_documentos.f0501_titulo_documento as titulo,
       edicion, 
       to_char(f_aprovacion, 'YYYY-MM-DD') as fecha_aprov,
       f0500_tipo_documento as tipo, f0060_nombre_proceso as proceso,
       tb0501_documentos.f0501_conservacion as conservacion
   from $df001$.tb0501_documentos
      left join otb_edicion on otb_edicion.f0501_id_documento = tb0501_documentos.f0501_id_documento
      join $df001$.tb0500_tipos_documentos on f0500_id_tipo_documento = f0501_id_tipo_documento
      left join $df001$.tb0060_procesos_compania on f0060_id_proceso = f0501_proceso
order by tb0501_documentos.f0501_codigo_documento