select f0310_id_documento as id_doc_inv, f0309_entrada as cantidad, f0310_documento_contabilidad as docto_contable
from camocontrol.tb0310_documentos_movimientos_inventarios
   join camocontrol.tb0309_items_movimientos
       on f0310_id_documento = f0309_id_documento AND f0309_anulado = 'N'
where f0310_id_documento_origen = 'RP-872' and f0310_anulado = 'N' and f0310_id_cia = '00000001'
      and substring(f0310_id_documento from 1 for 4) = 'EPR-'