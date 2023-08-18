
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class MenuData
    {
        public MenuModel Data { get; set; }

        public List<ListModel> MenuPadre { get; set; }
    }
}
