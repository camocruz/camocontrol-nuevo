using System;
using System.IO;

namespace App.ApiClient.CS.GestionArchivos.Cleanup
{
    public sealed class TemporaryFileCleanupService
    {
        private readonly string _tempFolder;

        public TemporaryFileCleanupService()
        {
            _tempFolder =
                Path.Combine(
                    Path.GetTempPath(),
                    "CamoControl");

            Directory.CreateDirectory(
                _tempFolder);
        }

        public int LimpiarTemporales(
            TimeSpan antiguedadMaxima)
        {
            int eliminados = 0;

            foreach (string archivo in
                     Directory.GetFiles(_tempFolder))
            {
                try
                {
                    FileInfo fileInfo =
                        new FileInfo(archivo);

                    TimeSpan edad =
                        DateTime.Now -
                        fileInfo.LastWriteTime;

                    if (edad >= antiguedadMaxima)
                    {
                        fileInfo.Delete();

                        eliminados++;
                    }
                }
                catch
                {
                    // Archivo bloqueado o acceso denegado.
                }
            }

            return eliminados;
        }
        public int LimpiarTodo()
        {
            int eliminados = 0;

            foreach (string archivo in
                     Directory.GetFiles(_tempFolder))
            {
                try
                {
                    File.Delete(archivo);

                    eliminados++;
                }
                catch
                {
                }
            }

            return eliminados;
        }


    }
}