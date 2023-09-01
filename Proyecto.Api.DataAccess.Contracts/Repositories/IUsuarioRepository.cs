
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.Business.Request;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> Exist(long id);
        Task<bool> Exist(string nombre);

        //Valida si existe datos por correo
        Task<UsuarioModel> ExisteUsuario(string email);

        Task<UsuarioModel> Get(long id);
        Task<ListadoPaginadoModel<UsuarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText);
        /// <summary>
        /// verifica email si ya existe
        /// </summary>
        /// <param name="id">ide del usuario</param>
        /// <param name="email">correo eléctronico</param>
        /// <returns></returns>
        Task<bool> Exist(long id, string email);
        Task<List<ListModel>> GetList();
        //Lista los datos para mostrar en un select
         Task<List<ListModel>> GetListById(int id);
        Task<List<ListModel>> GetList(long id);
        Task<long> UpdatePassword(Usuario entity);

        Task<Usuario> getEmail(string email);
    }
}
