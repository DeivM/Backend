
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface ISeguimientoPacienteService
    {
        Task<bool> Exist(long id);
        Task<SeguimientoPacienteModel> Get(long id);
        Task<ListadoPaginadoModel<SeguimientoPacienteModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<SeguimientoPacienteData> GetData(long id);
        Task<long> Add(SeguimientoPacienteRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(SeguimientoPacienteRequest data);
        Task<long> Delete(List<long> ids);

    }
}
