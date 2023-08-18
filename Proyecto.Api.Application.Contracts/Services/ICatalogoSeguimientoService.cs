
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface ICatalogoSeguimientoService
    {
        Task<bool> Exist(long id);
        Task<CatalogoSeguimientoModel> Get(long id);
        Task<ListadoPaginadoModel<CatalogoSeguimientoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<CatalogoSeguimientoData> GetData(long id);
        Task<long> Add(CatalogoSeguimientoRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(CatalogoSeguimientoRequest data);
        Task<long> Delete(List<long> ids);

        Task<List<ListModel>> GetList(long id);

    }
}
