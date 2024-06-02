--cambio de accion en una solicitud.
update camocontrol.tb0304_solicitud_compra set
   f0304_id_accion = 21783
where f0304_id_solicitud = 29311;
Update camocontrol.tb0305_items_solicitados set
   f0305_id_accion = 21783
where f0305_id_solicitud_compra = 29311;

--cambio de estructura de una solicitud
update camocontrol.tb0304_solicitud_compra set
   f0304_id_estructura = 1262
where f0304_id_solicitud = 29311;

-- cambio de estructura en todos los item de una solicitud.
update camocontrol.tb0305_items_solicitados set
   f0305_id_estructura = 1262
where f0305_id_solicitud_compra = 29311;

-- cambio de estructura en un solo item solicitado.
update camocontrol.tb0305_items_solicitados set
   f0305_id_estructura = 3542
where f0305_id_item_solicitud = 44111;

-- cambio de estructura de todas las solicitudes e items de una accion de acuerdo a la estructura de la accion.
update camocontrol.tb0304_solicitud_compra set
   f0304_id_estructura = 3958
where f0304_id_accion = 21949;
update camocontrol.tb0305_items_solicitados set
   f0305_id_estructura = 3958
where f0305_id_accion = 21949;

-- cambio de estructura de una accion
update camocontrol.tb0600_acciones
set f0600_id_estructura = 3958
where f0600_id_accion = 21949


