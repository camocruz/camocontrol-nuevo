SELECT f0010_id_recaudo as id_recaudo,
       f0200_nombres as razon_social, f0200_id as nit,
       f0010_documento_recibo as recibo_cg,
       to_char(f0010_fecha_registro_recibo, 'YYYY-MM-DD HH12:MI AM') as fecha_recibo,
       f0008_descripcion_banco as banco,
       to_char(f0010_fecha_transaccion, 'YYYY-MM-DD') as fecha, f0010_col_fecha as r_fecha, f0010_col_transaccion as r_transaccion,
       f0010_col_oficina as r_oficina, f0010_col_documento as r_documento, f0010_col_credito as r_credito,
       f0010_col_efectivo as r_efectivo, f0010_col_cheque as r_cheque, f0010_col_nit as r_nit, f0010_col_cliente as r_cliente
FROM $df001$.tb0010_bancos_recaudos
       join $df001$.tb0008_configuracion_planos_recaudos
            on f0010_id_config = f0008_id_config
       left join $df001$.tb0200_terceros
            on f0010_cliente_identificado = f0200_id_tercero
where f0010_id_cia = '$001$'
      and f0010_recibo = 'S'
      and f0010_fecha_registro_recibo BETWEEN '$002$' and '$003$' order by f0010_id_recaudo