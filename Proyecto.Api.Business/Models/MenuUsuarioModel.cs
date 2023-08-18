
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public partial class MenuUsuario
    {
        public string path { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public bool extralink { get; set; }
        public string clas { get; set; }

        public List<MenuUsuario> submenu { get; set; }
    }
}
