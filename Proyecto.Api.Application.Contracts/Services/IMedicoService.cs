
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IMedicoService
    {
        Task<bool> Exist(long id);
        Task<MedicoModel> Get(long id);
        Task<ListadoPaginadoModel<MedicoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<MedicoData> GetData(long id);
        Task<long> Add(MedicoRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(MedicoRequest data);
        Task<long> Delete(List<long> ids);
        //Lista los datos para mostrar en un select
        Task<List<ListModel>> GetList();

        Task<List<ListModel>> GetList(long id);

    }
}
