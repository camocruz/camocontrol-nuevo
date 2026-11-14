using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Representa un archivo físico asociado a una entidad.
    /// </summary>
    public sealed class SoporteDigitalDto
    {
        public long IdSoporte { get; set; }

        public string TipoEntidad { get; set; }

        public long IdEntidad { get; set; }

        public string TipoDocumento { get; set; }

        public long CodigoDocumento { get; set; }

        public int Consecutivo { get; set; }

        public string NombreArchivo { get; set; }

        public string ExtensionArchivo { get; set; }

        public string RutaArchivo { get; set; }

        public string HashSHA256 { get; set; }

        public int KeyVersion { get; set; }

        public long TamanoBytes { get; set; }

        public DateTime FechaCarga { get; set; }

        public string UsuarioCarga { get; set; }

        public bool EsEncriptado { get; set; }

        public bool EsCargaEspecial { get; set; }

        public bool EvitarEliminacionAutomatica { get; set; }

        public string Descripcion { get; set; }

        public SoporteDigitalDto()
        {
            TipoEntidad = string.Empty;
            TipoDocumento = string.Empty;
            NombreArchivo = string.Empty;
            ExtensionArchivo = string.Empty;
            RutaArchivo = string.Empty;
            HashSHA256 = string.Empty;
            UsuarioCarga = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
