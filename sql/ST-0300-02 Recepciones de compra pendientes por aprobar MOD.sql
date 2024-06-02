SELECT f0307_id_factura_compras as id_fcc, f0307_oc_uno as oc_uno,
     f0307_numero_factura as num_fact,
     trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2) as razon_social, f0200_id as nit
FROM $df001$.tb0307_facturas_compras
     left join $df001$.tb0200_terceros
        on f0307_id_tercero = f0200_id_tercero
where f0307_id_cia = '$001$'and f0307_anulado = 'N'
     and f0307_aprobada = 'N' and f0307_recepcion_aprobada = 'N'