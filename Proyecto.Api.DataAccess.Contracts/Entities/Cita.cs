using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Cita
    {
        public long CitId { get; set; }
        public long? MesId { get; set; }
        public DateTime? CitFechaAtencion { get; set; }
        public TimeSpan? CitInicioAtencion { get; set; }
        public TimeSpan? CitFinAtencion { get; set; }
        public string CitEstadoPaciente { get; set; }
        public string CitObservaciones { get; set; }
        public short? CitEstado { get; set; }
        public long? UsuId { get; set; }

        public virtual MedicosEspecialidade Mes { get; set; }
        public virtual Usuario Usu { get; set; }
        public virtual ICollection<SeguimientoPaciente> SeguimientoPacientes { get; set; }
    }
}
