
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
using Proyecto.Api.Business.Models.List;

namespace Proyecto.Api.Application.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _PerfilRepository;
        private readonly IMapper _mapper;

        public PerfilService(IPerfilRepository PerfilRepository,
            IMapper mapper
            )
        {
            _PerfilRepository = PerfilRepository;
            _mapper = mapper;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _PerfilRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _PerfilRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<PerfilModel> Get(long id)
        {
            return await _PerfilRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<PerfilModel>> GetAll(long idEmpresa, int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _PerfilRepository.GetAll(idEmpresa, quantity, page, orderBy, orderType, searchText);
        }

        /// <summary>
        /// busqueda los perfiles
        /// </summary>
        /// <returns>retorna los datos en un dto</returns>
        public async Task<List<ListModel>> GetList()
        {
            return await _PerfilRepository.GetList();
        }

        /// <summary>
        /// busqueda por el id de la empresa
        /// </summary>
        /// <param name="idEmpresa">id de la empresa</param>
        /// <returns>retorna los datos en un dto</returns>
        public async Task<List<ListModel>> GetList(long idEmpresa)
        {
            return await _PerfilRepository.GetList(idEmpresa);
        }

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<PerfilData> GetData(long id)
        {
            var data = new PerfilData();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(PerfilRequest data)
        {
            if (await Exist(data.PerNombre)) throw new Exception(Mensajes.ExistsData());
            return await _PerfilRepository.Add(_mapper.Map<Perfil>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(PerfilRequest data)
        {
            return await _PerfilRepository.Update(_mapper.Map<Perfil>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _PerfilRepository.Delete(ids);
        }

       

    }
}
