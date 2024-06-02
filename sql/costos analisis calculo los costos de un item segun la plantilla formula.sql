   select f0350_id_item, f0351_id_item, --f0300_id_tipo_item, f0310_id_tipo_documento,
       f0351_cantidad, f0350_produccion_x_bache,
       f0351_cantidad / f0350_produccion_x_bache as cant_unit,
       f0300_costo_promedio,
       f0300_costo_estandar,
        --sum(
          case when f0300_id_tipo_item = 1 
                 then (case when f0300_costo_estandar = 0 
                          then f0300_costo_promedio 
                          else
                          f0300_costo_estandar
                       end) 
           end * f0351_cantidad / f0350_produccion_x_bache
           --) 
           as costo_mp,
        --sum(
          case when f0300_id_tipo_item = 2
                 then (case when f0300_costo_estandar = 0 
                          then f0300_costo_promedio 
                          else
                          f0300_costo_estandar
                       end) 
           end * f0351_cantidad / f0350_produccion_x_bache
          -- ) 
           as costo_me,
        --sum(
          case when f0300_id_tipo_item = 25
                 then (case when f0300_costo_estandar = 0 
                          then f0300_costo_promedio 
                          else
                          f0300_costo_estandar
                       end) 
           end * f0351_cantidad / f0350_produccion_x_bache
          -- ) 
           as costo_prod_semiterm,
        --sum(
          case when f0300_id_tipo_item = 24
                 then (case when f0300_costo_estandar = 0 
                          then f0300_costo_promedio 
                          else
                          f0300_costo_estandar
                       end) 
           end * f0351_cantidad / f0350_produccion_x_bache
         --  ) 
           as costo_mano_obra,
        --sum(
          case when f0300_id_tipo_item <> 1 
                     and f0300_id_tipo_item <> 2 
                     and f0300_id_tipo_item <> 25
                     and f0300_id_tipo_item <> 24
                 then (case when f0300_costo_estandar = 0 
                          then f0300_costo_promedio 
                          else
                          f0300_costo_estandar
                       end) 
           end * f0351_cantidad / f0350_produccion_x_bache
         --  ) 
           as costo_otros
   from camocontrol.tb0351_elementos
      join camocontrol.tb0300_items
        on f0351_id_item = f0300_id_item   
      join camocontrol.tb0350_plantillas
        on f0350_id_plantilla = f0351_id_plantilla
   where f0350_id_cia = '00000001' 
         and f0350_anulado = 'N' and f0350_activa = 'S' and f0351_anulado = 'N'
        and f0350_id_item = 3392
   --group by f0350_id_item