using System;

namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Configuración de almacenamiento y procesamiento
    /// para un tipo documental.
    /// </summary>
    public sealed class ConfiguracionSoporteDigitalDto
    {
        /// <summary>
        /// Nombre lógico de la configuración.
        /// Ejemplo:
        /// FACTURAS
        /// ANTICIPOS
        /// INSTRUCTIVOS
        /// </summary>
        public string NombreConfiguracion { get; set; }

        /// <summary>
        /// Directorio raíz donde se almacenarán los documentos.
        /// </summary>
        public string DirectorioBase { get; set; }

        /// <summary>
        /// Indica si utiliza estructura Año/Mes.
        /// </summary>
        public bool UsarCarpetasPorFecha { get; set; }

        /// <summary>
        /// Nombre de carpeta fija cuando no se utiliza
        /// almacenamiento por fecha.
        /// </summary>
        public string CarpetaFija { get; set; }

        /// <summary>
        /// Descripción por defecto.
        /// </summary>
        public string DescripcionPorDefecto { get; set; }

        /// <summary>
        /// Tamaño máximo permitido en KB.
        /// </summary>
        public long TamanoMaximoKb { get; set; }

        /// <summary>
        /// Extensiones permitidas.
        /// Ejemplo:
        /// pdf;jpg;png;zip
        /// </summary>
        public string ExtensionesPermitidas { get; set; }

        /// <summary>
        /// Ancho máximo permitido para imágenes.
        /// </summary>
        public int AnchoMaximoImagen { get; set; }

        /// <summary>
        /// Indica si los archivos deben encriptarse.
        /// </summary>
        public bool EncriptarArchivos { get; set; }

        /// <summary>
        /// Indica si las imágenes deben comprimirse.
        /// </summary>
        public bool ComprimirImagenes { get; set; }

        /// <summary>
        /// Permite almacenar videos.
        /// </summary>
        public bool PermitirVideos { get; set; }

        /// <summary>
        /// Tamaño máximo permitido para videos en KB.
        /// </summary>
        public long TamanoMaximoVideoKb { get; set; }

        /// <summary>
        /// Cantidad de días de vida para videos.
        /// Cero indica conservación indefinida.
        /// </summary>
        public int DiasVidaVideo { get; set; }

        /// <summary>
        /// Permite que usuarios autorizados
        /// realicen cargas especiales.
        /// </summary>
        public bool PermitirCargaEspecial { get; set; }

        public ConfiguracionSoporteDigitalDto()
        {
            NombreConfiguracion = string.Empty;
            DirectorioBase = string.Empty;
            CarpetaFija = string.Empty;
            DescripcionPorDefecto = string.Empty;
            ExtensionesPermitidas = string.Empty;

            TamanoMaximoKb = 10240;

            AnchoMaximoImagen = 1920;

            EncriptarArchivos = true;

            ComprimirImagenes = true;
        }
    }
}
