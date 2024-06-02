delete from camocontrol.tb0843_info_guias_transportadora_envia;
copy camocontrol.tb0843_info_guias_transportadora_envia from 'C:\dat_temp\borrar2.txt';

-- informacion de guias
select guia, estado, cuenta, fec_captura, dias_prometidos, fec_entrega, dias_entrega, hora, servicio, regional_destino, ciudad_destino, nom_departamento, nombre_destinatario, direccion_destinatario, num_unidades, peso_real, volumen, kilos_cobrados, valor_declarado, valor_flete, flete_variable, valor_otros, total, numero_documento, notas, dice_contener, ciudad_origen, otra_guia, tel_destinatario, nom_remitente, dir_remitente, tel_remitente, fecha_novedad, descripcion_novedad, aclaracion_novedad, tipo_novedad, cod_servicio, factura, ctro_costo, texto_guia, accion_nota_guia, num_cliente, ced_destinatario, regional_orig, fecha_aprox_entrega, des_estado_guia, cartaporte, cod_cubrimiento, tiempo, ofi_ori, valor_producto, num_transaccion, memo_sac, cod_usr_crea, codigo_zipcode_origen, codigo_zipcode_destino
from camocontrol.tb0843_info_guias_transportadoras_unif
where guia = '794000197853'
union all
select guia, estado, cuenta, fec_captura, dias_prometidos, fec_entrega, dias_entrega, hora, servicio, regional_destino, ciudad_destino, nom_departamento, nombre_destinatario, direccion_destinatario, num_unidades, peso_real, volumen, kilos_cobrados, valor_declarado, valor_flete, flete_variable, valor_otros, total, numero_documento, notas, dice_contener, ciudad_origen, otra_guia, tel_destinatario, nom_remitente, dir_remitente, tel_remitente, fecha_novedad, descripcion_novedad, aclaracion_novedad, tipo_novedad, cod_servicio, factura, ctro_costo, texto_guia, accion_nota_guia, num_cliente, ced_destinatario, regional_orig, fecha_aprox_entrega, des_estado_guia, cartaporte, cod_cubrimiento, tiempo, ofi_ori, valor_producto, num_transaccion, memo_sac, cod_usr_crea, codigo_zipcode_origen, codigo_zipcode_destino 
from camocontrol.tb0843_info_guias_transportadora_envia
where guia = '794000197853'


INSERT INTO camocontrol.tb0843_info_guias_transportadoras_unif SELECT *, 'ENVIA' 
	FROM camocontrol.tb0843_info_guias_transportadora_envia
 ON CONFLICT (guia) DO UPDATE SET 
 fec_entrega = (select fec_entrega from camocontrol.tb0843_info_guias_transportadora_envia
			   where tb0843_info_guias_transportadoras_unif.guia =
			   	tb0843_info_guias_transportadora_envia.guia),
 dias_entrega = (select dias_entrega from camocontrol.tb0843_info_guias_transportadora_envia
			   where tb0843_info_guias_transportadoras_unif.guia =
			   	tb0843_info_guias_transportadora_envia.guia),
  hora = (select hora from camocontrol.tb0843_info_guias_transportadora_envia
			   where tb0843_info_guias_transportadoras_unif.guia =
			   	tb0843_info_guias_transportadora_envia.guia),
  estado = (select estado from camocontrol.tb0843_info_guias_transportadora_envia
			   where tb0843_info_guias_transportadoras_unif.guia =
			   	tb0843_info_guias_transportadora_envia.guia),
  des_estado_guia = (select des_estado_guia from camocontrol.tb0843_info_guias_transportadora_envia
			   where tb0843_info_guias_transportadoras_unif.guia =
			   	tb0843_info_guias_transportadora_envia.guia)
				;

-- Genero plano
copy (
select guia, estado, fec_captura, fec_entrega, dias_entrega, ciudad_destino, ciudad_origen,
	nom_remitente,
	num_unidades, valor_declarado, total
from camocontrol.tb0843_info_guias_transportadoras_unif
	) to 'C:\dat_temp\DatTransport.txt' DELIMITER '	'  CSV HEADER;