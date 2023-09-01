using System;
using System.Collections.Generic;


namespace Proyecto.Api.Business.Models
{
    public partial class Token
    {
        public long UsuId { get; set; }
        public string UsuNombre { get; set; }
        public string UsuApellidos { get; set; }
        public string UsuEmail { get; set; }
        public string Access_token { get; set; }
        public DateTime expires { get; set; }
        public long? PerId { get; set; }
        public List<MenuUsuario> Menu { get; set; }
        public List<string> Paths { get; set; }
        public string nombres { get; set; }


    }
}
