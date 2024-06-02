--Esta primera parte borra todos los duplicados
with analizador as (
SELECT to_char(f0600_fecha_inicio, 'YYYY-MM-DD') as fecha,
       count(f0600_id_accion) as cant, min(f0600_id_accion) as minima,
       f0600_id_accion_padre as padre, f0600_descripcion
  FROM camocontrol.tb0600_acciones
  where substring(f0600_path from 1 for char_length('-9068-')) = '-9068-'
        and f0600_anulado = 'N' 
  group by f0600_id_accion_padre, 
       to_char(f0600_fecha_inicio, 'YYYY-MM-DD'),f0600_descripcion
  order by fecha
),
duplicados as (
 select minima, cant, fecha, padre from analizador
 where cant > 1
)
--select minima, cant, fecha, padre from duplicados
  update camocontrol.tb0600_acciones set
         f0600_fm = now(), f0600_anulado = 'S', 
         f0600_usuario_anular = '00000004'
         from duplicados
  where f0600_id_accion_padre = duplicados.padre
        and f0600_anulado = 'N'
        and to_char(f0600_fecha_inicio, 'YYYY-MM-DD') = duplicados.fecha
        and f0600_id_accion > duplicados.minima;  

