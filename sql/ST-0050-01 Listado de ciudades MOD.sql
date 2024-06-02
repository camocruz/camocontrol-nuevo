SELECT f0052_codigo_ciudad as cod, f0052_ciudad as ciudad, f0051_departamento as departamento, f0052_ciudad_cg as equiv_cg
  FROM $df001$.tb0052_ciudades
     join $df001$.tb0051_departamentos on f0051_codigo_departamento = f0052_codigo_departamento;
