
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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public MedicoRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.Medico.CountAsync(x => x.MedId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.Medico.CountAsync(x => x.MedNombres.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<MedicoModel> Get(long id)
        {
            return await _controlHorarioContext.Medico
                .Where(x => x.MedId == id)
                .Select(x => new MedicoModel
                {
                    MedId = x.MedId,
                    MedNombres = x.MedNombres,
                    MedApellidos = x.MedApellidos,
                    MedCedula = x.MedCedula,
                    MedDireccion = x.MedDireccion,
                    MedCorreo = x.MedCorreo,
                    MedTelefono = x.MedTelefono,
                    MedSexo = x.MedSexo,
                    MedNumCsp = x.MedNumCsp,
                    MedEstado = x.MedEstado,
                    EmpId = x.EmpId
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MedicoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<MedicoModel>();
            var query = _controlHorarioContext.Medico.Select(x => new MedicoModel()
            {
                MedId = x.MedId,
                MedNombres = x.MedNombres,
                MedApellidos = x.MedApellidos,
                MedCedula = x.MedCedula,
                MedDireccion = x.MedDireccion,
                MedCorreo = x.MedCorreo,
                MedTelefono = x.MedTelefono,
                MedSexo = x.MedSexo,
                MedNumCsp = x.MedNumCsp,
                MedEstado = x.MedEstado,
                EmpId = x.EmpId
            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.MedNombres.Contains(searchText)
                      || x.MedApellidos.Contains(searchText)
                      || x.MedCedula.Contains(searchText)
                      || x.MedDireccion.Contains(searchText)
                      || x.MedCorreo.Contains(searchText)
                      || x.MedTelefono.Contains(searchText)
                      || x.MedSexo.Contains(searchText)
                      || x.MedNumCsp.Contains(searchText)
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
            return await _controlHorarioContext.Medico
                .Select(x => new ListModel
                {
                    id = x.MedId,
                    Nombre = x.MedNombres + x.MedApellidos
                }).ToListAsync();
        }

        public async Task<List<ListModel>> GetList(long id)
        {
            return await _controlHorarioContext.MedicosEspecialidade.Where(x => x.EspId == id)
                .Select(x => new ListModel
                {
                    id = x.MesId,
                    Nombre = x.Med.MedNombres + x.Med.MedApellidos
                }).ToListAsync();
        }


        //registra los datos a la base
        public async Task<long> Add(Medico entity)
        {
            await _controlHorarioContext.Medico.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MedId;
        }

        //actaliza un dato 
        public async Task<long> Update(Medico entity)
        {
            _controlHorarioContext.Medico.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MedId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                Medico Medico = null;
                try
                {
                    foreach (var item in ids)
                    {
                        Medico = await _controlHorarioContext.Medico.Where(x => x.MedId == item).FirstAsync();
                        _controlHorarioContext.Medico.Remove(Medico);
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
