with t1 as (select f0402_id_rp, f0310_id_documento as hh
from camocontrol.tb0310_documentos_movimientos_inventarios
  join camocontrol.tb0402_reporte_produccion
    on f0310_id_documento_origen = 'RP-' || f0402_id_rp
where f0402_id_prog_prod <= 9 and f0310_anulado = 'N' 
      and f0310_id_tipo_documento <> 4)
update camocontrol.tb0310_documentos_movimientos_inventarios
set f0310_id_documento_ref01 = 'DAC-00000001', f0310_documento_contabilidad = 'DOC-JUNIO'
from t1
where f0310_id_documento = t1.hh

      


