﻿
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
    public class HorarioRepository : IHorarioRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public HorarioRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.Horario.CountAsync(x => x.HorId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            //result = await _controlHorarioContext.Horario.CountAsync(x => x.CarNombre.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<HorarioModel> Get(long id)
        {
            return await _controlHorarioContext.Horario
                .Where(x => x.HorId == id)
                .Select(x => new HorarioModel
                {
                    HorId = x.HorId,
                    UsuId = x.UsuId,
                    HorFechaAtencion = x.HorFechaAtencion,
                    HorInicioAtencion = x.HorInicioAtencion,
                    HorFinAtencion = x.HorFinAtencion,
                    HorEstado = x.HorEstado
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<HorarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<HorarioModel>();
            var query = _controlHorarioContext.Horario.Select(x => new HorarioModel()
            {
                HorId = x.HorId,
                UsuId = x.UsuId,
                HorFechaAtencion = x.HorFechaAtencion,
                HorInicioAtencion = x.HorInicioAtencion,
                HorFinAtencion = x.HorFinAtencion,
                HorEstado = x.HorEstado
            });

            //buscar por texto
            /*if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.CarNombre.Contains(searchText)
                );
            }*/

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
        public async Task<List<ListModel>> GetList(long id, DateTime fecha, TimeSpan hora)
        {
            return await _controlHorarioContext.Horario.Where(x=>x.UsuId==id && x.HorInicioAtencion.Value >= hora
            && ! _controlHorarioContext.Cita
            .Where(x=>x.UsuId==id && x.CitEstado==1 && x.CitFechaAtencion.Value.Date== fecha.Date).Select(x=>x.HorId).Contains(x.HorId))
                .Select(x => new ListModel
                {
                    id = x.HorId,
                    //Nombre = x.CarNombre
                }).ToListAsync();
        }
 

            //registra los datos a la base
            public async Task<long> Add(Horario entity)
        {
            await _controlHorarioContext.Horario.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.HorId;
        }

        //actaliza un dato 
        public async Task<long> Update(Horario entity)
        {
            _controlHorarioContext.Horario.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.HorId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                Horario Horario = null;
                try
                {
                    foreach (var item in ids)
                    {
                        Horario = await _controlHorarioContext.Horario.Where(x => x.HorId == item).FirstAsync();
                        _controlHorarioContext.Horario.Remove(Horario);
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
