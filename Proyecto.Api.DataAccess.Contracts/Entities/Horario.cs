using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Horario
    {
        public long HorId { get; set; }
        public long? MedId { get; set; }
        public DateTime? HorFechaAtencion { get; set; }
        public TimeSpan? HorInicioAtencion { get; set; }
        public TimeSpan? HorFinAtencion { get; set; }
        public short? HorEstado { get; set; }

        public virtual Usuario Usu { get; set; }
    }
}
