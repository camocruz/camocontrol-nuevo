using App.ApiClient.CS.GestionArchivos.Models;
using System.Collections.Generic;

namespace App.ApiClient.CS.GestionArchivos.Audit
{
    public interface ISoporteAuditService
    {
        void RegistrarAcceso(
            SoporteDigitalAccesoDto acceso);

        void RegistrarVisualizacion(
            long idSoporte,
            string usuario,
            string moduloOrigen);

        void RegistrarDescarga(
            long idSoporte,
            string usuario,
            string moduloOrigen);

        void RegistrarIntentoFallido(
            long idSoporte,
            string usuario,
            string moduloOrigen,
            string observaciones);

        List<SoporteDigitalAccesoDto>
            ObtenerAccesos();
    }
}