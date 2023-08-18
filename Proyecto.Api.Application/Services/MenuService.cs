
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
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _MenuRepository;
        private readonly IMapper _mapper;
        public MenuService(IMenuRepository MenuRepository,
            IMapper mapper
            )
        {
            _MenuRepository = MenuRepository;
            _mapper = mapper;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _MenuRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _MenuRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<MenuModel> Get(long id)
        {
            return await _MenuRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MenuModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _MenuRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

        /// <summary>
        /// busqueda los perfiles
        /// </summary>
        /// <returns>retorna los datos en un dto</returns>
        public async Task<List<ListModel>> GetListMenuPadre()
        {
            return await _MenuRepository.GetListMenuPadre();
        }

        /// <summary>
        /// lista los menus que tengan link
        /// </summary>
        /// <returns></returns>
        public async Task<List<ListModel>> GetListMenuConPadre()
        {
            return await _MenuRepository.GetListMenuConPadre();
        }

        /// <summary>
        /// obtiene los menus por perfil
        /// </summary>
        /// <param name="id">ide del rol</param>
        /// <returns>retorna una tuple</returns>
        public async Task<Tuple<List<MenuUsuario>, List<string>>> GetMenuRol(long id)
        {
            return await _MenuRepository.GetMenuRol(id);
        }


        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<MenuData> GetData(long id)
        {
            var data = new MenuData();
            data.MenuPadre = await GetListMenuPadre();
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(MenuRequest data)
        {
            if (await Exist(data.MenNombre)) throw new Exception(Mensajes.ExistsData());
            return await _MenuRepository.Add(_mapper.Map<Menu>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(MenuRequest data)
        {
            return await _MenuRepository.Update(_mapper.Map<Menu>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _MenuRepository.Delete(ids);
        }

       

    }
}
