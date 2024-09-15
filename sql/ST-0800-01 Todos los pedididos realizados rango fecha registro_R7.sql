select f0800_id_despacho as id_pdd, coalesce(f0005_cod_bodega, 'ND') as bodega,
      trim(both ' ' from tb_asesor.f0200_apellido1 || ' ' || tb_asesor.f0200_apellido2 || ' ' || tb_asesor.f0200_nombres) as asesor,
      trim(both ' ' from tb_cliente.f0200_apellido1 || ' ' || tb_cliente.f0200_apellido2 || ' ' || tb_cliente.f0200_nombres) as cliente,
      tb_cliente.f0200_id as nit, f0052_ciudad || ' - ' || f0051_departamento as destino,
      to_char(f0800_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_pedido, f0800_tot_cajas_aprobadas as ped, f0800_tot_cajas_despachadas as car,
      trim(both ' ' from tb_transportadora.f0200_apellido1 || ' ' || tb_transportadora.f0200_apellido2 || ' ' || tb_transportadora.f0200_nombres) as transportadora, f0800_guia_transportadora as guia, 
	  to_char(f0800_fecha_registro_guia_transp, 'YYYY-MM-DD HH12:MI AM') as fecha_guia,
	  trim(both ' ' from tb_responsable_guia.f0200_apellido1 || ' ' || tb_responsable_guia.f0200_apellido2 || ' ' || tb_responsable_guia.f0200_nombres) as responsable_guia,
	  coalesce(((EXTRACT(EPOCH FROM f0800_fecha_registro_guia_transp)-
		EXTRACT(EPOCH FROM f0800_fr)) / 3600),-1)::int as horas_dif_ped_guia,
	  coalesce(f0803_demora, 'ND') as demora_ped_guia, 
	  f0800_id_accion as id_accion, to_char(f0600_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_rep_reclamo,
	  f0609_mef as mef, f0611_sub_fuente as sub_fuente
from camocontrol.tb0800_despachos_comercial
     left join camocontrol.tb0200_terceros as tb_asesor
        on f0800_vendedor = tb_asesor.f0200_id_tercero
     left join camocontrol.tb0200_terceros as tb_cliente
        on f0800_cliente = tb_cliente.f0200_id_tercero
     left join camocontrol.tb0200_terceros as tb_transportadora
        on f0800_transportadora = tb_transportadora.f0200_id_tercero
	 left join camocontrol.tb0200_terceros as tb_responsable_guia
       on f0800_funcionario_registra_guia_transp = tb_responsable_guia.f0200_id_tercero
     left join camocontrol.tb0052_ciudades
        on tb0800_despachos_comercial.f0800_id_ciudad_destino = f0052_codigo_ciudad
     left join camocontrol.tb0051_departamentos
        on f0051_codigo_departamento = f0052_codigo_departamento
	 left join camocontrol.tb0005_bodegas
	 	on f0005_id_bodega = f0800_id_bodega
	 left join camocontrol.tb0803_causas_demoras_despachos
	    on f0803_id_demora = f0800_id_demora
	 left join camocontrol.tb0600_acciones
	 	on f0800_id_accion = f0600_id_accion
	 left join camocontrol.tb0609_modos_efectos_falla
	    on f0609_id_mef = f0600_id_mef
	 left join camocontrol.tb0611_mef_sub_fuentes_acc
	 	on f0611_id_sub_fuente = f0600_id_subfuente
where f0800_anulado = 'N'
    and f0800_fr BETWEEN '2023-03-01' and '2023-03-04' order by f0800_id_despacho