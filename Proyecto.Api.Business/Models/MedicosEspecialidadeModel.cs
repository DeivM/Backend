using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Models
{
    public partial class MedicosEspecialidadeModel
    {
        public long MesId { get; set; }
        public long? EspId { get; set; }
        public long? MedId { get; set; }
        public short? MesEstado { get; set; }
        public string MedNombres { get; set; }
        public string EspNombre { get; set; }

    }
}
