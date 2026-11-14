using System;
using System.IO;

namespace App.ApiClient.CS.GestionArchivos.Helpers
{
    /// <summary>
    /// Utilidades para generación y administración
    /// de rutas físicas del sistema documental.
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Obtiene la carpeta física donde debe almacenarse
        /// un archivo según la fecha indicada.
        /// </summary>
        public static string BuildStoragePath(
            string baseDirectory,
            DateTime fileDate)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory))
            {
                throw new ArgumentException(
                    "El directorio base es obligatorio.");
            }

            string yearFolder =
                fileDate.Year.ToString("0000");

            string monthFolder =
                fileDate.Month.ToString("00");

            string finalPath =
                Path.Combine(
                    baseDirectory,
                    yearFolder,
                    monthFolder);

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            return finalPath;
        }

        /// <summary>
        /// Construye la ruta completa de un archivo
        /// incluyendo nombre y extensión.
        /// </summary>
        public static string BuildFilePath(
            string baseDirectory,
            DateTime fileDate,
            string fileName)
        {
            string storagePath =
                BuildStoragePath(
                    baseDirectory,
                    fileDate);

            return Path.Combine(
                storagePath,
                fileName);
        }
        /// <summary>
        /// Obtiene una carpeta fija de almacenamiento.
        /// Ejemplo:
        /// C:\Documentos\INSTRUCTIVOS
        /// </summary>
        public static string BuildFixedStoragePath(
            string baseDirectory,
            string folderName)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory))
            {
                throw new ArgumentException(
                    "El directorio base es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(folderName))
            {
                throw new ArgumentException(
                    "El nombre de carpeta es obligatorio.");
            }

            string finalPath =
                Path.Combine(
                    baseDirectory,
                    folderName);

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            return finalPath;
        }

        /// <summary>
        /// Construye la ruta completa de un archivo
        /// dentro de una carpeta fija.
        /// </summary>
        public static string BuildFixedFilePath(
            string baseDirectory,
            string folderName,
            string fileName)
        {
            string storagePath =
                BuildFixedStoragePath(
                    baseDirectory,
                    folderName);

            return Path.Combine(
                storagePath,
                fileName);
        }



    }
}
