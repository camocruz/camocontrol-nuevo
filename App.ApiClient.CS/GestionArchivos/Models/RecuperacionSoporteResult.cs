namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado de recuperación de un soporte.
    /// </summary>
    public sealed class RecuperacionSoporteResult
    {
        public string ArchivoTemporal { get; set; }

        public bool RecuperadoCorrectamente { get; set; }

        public string Mensaje { get; set; }

        public RecuperacionSoporteResult()
        {
            ArchivoTemporal = string.Empty;
            Mensaje = string.Empty;
        }
    }
}