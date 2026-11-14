using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace App.ApiClient.CS.GestionArchivos.Helpers
{
    /// <summary>
    /// Utilidades para cálculo de hashes.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Calcula el SHA256 de un arreglo de bytes.
        /// </summary>
        public static string CalculateSha256(byte[] data)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(data);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
        /// <summary>
        /// Calcula el SHA256 de un archivo.
        /// </summary>
        public static string CalculateSha256FromFile(
            string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);

            return CalculateSha256(data);
        }
    }


}