using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class MenuRequest
    {
        public long MenId { get; set; }
        public string MenNombre { get; set; }
        public long? MenMenId { get; set; }
        public string MenTipo { get; set; }
        public string MenIcono { get; set; }
        public string MenUrl { get; set; }
        public short? MenOrden { get; set; }
        public string MenCodigoUnico { get; set; }
        public short? MenEstado { get; set; }
    }
}
