namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado completo del procesamiento de un soporte.
    /// </summary>
    public sealed class ProcesamientoSoporteResult
    {
        public long IdSoporte { get; set; }

        public SoporteDigitalDto Soporte { get; set; }

        public string ArchivoEncriptado { get; set; }

        public string HashSHA256 { get; set; }

        public int KeyVersion { get; set; }

        public bool ProcesadoCorrectamente { get; set; }

        public string Mensaje { get; set; }

        public ProcesamientoSoporteResult()
        {
            ArchivoEncriptado = string.Empty;
            HashSHA256 = string.Empty;
            Mensaje = string.Empty;
        }
    }
}