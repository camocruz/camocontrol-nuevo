using System;
using System.Collections.Generic;
using Npgsql;

using App.ApiClient.CS.GestionArchivos.Models;
using App.ApiClient.CS.Infrastructure.Database;

namespace App.ApiClient.CS.GestionArchivos.Repositories
{
    public sealed class SoporteDigitalRepository
        : RepositoryBase,
          ISoporteDigitalRepository
    {
        #region Mappers

        private SoporteDigitalDto MapearSoporte(
            NpgsqlDataReader reader)
        {
            SoporteDigitalDto soporte =
                new SoporteDigitalDto();

            soporte.IdSoporte =
                Convert.ToInt64(
                    reader["f0510_id_soporte"]);

            soporte.TipoEntidad =
                reader["f0510_tipo_entidad"].ToString();

            soporte.IdEntidad =
                Convert.ToInt64(
                    reader["f0510_id_entidad"]);

            soporte.TipoDocumento =
                reader["f0510_tipo_documento"].ToString();

            soporte.CodigoDocumento =
                Convert.ToInt64(
                    reader["f0510_codigo_documento"]);

            soporte.Consecutivo =
                Convert.ToInt32(
                    reader["f0510_consecutivo"]);

            soporte.NombreArchivo =
                reader["f0510_nombre_archivo"].ToString();

            soporte.ExtensionArchivo =
                reader["f0510_extension_archivo"].ToString();

            soporte.RutaArchivo =
                reader["f0510_ruta_archivo"].ToString();

            soporte.HashSHA256 =
                reader["f0510_hash_sha256"].ToString();

            soporte.KeyVersion =
                reader["f0510_key_version"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(
                        reader["f0510_key_version"]);

            soporte.TamanoBytes =
                reader["f0510_tamano_bytes"] == DBNull.Value
                    ? 0
                    : Convert.ToInt64(
                        reader["f0510_tamano_bytes"]);

            soporte.FechaCarga =
                Convert.ToDateTime(
                    reader["f0510_fecha_carga"]);

            soporte.UsuarioCarga =
                reader["f0510_usuario_carga"].ToString();

            soporte.EsEncriptado =
                Convert.ToBoolean(
                    reader["f0510_es_encriptado"]);

            soporte.EsCargaEspecial =
                Convert.ToBoolean(
                    reader["f0510_es_carga_especial"]);

            soporte.EvitarEliminacionAutomatica =
                Convert.ToBoolean(
                    reader["f0510_evitar_eliminacion_auto"]);

            soporte.Descripcion =
                reader["f0510_descripcion"].ToString();

            return soporte;
        }

        #endregion

        #region CRUD

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
            using (NpgsqlConnection conn =
                ObtenerConexion())
            {
                string esquema =
                    ObtenerEsquema();

                string sql =
$@"
SELECT *
FROM {esquema}.tb0510_soportes_digitales
WHERE f0510_id_soporte = @id_soporte;
";

                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(
                        sql,
                        conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_soporte",
                        idSoporte);

                    using (NpgsqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearSoporte(
                                reader);
                        }
                    }
                }
            }

            return null;
        }

        public List<SoporteDigitalDto> ObtenerPorEntidad(
            string tipoEntidad,
            long idEntidad)
        {
            List<SoporteDigitalDto> lista =
                new List<SoporteDigitalDto>();

            using (NpgsqlConnection conn =
                ObtenerConexion())
            {
                string esquema =
                    ObtenerEsquema();

                string sql =
$@"
SELECT *
FROM {esquema}.tb0510_soportes_digitales
WHERE f0510_tipo_entidad = @tipo_entidad
AND f0510_id_entidad = @id_entidad
ORDER BY f0510_fecha_carga DESC;
";

                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(
                        sql,
                        conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@tipo_entidad",
                        tipoEntidad);

                    cmd.Parameters.AddWithValue(
                        "@id_entidad",
                        idEntidad);

                    using (NpgsqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(
                                MapearSoporte(
                                    reader));
                        }
                    }
                }
            }

            return lista;
        }

        public void RegistrarAcceso(
            SoporteDigitalAccesoDto acceso)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}