using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Menu
    {
   
        public long MenId { get; set; }
        public string MenNombre { get; set; }
        public long? MenMenId { get; set; }
        public string MenTipo { get; set; }
        public string MenIcono { get; set; }
        public string MenUrl { get; set; }
        public short? MenOrden { get; set; }
        public string MenCodigoUnico { get; set; }
        public short? MenEstado { get; set; }

        public virtual Menu MenMen { get; set; }
        public virtual ICollection<Menu> InverseMenMen { get; set; }
        public virtual ICollection<MenuPerfil> MenuPerfil { get; set; }
    }
}
