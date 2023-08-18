
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Application.Contracts.Services;
using Proyecto.Api.Business.Models;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Request;
using Proyecto.Api.Business.Models.List;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.Business.helpers;

namespace Proyecto.Api.Application.Services
{
    public class MenuPerfilService : IMenuPerfilService
    {
        private readonly IMenuPerfilRepository _MenuPerfilRepository;
        private readonly IMapper _mapper;
        private readonly IMenuService _MenuService;
        private readonly IPerfilService _PerfilService;
        public MenuPerfilService(IMenuPerfilRepository MenuPerfilRepository,
            IMapper mapper,
            IMenuService MenuService,
            IPerfilService PerfilService
            )
        {
            _MenuPerfilRepository = MenuPerfilRepository;
            _mapper = mapper;
            _MenuService = MenuService;
            _PerfilService = PerfilService;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _MenuPerfilRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _MenuPerfilRepository.Exist(id);
        }

        /// <summary>
        /// valida si ya existe datos por perfil y menu
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public async Task<bool> Exist(long idPerfil, long idMenu)
        {
            return await _MenuPerfilRepository.Exist(idPerfil, idMenu);
        }

        /// <summary>
        /// valida si ya existe datos por perfil y menu y diferente del id
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public async Task<bool> Exist(long id, long idPerfil, long idMenu)
        {
            return await _MenuPerfilRepository.Exist(id, idPerfil, idMenu);
        }
    //servicio que obtiene un solo dato por la clave principal id
    public async Task<MenuPerfilModel> Get(long id)
        {
            return await _MenuPerfilRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MenuPerfilModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _MenuPerfilRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

        /// <summary>
        /// busqueda los perfiles
        /// </summary>
        /// <returns>retorna los datos en un dto</returns>
        public async Task<List<ListModel>> GetList()
        {
            return await _MenuPerfilRepository.GetList();
        }

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<MenuPerfilData> GetData(long id, long idEmpresa)
        {
            var data = new MenuPerfilData();
            data.Perfil = await _PerfilService.GetList(idEmpresa);
            data.Menu = await _MenuService.GetListMenuConPadre();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(MenuPerfilRequest data)
        {
           if (await Exist(data.PerId.Value, data.MenId.Value)) throw new Exception(Mensajes.ExistsData());
            return await _MenuPerfilRepository.Add(_mapper.Map<MenuPerfil>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(MenuPerfilRequest data)
        {
            if (await Exist(data.MepId,data.PerId.Value, data.MenId.Value)) throw new Exception(Mensajes.ExistsData());
            return await _MenuPerfilRepository.Update(_mapper.Map<MenuPerfil>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _MenuPerfilRepository.Delete(ids);
        }

       

    }
}
