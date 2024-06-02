select f0319_id_oc as id_oc, f0319_cumplida as cumpl,
       trim(both ' ' from tb_proveedor.f0200_nombres || ' ' || tb_proveedor.f0200_apellido1 || ' ' || tb_proveedor.f0200_apellido2) as razon_social, 
       tb_proveedor.f0200_id as nit,
       f0319_fecha_oc as fecha_oc,
       case when f0319_aprobada = 'S' 
            then tb_aprobado.f0200_apellido1 || ' ' || substring(tb_aprobado.f0200_nombres from 1 for 8)
            else 'SIN APROBAR!!!!'
       end as aprobo,
       to_char(f0319_fecha_aprobacion, 'YYYY-MM-DD HH12:MI AM') as f_aprobacion,
       case when f0319_anulado = 'S' then 'ANULADO' end as inf
from $df001$.tb0319_ordenes_compra
    left join $df001$.tb0200_terceros as tb_aprobado
      on f0319_usuario_aprobar = tb_aprobado.f0200_id_tercero
    join $df001$.tb0200_terceros as tb_proveedor
      on tb_proveedor.f0200_id_tercero = f0319_id_tercero
Where f0319_id_cia = '$001$' and f0319_fecha_oc BETWEEN '$002$' AND '$003$'
order by f0319_id_oc