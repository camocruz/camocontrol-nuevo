SELECT f0307_id_factura_compras as id_fcc, 
       f0307_numero_factura as num_fact,
	   to_char(f0307_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_registro,
       trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2) as razon_social, f0200_id as nit,
       to_char( total ,'FM999,999,999') as valor_tot, cant_sop, f0307_doc_entrada as id_doc_inv,
	   f0307_aprobada as aprobada, f0307_conta1 as contab
FROM $df001$.tb0307_facturas_compras
   left join $df001$.tb0200_terceros
        on f0307_id_tercero = f0200_id_tercero
   left join (select f0305_id_factura_compras, sum(f0305_costo_total_planificado) as total
                 from $df001$.tb0305_items_solicitados
              group by f0305_id_factura_compras) as otb_items_fact
        on f0307_id_factura_compras = otb_items_fact.f0305_id_factura_compras
   left join (select substring(f0503_nombre_archivo from 5 for 12)::int as id_factura,
                               count(f0503_nombre_archivo) as cant_sop
                 from camocontrol.tb0503_archivos_asociados
              where substring(f0503_nombre_archivo from 1 for 4) = 'FCC-'
                              and f0503_anulado = 'N'
              group by f0503_nombre_archivo
             ) as otb_arch_sop
         on f0307_id_factura_compras = id_factura
where f0307_id_cia = '$001$' and f0307_anulado = 'N'
      and f0307_fecha_factura > '2020-01-01'
      and (f0307_aprobada = 'N')

