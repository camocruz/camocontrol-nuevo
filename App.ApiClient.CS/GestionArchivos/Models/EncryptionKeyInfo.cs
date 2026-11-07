namespace App.ApiClient.CS.GestionArchivos.Models
{
    /// <summary>
    /// Representa una clave de encriptación disponible en el sistema.
    /// Permite mantener varias versiones de claves para soportar
    /// la rotación de claves sin perder acceso a archivos históricos.
    /// </summary>
    public sealed class EncryptionKeyInfo
    {
        /// <summary>
        /// Versión única de la clave.
        /// </summary>
        public int KeyVersion { get; set; }

        /// <summary>
        /// Clave AES-256.
        /// </summary>
        public byte[] Key { get; set; }

        /// <summary>
        /// Vector de inicialización.
        /// </summary>
        public byte[] IV { get; set; }

        /// <summary>
        /// Indica si esta clave debe utilizarse para nuevas encriptaciones.
        /// </summary>
        public bool IsActiveForNewEncryptions { get; set; }

        public EncryptionKeyInfo()
        {
            Key = new byte[0];
            IV = new byte[0];
        }
    }
}