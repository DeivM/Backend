
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IMedicosEspecialidadeRepository : IRepository<MedicosEspecialidade>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<MedicosEspecialidadeModel> Get(long id);
        Task<ListadoPaginadoModel<MedicosEspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<List<ListModel>> GetList();
    }
}
