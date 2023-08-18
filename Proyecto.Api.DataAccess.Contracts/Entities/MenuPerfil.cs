using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class MenuPerfil
    {
        public long MepId { get; set; }
        public long? MenId { get; set; }
        public long? PerId { get; set; }
        public short? MepEstado { get; set; }


        public virtual Menu Men { get; set; }
        public virtual Perfil Per { get; set; }
    }
}
