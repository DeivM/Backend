using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class CatalogoSeguimientoRequest
    {

        public long CasId { get; set; }
        public long? EspId { get; set; }
        public string CasNombre { get; set; }
        public short? CasEstado { get; set; }

    }
}
