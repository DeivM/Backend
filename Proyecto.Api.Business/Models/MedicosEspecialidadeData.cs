
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class MedicosEspecialidadeData
    {
        public MedicosEspecialidadeModel Data { get; set; }

        public List<ListModel> Medicos { get; set; }

        public List<ListModel> MedicosEspecialidad { get; set; }
    }
}
