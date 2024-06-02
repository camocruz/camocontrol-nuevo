SELECT f0607_id_seguimiento_accion as id_sgmnto, f0607_r_lectura as lectura, f0607_r_respuesta as responder
     FROM camocontrol.tb0607_seg_acc_personal
where f0607_id_tercero = '00000003'
     and ((f0607_r_lectura = 'S' and f0607_leido = 'N') or (f0607_r_respuesta = 'S' and f0607_respondido = 'N'))