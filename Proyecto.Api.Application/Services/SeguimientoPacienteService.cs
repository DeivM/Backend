
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
    public class SeguimientoPacienteService : ISeguimientoPacienteService
    {
        private readonly ISeguimientoPacienteRepository _SeguimientoPacienteRepository;
        private readonly IMapper _mapper;
        private readonly ICatalogoSeguimientoService _seguimientoService;
        private readonly ICitaService _citaService;

        public SeguimientoPacienteService(ISeguimientoPacienteRepository SeguimientoPacienteRepository,
            IMapper mapper,
            ICatalogoSeguimientoService seguimientoService,
            ICitaService citaService
            )
        {
            _SeguimientoPacienteRepository = SeguimientoPacienteRepository;
            _mapper = mapper;
            _seguimientoService = seguimientoService;
            _citaService = citaService;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _SeguimientoPacienteRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _SeguimientoPacienteRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<SeguimientoPacienteModel> Get(long id)
        {
            return await _SeguimientoPacienteRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<SeguimientoPacienteModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _SeguimientoPacienteRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<SeguimientoPacienteData> GetData(long id)
        {
            var data = new SeguimientoPacienteData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            data.Preguntas = await _seguimientoService.GetList(id);
           // data.Citas = await _citaService.
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(SeguimientoPacienteRequest data)
        {
            if (await Exist(data.SepObservacion)) throw new Exception(Mensajes.ExistsData());
            return await _SeguimientoPacienteRepository.Add(_mapper.Map<SeguimientoPaciente>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(SeguimientoPacienteRequest data)
        {
            return await _SeguimientoPacienteRepository.Update(_mapper.Map<SeguimientoPaciente>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _SeguimientoPacienteRepository.Delete(ids);
        }

       

    }
}
