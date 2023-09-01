
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
using Proyecto.Api.Business.Request;


namespace Proyecto.Api.DataAccess.Repositories
{
    public class SeguimientoPacienteRepository : ISeguimientoPacienteRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public SeguimientoPacienteRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.SeguimientoPaciente.CountAsync(x => x.SepId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.SeguimientoPaciente.CountAsync(x => x.SepObservacion.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<SeguimientoPacienteModel> Get(long id)
        {
            return await _controlHorarioContext.SeguimientoPaciente
                .Where(x => x.SepId == id)
                .Select(x => new SeguimientoPacienteModel
                {
                    SepId = x.SepId,
                    CasId = x.CasId,
                    SepObservacion = x.SepObservacion,
                    SepFinalizar = x.SepFinalizar,
                    UsuId = x.UsuId
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<SeguimientoPacienteModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<SeguimientoPacienteModel>();
            var query = _controlHorarioContext.SeguimientoPaciente.Select(x => new SeguimientoPacienteModel()
            {
                SepId = x.SepId,
                CasId = x.CasId,
                CasNombre = x.Cas.CasNombre,
                paciente = x.Usu.UsuNombres + " " + x.Usu.UsuApellidos,
                medico = x.Cit.Mes.Usu.UsuNombres + " " + x.Cit.Mes.Usu.UsuApellidos,
                Finalizar = x.SepFinalizar ? "Paciente Necesita cita médica" : "Estado de salud estable",
                SepObservacion = x.SepObservacion,
                SepFinalizar = x.SepFinalizar,
                estadoSiNo = (x.SepFinalizar==true? "Si":"No"),
                UsuId = x.UsuId,
                Especialidad=x.Cit.Mes.Esp.EspNombre
            }); ;

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.SepObservacion.Contains(searchText)
                      || x.CasNombre.Contains(searchText)
                      || x.paciente.Contains(searchText)
                      || x.medico.Contains(searchText)

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

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<List<SeguimientoPacienteModel>> GetAllById(int id)
        {

            var query = _controlHorarioContext.SeguimientoPaciente.Where(x=>x.UsuId==id && x.Cit.CitEstado==1)
                .Select(x => new SeguimientoPacienteModel()
            {
                SepId = x.SepId,
                CasId = x.CasId,
                CitId = x.CitId,
                SepObservacion = x.SepObservacion,
                SepFinalizar = x.SepFinalizar,
                UsuId = x.UsuId,
                CasNombre=x.Cas.CasNombre
            });

           return await query.ToListAsync();
 
        }



        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetList()
        {
            return await _controlHorarioContext.SeguimientoPaciente
                .Select(x => new ListModel
                {
                    id = x.SepId,
                    Nombre = x.SepObservacion
                }).ToListAsync();
        }
 

            //registra los datos a la base
            public async Task<long> Add(SeguimientoPaciente entity)
        {
            await _controlHorarioContext.SeguimientoPaciente.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.SepId;
        }

        //registra los datos a la base
        public async Task<long> Update(List<SeguimientoPacienteRequest> entity)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                SeguimientoPaciente SeguimientoPaciente = null;
                try
                {
                    foreach (var item in entity)
                    {
                        SeguimientoPaciente = new SeguimientoPaciente();
                        SeguimientoPaciente.SepId = item.SepId;
                        SeguimientoPaciente.CasId = item.CasId;
                        SeguimientoPaciente.SepObservacion=item.SepObservacion;
                        SeguimientoPaciente.SepFinalizar=item.SepFinalizar;
                        SeguimientoPaciente.UsuId=item.UsuId;
                        SeguimientoPaciente.CitId = item.CitId;
                        _controlHorarioContext.SeguimientoPaciente.Update(SeguimientoPaciente);
                    }
                    await _controlHorarioContext.SaveChangesAsync();
                    var citId= entity.Select(x=>x.CitId).FirstOrDefault();
                    var cita = new Cita();
                    cita.CitId = citId;
                    cita.CitEstado = 2;
                    _controlHorarioContext.Cita.Attach(cita);
                    _controlHorarioContext.Entry(cita).Property("CitEstado").IsModified = true;
                    await _controlHorarioContext.SaveChangesAsync();
                    await tran.CommitAsync();
                    return 1;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    throw new Exception(e.Message);
                }
            }
        }


        //actaliza un dato 
        public async Task<long> Update(SeguimientoPaciente entity)
        {
            _controlHorarioContext.SeguimientoPaciente.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.SepId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                SeguimientoPaciente SeguimientoPaciente = null;
                try
                {
                    foreach (var item in ids)
                    {
                        SeguimientoPaciente = await _controlHorarioContext.SeguimientoPaciente.Where(x => x.SepId == item).FirstAsync();
                        _controlHorarioContext.SeguimientoPaciente.Remove(SeguimientoPaciente);
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
