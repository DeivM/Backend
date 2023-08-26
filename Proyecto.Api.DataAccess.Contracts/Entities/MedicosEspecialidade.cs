using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class MedicosEspecialidade
    {
        public long MesId { get; set; }
        public long? EspId { get; set; }
        public long? MedId { get; set; }
        public short? MesEstado { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
        public virtual Especialidade Esp { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}
