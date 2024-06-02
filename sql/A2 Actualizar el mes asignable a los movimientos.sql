-- Actualizo el mes asignable para actualizar los movimientos del mes de acuerdo a fecha de produccion
WITH otb_fechas AS (
   select f0310_id_documento, to_char(f0402_fecha_produccion,'YYYY-MM') as ofecha
         from camocontrol.tb0402_reporte_produccion
           join camocontrol.tb0310_documentos_movimientos_inventarios
             on f0310_id_documento_origen = 'RP-' || f0402_id_rp
)        
update camocontrol.tb0309_items_movimientos set
    f0309_mes_asignable = otb_fechas.ofecha
from otb_fechas
where f0309_mes_asignable = '' and otb_fechas.f0310_id_documento = f0309_id_documento