using App.ApiClient.CS.GestionArchivos.Models;
using App.ApiClient.CS.Infrastructure.Database;
using Npgsql;
using System;
using System.Collections.Generic;

namespace App.ApiClient.CS.GestionArchivos.Repositories
{
    public sealed class SoporteDigitalRepository
        : RepositoryBase,
          ISoporteDigitalRepository
    {
        public long Insertar(
            SoporteDigitalDto soporte)
        {
            using (NpgsqlConnection conn =
                ObtenerConexion())
            {
                string esquema =
                    ObtenerEsquema();

                string sql =
        $@"
INSERT INTO {esquema}.tb0510_soportes_digitales
(
    f0510_tipo_entidad,
    f0510_id_entidad,
    f0510_tipo_documento,
    f0510_codigo_documento,
    f0510_consecutivo,
    f0510_nombre_archivo,
    f0510_extension_archivo,
    f0510_ruta_archivo,
    f0510_hash_sha256,
    f0510_key_version,
    f0510_tamano_bytes,
    f0510_fecha_carga,
    f0510_usuario_carga,
    f0510_es_encriptado,
    f0510_es_carga_especial,
    f0510_evitar_eliminacion_auto,
    f0510_descripcion
)
VALUES
(
    @tipo_entidad,
    @id_entidad,
    @tipo_documento,
    @codigo_documento,
    @consecutivo,
    @nombre_archivo,
    @extension_archivo,
    @ruta_archivo,
    @hash_sha256,
    @key_version,
    @tamano_bytes,
    @fecha_carga,
    @usuario_carga,
    @es_encriptado,
    @es_carga_especial,
    @evitar_eliminacion_auto,
    @descripcion
)
RETURNING f0510_id_soporte;
";
                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(
                        sql,
                        conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@tipo_entidad",
                        soporte.TipoEntidad);

                    cmd.Parameters.AddWithValue(
                        "@id_entidad",
                        soporte.IdEntidad);

                    cmd.Parameters.AddWithValue(
                        "@tipo_documento",
                        soporte.TipoDocumento);

                    cmd.Parameters.AddWithValue(
                        "@codigo_documento",
                        soporte.CodigoDocumento);

                    cmd.Parameters.AddWithValue(
                        "@consecutivo",
                        soporte.Consecutivo);

                    cmd.Parameters.AddWithValue(
                        "@nombre_archivo",
                        soporte.NombreArchivo);

                    cmd.Parameters.AddWithValue(
                        "@extension_archivo",
                        soporte.ExtensionArchivo);

                    cmd.Parameters.AddWithValue(
                        "@ruta_archivo",
                        soporte.RutaArchivo);

                    cmd.Parameters.AddWithValue(
                        "@hash_sha256",
                        soporte.HashSHA256);

                    cmd.Parameters.AddWithValue(
                        "@key_version",
                        soporte.KeyVersion);

                    cmd.Parameters.AddWithValue(
                        "@tamano_bytes",
                        soporte.TamanoBytes);

                    cmd.Parameters.AddWithValue(
                        "@fecha_carga",
                        soporte.FechaCarga);

                    cmd.Parameters.AddWithValue(
                        "@usuario_carga",
                        soporte.UsuarioCarga);

                    cmd.Parameters.AddWithValue(
                        "@es_encriptado",
                        soporte.EsEncriptado);

                    cmd.Parameters.AddWithValue(
                        "@es_carga_especial",
                        soporte.EsCargaEspecial);

                    cmd.Parameters.AddWithValue(
                        "@evitar_eliminacion_auto",
                        soporte.EvitarEliminacionAutomatica);

                    cmd.Parameters.AddWithValue(
                        "@descripcion",
                        soporte.Descripcion);

                    return Convert.ToInt64(
                        cmd.ExecuteScalar());
                }
            }
        }
        public SoporteDigitalDto ObtenerPorId(
    long idSoporte)
        {
            throw new NotImplementedException();
        }

        public List<SoporteDigitalDto> ObtenerPorEntidad(
            string tipoEntidad,
            long idEntidad)
        {
            throw new NotImplementedException();
        }

        public void RegistrarAcceso(
            SoporteDigitalAccesoDto acceso)
        {
            throw new NotImplementedException();
        }
    }
    }