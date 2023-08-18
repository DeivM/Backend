
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IMenuPerfilService
    {
        Task<bool> Exist(long id);
        Task<MenuPerfilModel> Get(long id);
        Task<ListadoPaginadoModel<MenuPerfilModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);

        /// <summary>
        /// busqueda los perfiles
        /// </summary>
        /// <returns>retorna los datos en un dto</returns>
        Task<List<ListModel>> GetList();

        Task<MenuPerfilData> GetData(long id, long idEmpresa);
        Task<long> Add(MenuPerfilRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(MenuPerfilRequest data);
        Task<long> Delete(List<long> ids);

    }
}
