
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Api.Business.common.extension;
using Proyecto.Api.Business.Models;
using Proyecto.Api.DataAccess.Contracts;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Repositories
{
    public class MenuPerfilRepository : IMenuPerfilRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public MenuPerfilRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.MenuPerfil.CountAsync(x => x.MepId == id);
            return result > 0;
        }

        /// <summary>
        /// valida si ya existe datos por perfil y menu
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public async Task<bool> Exist(long idPerfil, long idMenu)
        {
            var result = 0;
            result = await _controlHorarioContext.MenuPerfil.CountAsync(x => x.PerId == idPerfil && x.MenId==idMenu);
            return result > 0;
        }


        /// <summary>
        /// valida si ya existe datos por perfil y menu y diferente del id
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public async Task<bool> Exist(long id, long idPerfil, long idMenu)
        {
            var result = 0;
            result = await _controlHorarioContext.MenuPerfil.CountAsync(x => x.PerId == idPerfil && x.MenId == idMenu && x.MepId!=id);
            return result > 0;
        }

        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            return false;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<MenuPerfilModel> Get(long id)
        {
            return await _controlHorarioContext.MenuPerfil
                .Where(x => x.MepId == id)
                .Select(x => new MenuPerfilModel
                {
                    MepId = x.MepId,
                    MenId=x.MenId,
                    PerId=x.PerId,
                    MepEstado=x.MepEstado
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MenuPerfilModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<MenuPerfilModel>();
            var query = _controlHorarioContext.MenuPerfil.Select(x => new MenuPerfilModel()
            {
                MepId = x.MepId,
                MenNombre=x.Men.MenNombre,
                PerNombre=x.Per.PerNombre,
                MepEstado=x.MepEstado
            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.MenNombre.Contains(searchText)
                      || x.PerNombre.Contains(searchText)
                );
            }
            // total de items
            result.FiitidadElementos = query.Count();
            // Ordenamiento y paginado
            result.Elementos = await query.OrderByPropertyOrField(orderBy, orderType)
                .Skip(page * quantity)
                .Take(quantity)
                .ToListAsync();
            return result;
        }

        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetList()
        {
            return await _controlHorarioContext.MenuPerfil
                .Select(x => new ListModel
                {
                    id = x.MepId,
                }).ToListAsync();
        }

        //registra los datos a la base
        public async Task<long> Add(MenuPerfil entity)
        {
            await _controlHorarioContext.MenuPerfil.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MepId;
        }

        //actaliza un dato 
        public async Task<long> Update(MenuPerfil entity)
        {
            _controlHorarioContext.MenuPerfil.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MepId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                MenuPerfil carrera = null;
                try
                {
                    foreach (var item in ids)
                    {
                        carrera = await _controlHorarioContext.MenuPerfil.Where(x => x.MepId == item).FirstAsync();
                        _controlHorarioContext.MenuPerfil.Remove(carrera);
                    }
                    await _controlHorarioContext.SaveChangesAsync();
                    await tran.CommitAsync();
                    return 1;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    string messaje = e.Message;
                    if (e.InnerException != null)
                    {
                        if (e.InnerException.InnerException != null)
                        {
                            messaje += e.InnerException.InnerException.Message + " ";
                        }
                        else
                        {
                            messaje += e.InnerException.Message + " ";
                        }
                    }
                    throw new Exception(messaje);
                }
            }
        }
    }
}
