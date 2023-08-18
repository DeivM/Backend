using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class SeguimientoPaciente
    {
        public long SepId { get; set; }
        public long? CasId { get; set; }
        public string SepObservacion { get; set; }
        public bool SepFinalizar { get; set; }
        public long? UsuId { get; set; }
        public long CitId { get; set; }


        public virtual CatalogoSeguimiento Cas { get; set; }
        public virtual Usuario Usu { get; set; }
        public virtual Cita Cit { get; set; }
    }
}
