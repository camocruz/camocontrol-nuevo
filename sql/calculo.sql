SELECT f0402_id_rp, f0402_id_ipp, f0402_fecha_produccion, 
       f0402_turno, f0402_clasificador, f0402_id_item, f0402_cantidad_producida, 
       f0402_tiempo_produccion, f0402_horas_hombre, f0402_recorte_usado, 
       f0402_recorte_mt_producido, f0402_recorte_me_producido, f0402_fm, 
       f0402_fr, f0402_usuario_crear, f0402_usuario_modificar, f0402_anulado, 
       f0402_usuario_anular, f0402_id_prog_prod, f0402_id_bodega_consumo_insumos, 
       f0402_lote, f0402_fecha_vence, f0402_estado, f0402_tot_t_improductivo, 
       f0402_costo_mp, f0402_costo_me, f0402_costo_mp_np, f0402_costo_me_np, 
       f0402_num_funcionarios, f0402_costo_mano_obra, f0402_productividad, 
       f0402_recorte_producido, f0402_tree_path, f0402_id_act_alterna, 
       f0402_id_maquina, f0402_tipo_registro, f0402_ampliacion, f0402_planta_produccion
       
  FROM camocontrol.tb0402_reporte_produccion
     join camocontrol.tb0309_items_movimientos
       on 
where f0402_id_cia = '00000001' and f0402_anulado = 'N' and f0402_estado = 'C'
      and f0402_horas_hombre <> 1000
      and f0402_id_item = '2657' and f0402_fecha_produccion > now() - interval '30 day'
