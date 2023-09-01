
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
    public class CitaRepository : ICitaRepository
    {
        private readonly IProyectoContext _controlHorarioContext;

        public CitaRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.Cita.CountAsync(x => x.CitId == id);
            return result > 0;
        }

        //Valida si existe datos por id
        public async Task<bool> ValidarCitasHorario(long idMedico, DateTime fecha, TimeSpan horaInicio, TimeSpan horafin)
        {
            var result = 0;
            result = await _controlHorarioContext.Cita.Where(x=>x.MesId==idMedico &&
                                                             x.CitFechaAtencion.Value.Date==fecha.Date &&
                                                             x.CitInicioAtencion <= horaInicio &&
                                                             x.CitFinAtencion >= horafin)
                                                       .CountAsync();

            return result > 0;
        }


        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.Cita.CountAsync(x => x.CitEstadoPaciente.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<CitaModel> Get(long id)
        {
            return await _controlHorarioContext.Cita
                .Where(x => x.CitId == id)
                .Select(x => new CitaModel
                {
                    CitId = x.CitId,
                    MesId = x.MesId,
                    EspId = x.Mes.EspId,
                    CitFechaAtencion = x.CitFechaAtencion,
                    CitInicioAtencion = x.CitInicioAtencion,
                    CitFinAtencion = x.CitFinAtencion,
                    CitEstadoPaciente = x.CitEstadoPaciente,
                    CitObservaciones = x.CitObservaciones,
                    CitEstado = x.CitEstado,
                    UsuId = x.UsuId,
                    UsuImagen = x.Usu.UsuImagen,
                    MedNombres = x.Mes.Usu.UsuNombres + x.Mes.Usu.UsuApellidos,
                    UsuNombres = x.Usu.UsuNombres + x.Usu.UsuApellidos,
                    EspNombre = x.Mes.Esp.EspNombre

                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<CitaModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText, int perId, int usuId)
        {
            var result = new ListadoPaginadoModel<CitaModel>();
            var query = _controlHorarioContext.Cita.Select(x => new CitaModel()
            {
                CitId = x.CitId,
                MesId = x.MesId,
                CitFechaAtencion = x.CitFechaAtencion,
                CitInicioAtencion = x.CitInicioAtencion,
                CitFinAtencion = x.CitFinAtencion,
                CitEstadoPaciente = x.CitEstadoPaciente,
                CitObservaciones = x.CitObservaciones,
                CitEstado = x.CitEstado,
                UsuId = x.UsuId,
                UsuImagen = x.Usu.UsuImagen,
                MedNombres = x.Mes.Usu.UsuNombres +" "+ x.Mes.Usu.UsuApellidos,
                UsuNombres = x.Usu.UsuNombres +" "+ x.Usu.UsuApellidos,
                EspNombre = x.Mes.Esp.EspNombre  

            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.CitEstadoPaciente.Contains(searchText)
                      || x.CitObservaciones.Contains(searchText)
                      || x.MedNombres.Contains(searchText)
                      || x.UsuNombres.Contains(searchText)
                      || x.EspNombre.Contains(searchText)

                );
            }
            if (perId==2)
            {
                var medicosspecilaes = await _controlHorarioContext.MedicosEspecialidade.Where(x => x.UsuId == usuId).Select(x => x.MesId).FirstOrDefaultAsync();

                query = query.Where(x =>x.MesId== medicosspecilaes);
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
        public async Task<List<CitaModel>> GetAllById(int id)
        {

            var query = _controlHorarioContext.Cita.Where(x=>x.UsuId==id && x.CitEstado==1).OrderByDescending(x=>x.CitFechaAtencion.Value.Date).Select(x => new CitaModel()
            {
                CitId = x.CitId,
                MesId = x.MesId,
                CitFechaAtencion = x.CitFechaAtencion,
                CitInicioAtencion = x.CitInicioAtencion,
                CitFinAtencion = x.CitFinAtencion,
                CitEstadoPaciente = x.CitEstadoPaciente,
                CitObservaciones = x.CitObservaciones,
                CitEstado = x.CitEstado,
                UsuId = x.UsuId,
                UsuImagen = x.Usu.UsuImagen,
                MedNombres = x.Mes.Usu.UsuNombres + x.Mes.Usu.UsuApellidos,
                UsuNombres = x.Usu.UsuNombres + x.Usu.UsuApellidos,
                EspNombre = x.Mes.Esp.EspNombre

            });

          return await  query.ToListAsync();

        }




        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetList()
        {
            return await _controlHorarioContext.Cita
                .Select(x => new ListModel
                {
                    id = x.CitId,
                    Nombre = x.Usu.UsuNombres + x.Usu.UsuApellidos
                }).ToListAsync();
        }


            //registra los datos a la base
            public async Task<long> Add(Cita entity)
        {
            

            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                try
                {
                    // Agregar la nueva entidad de Cita al contexto y guardarla en la base de datos
                    await _controlHorarioContext.Cita.AddAsync(entity);
                    await _controlHorarioContext.SaveChangesAsync();

                    // Agregar la nueva entidad de Cita al contexto y guardarla en la base de datos
                    var especialidades = await _controlHorarioContext.MedicosEspecialidade
                        .Where(x => x.MesId == entity.MesId)
                        .Select(x => new EspecialidadeModel
                        {
                            EspId = x.EspId.Value,

                        }).FirstOrDefaultAsync();

                    // Obtener las preguntas (CasId) relacionadas con la especialidad de la cita
                    var catalogo = await _controlHorarioContext.CatalogoSeguimiento
                        .Where(x => x.EspId == especialidades.EspId).Select(x => new ListModel
                        {
                            id = x.CasId,
                            Nombre = x.CasNombre
                        }).ToListAsync();
                    
                    // Para cada pregunta (CasId) obtenida, asignar una nueva entidad de SeguimientoPaciente
                    // con los datos de la cita y la pregunta correspondiente, y agregarla al contexto.

                    foreach (var item in catalogo)
                    {
                        var seguimientopaciente = new SeguimientoPaciente();
                        seguimientopaciente.UsuId = entity.UsuId;
                        seguimientopaciente.CasId = item.id;
                        seguimientopaciente.CitId = entity.CitId;
                        seguimientopaciente.SepFinalizar = false;
                        await _controlHorarioContext.SeguimientoPaciente.AddAsync(seguimientopaciente);
                      
                    }
                    // Guardar los cambios en el contexto para agregar las entidades de SeguimientoPaciente
                    await _controlHorarioContext.SaveChangesAsync();
                    await tran.CommitAsync();
                    return entity.CitId;
                    //return 1;
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

            //return entity.CitId;
        }

        //actaliza un dato 
        public async Task<long> Update(Cita entity)
        {
            _controlHorarioContext.Cita.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.CitId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                Cita Cita = null;
                try
                {
                    foreach (var item in ids)
                    {
                        Cita = await _controlHorarioContext.Cita.Where(x => x.CitId == item).FirstAsync();
                        _controlHorarioContext.Cita.Remove(Cita);
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

        //registra los datos a la base
        public async Task<long> Update(List<CitaRequest> entity)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                Cita cita = null;
                try
                {
                    foreach (var item in entity)
                    {
                        cita = new Cita();

                        cita.CitId = item.CitId;
                        cita.MesId = item.MesId;
                        cita.CitFechaAtencion = item.CitFechaAtencion;
                        cita.CitInicioAtencion = item.CitInicioAtencion;
                        cita.CitFinAtencion = item.CitFinAtencion;
                        cita.CitEstadoPaciente = item.CitEstadoPaciente;
                        cita.CitObservaciones = item.CitObservaciones;
                        cita.CitEstado = item.CitEstado;
                        cita.UsuId = item.UsuId;
                        _controlHorarioContext.Cita.Update(cita);
                    }
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



    }
}
