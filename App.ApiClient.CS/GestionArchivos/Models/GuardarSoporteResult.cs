namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Resultado del almacenamiento físico de un soporte.
    /// </summary>
    public sealed class GuardarSoporteResult
    {
        public SoporteDigitalDto Soporte { get; set; }

        public bool ArchivoEncriptado { get; set; }

        public string ArchivoFisico { get; set; }

        public GuardarSoporteResult()
        {
            ArchivoFisico = string.Empty;
        }
    }
}