namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado de una operación de encriptación.
    /// </summary>
    public sealed class EncryptResult
    {
        /// <summary>
        /// Versión de la clave utilizada.
        /// </summary>
        public int KeyVersion { get; set; }

        /// <summary>
        /// Hash SHA256 del archivo original.
        /// </summary>
        public string HashSHA256 { get; set; }

        public EncryptResult()
        {
            HashSHA256 = string.Empty;
        }
    }
}