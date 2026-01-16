using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using App.ApiClient.CS.DTOs;

namespace App.ApiClient.CS.Helpers
{
    public static class OrdenCompraDataTableBuilder
    {
        public static DataTable ToDataTable(List<OrdenCompraDto> lista, Dictionary<string, string> columnMap)
        {
            var dt = new DataTable();

            // Crear columnas
            foreach (PropertyInfo prop in typeof(OrdenCompraDto).GetProperties())
            {
                string colName = prop.Name;

                if (columnMap.ContainsKey(colName))
                    dt.Columns.Add(columnMap[colName]);
                else
                    dt.Columns.Add(colName);
            }

            // Agregar filas
            foreach (var item in lista)
            {
                var row = dt.NewRow();

                foreach (PropertyInfo prop in typeof(OrdenCompraDto).GetProperties())
                {
                    string colName = prop.Name;
                    object value = prop.GetValue(item, null);

                    if (columnMap.ContainsKey(colName))
                        row[columnMap[colName]] = value ?? DBNull.Value;
                    else
                        row[colName] = value ?? DBNull.Value;
                }

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
