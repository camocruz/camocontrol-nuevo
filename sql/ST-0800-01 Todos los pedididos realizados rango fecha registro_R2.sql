select f0800_id_despacho as id_pdd,
      trim(both ' ' from tb_asesor.f0200_apellido1 || ' ' || tb_asesor.f0200_apellido2 || ' ' || tb_asesor.f0200_nombres) as asesor,
      trim(both ' ' from tb_cliente.f0200_apellido1 || ' ' || tb_cliente.f0200_apellido2 || ' ' || tb_cliente.f0200_nombres) as cliente,
      tb_cliente.f0200_id as nit, f0052_ciudad || ' - ' || f0051_departamento as destino,
      to_char(f0800_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_pedido, f0800_tot_cajas_aprobadas as ped, f0800_tot_cajas_despachadas as car,
      trim(both ' ' from tb_transportadora.f0200_apellido1 || ' ' || tb_transportadora.f0200_apellido2 || ' ' || tb_transportadora.f0200_nombres) as transportadora, f0800_guia_transportadora as guia, to_char(f0800_fecha_registro_guia_transp, 'YYYY-MM-DD HH12:MI AM') as fecha_guia
from camocontrol.tb0800_despachos_comercial
     left join camocontrol.tb0200_terceros as tb_asesor
        on f0800_vendedor = tb_asesor.f0200_id_tercero
     left join camocontrol.tb0200_terceros as tb_cliente
        on f0800_cliente = tb_cliente.f0200_id_tercero
     left join camocontrol.tb0200_terceros as tb_transportadora
        on f0800_transportadora = tb_transportadora.f0200_id_tercero
     left join camocontrol.tb0052_ciudades
        on tb_cliente.f0200_ciudad_residencia = f0052_codigo_ciudad
     left join camocontrol.tb0051_departamentos
        on f0051_codigo_departamento = f0052_codigo_departamento
where f0800_anulado = 'N'
    and f0800_fr BETWEEN '2015-01-01' and '2015-12-01' order by f0800_id_despacho