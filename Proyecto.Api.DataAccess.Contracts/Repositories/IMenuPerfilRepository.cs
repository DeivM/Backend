
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IMenuPerfilRepository : IRepository<MenuPerfil>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        /// <summary>
        /// valida si ya existe datos por perfil y menu
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idMenu"></param>
        /// <returns></returns>
         Task<bool> Exist(long idPerfil, long idMenu);
        /// <summary>
        /// valida si ya existe datos por perfil y menu y diferente del id
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        Task<bool> Exist(long id, long idPerfil, long idMenu);
        Task<MenuPerfilModel> Get(long id);
        Task<ListadoPaginadoModel<MenuPerfilModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<List<ListModel>> GetList();
    }
}
