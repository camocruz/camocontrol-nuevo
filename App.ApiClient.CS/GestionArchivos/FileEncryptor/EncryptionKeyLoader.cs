using System;
using System.Collections.Generic;
using System.Configuration;

using App.ApiClient.CS.GestionArchivos.Helpers;
using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.FileEncryptor
{
    /// <summary>
    /// Carga las claves de encriptación configuradas en App.config.
    /// </summary>
    public static class EncryptionKeyLoader
    {
        /// <summary>
        /// Obtiene todas las claves configuradas.
        /// </summary>
        public static List<EncryptionKeyInfo> LoadKeys()
        {
            List<EncryptionKeyInfo> keys =
                new List<EncryptionKeyInfo>();

            int activeVersion =
                Convert.ToInt32(
                    ConfigurationManager.AppSettings[
                        "AES_ACTIVE_VERSION"]);

            int version = 1;

            while (true)
            {
                string keyName =
                    string.Format("AES_KEY_{0}", version);

                string ivName =
                    string.Format("AES_IV_{0}", version);

                string keyValue =
                    ConfigurationManager.AppSettings[keyName];

                string ivValue =
                    ConfigurationManager.AppSettings[ivName];

                if (string.IsNullOrWhiteSpace(keyValue))
                    break;

                if (string.IsNullOrWhiteSpace(ivValue))
                    break;

                EncryptionKeyInfo keyInfo =
                    new EncryptionKeyInfo();

                keyInfo.KeyVersion = version;
                keyInfo.Key = SecurityHelper.FromBase64(keyValue);
                keyInfo.IV = SecurityHelper.FromBase64(ivValue);
                keyInfo.IsActiveForNewEncryptions =
                    version == activeVersion;

                keys.Add(keyInfo);

                version++;
            }

            return keys;
        }
    }
}