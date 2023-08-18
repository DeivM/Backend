
using System.Collections.Generic;

namespace Proyecto.Api.Business.Models
{
    public partial class MenuModel
    {
        public long MenId { get; set; }
        public string MenNombre { get; set; }
        public string MenNombrePadre { get; set; }
        public long? MenMenId { get; set; }
        public string MenTipo { get; set; }
        public string MenIcono { get; set; }
        public string MenUrl { get; set; }
        public short? MenOrden { get; set; }
        public string MenCodigoUnico { get; set; }
        public short? MenEstado { get; set; }
        public List<MenuModel> menusHijos { get; set; }
    }
}
