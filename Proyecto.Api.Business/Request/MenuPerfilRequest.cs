using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class MenuPerfilRequest
    {
        public long MepId { get; set; }
        public long? MenId { get; set; }
        public long? PerId { get; set; }
        public short? MepEstado { get; set; }
    }
}
