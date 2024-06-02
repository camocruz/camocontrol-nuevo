select f0800_id_despacho as id_pdd, f0850_rm as remision, f0850_num_factura as factura,
      f0310_id_documento as id_doc_inv,
      trim(both ' ' from tb_asesor.f0200_apellido1 || ' ' || tb_asesor.f0200_apellido2 || ' ' || tb_asesor.f0200_nombres) as asesor,
      trim(both ' ' from tb_cliente.f0200_apellido1 || ' ' || tb_cliente.f0200_apellido2 || ' ' || tb_cliente.f0200_nombres) as cliente,
      tb_cliente.f0200_id as nit, f0052_ciudad || ' - ' || f0051_departamento as destino,
      to_char(f0800_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_pedido,
      trim(both ' ' from tb_transportadora.f0200_apellido1 || ' ' || tb_transportadora.f0200_apellido2 || ' ' || tb_transportadora.f0200_nombres) as transportadora, f0800_guia_transportadora as guia, to_char(f0800_fecha_registro_guia_transp, 'YYYY-MM-DD HH12:MI AM') as fecha_guia
from $df001$.tb0800_despachos_comercial
     join $df001$.tb0850_remisiones_cguno_encabezado
        on f0800_id_despacho = f0850_id_despacho
     left join $df001$.tb0310_documentos_movimientos_inventarios
        on f0850_rm = f0310_documento_contabilidad and f0310_anulado = 'N'
     join $df001$.tb0200_terceros as tb_asesor
        on f0800_vendedor = tb_asesor.f0200_id_tercero
     join $df001$.tb0200_terceros as tb_cliente
        on f0800_cliente = tb_cliente.f0200_id_tercero
     left join $df001$.tb0200_terceros as tb_transportadora
        on f0800_transportadora = tb_transportadora.f0200_id_tercero
     join $df001$.tb0052_ciudades
        on f0800_id_ciudad_destino = f0052_codigo_ciudad
     join $df001$.tb0051_departamentos
        on f0051_codigo_departamento = f0052_codigo_departamento
where f0800_anulado = 'N'
    and f0800_fr BETWEEN '$001$' and '$002$' order by f0800_id_despacho