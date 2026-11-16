using Npgsql;

namespace App.ApiClient.CS.Infrastructure.Database
{
    public abstract class RepositoryBase
    {
        protected NpgsqlConnection ObtenerConexion()
        {
            return DatabaseProvider.ObtenerConexion();
        }

        protected string ObtenerEsquema()
        {
            return DatabaseProvider.ObtenerEsquema();
        }
    }
}