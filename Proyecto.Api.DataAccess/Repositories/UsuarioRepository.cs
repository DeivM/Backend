
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public UsuarioRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.Usuario.CountAsync(x => x.UsuId == id);
            return result > 0;
        }

        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.Usuario.CountAsync(x => x.UsuEmail.ToUpper() == nombre.ToUpper());
            return result > 0;
        }
        public async Task<bool> Exist(long id, string email)
        {
            var result = 0;
            result = await _controlHorarioContext.Usuario.CountAsync(x => x.UsuEmail.ToUpper() == email.ToUpper().Trim() && x.UsuId != id);
            return result > 0;
        }

        //Valida si existe datos por correo
        public async Task<UsuarioModel> ExisteUsuario(string email)
        {
            return await _controlHorarioContext.Usuario
                 .Where(x => x.UsuEmail == email)
                 .Select(x => new UsuarioModel
                 {
                     UsuId = x.UsuId,
                     UsuNombres = x.UsuNombres,
                     UsuEmail = x.UsuEmail,
                     UsuPassword=x.UsuPassword,
                     PerId=x.PerId,
                     EmpId=x.Per.EmpId,
                     UsuApellidos=x.UsuApellidos,
                     UsuEstado=x.UsuEstado,
                     // UsuIdentificacion=x.UsuIdentificacion
                 }).FirstOrDefaultAsync();
        }


        //obtiene un solo dato por la clave principal id
        public async Task<UsuarioModel> Get(long id)
        {
            return await _controlHorarioContext.Usuario
                .Where(x => x.UsuId == id)
                .Select(x => new UsuarioModel
                {
                    UsuId = x.UsuId,
                    UsuNombres = x.UsuNombres,
                    UsuEmail = x.UsuEmail,
                    UsuPassword = x.UsuPassword,
                    PerId = x.PerId,
                    EmpId = x.Per.EmpId,
                    UsuApellidos = x.UsuApellidos,
                    UsuEstado = x.UsuEstado,
                    UsuCedula=x.UsuCedula,
                    UsuDireccion=x.UsuDireccion,
                    UsuTelefono=x.UsuTelefono,
                    UsuSexo=x.UsuSexo,
                    UsuFechaNacimiento=x.UsuFechaNacimiento

                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<UsuarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<UsuarioModel>();
            var query = _controlHorarioContext.Usuario.Select(x => new UsuarioModel()
            {
                UsuId = x.UsuId,
                UsuNombres = x.UsuNombres,
                UsuEmail = x.UsuEmail,
                UsuPassword = x.UsuPassword,
                UsuApellidos = x.UsuApellidos,
                PerNombre=x.Per.PerNombre,
                UsuEstado=x.UsuEstado,
                UsuCedula = x.UsuCedula,
                UsuDireccion = x.UsuDireccion,
                UsuTelefono = x.UsuTelefono,
                UsuSexo = x.UsuSexo,
                UsuFechaNacimiento = x.UsuFechaNacimiento

            });
            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x => x.UsuNombres.Contains(searchText)
                || x.UsuApellidos.Contains(searchText)
                 || x.UsuEmail.Contains(searchText)
                 || x.UsuDireccion.Contains(searchText)
                 || x.UsuCedula.Contains(searchText)
                 || x.UsuSexo.Contains(searchText)
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
            return await _controlHorarioContext.Usuario
                .Select(x => new ListModel
                {
                    id = x.UsuId,
                    Nombre = x.UsuNombres + x.UsuApellidos
                }).ToListAsync();
        }

        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetListById(int id)
        {
            return await _controlHorarioContext.Usuario.Where(x=>x.PerId==id)
                .Select(x => new ListModel
                {
                    id = x.UsuId,
                    Nombre = x.UsuNombres + x.UsuApellidos
                }).ToListAsync();
        }


        //registra los datos a la base
        public async Task<long> Add(Usuario entity)
        {
            await _controlHorarioContext.Usuario.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            if (entity.PerId==2)
            {
                var medico = new Medico();
                medico.MedId = entity.UsuId;
                medico.MedNombres = entity.UsuNombres;
                medico.MedApellidos = entity.UsuApellidos;
                medico.MedCedula = entity.UsuCedula;
                medico.MedDireccion = entity.UsuDireccion;
                medico.MedCorreo = entity.UsuEmail;
                medico.MedTelefono = entity.UsuTelefono;
                medico.MedSexo = entity.UsuSexo;
                await _controlHorarioContext.Medico.AddAsync(medico);
                await _controlHorarioContext.SaveChangesAsync();
            }



            return entity.UsuId;
        }

        //actaliza un dato 
        public async Task<long> Update(Usuario entity)
        {
            _controlHorarioContext.Usuario.Attach(entity);
            _controlHorarioContext.Entry(entity).Property("UsuNombres").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuApellidos").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuEmail").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuEstado").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuCedula").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuDireccion").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuTelefono").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuSexo").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("UsuFechaNacimiento").IsModified = true;
            _controlHorarioContext.Entry(entity).Property("PerId").IsModified = true;

            await _controlHorarioContext.SaveChangesAsync();
            return entity.UsuId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        var entity = await _controlHorarioContext.Usuario.Where(x => x.UsuId == item).FirstAsync();
                        _controlHorarioContext.Usuario.Remove(entity);
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
