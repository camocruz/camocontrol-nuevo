select f0402_id_rp as id_rp, f0402_clasificador as clasificador, f0402_id_item as id_item, f0300_referencia as ref_1, f0402_lote as lote,
    f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ' <' || f0002_unidad_medicion || '> )' as producto,
    f0002_unidad_medicion as unidad, round(f0402_cantidad_producida,2) as produccion, f0402_productividad as productividad,
    to_char(f0402_fecha_produccion, 'YYYY-MM-DD') as fecha_prod,
    to_char(f0402_fecha_produccion,'yyyy-MM') as mes, 
    EXTRACT(WEEK FROM f0402_fecha_produccion) as semana,
    to_char(f0402_fecha_produccion,'dd') as dia,
    f0302_descripcion_tipo_item as tipo_item, 
    round(f0300_peso_neto * f0402_cantidad_producida, 2) as peso_unit_net, f0402_estado as estado, round(f0402_tiempo_produccion, 2) as t_produccion,
    f0402_num_funcionarios as personas, round(f0402_horas_hombre, 2) as h_hombre,
    coalesce(f0005_descripcion_bodega, 'ND') as bodega_consumo_mp,
    round(f0402_tot_t_improductivo/60, 2) as t_improductivo, 
    --round(((f0402_tot_t_improductivo/60) / f0402_tiempo_produccion) * 100, 2) as porc_t_imp,
    round(f0402_recorte_usado, 2) as rcte_usad, round(f0402_recorte_producido, 2) as rcte_prod,
    planta.f0100_nombre as planta_prod, maquina.f0100_nombre as maquina,
    f0303_descripcion_linea_item as linea, round(f0402_costo_unitario,2) as c_unit
from $df001$.tb0402_reporte_produccion
    join $df001$.tb0300_items
      on f0402_id_item = f0300_id_item
    join $df001$.tb0002_unidades_medicion
      on f0300_id_unidad_medicion=f0002_id_unidad_medicion
    join $df001$.tb0302_tipos_items
      on f0300_id_tipo_item = f0302_id_tipo_item
    join $df001$.tb0303_lineas_items
      on f0303_id_linea_item = f0300_id_linea
    left join $df001$.tb0005_bodegas
      on f0005_id_bodega = f0402_id_bodega_consumo_insumos
    left join $df001$.tb0100_estructura_mantenimiento as planta
      on planta.f0100_id_estructura = f0402_planta_produccion
    left join $df001$.tb0100_estructura_mantenimiento as maquina
      on maquina.f0100_id_estructura = f0402_id_maquina 
where f0402_anulado = 'N' and f0402_id_cia = '$001$' and f0300_ar = '$004$'
    and f0402_fecha_produccion BETWEEN '$002$' and '$003$'
order by f0402_fecha_produccion asc