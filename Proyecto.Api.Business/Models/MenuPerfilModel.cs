

namespace Proyecto.Api.Business.Models
{
    public partial class MenuPerfilModel
    {
        public long MepId { get; set; }
        public long? MenId { get; set; }
        public long? PerId { get; set; }
        public short? MepEstado { get; set; }
        public string MenNombre { get; set; }

        public string PerNombre { get; set; }
    }
}
