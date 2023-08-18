
using Proyecto.Api.Business.Models.List;
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public  class UsuarioData
    {
        public UsuarioModel Data { get; set; }
        public List<ListModel> Perfil { get; set; }
    }
}
