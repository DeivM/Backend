using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Medico
    {
        public Medico()
        {
            Horarios = new HashSet<Horario>();
            MedicosEspecialidades = new HashSet<MedicosEspecialidade>();
        }

        public long MedId { get; set; }
        public string MedNombres { get; set; }
        public string MedApellidos { get; set; }
        public string MedCedula { get; set; }
        public string MedDireccion { get; set; }
        public string MedCorreo { get; set; }
        public string MedTelefono { get; set; }
        public string MedSexo { get; set; }
        public string MedNumCsp { get; set; }
        public short? MedEstado { get; set; }
        public long? EmpId { get; set; }

        public virtual Empresa Emp { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection<MedicosEspecialidade> MedicosEspecialidades { get; set; }
    }
}
