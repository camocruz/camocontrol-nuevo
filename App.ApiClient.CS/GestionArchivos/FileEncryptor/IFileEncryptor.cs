using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.FileEncryptor
{
    public interface IFileEncryptor
    {
        string EncryptText(
            string plainText);

        string DecryptText(
            string encryptedText);

        FileEncryptionResult EncryptFile(
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