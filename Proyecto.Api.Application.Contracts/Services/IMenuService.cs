
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IMenuService
    {
        Task<bool> Exist(long id);
        Task<MenuModel> Get(long id);
        Task<ListadoPaginadoModel<MenuModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);

        /// <summary>
        /// busqueda los perfiles
        /// </summary>
        /// <returns>retorna los datos en un dto</returns>
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

        Task<MenuData> GetData(long id);
        Task<long> Add(MenuRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(MenuRequest data);
        Task<long> Delete(List<long> ids);

    }
}
