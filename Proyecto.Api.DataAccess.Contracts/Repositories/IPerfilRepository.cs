
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<PerfilModel> Get(long id);
        Task<ListadoPaginadoModel<PerfilModel>> GetAll(long idEmpresa, int quantity, int page, string orderBy, string orderType, string searchText);
        Task<List<ListModel>> GetList();

        /// <summary>
        /// busqueda por el id de la empresa
        /// </summary>
        /// <param name="idEmpresa">id de la empresa</param>
        /// <returns>retorna los datos en un dto</returns>
        Task<List<ListModel>> GetList(long idEmpresa);
    }
}
