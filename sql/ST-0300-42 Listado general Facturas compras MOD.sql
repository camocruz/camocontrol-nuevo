SELECT f0307_id_factura_compras as id_fcc,  
      f0307_numero_factura as num_fact,
      to_char(f0307_fecha_factura, 'YYYY-MM-DD') as fecha_factura,
      trim(both ' ' from tb0200_terceros.f0200_nombres || ' ' || tb0200_terceros.f0200_apellido1 || ' ' || tb0200_terceros.f0200_apellido2) as razon_social, tb0200_terceros.f0200_id as nit,
      to_char(f0307_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as fecha_aprobacion,
      trim(both ' ' from aprobador.f0200_apellido1 || ' ' || aprobador.f0200_apellido2 || ' ' || aprobador.f0200_nombres) as aprobado_por,
      f0307_id_oc as id_oc, f0307_doc_entrada as id_doc_inv
FROM $df001$.tb0307_facturas_compras
    left join $df001$.tb0200_terceros
        on f0307_id_tercero = f0200_id_tercero
    left join $df001$.tb0200_terceros as aprobador
        on f0307_usuario_aprobar = aprobador.f0200_id_tercero
where f0307_id_cia = '$001$' and f0307_anulado = 'N'
    and f0307_fecha_factura BETWEEN '$002$' and '$003$' order by f0307_id_factura_compras