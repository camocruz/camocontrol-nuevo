using System.Collections.Generic;

namespace App.ApiClient.CS.Helpers

{
    public static class OrdenCompraColumnMapper
    {
        public static Dictionary<string, string> GetColumnMap()
        {
            return new Dictionary<string, string>
            {
                // Cabecera
                { "f420_rowid", "RowID" },
                { "f420_id_cia", "Compañía" },
                { "f420_id_co", "Centro Operación" },
                { "f420_id_tipo_docto", "Tipo Documento" },
                { "f420_consec_docto", "Consecutivo" },
                { "f420_fecha", "Fecha" },
                { "f420_desc_clase_docto", "Clase Documento" },
                { "f420_desc_estado", "Estado" },
                { "f420_id_cond_pago", "Condición Pago" },

                // Proveedor
                { "f200_id_prov", "ID Proveedor" },
                { "f200_nit_prov", "NIT Proveedor" },
                { "f200_razon_social_prov", "Proveedor" },
                { "f202_id_sucursal_prov", "Sucursal Proveedor" },
                { "f202_descripcion_sucursal_prov", "Descripción Sucursal" },

                // Producto
                { "f120_referencia", "Referencia" },
                { "f120_descripcion", "Descripción Producto" },
                { "f150_descripcion", "Grupo Inventario" },

                // Detalle (línea)
                { "f421_cant_pedida", "Cantidad Pedida" },
                { "f421_cant_entrada", "Cantidad Entrada" },
                { "f421_precio_unitario", "Precio Unitario" },
                { "f421_vlr_bruto", "Valor Bruto" },
                { "f421_vlr_imp", "Impuestos" },
                { "f421_vlr_neto", "Valor Neto" },
                { "f421_fecha_entrega", "Fecha Entrega" },
                { "f421_id_unidad_medida", "Unidad" }
            };
        }
    }
}