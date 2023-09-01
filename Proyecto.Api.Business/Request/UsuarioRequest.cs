
using System;

namespace Proyecto.Api.Business.Request
{
    public class UsuarioRequest
    {
        public long UsuId { get; set; }
        public string UsuNombres { get; set; }
        public string UsuApellidos { get; set; }
        public string UsuEmail { get; set; }
        public string UsuPassword { get; set; }
        public short? UsuEstado { get; set; }
        public string UsuCedula { get; set; }
        public string UsuDireccion { get; set; }
        public string UsuTelefono { get; set; }
        public string UsuSexo { get; set; }
        public DateTime? UsuFechaNacimiento { get; set; }
        public string UsuImagen { get; set; }
        public long? PerId { get; set; }
    }
}
