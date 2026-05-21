using System;
using System.Globalization;

namespace App.ApiClient.CS.Utilities
{
    // public class DecimalFormatter
    // Clase para formatear números decimales con un número específico de decimales
    // Permite formatear un valor a una cadena con el formato "0.00" o similar, dependiendo del número de decimales especificado
    // Ejemplo de uso:
    // var formatter = new DecimalFormatter(2);
    // string resultado = formatter.Format(123.456); // resultado: "123.46"
    // string resultado2 = formatter.Format(null); // resultado2: "0.00"
    // También se puede usar la versión estática:
    // string resultado3 = DecimalFormatter.Format(123.456, 3); // resultado3: "123.456"
    // Si el valor no es un número válido, se devuelve el formato con ceros (por ejemplo, "0.00" para 2 decimales)
    // El constructor lanza una excepción si el número de decimales es negativo
    // Ejemplo de uso en VB.NET:
    // Dim formatter As New DecimalFormatter(2)
    // Dim resultado As String = formatter.Format(123.456) ' resultado: "123.46"
    // version estática:
    // Dim resultado2 As String = DecimalFormatter.Format(123.456, 3) ' resultado2: "123.456"
    public class DecimalFormatter
    {
        private readonly int _decimales;
        private readonly string _formato;

        public DecimalFormatter(int decimales)
        {
            if (decimales < 0)
                throw new ArgumentException("Los decimales no pueden ser negativos.");

            _decimales = decimales;
            _formato = "0." + new string('0', decimales);
        }

        public string Format(object valor)
        {
            if (valor == null)
                return _formato;

            if (decimal.TryParse(
                    Convert.ToString(valor, CultureInfo.InvariantCulture),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal numero))
            {
                return numero.ToString(_formato, CultureInfo.InvariantCulture);
            }

            return _formato;
        }

        // Versión estática para uso rápido
        public static string Format(object valor, int decimales)
        {
            var formatter = new DecimalFormatter(decimales);
            return formatter.Format(valor);
        }
    }

}