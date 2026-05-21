using App.ApiClient.CS.DTOs.SpecificDtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.ApiClient.CS.Services
{
    public class EstructuraSiesaService
    {
        public string CrearLineaInicial(int longitud)
        {
            if (longitud <= 0)
                return string.Empty;

            return new string(' ', longitud);
        }
        public IEnumerable<DefinicionEstructuraSiesaDto> ConvertirMatriz(string[,] matriz)
        {
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);

            var lista = new List<DefinicionEstructuraSiesaDto>();

            for (int i = 0; i < filas; i++)
            {
                lista.Add(new DefinicionEstructuraSiesaDto
                {
                    Nombre = matriz[i, 0],
                    Tipo = matriz[i, 1],
                    Inicio = matriz[i, 2],
                    Tamaño = matriz[i, 3],
                    DigRelleno = matriz[i, 4],
                    Valor = matriz[i, 5]
                });
            }

            return lista;
        }

        public DefinicionEstructuraSiesaDto ObtenerCampoPorNombre(
            IEnumerable<DefinicionEstructuraSiesaDto> campos,
            string nombreBuscado)
        {
            return campos.FirstOrDefault(c =>
                c.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase));
        }

        public string ReemplazarFragmento(
            string lineaTotal,
            string fragmentoLinea,
            int posicionInicio)
        {
            if (posicionInicio < 0)
                throw new ArgumentOutOfRangeException(nameof(posicionInicio));

            if (posicionInicio + fragmentoLinea.Length > lineaTotal.Length)
                throw new ArgumentException("El fragmento excede la longitud de la línea.");

            char[] resultado = lineaTotal.ToCharArray();

            for (int i = 0; i < fragmentoLinea.Length; i++)
            {
                resultado[posicionInicio + i] = fragmentoLinea[i];
            }

            return new string(resultado);
        }

        public string ReemplazarValores(
            IEnumerable<DefinicionEstructuraSiesaDto> listaDtosSecc,
            string lineaEdicion,
            string nombre,
            string valor)
        {
            var campo = ObtenerCampoPorNombre(listaDtosSecc, nombre);

            if (campo == null)
                throw new Exception($"Campo '{nombre}' no encontrado.");

            if (!string.IsNullOrEmpty(valor))
                campo.Valor = valor;

            int tam = Convert.ToInt32(campo.Tamaño);

            if (campo.Tipo.ToUpper() == "NUMÉRICO")
            {
                campo.Valor = campo.Valor.PadLeft(tam, '0');
            }
            else
            {
                campo.Valor = campo.Valor.PadRight(tam, ' ');
            }

            char dig = campo.DigRelleno[0];

            string valorFormateado = campo.Valor.PadLeft(tam, dig);

            int inicio = Convert.ToInt32(campo.Inicio) - 1;

            return ReemplazarFragmento(lineaEdicion, valorFormateado, inicio);
        }
    }
}