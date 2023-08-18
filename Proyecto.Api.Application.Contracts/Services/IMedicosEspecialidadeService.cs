
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface IMedicosEspecialidadeService
    {
        Task<bool> Exist(long id);
        Task<MedicosEspecialidadeModel> Get(long id);
        Task<ListadoPaginadoModel<MedicosEspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<MedicosEspecialidadeData> GetData(long id);
        Task<long> Add(MedicosEspecialidadeRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(MedicosEspecialidadeRequest data);
        Task<long> Delete(List<long> ids);

    }
}
