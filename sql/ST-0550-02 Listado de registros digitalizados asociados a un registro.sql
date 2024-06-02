SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion,
       f0503_extension as extension, f0503_nombre_original as archivo,
       to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor
from camocontrol.tb0503_archivos_asociados
      join camocontrol.tb0200_terceros on f0503_usuario_crear = f0200_id_tercero
where f0503_nombre_archivo = 'BKC-00000071'
      and f0503_id_cia = '00000001'
      and f0503_usuario_crear = '00000004' and f0503_anulado = 'N'