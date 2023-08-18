using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            CatalogoSeguimientos = new HashSet<CatalogoSeguimiento>();
            IndiceSeguimientos = new HashSet<IndiceSeguimiento>();
            MedicosEspecialidades = new HashSet<MedicosEspecialidade>();
        }

        public long EspId { get; set; }
        public string EspNombre { get; set; }
        public string EspDescripcion { get; set; }
        public DateTime? EspFechaRegistro { get; set; }
        public short? EspEstado { get; set; }
        public long? EmpId { get; set; }

        public virtual Empresa Emp { get; set; }
        public virtual ICollection<CatalogoSeguimiento> CatalogoSeguimientos { get; set; }
        public virtual ICollection<IndiceSeguimiento> IndiceSeguimientos { get; set; }
        public virtual ICollection<MedicosEspecialidade> MedicosEspecialidades { get; set; }
    }
}
