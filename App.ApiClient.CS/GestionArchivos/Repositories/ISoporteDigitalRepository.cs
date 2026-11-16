using System.Collections.Generic;

using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.Repositories
{
    public interface ISoporteDigitalRepository
    {
        long Insertar(
            SoporteDigitalDto soporte);

        SoporteDigitalDto ObtenerPorId(
            long idSoporte);

        List<SoporteDigitalDto> ObtenerPorEntidad(
            string tipoEntidad,
            long idEntidad);

        void RegistrarAcceso(
            SoporteDigitalAccesoDto acceso);
    }
}