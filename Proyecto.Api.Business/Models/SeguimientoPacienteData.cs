
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class SeguimientoPacienteData
    {
        public SeguimientoPacienteModel Data { get; set; }

        public List<ListModel> Preguntas { get; set; }
        public List<ListModel> Citas { get; set; }
    }
}
