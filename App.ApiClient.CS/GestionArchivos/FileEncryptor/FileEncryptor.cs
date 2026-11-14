using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using App.ApiClient.CS.GestionArchivos.Helpers;
using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.FileEncryptor
{
    /// <summary>
    /// Implementación del motor AES-256 utilizado para
    /// proteger soportes digitales y archivos del sistema.
    /// </summary>
    public sealed class FileEncryptor : IFileEncryptor
    {
        private readonly List<EncryptionKeyInfo> _keys;

        private readonly EncryptionKeyInfo _activeKey;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileEncryptor()
        {
            _keys = EncryptionKeyLoader.LoadKeys();

            _activeKey =
                _keys.First(
                    x => x.IsActiveForNewEncryptions);
        }

        /// <summary>
        /// Obtiene la versión de clave activa.
        /// </summary>
        public int GetActiveKeyVersion()
        {
            return _activeKey.KeyVersion;
        }

        /// <summary>
        /// Obtiene una clave específica según su versión.
        /// </summary>
        private EncryptionKeyInfo GetKeyByVersion(
            int keyVersion)
        {
            EncryptionKeyInfo keyInfo =
                _keys.FirstOrDefault(
                    x => x.KeyVersion == keyVersion);

            if (keyInfo == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "No existe una clave configurada para la versión {0}.",
                        keyVersion));
            }

            return keyInfo;
        }

        /// <summary>
        /// Encripta texto utilizando la clave activa.
        /// </summary>
        public string EncryptText(
            string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return string.Empty;

            byte[] plainBytes =
                Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _activeKey.Key;
                aes.IV = _activeKey.IV;

                ICryptoTransform encryptor =
                    aes.CreateEncryptor();

                byte[] encryptedBytes =
                    encryptor.TransformFinalBlock(
                        plainBytes,
                        0,
                        plainBytes.Length);

                return Convert.ToBase64String(
                    encryptedBytes);
            }
        }

        /// <summary>
        /// Desencripta texto utilizando la clave activa.
        /// </summary>
        public string DecryptText(
            string encryptedText)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                return string.Empty;

            byte[] encryptedBytes =
                Convert.FromBase64String(
                    encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _activeKey.Key;
                aes.IV = _activeKey.IV;

                ICryptoTransform decryptor =
                    aes.CreateDecryptor();

                byte[] plainBytes =
                    decryptor.TransformFinalBlock(
                        encryptedBytes,
                        0,
                        encryptedBytes.Length);

                return Encoding.UTF8.GetString(
                    plainBytes);
            }
        }

        /// <summary>
        /// Encripta un archivo físico.
        /// </summary>
        public FileEncryptionResult EncryptFile(
            string sourceFile,
            string targetFile)
        {
            byte[] originalBytes =
                File.ReadAllBytes(sourceFile);

            string hash =
                HashHelper.CalculateSha256(
                    originalBytes);

            byte[] encryptedBytes;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _activeKey.Key;
                aes.IV = _activeKey.IV;

                ICryptoTransform encryptor =
                    aes.CreateEncryptor();

                encryptedBytes =
                    encryptor.TransformFinalBlock(
                        originalBytes,
                        0,
                        originalBytes.Length);
            }

            File.WriteAllBytes(
                targetFile,
                encryptedBytes);

            FileInfo fileInfo =
                new FileInfo(targetFile);

            FileEncryptionResult result =
                new FileEncryptionResult();

            result.EncryptedFilePath =
                targetFile;

            result.HashSHA256 =
                hash;

            result.KeyVersion =
                _activeKey.KeyVersion;

            result.FileSizeBytes =
                fileInfo.Length;

            return result;
        }

        /// <summary>
        /// Desencripta un archivo físico.
        /// </summary>
        public void DecryptFile(
            string encryptedFile,
            string targetFile,
            int keyVersion,
            string expectedHash)
        {
            EncryptionKeyInfo keyInfo =
                GetKeyByVersion(keyVersion);

            byte[] encryptedBytes =
                File.ReadAllBytes(
                    encryptedFile);

            byte[] plainBytes;

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyInfo.Key;
                aes.IV = keyInfo.IV;

                ICryptoTransform decryptor =
                    aes.CreateDecryptor();

                plainBytes =
                    decryptor.TransformFinalBlock(
                        encryptedBytes,
                        0,
                        encryptedBytes.Length);
            }

            File.WriteAllBytes(
                targetFile,
                plainBytes);

            string generatedHash =
                HashHelper.CalculateSha256(
                    plainBytes);

            if (!string.Equals(
                    generatedHash,
                    expectedHash,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "El Hash del archivo desencriptado no coincide.");
            }
        }
    }
}