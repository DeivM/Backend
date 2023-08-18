
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<MenuModel> Get(long id);
        Task<ListadoPaginadoModel<MenuModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<List<ListModel>> GetListMenuPadre();

        /// <summary>
        /// lista los menus que tengan link
        /// </summary>
        /// <returns></returns>
         Task<List<ListModel>> GetListMenuConPadre();

        /// <summary>
        /// obtiene los menus por perfil
        /// </summary>
        /// <param name="id">ide del rol</param>
        /// <returns>retorna una tuple</returns>
       Task<Tuple<List<MenuUsuario>, List<string>>> GetMenuRol(long id);
    }
}
