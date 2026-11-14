using System;
using System.IO;

using App.ApiClient.CS.GestionArchivos.Helpers;
using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.Services
{
    public sealed class SoporteDigitalService
    {
        public PreparacionArchivoResult PrepararArchivo(
            ConfiguracionSoporteDigitalDto configuracion,
            string tipoDocumento,
            long codigoDocumento,
            int consecutivo,
            string extension)
        {
            string nombreArchivo =
                string.Format(
                    "{0}.{1}",
                    FileNameHelper.GenerateDocumentName(
                        tipoDocumento,
                        codigoDocumento,
                        consecutivo),
                    extension.TrimStart('.'));

            string rutaCompleta;

            if (configuracion.UsarCarpetasPorFecha)
            {
                rutaCompleta =
                    PathHelper.BuildFilePath(
                        configuracion.DirectorioBase,
                        DateTime.Now,
                        nombreArchivo);
            }
            else
            {
                rutaCompleta =
                    PathHelper.BuildFixedFilePath(
                        configuracion.DirectorioBase,
                        configuracion.CarpetaFija,
                        nombreArchivo);
            }

            PreparacionArchivoResult result =
                new PreparacionArchivoResult();

            result.NombreArchivo =
                nombreArchivo;

            result.RutaCompleta =
                rutaCompleta;

            return result;
        }

        public SoporteDigitalDto PrepararSoporte(
            string archivoOrigen,
            ConfiguracionSoporteDigitalDto configuracion,
            string tipoEntidad,
            long idEntidad,
            string tipoDocumento,
            long codigoDocumento,
            int consecutivo,
            string usuario)
        {
            var validacion =
                FileValidationHelper.ValidateFile(
                    archivoOrigen,
                    configuracion);

            if (!validacion.EsValido)
            {
                throw new InvalidOperationException(
                    validacion.Mensaje);
            }

            FileInfo fileInfo =
                new FileInfo(archivoOrigen);

            string extension =
                fileInfo.Extension
                    .Replace(".", "");

            PreparacionArchivoResult archivoPreparado =
                PrepararArchivo(
                    configuracion,
                    tipoDocumento,
                    codigoDocumento,
                    consecutivo,
                    extension);

            SoporteDigitalDto soporte =
                new SoporteDigitalDto();

            soporte.TipoEntidad =
                tipoEntidad;

            soporte.IdEntidad =
                idEntidad;

            soporte.TipoDocumento =
                tipoDocumento;

            soporte.CodigoDocumento =
                codigoDocumento;

            soporte.Consecutivo =
                consecutivo;

            soporte.NombreArchivo =
                archivoPreparado.NombreArchivo;

            soporte.ExtensionArchivo =
                extension;

            soporte.RutaArchivo =
                archivoPreparado.RutaCompleta;

            soporte.TamanoBytes =
                fileInfo.Length;

            soporte.FechaCarga =
                DateTime.Now;

            soporte.UsuarioCarga =
                usuario;

            soporte.EsEncriptado =
                configuracion.EncriptarArchivos;

            soporte.Descripcion =
                configuracion.DescripcionPorDefecto;

            return soporte;
        }
        public GuardarSoporteResult GuardarSoporte(
            string archivoOrigen,
            ConfiguracionSoporteDigitalDto configuracion,
            string tipoEntidad,
            long idEntidad,
            string tipoDocumento,
            long codigoDocumento,
            int consecutivo,
            string usuario)
        {
            SoporteDigitalDto soporte =
                PrepararSoporte(
                    archivoOrigen,
                    configuracion,
                    tipoEntidad,
                    idEntidad,
                    tipoDocumento,
                    codigoDocumento,
                    consecutivo,
                    usuario);

            File.Copy(
                archivoOrigen,
                soporte.RutaArchivo,
                true);
            if (!File.Exists(soporte.RutaArchivo))
            {
                throw new Exception(
                    "El archivo no fue copiado.");
            }

            GuardarSoporteResult result =
                new GuardarSoporteResult();

            result.Soporte =
                soporte;

            result.ArchivoFisico =
                soporte.RutaArchivo;

            result.ArchivoEncriptado =
                false;

            return result;
        }


    }
}