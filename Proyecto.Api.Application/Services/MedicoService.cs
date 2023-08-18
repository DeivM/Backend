
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
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _MedicoRepository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository MedicoRepository,
            IMapper mapper
            )
        {
            _MedicoRepository = MedicoRepository;
            _mapper = mapper;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _MedicoRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _MedicoRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<MedicoModel> Get(long id)
        {
            return await _MedicoRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MedicoModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _MedicoRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

        public async Task<List<ListModel>> GetList(long id)
        {
            return await _MedicoRepository.GetList(id);
        }

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<MedicoData> GetData(long id)
        {
            var data = new MedicoData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(MedicoRequest data)
        {
            if (await Exist(data.MedNombres)) throw new Exception(Mensajes.ExistsData());
            return await _MedicoRepository.Add(_mapper.Map<Medico>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(MedicoRequest data)
        {
            return await _MedicoRepository.Update(_mapper.Map<Medico>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _MedicoRepository.Delete(ids);
        }

        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetList()
        {
            return await _MedicoRepository.GetList();
        }

    }
}
