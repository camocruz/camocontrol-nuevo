select 
  array [
         round((f0402_cantidad_producida / ((f0350_produccion_x_bache / f0350_hh_prod_bache) * f0402_horas_hombre)) * 100, 2)
          , 100] as productividad,
   array [round(f0402_cantidad_producida / f0402_tiempo_produccion, 3),
              round((f0402_horas_hombre / f0402_tiempo_produccion) * (f0350_produccion_x_bache / f0350_hh_prod_bache), 3)] as prod_hora,
   array [round(f0402_cantidad_producida / f0402_horas_hombre, 3), round(f0350_produccion_x_bache / f0350_hh_prod_bache, 3)] as prod_hh,
   array [f0402_cantidad_producida, round((f0350_produccion_x_bache / f0350_hh_prod_bache) * f0402_horas_hombre, 3)]  as produccion,
   array [round(f0402_recorte_usado,3), 0] as rec_aprov_kg,
   array [round(f0402_recorte_producido,3), 0] as rec_gen_kg,
   array [round((
                 coalesce(
                 (select sum(f0309_costo_unit_promedio * f0309_salida) as costo
                     from camocontrol.tb0309_items_movimientos
                        join camocontrol.tb0310_documentos_movimientos_inventarios
                           on f0310_id_documento = f0309_id_documento
                  where f0310_id_documento_origen = 'RP-' || 19379
                     and f0309_salida > 0
                     and f0310_anulado = 'N'
                  ),0) 
                  + 
                  (CASE WHEN f0402_horas_hombre = 1000 THEN 1 ELSE f0402_horas_hombre END * 8000)
                ) 
                / f0402_cantidad_producida, 2), 0] as c_unit
from camocontrol.tb0402_reporte_produccion
  left join camocontrol.tb0350_plantillas
    on f0350_id_item = f0402_id_item and f0350_activa = 'S'
where f0402_anulado = 'N' and f0402_id_cia = '00000001' and f0402_id_rp = '19379'
