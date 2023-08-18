
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Api.Business.common.extension;
using Proyecto.Api.Business.Models;
using Proyecto.Api.DataAccess.Contracts;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.Business.Models.List;

namespace Proyecto.Api.DataAccess.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public PerfilRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.Perfil.CountAsync(x => x.PerId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.Perfil.CountAsync(x => x.PerNombre.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<PerfilModel> Get(long id)
        {
            return await _controlHorarioContext.Perfil
                .Where(x => x.PerId == id)
                .Select(x => new PerfilModel
                {
                    PerId = x.PerId,
                    PerNombre = x.PerNombre,
                    PerEstado=x.PerEstado,
                    EmpId=x.EmpId
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<PerfilModel>> GetAll(long idEmpresa, int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<PerfilModel>();
            var query = _controlHorarioContext.Perfil.Where(x=>x.EmpId== idEmpresa).Select(x => new PerfilModel()
            {
                PerId = x.PerId,
                PerNombre = x.PerNombre,
                PerEstado = x.PerEstado,
                EmpId = x.EmpId
            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.PerNombre.Contains(searchText)
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
            return await _controlHorarioContext.Perfil
                .Select(x => new ListModel
                {
                    id = x.PerId,
                    Nombre = x.PerNombre
                }).ToListAsync();
        }

        /// <summary>
        /// busqueda por el id de la empresa
        /// </summary>
        /// <param name="idEmpresa">id de la empresa</param>
        /// <returns>retorna los datos en un dto</returns>
        public async Task<List<ListModel>> GetList(long idEmpresa)
        {
            return await _controlHorarioContext.Perfil.Where(x=>x.EmpId==idEmpresa)
                .Select(x => new ListModel
                {
                    id = x.PerId,
                    Nombre = x.PerNombre
                }).ToListAsync();
        }


        //registra los datos a la base
        public async Task<long> Add(Perfil entity)
        {
            await _controlHorarioContext.Perfil.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.PerId;
        }

        //actaliza un dato 
        public async Task<long> Update(Perfil entity)
        {
            _controlHorarioContext.Perfil.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.PerId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                Perfil carrera = null;
                try
                {
                    foreach (var item in ids)
                    {
                        carrera = await _controlHorarioContext.Perfil.Where(x => x.PerId == item).FirstAsync();
                        _controlHorarioContext.Perfil.Remove(carrera);
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
