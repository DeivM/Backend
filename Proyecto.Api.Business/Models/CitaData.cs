
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class CitaData
    {
        public CitaModel Data { get; set; }

        public List<ListModel>  Medicos  { get; set; }
        public List<ListModel> Pacientes { get; set; }
        public List<ListModel> MedicosEspecialidad { get; set; }
        public List<ListModel> Citas { get; set; }
    }
}
