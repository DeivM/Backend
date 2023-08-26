
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IUsuarioService
    {
        Task<bool> Exist(long id);
        Task<UsuarioModel> Get(long id);
        Task<ListadoPaginadoModel<UsuarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<UsuarioData> GetData(long id, long idEmpresa);
        Task<long> Add(UsuarioRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Task<Token> login(UsuarioRequest data);
        Task<long> Update(UsuarioRequest data);
        Task<long> Delete(List<long> ids);

        Task<List<ListModel>> GetList();
        Task<List<ListModel>> GetListById(int id);
    }
}
