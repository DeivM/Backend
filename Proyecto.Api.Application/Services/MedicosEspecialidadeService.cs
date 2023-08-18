
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
    public class MedicosEspecialidadeService : IMedicosEspecialidadeService
    {
        private readonly IMedicosEspecialidadeRepository _MedicosEspecialidadeRepository;
        private readonly IMapper _mapper;
        private readonly IMedicoService _medicoService;
        private readonly IEspecialidadeService _especialidadService;

        public MedicosEspecialidadeService(IMedicosEspecialidadeRepository MedicosEspecialidadeRepository,
            IMapper mapper,
            IMedicoService medicoService,
            IEspecialidadeService especialidadService
            )
        {
            _MedicosEspecialidadeRepository = MedicosEspecialidadeRepository;
            _mapper = mapper;
            _medicoService= medicoService;
            _especialidadService = especialidadService;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _MedicosEspecialidadeRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _MedicosEspecialidadeRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<MedicosEspecialidadeModel> Get(long id)
        {
            return await _MedicosEspecialidadeRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MedicosEspecialidadeModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _MedicosEspecialidadeRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<MedicosEspecialidadeData> GetData(long id)
        {
            var data = new MedicosEspecialidadeData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            data.Medicos = await _medicoService.GetList();
            data.MedicosEspecialidad = await _especialidadService.GetList();
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(MedicosEspecialidadeRequest data)
        {
            //if (await Exist(data.CarNombre)) throw new Exception(Mensajes.ExistsData());
            return await _MedicosEspecialidadeRepository.Add(_mapper.Map<MedicosEspecialidade>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(MedicosEspecialidadeRequest data)
        {
            return await _MedicosEspecialidadeRepository.Update(_mapper.Map<MedicosEspecialidade>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _MedicosEspecialidadeRepository.Delete(ids);
        }

       

    }
}
