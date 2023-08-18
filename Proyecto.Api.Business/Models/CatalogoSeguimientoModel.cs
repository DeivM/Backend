using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Models
{
    public partial class CatalogoSeguimientoModel
    {

        public long CasId { get; set; }
        public long? EspId { get; set; }
        public string CasNombre { get; set; }
        public short? CasEstado { get; set; }
        public string EspNombre { get; set; }

    }
}
