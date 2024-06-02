select f0800_id_despacho as id_pdd,
      trim(both ' ' from tb_cliente.f0200_apellido1 || ' ' || tb_cliente.f0200_apellido2 || ' ' || tb_cliente.f0200_nombres) as cliente,
      tb_cliente.f0200_id as nit, f0052_ciudad || ' - ' || f0051_departamento as destino,
      trim(both ' ' from tb_anulador.f0200_apellido1 || ' ' || tb_anulador.f0200_apellido2 || ' ' || tb_anulador.f0200_nombres) as anulador,
      to_char(f0800_fm, 'YYYY-MM-DD HH12:MI AM') as fecha_anulacion
from $df001$.tb0800_despachos_comercial
     join $df001$.tb0200_terceros as tb_anulador
        on f0800_usuario_anular = tb_anulador.f0200_id_tercero
     join $df001$.tb0200_terceros as tb_cliente
        on f0800_cliente = tb_cliente.f0200_id_tercero
     join $df001$.tb0052_ciudades
        on tb_cliente.f0200_ciudad_residencia = f0052_codigo_ciudad
     join $df001$.tb0051_departamentos
        on f0051_codigo_departamento = f0052_codigo_departamento
where f0800_anulado = 'S'
order by f0800_id_despacho desc