
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Application.Contracts.Services;
using Proyecto.Api.Business.helpers;
using Proyecto.Api.Business.Models;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Request;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Microsoft.Extensions.Configuration;
using Proyecto.Api.Business.Models.List;

namespace Proyecto.Api.Application.Services
{
    public class CatalogoSeguimientoService : ICatalogoSeguimientoService
    {
        private readonly ICatalogoSeguimientoRepository _CatalogoSeguimientoRepository;
        private readonly IMapper _mapper;
        private readonly IEspecialidadeService _especialidadService;
        public CatalogoSeguimientoService(ICatalogoSeguimientoRepository CatalogoSeguimientoRepository,
            IMapper mapper,
            IEspecialidadeService especialidadService
            )
        {
            _CatalogoSeguimientoRepository = CatalogoSeguimientoRepository;
            _mapper = mapper;
            _especialidadService = especialidadService;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _CatalogoSeguimientoRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _CatalogoSeguimientoRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<CatalogoSeguimientoModel> Get(long id)
        {
            return await _CatalogoSeguimientoRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<CatalogoSeguimientoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _CatalogoSeguimientoRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<CatalogoSeguimientoData> GetData(long id)
        {
            var data = new CatalogoSeguimientoData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            data.MedicosEspecialidad = await _especialidadService.GetList();
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(CatalogoSeguimientoRequest data)
        {
            if (await Exist(data.CasNombre)) throw new Exception(Mensajes.ExistsData());
            return await _CatalogoSeguimientoRepository.Add(_mapper.Map<CatalogoSeguimiento>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(CatalogoSeguimientoRequest data)
        {
            return await _CatalogoSeguimientoRepository.Update(_mapper.Map<CatalogoSeguimiento>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _CatalogoSeguimientoRepository.Delete(ids);
        }

        public async Task<List<ListModel>> GetList(long id)
        {
            return await _CatalogoSeguimientoRepository.GetList(id);
        }


    }
}
