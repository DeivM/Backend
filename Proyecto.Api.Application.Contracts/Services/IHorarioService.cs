
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IHorarioService
    {
        Task<bool> Exist(long id);
        Task<HorarioModel> Get(long id);
        Task<ListadoPaginadoModel<HorarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<HorarioData> GetData(long id);
        Task<long> Add(HorarioRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(HorarioRequest data);
        Task<long> Delete(List<long> ids);

    }
}
