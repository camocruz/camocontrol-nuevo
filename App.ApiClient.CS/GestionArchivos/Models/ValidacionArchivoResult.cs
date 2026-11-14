namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado de la validación de un archivo.
    /// </summary>
    public sealed class ValidacionArchivoResult
    {
        public bool EsValido { get; set; }

        public string Mensaje { get; set; }

        public ValidacionArchivoResult()
        {
            Mensaje = string.Empty;
        }
    }
}