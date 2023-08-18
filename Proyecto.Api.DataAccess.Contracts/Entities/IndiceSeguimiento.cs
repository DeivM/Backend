using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class IndiceSeguimiento
    {
        public long IseId { get; set; }
        public long? EspId { get; set; }
        public int? IseNumero { get; set; }
        public long? UsuId { get; set; }

        public virtual Especialidade Esp { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}
