
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.Application.Contracts.Services
{
  public  interface ICitaService
    {
        Task<bool> Exist(long id);
        Task<CitaModel> Get(long id);
        Task<ListadoPaginadoModel<CitaModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText, int PerId, int UsuId);
        Task<CitaData> GetData(long id);
        Task<long> Add(CitaRequest data);
        /// <summary>
        /// rregistra y geera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<long> Update(CitaRequest data);
        Task<long> Delete(List<long> ids);
        Task<List<CitaModel>> GetAllById(int id);
        Task<long> Update(List<CitaRequest> entity);

    }
}
