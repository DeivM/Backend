
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


namespace Proyecto.Api.Application.Services
{
    public class IndiceSeguimientoService : IIndiceSeguimientoService
    {
        private readonly IIndiceSeguimientoRepository _IndiceSeguimientoRepository;
        private readonly IMapper _mapper;

        public IndiceSeguimientoService(IIndiceSeguimientoRepository IndiceSeguimientoRepository,
            IMapper mapper
            )
        {
            _IndiceSeguimientoRepository = IndiceSeguimientoRepository;
            _mapper = mapper;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _IndiceSeguimientoRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _IndiceSeguimientoRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<IndiceSeguimientoModel> Get(long id)
        {
            return await _IndiceSeguimientoRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<IndiceSeguimientoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _IndiceSeguimientoRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<IndiceSeguimientoData> GetData(long id)
        {
            var data = new IndiceSeguimientoData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(IndiceSeguimientoRequest data)
        {
            //if (await Exist(data.CarNombre)) throw new Exception(Mensajes.ExistsData());
            return await _IndiceSeguimientoRepository.Add(_mapper.Map<IndiceSeguimiento>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(IndiceSeguimientoRequest data)
        {
            return await _IndiceSeguimientoRepository.Update(_mapper.Map<IndiceSeguimiento>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _IndiceSeguimientoRepository.Delete(ids);
        }

       

    }
}
