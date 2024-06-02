select f0402_id_rp as id_rp, f0402_fecha_produccion as fecha, f0402_turno as tuno,
    f0402_cantidad_producida as cant_prod, f0402_tiempo_produccion as h_prod,
    f0402_horas_hombre as h_hombre, f0402_recorte_usado as rec_mt_us,
    f0402_recorte_mt_producido as rec_mt_prod,
    f0402_recorte_me_producido as rec_me_prod
from $df001$.tb0402_reporte_produccion
where f0402_id_cia = '$001$' and f0402_id_ipp = '$002$' and f0402_anulado = 'N'