
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class MenuPerfilData
    {
        public MenuPerfilModel Data { get; set; }
        public List<ListModel> Menu { get; set; }
        public List<ListModel> Perfil { get; set; }
    }
}
