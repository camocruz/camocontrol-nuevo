namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado de un proceso de encriptación de archivos.
    /// </summary>
    public sealed class FileEncryptionResult
    {
        public string HashSHA256 { get; set; }

        public int KeyVersion { get; set; }

        public string EncryptedFilePath { get; set; }

        public long FileSizeBytes { get; set; }

        public FileEncryptionResult()
        {
            HashSHA256 = string.Empty;
            EncryptedFilePath = string.Empty;
        }
    }
}
