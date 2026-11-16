using System.Configuration;
using Npgsql;
namespace App.ApiClient.CS.Infrastructure.Database
{
    public static class DatabaseProvider
    {
        public static NpgsqlConnection ObtenerConexion()
        {
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["cs_camocontrol"]
                    .ConnectionString;

            connectionString =
                connectionString.Replace(
                    "usuario",
                    "camo");

            connectionString =
                connectionString.Replace(
                    "clave",
                    "camo001");

            NpgsqlConnection conn =
                new NpgsqlConnection(
                    connectionString);

            conn.Open();

            return conn;
        }

        public static string ObtenerEsquema()
        {
            return ConfigurationManager
                .ConnectionStrings["esquema_camocontrol"]
                .ConnectionString;
        }
    }
}