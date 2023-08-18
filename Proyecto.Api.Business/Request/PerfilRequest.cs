using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class PerfilRequest
    {
        public long PerId { get; set; }
        public string PerNombre { get; set; }
        public short? PerEstado { get; set; }
        public long EmpId { get; set; }
    }
}
