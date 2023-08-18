using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Perfil
    {
        public long PerId { get; set; }
        public string PerNombre { get; set; }
        public short? PerEstado { get; set; }
        public long EmpId { get; set; }

        public virtual Empresa Emp { get; set; }
        public virtual ICollection<MenuPerfil> MenuPerfils { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
