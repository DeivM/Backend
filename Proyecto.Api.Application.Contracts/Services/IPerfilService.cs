
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IPerfilService
    {
        Task<bool> Exist(long id);
        Task<PerfilModel> Get(long id);
        Task<ListadoPaginadoModel<PerfilModel>> GetAll(long idEmpresa, int quantity, int page, string orderBy, string orderType, string searchText);

        /// <summary>
        /// busqueda los perfiles
        /// </summary>
        /// <returns>retorna los datos en un dto</returns>
        Task<List<ListModel>> GetList();
        /// <summary>
        /// lista los perfiles por empresa
        /// </summary>
        /// <param name="idEmpresa">ide de la empresa</param>
        /// <returns>retonra una lista</returns>
        Task<List<ListModel>> GetList(long idEmpresa);

        Task<PerfilData> GetData(long id);
        Task<long> Add(PerfilRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(PerfilRequest data);
        Task<long> Delete(List<long> ids);

    }
}
