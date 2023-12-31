﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface ISeguimientoPacienteRepository : IRepository<SeguimientoPaciente>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);
        Task<SeguimientoPacienteModel> Get(long id);
        Task<ListadoPaginadoModel<SeguimientoPacienteModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        Task<List<ListModel>> GetList();

        Task<List<SeguimientoPacienteModel>> GetAllById(int id);

        //registra los datos a la base
        Task<long> Update(List<SeguimientoPacienteRequest> entity);


    }
}
