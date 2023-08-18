using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class MedicosEspecialidadeRequest
    {
        public long MesId { get; set; }
        public long? EspId { get; set; }
        public long? MedId { get; set; }
        public short? MesEstado { get; set; }

    }
}
