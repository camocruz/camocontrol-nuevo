SELECT tb0240_cargos_compania.f0240_id_cargo as id_crgo, tb0240_cargos_compania.f0240_cargo as cargo, 
    coalesce(jefe.f0240_cargo, 'ND') as jefe_inmediato, 
    coalesce(f0060_nombre_proceso, 'ND') as proceso
  FROM $df001$.tb0240_cargos_compania
    left join $df001$.tb0240_cargos_compania as jefe on jefe.f0240_id_cargo = tb0240_cargos_compania.f0240_superior
    left join $df001$.tb0060_procesos_compania on f0060_id_proceso = tb0240_cargos_compania.f0240_id_proceso
where tb0240_cargos_compania.f0240_id_cia = '$001$' and tb0240_cargos_compania.f0240_anulado = 'N'
order by tb0240_cargos_compania.f0240_cargo