using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Models
{
    public partial class PerfilModel
    {
        public long PerId { get; set; }
        public string PerNombre { get; set; }
        public short? PerEstado { get; set; }
        public long? EmpId { get; set; }
    }
}
