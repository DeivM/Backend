
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IEspecialidadeService
    {
        Task<bool> Exist(long id);
        Task<EspecialidadeModel> Get(long id);
        Task<ListadoPaginadoModel<EspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<EspecialidadeData> GetData(long id);
        Task<long> Add(EspecialidadeRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(EspecialidadeRequest data);
        Task<long> Delete(List<long> ids);

        Task<List<ListModel>> GetList();

    }
}
