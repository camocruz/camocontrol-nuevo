SELECT f0216_id_ausentismo as id_ausnt, f0200_id_tercero,
       f0216_id_tipo,
       to_char(f0216_fecha_inicio_tnl, 'YYYY-MM-DD HH12:MI AM') as f_inicial_tnl,
       to_char(f0216_fecha_inicio_tnl, 'YYYY') as año_tnl,
       f0216_nombre_mes_ini_tnl as mes_ini_tnl,
       f0216_nombre_dia_ini_tnl as dia_ini_tnl,
       to_char(f0216_fecha_fin_tnl, 'YYYY-MM-DD HH12:MI AM') as f_final_tnl, 
       f0216_horas_tnl as horas_tnl,
       f0215_id_causa, f0215_codigo as codigo, f0215_causa as causa, 
       f0214_descripcion_grupo as grupo, f0213_clase as clase, 
       f0216_lugar_ocurrencia, f0216_observacion as observacion, 
       f0216_edad as edad, f0240_cargo as cargo, f0216_id_contrato as id_contrato, 
       f0216_antiguedad_ini as ant_tot, 
       f0216_antiguedad_act as ant_act,
       f0216_dias_incap_inicial as d_inc_ini, f0216_cant_prorrogas,
       f0216_dias_prorroga as d_prorroga,
       f0216_planta, f0216_maquina, 
       planta.f0100_nombre as planta_prod, maquina.f0100_nombre as maquina,
       to_char(f0216_fr, 'YYYY-MM-DD HH12:MI AM') as f_registro,
       otb_tercero_registro.f0200_apellido1 || ' ' || otb_tercero_registro.f0200_apellido2 || ' ' || otb_tercero_registro.f0200_nombres as registrado_por
  FROM camocontrol.tb0216_ausentismo
  left join camocontrol.tb0215_causas_ausentismo
     on f0216_id_causa = f0215_id_causa
  left join camocontrol.tb0240_cargos_compania
     on f0216_id_cargo = f0240_id_cargo
  left join camocontrol.tb0214_grupos_ausentismo
     on f0215_id_grupo = f0214_id_grupo
  left join camocontrol.tb0213_clasificacion_ausentismo
     on f0213_id_clase = f0214_id_clase
  join camocontrol.tb0200_terceros as otb_tercero_registro
     on f0216_usuario_crear = otb_tercero_registro.f0200_id_tercero
  left join camocontrol.tb0217_contratos_personal
     on f0217_id_contrato =  f0216_id_contrato
  left join camocontrol.tb0100_estructura_mantenimiento as planta
      on planta.f0100_id_estructura = f0216_planta
  left join camocontrol.tb0100_estructura_mantenimiento as maquina
      on maquina.f0100_id_estructura = f0216_maquina  
  left join camocontrol.tb0217_tipos_ausentismo
     on f0217_id_tipo = f0216_id_tipo  
  where f0216_id_cia = '00000001' and  f0216_id_ausentismo = 3
