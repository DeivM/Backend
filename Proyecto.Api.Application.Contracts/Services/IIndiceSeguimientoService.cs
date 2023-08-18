
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IIndiceSeguimientoService
    {
        Task<bool> Exist(long id);
        Task<IndiceSeguimientoModel> Get(long id);
        Task<ListadoPaginadoModel<IndiceSeguimientoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<IndiceSeguimientoData> GetData(long id);
        Task<long> Add(IndiceSeguimientoRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(IndiceSeguimientoRequest data);
        Task<long> Delete(List<long> ids);

    }
}
