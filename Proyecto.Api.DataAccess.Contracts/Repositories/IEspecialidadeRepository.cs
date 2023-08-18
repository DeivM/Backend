
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IEspecialidadeRepository : IRepository<Especialidade>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<EspecialidadeModel> Get(long id);
        Task<ListadoPaginadoModel<EspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<List<ListModel>> GetList();
    }
}
