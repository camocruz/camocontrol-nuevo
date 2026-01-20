using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace App.ApiClient.CS.Helpers.Commons
{
    public static class DataTableExtensions
    {
        private static readonly ConcurrentDictionary<Type, List<PropertyMetadata>> _cache =
            new ConcurrentDictionary<Type, List<PropertyMetadata>>();

        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var type = typeof(T);
            var metadata = _cache.GetOrAdd(type, BuildMetadata);

            DataTable dt = new DataTable(type.Name);

            // ============================
            // CREACIÓN DE COLUMNAS
            // ============================
            foreach (var m in metadata.OrderBy(m => m.Order))
            {
                // DisplayFormat explícito (NO moneda) → texto
                if (!string.IsNullOrEmpty(m.DisplayFormat) && !m.IsCurrency)
                {
                    dt.Columns.Add(m.ColumnName, typeof(string));
                }
                // Enum → texto
                else if (m.IsEnumText)
                {
                    dt.Columns.Add(m.ColumnName, typeof(string));
                }
                // Moneda → decimal
                else if (m.IsCurrency)
                {
                    dt.Columns.Add(m.ColumnName, typeof(decimal));
                }
                // Resto → tipo original
                else
                {
                    dt.Columns.Add(m.ColumnName, m.ColumnType);
                }
            }

            // ============================
            // LLENADO DE FILAS
            // ============================
            foreach (var item in items)
            {
                var row = dt.NewRow();

                foreach (var m in metadata)
                {
                    object value = m.Property.GetValue(item);

                    if (value == null)
                    {
                        row[m.ColumnName] = DBNull.Value;
                        continue;
                    }

                    // Enum → texto
                    if (m.IsEnumText)
                    {
                        row[m.ColumnName] = value.ToString();
                        continue;
                    }

                    // DisplayFormat explícito (NO moneda)
                    if (!string.IsNullOrEmpty(m.DisplayFormat) && !m.IsCurrency)
                    {
                        try
                        {
                            if (value is IFormattable formattable)
                                row[m.ColumnName] = formattable.ToString(m.DisplayFormat, CultureInfo.CurrentCulture);
                            else
                                row[m.ColumnName] = value.ToString();
                        }
                        catch
                        {
                            row[m.ColumnName] = value.ToString();
                        }
                        continue;
                    }

                    // Moneda → mantener decimal
                    if (m.IsCurrency)
                    {
                        row[m.ColumnName] = value;
                        continue;
                    }

                    // Resto → tipo original
                    row[m.ColumnName] = value;
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        // ============================
        // METADATA BUILDER
        // ============================
        private static List<PropertyMetadata> BuildMetadata(Type type)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var list = new List<PropertyMetadata>();

            foreach (var p in props)
            {
                if (p.GetCustomAttribute<ColumnIgnoreAttribute>() != null)
                    continue;

                var colNameAttr = p.GetCustomAttribute<ColumnNameAttribute>();
                var orderAttr = p.GetCustomAttribute<ColumnOrderAttribute>();
                var enumTextAttr = p.GetCustomAttribute<EnumTextAttribute>();
                var displayNameAttr = p.GetCustomAttribute<DisplayNameAttribute>();
                var displayFormatAttr = p.GetCustomAttribute<DisplayFormatAttribute>();

                string columnName =
                    colNameAttr?.Name ??
                    displayNameAttr?.DisplayName ??
                    p.Name;

                string displayFormat = displayFormatAttr?.DataFormatString;

                // Normalizar: "{0:C}" → "C"
                if (!string.IsNullOrEmpty(displayFormat) &&
                    displayFormat.StartsWith("{0:") &&
                    displayFormat.EndsWith("}"))
                {
                    displayFormat = displayFormat.Substring(3, displayFormat.Length - 4);
                }

                bool isCurrency =
                    (displayFormat != null && displayFormat.Contains("C")) ||
                    p.Name.ToLower().Contains("total") ||
                    p.Name.ToLower().Contains("valor") ||
                    p.Name.ToLower().Contains("monto") ||
                    p.Name.ToLower().Contains("precio");

                Type colType = p.PropertyType;
                if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    colType = Nullable.GetUnderlyingType(colType);

                list.Add(new PropertyMetadata
                {
                    Property = p,
                    ColumnName = columnName,
                    Order = orderAttr?.Order ?? int.MaxValue,
                    IsEnumText = enumTextAttr != null,
                    DisplayFormat = displayFormat,
                    IsCurrency = isCurrency,
                    ColumnType = colType
                });
            }

            return list;
        }

        // ============================
        // METADATA CLASS
        // ============================
        private class PropertyMetadata
        {
            public PropertyInfo Property { get; set; }
            public string ColumnName { get; set; }
            public int Order { get; set; }
            public bool IsEnumText { get; set; }
            public string DisplayFormat { get; set; }
            public bool IsCurrency { get; set; }
            public Type ColumnType { get; set; }
        }
    }
}