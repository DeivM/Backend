
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;
using System;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface ICitaRepository : IRepository<Cita>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<CitaModel> Get(long id);
        Task<ListadoPaginadoModel<CitaModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText, int perId, int usuId);
        Task<List<ListModel>> GetList();
        //Valida si existe datos por id
        Task<bool> ValidarCitasHorario(long idMedico, DateTime fecha, TimeSpan horaInicio, TimeSpan horafin);
        Task<List<CitaModel>> GetAllById(int id);

    }
}
