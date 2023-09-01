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
    public class CatalogoSeguimientoRepository : ICatalogoSeguimientoRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public CatalogoSeguimientoRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.CatalogoSeguimiento.CountAsync(x => x.CasId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.CatalogoSeguimiento.CountAsync(x => x.CasNombre.ToUpper() == nombre.ToUpper());
            return result > 0;
        }

        //obtiene un solo dato por la clave principal id
        public async Task<CatalogoSeguimientoModel> Get(long id)
        {
            return await _controlHorarioContext.CatalogoSeguimiento
                .Where(x => x.CasId == id)
                .Select(x => new CatalogoSeguimientoModel
                {
                    CasId = x.CasId,
                    EspId = x.EspId,
                    CasNombre = x.CasNombre,
                    CasEstado = x.CasEstado
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<CatalogoSeguimientoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<CatalogoSeguimientoModel>();
            var query = _controlHorarioContext.CatalogoSeguimiento.Select(x => new CatalogoSeguimientoModel()
            {
                CasId = x.CasId,
                EspId = x.EspId,
                CasNombre = x.CasNombre,
                CasEstado = x.CasEstado,
                EspNombre =x.Esp.EspNombre
            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.CasNombre.Contains(searchText)
                      || x.EspNombre.Contains(searchText)
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
            return await _controlHorarioContext.CatalogoSeguimiento
                .Select(x => new ListModel
                {
                    id = x.CasId,
                    Nombre = x.CasNombre
                }).ToListAsync();
        }

        public async Task<List<ListModel>> GetList(long id)
        {
            return await _controlHorarioContext.CatalogoSeguimiento
                .Where(x => x.EspId == id).Select(x => new ListModel
                {
                    id = x.CasId,
                    Nombre = x.CasNombre
                }).ToListAsync();
        }


        //registra los datos a la base
        public async Task<long> Add(CatalogoSeguimiento entity)
        {
            await _controlHorarioContext.CatalogoSeguimiento.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.CasId;
        }

        //actaliza un dato 
        public async Task<long> Update(CatalogoSeguimiento entity)
        {
            _controlHorarioContext.CatalogoSeguimiento.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.CasId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                CatalogoSeguimiento CatalogoSeguimiento = null;
                try
                {
                    foreach (var item in ids)
                    {
                        CatalogoSeguimiento = await _controlHorarioContext.CatalogoSeguimiento.Where(x => x.CasId == item).FirstAsync();
                        _controlHorarioContext.CatalogoSeguimiento.Remove(CatalogoSeguimiento);
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
