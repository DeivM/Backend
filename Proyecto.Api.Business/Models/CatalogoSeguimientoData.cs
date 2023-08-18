
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class CatalogoSeguimientoData
    {
        public CatalogoSeguimientoModel Data { get; set; }

        public List<ListModel> MedicosEspecialidad { get; set; }
    }
}
