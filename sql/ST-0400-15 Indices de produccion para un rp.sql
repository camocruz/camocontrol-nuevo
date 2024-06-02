select round(f0402_cantidad_producida / f0402_tiempo_produccion, 3) as prod_hora,
   round(f0402_cantidad_producida / f0402_horas_hombre, 3) as rend_hh
from camocontrol.tb0402_reporte_produccion
where f0402_anulado = 'N' and f0402_id_cia = '00000001' and f0402_id_rp = '7848'