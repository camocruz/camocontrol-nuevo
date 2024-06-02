SELECT f0501_id_documento as id_documento, f0500_tipo_documento as tipo, 
       f0501_codigo_documento as codigo, 
       f0501_titulo_documento as titulo, 
       f0060_nombre_proceso as proceso, f0501_conservacion as conservacion
  FROM $df001$.tb0501_documentos
    join $df001$.tb0500_tipos_documentos on f0501_id_tipo_documento = f0500_id_tipo_documento
    left join $df001$.tb0060_procesos_compania on f0060_id_proceso = f0501_proceso
where f0501_id_cia = '$001$' and f0501_id_documento = '$002$'