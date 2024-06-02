SELECT 
      case when f0310_id_bodega_destino = 0 then
        tb_bodega.f0005_descripcion_bodega
        else
        tb_bodega.f0005_descripcion_bodega || ' <==> ' || tb_bod_destino.f0005_descripcion_bodega
      end as bodega,
       f0310_id_documento as id_doc_inv, f0310_id_documento_origen as docto_origen, 
       f0311_documento as tipo,
       f0310_documento_contabilidad as docto_cg,
       to_char(f0310_fecha, 'YYYY-MM-DD HH12:MI AM') as fecha_docto,
       to_char(f0310_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_registro,
       tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable,
       case when f0310_anulado = 'S' then 'ANULADO' end as estado,
       case when f0310_anulado = 'S' then
         tb_anulo.f0200_apellido1 || ' ' || tb_anulo.f0200_apellido2 || ' ' || tb_anulo.f0200_nombres
       end  as anula
 FROM $df001$.tb0310_documentos_movimientos_inventarios
    join $df001$.tb0005_bodegas as tb_bodega
      on f0310_id_bodega = tb_bodega.f0005_id_bodega
    left join $df001$.tb0005_bodegas as tb_bod_destino
      on f0310_id_bodega_destino = tb_bod_destino.f0005_id_bodega
    join $df001$.tb0200_terceros as tb_responsable
      on f0310_usuario_crear = tb_responsable.f0200_id_tercero
    left join $df001$.tb0200_terceros as tb_anulo
      on f0310_usuario_anular = tb_anulo.f0200_id_tercero
    join $df001$.tb0311_tipos_doc_mov_inventarios
      on f0310_id_tipo_documento = f0311_id_tipo_doc
 where f0310_id_cia = '$001$' and f0310_fr BETWEEN '$002$' and '$003$'
