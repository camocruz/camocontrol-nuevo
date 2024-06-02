select f0850_rm, f0310_id_documento,f0850_id_rm
from camocontrol.tb0850_remisiones_cguno_encabezado 
Join camocontrol.tb0310_documentos_movimientos_inventarios 
 on f0850_rm = f0310_documento_contabilidad and f0310_anulado = 'N'
    and coalesce((string_to_array(f0310_id_documento_origen,'-'))[2]::int,0) = f0850_id_rm
where f0850_id_despacho = '25098'
