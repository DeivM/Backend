using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.DataAccess.Contracts.Entities
{
    public partial class Empresa
    {


        public long EmpId { get; set; }
        public string EmpNombre { get; set; }
        public string EmpIdentificacion { get; set; }
        public string EmpCorreo { get; set; }
        public string EmpTelefono { get; set; }
        public string EmpDireccion { get; set; }

        public virtual ICollection<Perfil> Perfils { get; set; }
        public virtual ICollection<Especialidade> Especialidades { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
