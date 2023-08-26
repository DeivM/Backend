using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Usuario
    {
        public long UsuId { get; set; }
        public string UsuNombres { get; set; }
        public string UsuApellidos { get; set; }
        public string UsuEmail { get; set; }
        public string UsuPassword { get; set; }
        public short? UsuEstado { get; set; }
        public long? PerId { get; set; }
        public string UsuCedula { get; set; }
        public string UsuDireccion { get; set; }
        public string UsuTelefono { get; set; }
        public string UsuSexo { get; set; }
        public DateTime? UsuFechaNacimiento { get; set; }

        public virtual Perfil Per { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }

        public virtual ICollection<IndiceSeguimiento> IndiceSeguimientos { get; set; }
        public virtual ICollection<SeguimientoPaciente> SeguimientoPacientes { get; set; }

        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection<MedicosEspecialidade> MedicosEspecialidades { get; set; }

    }
}
