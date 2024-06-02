SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion,
       f0503_extension as extension, f0503_nombre_original as archivo,
       to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga,
       f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor
from $df001$.tb0503_archivos_asociados
      join $df001$.tb0200_terceros on f0503_usuario_crear = f0200_id_tercero
where f0503_nombre_archivo = '$002$'
      and f0503_id_cia = '$001$'
      and f0503_usuario_crear = $003$ and f0503_anulado = 'N' --OJO EL $003$ ESTA SIN '' DEBIDO A QUE LO REEMPLAZO POR CODIGO EN EL FORMATO PLANTILLA

