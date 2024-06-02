update camocontrol.tb0600_acciones
set f0600_id_accion_principal = case when (string_to_array(f0600_path, '-'))[2] = '' 
					then 
						null
					else 
						(string_to_array(f0600_path, '-'))[2]::int 
				end
