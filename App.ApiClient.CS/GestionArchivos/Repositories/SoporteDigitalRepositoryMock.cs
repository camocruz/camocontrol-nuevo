using System.Collections.Generic;
using System.Linq;

using App.ApiClient.CS.GestionArchivos.Models;

namespace App.ApiClient.CS.GestionArchivos.Repositories
{
    public sealed class SoporteDigitalRepositoryMock
        : ISoporteDigitalRepository
    {
        private readonly List<SoporteDigitalDto> _soportes;

        private readonly List<SoporteDigitalAccesoDto> _accesos;

        private long _idActual;

        public SoporteDigitalRepositoryMock()
        {
            _soportes =
                new List<SoporteDigitalDto>();

            _accesos =
                new List<SoporteDigitalAccesoDto>();

            _idActual = 1;
        }

        public long Insertar(
            SoporteDigitalDto soporte)
        {
            soporte.IdSoporte = _idActual++;

            _soportes.Add(soporte);

            return soporte.IdSoporte;
        }

        public void Actualizar(
            SoporteDigitalDto soporte)
        {
            // Temporalmente vacío
        }

        public SoporteDigitalDto ObtenerPorId(
            long idSoporte)
        {
            return _soportes
                .FirstOrDefault(
                    x => x.IdSoporte == idSoporte);
        }

        public List<SoporteDigitalDto> ObtenerPorEntidad(
            string tipoEntidad,
            long idEntidad)
        {
            return _soportes
                .Where(x =>
                    x.TipoEntidad == tipoEntidad &&
                    x.IdEntidad == idEntidad)
                .ToList();
        }

        public void RegistrarAcceso(
            SoporteDigitalAccesoDto acceso)
        {
            _accesos.Add(acceso);
        }

        public List<SoporteDigitalAccesoDto>
            ObtenerAccesos(
                long idSoporte)
        {
            return _accesos
                .Where(x =>
                    x.IdSoporte == idSoporte)
                .ToList();
        }
    }
}
