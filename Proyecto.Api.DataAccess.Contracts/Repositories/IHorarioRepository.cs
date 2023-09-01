
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;
using System;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IHorarioRepository : IRepository<Horario>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<HorarioModel> Get(long id);
        Task<ListadoPaginadoModel<HorarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        //Lista los datos para mostrar en un select
        Task<List<ListModel>> GetList(long id, DateTime fecha, TimeSpan hora);
    }
}
