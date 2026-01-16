using System;

namespace App.ApiClient.CS.Exceptions
{
    public class SiesaApiException : Exception
    {
        public int Codigo { get; }

        public SiesaApiException(int codigo, string mensaje)
            : base($"Error Siesa (código {codigo}): {mensaje}")
        {
            Codigo = codigo;
        }
    }
}