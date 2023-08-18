
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
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _EspecialidadeRepository;
        private readonly IMapper _mapper;

        public EspecialidadeService(IEspecialidadeRepository EspecialidadeRepository,
            IMapper mapper
            )
        {
            _EspecialidadeRepository = EspecialidadeRepository;
            _mapper = mapper;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _EspecialidadeRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _EspecialidadeRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<EspecialidadeModel> Get(long id)
        {
            return await _EspecialidadeRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<EspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _EspecialidadeRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<EspecialidadeData> GetData(long id)
        {
            var data = new EspecialidadeData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(EspecialidadeRequest data)
        {
            if (await Exist(data.EspNombre)) throw new Exception(Mensajes.ExistsData());
            return await _EspecialidadeRepository.Add(_mapper.Map<Especialidade>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(EspecialidadeRequest data)
        {
            return await _EspecialidadeRepository.Update(_mapper.Map<Especialidade>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _EspecialidadeRepository.Delete(ids);
        }

        public async Task<List<ListModel>> GetList()
        {
            return await _EspecialidadeRepository.GetList();
        }

    }
}
