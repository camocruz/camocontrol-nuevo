using System;
using System.Security.Cryptography;

namespace App.ApiClient.CS.GestionArchivos.Helpers
{
    /// <summary>
    /// Funciones auxiliares de seguridad.
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// Genera una clave AES-256.
        /// </summary>
        public static byte[] GenerateAes256Key()
        {
            byte[] key = new byte[32];

            using (RNGCryptoServiceProvider rng =
                   new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }

            return key;
        }

        /// <summary>
        /// Genera un vector de inicialización AES.
        /// </summary>
        public static byte[] GenerateInitializationVector()
        {
            byte[] iv = new byte[16];

            using (RNGCryptoServiceProvider rng =
                   new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }

            return iv;
        }

        /// <summary>
        /// Convierte un arreglo de bytes a Base64.
        /// </summary>
        public static string ToBase64(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Convierte Base64 a arreglo de bytes.
        /// </summary>
        public static byte[] FromBase64(string value)
        {
            return Convert.FromBase64String(value);
        }
    }
}