using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Models
{
    public partial class IndiceSeguimientoModel
    {
        public long IseId { get; set; }
        public long? EspId { get; set; }
        public int? IseNumero { get; set; }
        public long? UsuId { get; set; }

    }
}
