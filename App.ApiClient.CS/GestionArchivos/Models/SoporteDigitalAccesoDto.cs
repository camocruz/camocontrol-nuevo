using System;

namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Registro de auditoría de accesos
    /// a soportes digitales.
    /// </summary>
    public sealed class SoporteDigitalAccesoDto
    {
        /// <summary>
        /// Identificador del acceso.
        /// </summary>
        public long IdAcceso { get; set; }

        /// <summary>
        /// Identificador del soporte.
        /// </summary>
        public long IdSoporte { get; set; }

        /// <summary>
        /// Usuario que realizó el acceso.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Fecha y hora del acceso.
        /// </summary>
        public DateTime FechaHoraAcceso { get; set; }

        /// <summary>
        /// Módulo desde el que se solicitó el acceso.
        /// </summary>
        public string ModuloOrigen { get; set; }

        /// <summary>
        /// Tipo de acceso.
        /// Visualizacion
        /// Descarga
        /// Eliminacion
        /// </summary>
        public string TipoAcceso { get; set; }

        /// <summary>
        /// Indica si el acceso fue autorizado.
        /// </summary>
        public bool Autorizado { get; set; }

        /// <summary>
        /// Mensaje de auditoría.
        /// </summary>
        public string Observaciones { get; set; }

        public SoporteDigitalAccesoDto()
        {
            Usuario = string.Empty;
            ModuloOrigen = string.Empty;
            TipoAcceso = string.Empty;
            Observaciones = string.Empty;
        }
    }
}