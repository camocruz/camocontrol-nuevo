SELECT f0010_id_recaudo as id_recaudo, to_char(f0010_fecha_identificado, 'YYYY-MM-DD HH12:MI AM') as fecha_identificado,
       f0200_nombres as razon_social, f0200_id as nit,
       f0010_documento_recibo as recibo_cg,
       to_char(f0010_fecha_registro_recibo, 'YYYY-MM-DD HH12:MI AM') as fecha_recibo,
       f0011_razon_social as banco, f0008_descripcion_banco as tipo_lectura,
       to_char(f0010_fecha_transaccion, 'YYYY-MM-DD') as fecha, f0010_col_fecha as r_fecha, f0010_col_transaccion as r_transaccion,
       f0010_col_oficina as r_oficina, f0010_col_documento as r_documento, f0010_col_credito as r_credito,
       f0010_col_efectivo as r_efectivo, f0010_col_cheque as r_cheque, f0010_col_nit as r_nit, f0010_col_cliente as r_cliente
FROM camocontrol.tb0010_bancos_recaudos
       join camocontrol.tb0008_configuracion_planos_recaudos
           on f0010_id_config = f0008_id_config
       join camocontrol.tb0011_bancos
           on f0008_id_banco = f0011_id_banco
       left join camocontrol.tb0200_terceros
           on f0010_cliente_identificado = f0200_id_tercero
where f0010_id_cia = '00000001'
       and f0010_fecha_transaccion BETWEEN '2015-06-01' and '2015-07-01' order by f0010_id_recaudo