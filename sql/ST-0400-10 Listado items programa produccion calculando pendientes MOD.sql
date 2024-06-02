select *, f0401_cantidad - coalesce(cast((
         select sum(f0402_cantidad_producida)
            from $df001$.tb0402_reporte_produccion
         where f0402_id_item = f0401_id_item and f0402_id_prog_prod = f0401_id_prog_prod and f0402_anulado='N'
       ) as numeric),0) as pendiente
from $df001$.tb0401_items_prog_prod
    join $df001$.tb0300_items
       on f0401_id_item = f0300_id_item
    join $df001$.tb0400_programa_produccion
       on f0401_id_prog_prod = f0400_id_pp
 where f0401_id_cia = '$001$' and f0400_explosiona = 'S' and f0401_anulado = 'N' and f0401_id_ipp_padre is null