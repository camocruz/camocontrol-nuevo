using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.FileEncryptor
{
    /// <summary>
    /// Contrato para el motor de encriptación de archivos.
    /// </summary>
    public interface IFileEncryptor
    {
        EncryptResult EncryptFile(
            string sourceFile,
            string targetFile);

        void DecryptFile(
            string encryptedFile,
            string targetFile,
            int keyVersion,
            string expectedHash);

        int GetActiveKeyVersion();
    }
}