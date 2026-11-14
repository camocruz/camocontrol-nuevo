using System;
using System.IO;
using System.Linq;

using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.Helpers
{
    /// <summary>
    /// Validaciones de archivos para el módulo documental.
    /// </summary>
    public static class FileValidationHelper
    {
        public static ValidacionArchivoResult ValidateFile(
            string filePath,
            ConfiguracionSoporteDigitalDto configuracion)
        {
            ValidacionArchivoResult result =
                new ValidacionArchivoResult();

            if (!File.Exists(filePath))
            {
                result.EsValido = false;
                result.Mensaje =
                    "El archivo no existe.";

                return result;
            }

            FileInfo fileInfo =
                new FileInfo(filePath);

            long fileSizeKb =
                fileInfo.Length / 1024;

            if (configuracion.TamanoMaximoKb > 0 &&
                fileSizeKb > configuracion.TamanoMaximoKb)
            {
                result.EsValido = false;

                result.Mensaje =
                    string.Format(
                        "El archivo excede el tamaño máximo permitido ({0} KB).",
                        configuracion.TamanoMaximoKb);

                return result;
            }

            string extension =
            fileInfo.Extension
            .Replace(".", "")
            .ToLower();

            bool allowed =
                ExtensionHelper.IsAllowed(
                    extension,
                    configuracion.ExtensionesPermitidas);

            if (!allowed)
            {
                result.EsValido = false;

                result.Mensaje =
                    string.Format(
                        "La extensión '{0}' no está permitida.",
                        extension);

                return result;
            }

            result.EsValido = true;

            return result;
        }
    }
}