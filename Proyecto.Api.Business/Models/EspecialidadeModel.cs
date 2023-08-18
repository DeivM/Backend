using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Models
{
    public partial class EspecialidadeModel
    {

        public long EspId { get; set; }
        public string EspNombre { get; set; }
        public string EspDescripcion { get; set; }
        public DateTime? EspFechaRegistro { get; set; }
        public short? EspEstado { get; set; }
        public long? EmpId { get; set; }

    }
}
