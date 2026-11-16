using System;
using System.Collections.Generic;

using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.Audit
{
    public sealed class SoporteAuditService
        : ISoporteAuditService
    {
        private readonly List<SoporteDigitalAccesoDto> _accesos;

        public SoporteAuditService()
        {
            _accesos =
                new List<SoporteDigitalAccesoDto>();
        }

        public void RegistrarAcceso(
            SoporteDigitalAccesoDto acceso)
        {
            acceso.FechaHoraAcceso =
                DateTime.Now;

            _accesos.Add(acceso);
        }

        public void RegistrarVisualizacion(
            long idSoporte,
            string usuario,
            string moduloOrigen)
        {
            RegistrarAcceso(
                new SoporteDigitalAccesoDto
                {
                    IdSoporte = idSoporte,
                    Usuario = usuario,
                    ModuloOrigen = moduloOrigen,
                    TipoAcceso = "VISUALIZACION",
                    Autorizado = true
                });
        }

        public void RegistrarDescarga(
            long idSoporte,
            string usuario,
            string moduloOrigen)
        {
            RegistrarAcceso(
                new SoporteDigitalAccesoDto
                {
                    IdSoporte = idSoporte,
                    Usuario = usuario,
                    ModuloOrigen = moduloOrigen,
                    TipoAcceso = "DESCARGA",
                    Autorizado = true
                });
        }

        public void RegistrarIntentoFallido(
            long idSoporte,
            string usuario,
            string moduloOrigen,
            string observaciones)
        {
            RegistrarAcceso(
                new SoporteDigitalAccesoDto
                {
                    IdSoporte = idSoporte,
                    Usuario = usuario,
                    ModuloOrigen = moduloOrigen,
                    TipoAcceso = "INTENTO_FALLIDO",
                    Autorizado = false,
                    Observaciones = observaciones
                });
        }
        public List<SoporteDigitalAccesoDto> ObtenerAccesos()
        {
            return new List<SoporteDigitalAccesoDto>(
                _accesos);
        }


    }
}