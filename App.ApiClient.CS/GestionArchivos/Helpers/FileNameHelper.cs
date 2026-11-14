using System;

namespace App.ApiClient.CS.GestionArchivos.Helpers
{
    /// <summary>
    /// Utilidades para generación de nombres
    /// de archivos del sistema documental.
    /// </summary>
    public static class FileNameHelper
    {
        /// <summary>
        /// Genera el nombre base de un documento.
        /// </summary>
        public static string GenerateDocumentName(
            string documentType,
            long documentCode,
            int consecutive)
        {
            if (string.IsNullOrWhiteSpace(documentType))
            {
                throw new ArgumentException(
                    "El tipo de documento es obligatorio.");
            }

            return string.Format(
                "{0}-{1}-{2}",
                documentType.ToUpper(),
                documentCode.ToString("D8"),
                consecutive.ToString("D3"));
        }
    }
}
