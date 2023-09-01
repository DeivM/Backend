
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
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _HorarioRepository;
        private readonly IMapper _mapper;

        public HorarioService(IHorarioRepository HorarioRepository,
            IMapper mapper
            )
        {
            _HorarioRepository = HorarioRepository;
            _mapper = mapper;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _HorarioRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _HorarioRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<HorarioModel> Get(long id)
        {
            return await _HorarioRepository.Get(id);
        }




        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<HorarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _HorarioRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<HorarioData> GetData(long id)
        {
            var data = new HorarioData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetList(long id, DateTime fecha, TimeSpan hora)
        {
          return  await _HorarioRepository.GetList(id, fecha, hora);
        }



        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(HorarioRequest data)
        {
            //if (await Exist(data.CarNombre)) throw new Exception(Mensajes.ExistsData());
            return await _HorarioRepository.Add(_mapper.Map<Horario>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(HorarioRequest data)
        {
            return await _HorarioRepository.Update(_mapper.Map<Horario>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _HorarioRepository.Delete(ids);
        }

       

    }
}
