
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
    public class MedicosEspecialidadeRepository : IMedicosEspecialidadeRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public MedicosEspecialidadeRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.MedicosEspecialidade.CountAsync(x => x.MesId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            //result = await _controlHorarioContext.MedicosEspecialidade.CountAsync(x => x.CarNombre.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<MedicosEspecialidadeModel> Get(long id)
        {
            return await _controlHorarioContext.MedicosEspecialidade
                .Where(x => x.MesId == id)
                .Select(x => new MedicosEspecialidadeModel
                {
                    MesId = x.MesId,
                    EspId = x.EspId,
                    MedId = x.MedId,
                    MesEstado = x.MesEstado
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MedicosEspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<MedicosEspecialidadeModel>();
            var query = _controlHorarioContext.MedicosEspecialidade.Select(x => new MedicosEspecialidadeModel()
            {
                MesId = x.MesId,
                EspId = x.EspId,
                MedId = x.MedId,
                MesEstado = x.MesEstado,
                MedNombres=x.Usu.UsuNombres+" "+ x.Usu.UsuApellidos,
                EspNombre=x.Esp.EspNombre
            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.MedNombres.Contains(searchText)
                     ||x.EspNombre.Contains(searchText)
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
            return await _controlHorarioContext.MedicosEspecialidade
                .Select(x => new ListModel
                {
                    id = x.MesId,
                    //Nombre = x.CarNombre
                }).ToListAsync();
        }
 

            //registra los datos a la base
            public async Task<long> Add(MedicosEspecialidade entity)
        {
            await _controlHorarioContext.MedicosEspecialidade.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MesId;
        }

        //actaliza un dato 
        public async Task<long> Update(MedicosEspecialidade entity)
        {
            _controlHorarioContext.MedicosEspecialidade.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MesId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                MedicosEspecialidade MedicosEspecialidade = null;
                try
                {
                    foreach (var item in ids)
                    {
                        MedicosEspecialidade = await _controlHorarioContext.MedicosEspecialidade.Where(x => x.MesId == item).FirstAsync();
                        _controlHorarioContext.MedicosEspecialidade.Remove(MedicosEspecialidade);
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
