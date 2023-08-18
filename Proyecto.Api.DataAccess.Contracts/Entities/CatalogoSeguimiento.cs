using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class CatalogoSeguimiento
    {
        public CatalogoSeguimiento()
        {
            SeguimientoPacientes = new HashSet<SeguimientoPaciente>();
        }

        public long CasId { get; set; }
        public long? EspId { get; set; }
        public string CasNombre { get; set; }
        public short? CasEstado { get; set; }

        public virtual Especialidade Esp { get; set; }
        public virtual ICollection<SeguimientoPaciente> SeguimientoPacientes { get; set; }
    }
}
