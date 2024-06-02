with otb_edicion as (
     select f0501_id_documento as id_documento, 
            max(f0502_id_ed) as edicion
        from $df001$.tb0501_documentos
           left join $df001$.tb0502_documentos_ed on f0501_id_documento = f0502_id_documento
           group by f0501_codigo_documento, f0501_id_documento
     order by f0501_id_documento
)
select tb0501_documentos.f0501_codigo_documento as cod_doc, 
       tb0501_documentos.f0501_titulo_documento as titulo,
       f0502_ed as edicion, 
       to_char(f0502_fecha_aprobacion, 'YYYY-MM-DD') as fecha_aprov,
       f0500_tipo_documento as tipo, f0060_nombre_proceso as proceso,
       tb0501_documentos.f0501_conservacion as conservacion_reg,
       to_char(f0502_fecha_max_vigencia, 'YYYY-MM-DD') as vigente_hasta,
       to_char(f0502_fecha_inicio_tramites, 'YYYY-MM-DD') as inicio_tramites
   from $df001$.tb0501_documentos
      join $df001$.tb0500_tipos_documentos on f0500_id_tipo_documento = f0501_id_tipo_documento
      left join $df001$.tb0060_procesos_compania on f0060_id_proceso = f0501_proceso
      left join otb_edicion on otb_edicion.id_documento = tb0501_documentos.f0501_id_documento
      left join $df001$.tb0502_documentos_ed on otb_edicion.edicion = f0502_id_ed
                                                    and f0501_id_documento = f0502_id_documento    
order by tb0501_documentos.f0501_codigo_documento