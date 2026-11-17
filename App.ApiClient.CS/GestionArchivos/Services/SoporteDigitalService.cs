using App.ApiClient.CS.GestionArchivos.FileEncryptor;
using App.ApiClient.CS.GestionArchivos.Helpers;
using App.ApiClient.CS.GestionArchivos.Models;
using App.ApiClient.CS.GestionArchivos.Audit;
using App.ApiClient.CS.GestionArchivos.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace App.ApiClient.CS.GestionArchivos.Services
{
    public sealed class SoporteDigitalService
    {
        private readonly IFileEncryptor _fileEncryptor;
        private readonly ISoporteAuditService _auditService;
        private readonly ISoporteDigitalRepository _repository;
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

            string rutaEncriptada =
                soporte.RutaArchivo + ".enc";

            FileEncryptionResult encryptionResult =
                _fileEncryptor.EncryptFile(
                    archivoOrigen,
                    rutaEncriptada);

            soporte.RutaArchivo =
                encryptionResult.EncryptedFilePath;

            soporte.HashSHA256 =
                encryptionResult.HashSHA256;

            soporte.KeyVersion =
                encryptionResult.KeyVersion;

            soporte.EsEncriptado =
                true;

            long idSoporte =
                _repository.Insertar(
                    soporte);

            soporte.IdSoporte =
                idSoporte;

            GuardarSoporteResult result =
                new GuardarSoporteResult();

            result.IdSoporte =
                idSoporte;

            result.Soporte =
                soporte;

            result.ArchivoFisico =
                soporte.RutaArchivo;

            result.ArchivoEncriptado =
                true;

            result.HashSHA256 =
                soporte.HashSHA256;

            result.KeyVersion =
                soporte.KeyVersion;

            return result;
        }
        public RecuperacionSoporteResult RecuperarSoporte(
            SoporteDigitalDto soporte,
            string usuario,
            string moduloOrigen)
        {
            if (soporte == null)
            {
                throw new ArgumentNullException(
                    nameof(soporte));
            }

            _auditService.RegistrarVisualizacion(
                soporte.IdSoporte,
                usuario,
                moduloOrigen);

            string extension =
                soporte.ExtensionArchivo;

            //string archivoTemporal =
            //    Path.Combine(
            //        Path.GetTempPath(),
            //        Guid.NewGuid().ToString() +
            //        "." +
            //        extension);
            string tempFolder =
                Path.Combine(
                Path.GetTempPath(),
                "CamoControl");

            Directory.CreateDirectory(
                tempFolder);

            string archivoTemporal =
                Path.Combine(
                    tempFolder,
                    Guid.NewGuid().ToString() +
                    "." +
                    extension);

            _fileEncryptor.DecryptFile(
                soporte.RutaArchivo,
                archivoTemporal,
                soporte.KeyVersion,
                soporte.HashSHA256);

            RecuperacionSoporteResult result =
                new RecuperacionSoporteResult();

            result.ArchivoTemporal =
                archivoTemporal;

            result.RecuperadoCorrectamente =
                true;

            result.Mensaje =
                "Archivo recuperado correctamente.";

            return result;
        }
        public SoporteDigitalService()
        {
            _fileEncryptor =
                new AesFileEncryptor();

            _auditService =
                new SoporteAuditService();

            _repository =
                new SoporteDigitalRepository();
        }
        private string ObtenerRutaFisicaFinal(
            SoporteDigitalDto soporte,
            bool encriptado)
        {
            if (!encriptado)
            {
                return soporte.RutaArchivo;
            }

            return soporte.RutaArchivo + ".enc";
        }



    }
}