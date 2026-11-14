namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado de preparación de un archivo.
    /// </summary>
    public sealed class PreparacionArchivoResult
    {
        public string NombreArchivo { get; set; }

        public string RutaCompleta { get; set; }

        public PreparacionArchivoResult()
        {
            NombreArchivo = string.Empty;
            RutaCompleta = string.Empty;
        }
    }
}
