SELECT f0800_id_despacho as id_pdd, 
     coalesce(trim(both ' ' from tercero_ped.f0200_apellido1 || ' ' || tercero_ped.f0200_apellido2 || ' ' || tercero_ped.f0200_nombres),
              trim(both ' ' from tercero_acc.f0200_apellido1 || ' ' || tercero_acc.f0200_apellido2 || ' ' || tercero_acc.f0200_nombres)) as tercero,
     coalesce(tercero_ped.f0200_id, tercero_acc.f0200_id) as nit, otb_mef.f0609_mef as reclamo_mef, otb_causa.f0609_mef as causa_raiz,
     f0800_docto_devolucion as id_doc_inv,
     f0605_descriptor_tipo_registro as tipo,
     f0600_id_accion as id_accion, f0600_path || f0600_id_accion as path,
     f0603_descriptor_estado as estado,
     f0600_descripcion as descripcion,
     to_char(f0600_fr, 'YYYY-MM-DD') as f_reporte, to_char(f0600_fr, 'YYYY') as ano, to_char(f0600_fr, 'YYYY-MM') as mes,
     trim(both ' ' from tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres) as responsable,
     trim(both ' ' from tb_emisor.f0200_apellido1 || ' ' || tb_emisor.f0200_apellido2 || ' ' || tb_emisor.f0200_nombres) as emisor,
     trim(both ' ' from tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres) as evaluador,
     trim(both ' ' from transportadora.f0200_apellido1 || ' ' || transportadora.f0200_apellido2 || ' ' || transportadora.f0200_nombres) as transportadora
FROM camocontrol.tb0600_acciones
    Join camocontrol.tb0603_estados_acciones
       on f0600_id_estado_accion = f0603_id_estado_accion
    join camocontrol.tb0200_terceros as tb_responsable
       on f0600_responsable = tb_responsable.f0200_id_tercero
    join camocontrol.tb0200_terceros as tb_emisor
       on f0600_emisor = tb_emisor.f0200_id_tercero
    join camocontrol.tb0200_terceros as tb_evaluador
       on f0600_evaluador = tb_evaluador.f0200_id_tercero
    left join camocontrol.tb0800_despachos_comercial
       on f0600_id_accion = f0800_id_accion
    left join camocontrol.tb0200_terceros as tercero_ped
       on tercero_ped.f0200_id_tercero = f0800_cliente
    left join camocontrol.tb0200_terceros as transportadora
       on transportadora.f0200_id_tercero = f0800_transportadora
    left join camocontrol.tb0200_terceros as tercero_acc
       on tercero_acc.f0200_id_tercero = f0600_tercero_relacionado
    Join camocontrol.tb0605_tipos_registro_acciones
       on f0600_id_tipo_registro = f0605_id_tipo_registro
    left join camocontrol.tb0609_modos_efectos_falla as otb_mef
       on otb_mef.f0609_id_mef = f0600_id_mef
    left join camocontrol.tb0609_modos_efectos_falla as otb_causa
       on otb_causa.f0609_id_mef = f0600_id_mef_causa
where f0600_id_fuente_accion = '00000004' and f0605_id_tipo_registro = '01'
    and f0600_fr > '2017-01-01'
order by tipo desc, f0600_id_accion