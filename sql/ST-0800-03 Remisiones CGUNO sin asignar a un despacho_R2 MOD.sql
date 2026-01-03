SELECT f0850_id_rm as id_rm, f0850_rm as rm, f0850_fecha_documento as fecha, f0850_codigo_tercero as nit,
       f0850_razon_social as cliente, f0850_ciudad_destino as ciudad, f0850_direccion_destino as direccion,
       f0850_nombre_vendedor as vendedor, f0850_id_tercero as id_tercero
  FROM $df001$.tb0850_remisiones_cguno_encabezado
  where f0850_anulado = 'N' and f0850_id_cia = '$001$' and f0850_id_despacho is null
