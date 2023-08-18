
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Api.Business.common.extension;
using Proyecto.Api.Business.Models;
using Proyecto.Api.DataAccess.Contracts;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.Business.Models.List;

namespace Proyecto.Api.DataAccess.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IProyectoContext _controlHorarioContext;
        public MenuRepository(IProyectoContext controlHorarioContext)
        {
            _controlHorarioContext = controlHorarioContext;
        }
        //Valida si existe datos por id
        public async Task<bool> Exist(long id)
        {
            var result = 0;
            result = await _controlHorarioContext.Menu.CountAsync(x => x.MenId == id);
            return result > 0;
        } 
        //Valida si existe datos por nombre
        public async Task<bool> Exist(string nombre)
        {
            var result = 0;
            result = await _controlHorarioContext.Menu.CountAsync(x => x.MenNombre.ToUpper() == nombre.ToUpper());
            return result > 0;
        }


        //obtiene un solo dato por la clave principal id
        public async Task<MenuModel> Get(long id)
        {
            return await _controlHorarioContext.Menu
                .Where(x => x.MenId == id)
                .Select(x => new MenuModel
                {
                    MenId = x.MenId,
                    MenNombre = x.MenNombre,
                    MenMenId = x.MenMenId,
                    MenTipo = x.MenTipo,
                    MenIcono = x.MenIcono,
                    MenUrl = x.MenUrl,
                    MenOrden = x.MenOrden,
                    MenCodigoUnico = x.MenCodigoUnico,
                    MenEstado = x.MenEstado,
                }).FirstOrDefaultAsync();
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los dias primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<MenuModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            var result = new ListadoPaginadoModel<MenuModel>();
            var query = _controlHorarioContext.Menu.Select(x => new MenuModel()
            {
                MenId = x.MenId,
                MenNombrePadre=x.MenMen.MenNombre,
                MenNombre = x.MenNombre,
                MenMenId = x.MenMenId,
                MenTipo = x.MenTipo,
                MenIcono = x.MenIcono,
                MenUrl = x.MenUrl,
                MenOrden = x.MenOrden,
                MenCodigoUnico = x.MenCodigoUnico,
                MenEstado = x.MenEstado,
            });

            //buscar por texto
            if (searchText != null && searchText.Length > 0)
            {
                query = query.Where(x =>
                      x.MenNombre.Contains(searchText)
                      || x.MenNombrePadre.Contains(searchText)
                      || x.MenTipo.Contains(searchText)
                      || x.MenIcono.Contains(searchText)
                      || x.MenUrl.Contains(searchText)
                      || x.MenOrden.ToString().Contains(searchText)
                );
            }
            // total de items
            result.FiitidadElementos = query.Count();
            // Ordenamiento y paginado
            result.Elementos = await query.OrderByPropertyOrField(orderBy, orderType)
                .Skip(page * quantity)
                .Take(quantity)
                .ToListAsync();
            return result;
        }

        //Lista los datos para mostrar en un select
        public async Task<List<ListModel>> GetListMenuPadre()
        {
            return await _controlHorarioContext.Menu.Where(x=>x.MenEstado==1  && (x.MenUrl==null || x.MenUrl==""))
                .Select(x => new ListModel
                {
                    id = x.MenId,
                    Nombre = x.MenNombre
                }).ToListAsync();
        }

     /// <summary>
     /// lista los menus que tengan link
     /// </summary>
     /// <returns></returns>
        public async Task<List<ListModel>> GetListMenuConPadre()
        {
            return await _controlHorarioContext.Menu.Where(x =>x.MenEstado==1 && x.MenUrl!=null && x.MenUrl!="").OrderBy(x=>x.MenNombre)
                .Select(x => new ListModel
                {
                    id = x.MenId,
                    Nombre = x.MenNombre
                }).ToListAsync();
        }

        /// <summary>
        /// obtiene los menus por perfil
        /// </summary>
        /// <param name="id">ide del rol</param>
        /// <returns>retorna una tuple</returns>
        public async   Task<Tuple<List<MenuUsuario>, List<string>> > GetMenuRol(long id)
        {
            var menus = await _controlHorarioContext.Menu.Where(x=>x.MenEstado==1)
                .Select(x => new MenuModel()
            {
                MenId = x.MenId,
                MenNombre = x.MenNombre!=null? x.MenNombre:"",
                MenMenId = x.MenMenId,
               // MenTipo = x.MenTipo,
                MenIcono = !string.IsNullOrEmpty( x.MenIcono) ? x.MenIcono : "mdi mdi-adjust",
                MenUrl = x.MenUrl != null ? x.MenUrl : "",
                MenOrden = x.MenOrden,
               // MenCodigoUnico = x.MenCodigoUnico,
                MenEstado = x.MenEstado,
            }).ToListAsync();

            var menusRecorrido = menus.OrderBy(x=>x.MenOrden).Select(x => new MenuModel()
            {
                MenId = x.MenId,
                MenMenId = x.MenMenId,
                MenNombre = x.MenNombre,
                //MenTipo = x.MenTipo,
                MenIcono = x.MenIcono,
                MenUrl = x.MenUrl,
                MenOrden = x.MenOrden,
                menusHijos = MenusHijos(menus, x.MenId)
            }).ToList();

            var menusPerfiles = await _controlHorarioContext.MenuPerfil.Where(x => x.MepEstado == 1 && x.PerId==id)
               .Select(x =>x.MenId).ToListAsync();

           var menusNuevos =new List<MenuUsuario>();
            /* menusNuevos.Add(new MenuUsuario
             {
                 title = "Inicio",
                 icon = null,
                 path = "starter"
             });*/

            List<string> paths = await _controlHorarioContext.MenuPerfil
                .Where(x => x.MepEstado == 1 && x.Men.MenEstado==1 && x.PerId == id && !string.IsNullOrEmpty( x.Men.MenUrl))
               .Select(x => x.Men.MenUrl).ToListAsync();


            foreach (var item in menusRecorrido.Where(x=>x.MenMenId==null).OrderBy(x=>x.MenOrden))
            {
                var menusNuevosHijosVacios = new List<MenuUsuario>();
                var menusNuevo = new MenuUsuario();

                if (item.menusHijos != null && item.menusHijos.Count>0)
                {
                    //menusNuevo.MenId = item.MenId;
                   // menusNuevo.MenMenId = item.MenMenId;
                    menusNuevo.title = item.MenNombre;
                  //  menusNuevo.MenTipo = item.MenTipo;
                    menusNuevo.icon = item.MenIcono;
                    menusNuevo.path = item.MenUrl;
                  //  menusNuevo.MenOrden = item.MenOrden;
                    menusNuevo.submenu = MenusHijosNuevo(item.menusHijos.OrderBy(x=>x.MenOrden).ToList(), menusPerfiles);

                    menusNuevos.Add(menusNuevo);
                }
                else if (menusPerfiles.Contains( item.MenId))
                {
                    //menusNuevo.MenId = item.MenId;
                    // menusNuevo.MenMenId = item.MenMenId;
                    menusNuevo.title = item.MenNombre;
                    //  menusNuevo.MenTipo = item.MenTipo;
                    menusNuevo.icon = item.MenIcono;
                    menusNuevo.path = item.MenUrl;
                    //  menusNuevo.MenOrden = item.MenOrden;
                      menusNuevo.submenu = menusNuevosHijosVacios;
                    menusNuevos.Add(menusNuevo);
                }
                
            }

            return Tuple.Create<List<MenuUsuario>, List<string>>(menusNuevos, paths);
        }



        public List<MenuUsuario> MenusHijosNuevo(List<MenuModel> menusHijos,  List<long?> idsMenus)
        {
            var menusNuevos = new List<MenuUsuario>();
            var menusNuevosHijosVacios = new List<MenuUsuario>();
            foreach (var item in menusHijos)
            {
                var menusNuevo = new MenuUsuario();
                if (item.menusHijos!=null && item.menusHijos.Count > 0)
                {
                  //  menusNuevo.MenId = item.MenId;
                    menusNuevo.title = item.MenNombre;
                   // menusNuevo.MenTipo = item.MenTipo;
                    menusNuevo.icon = item.MenIcono;
                    menusNuevo.path = item.MenUrl;
                  //  menusNuevo.MenOrden = item.MenOrden;
                    menusNuevo.submenu = MenusHijosNuevo(item.menusHijos.OrderBy(x=>x.MenOrden).ToList(),  idsMenus);

                    menusNuevos.Add(menusNuevo);
                }
                else if (idsMenus.Contains(item.MenId))
                {
                    //  menusNuevo.MenId = item.MenId;
                    menusNuevo.title = item.MenNombre;
                    // menusNuevo.MenTipo = item.MenTipo;
                    menusNuevo.icon = item.MenIcono;
                    menusNuevo.path = item.MenUrl;
                    menusNuevo.submenu = menusNuevosHijosVacios;
                    //  menusNuevo.MenOrden = item.MenOrden;
                    menusNuevos.Add(menusNuevo);
                }

            }
            return menusNuevos;
        }



        public List<MenuModel> MenusHijos(List<MenuModel>menusHijos, long id)
        {
            return menusHijos.Where(x=>x.MenMenId==id).OrderBy(x=>x.MenOrden).Select(x => new MenuModel()
            {
                MenId = x.MenId,
                MenMenId =x.MenMenId,
            MenNombre = x.MenNombre,
                MenTipo = x.MenTipo,
                MenIcono = x.MenIcono,
                MenUrl = x.MenUrl,
                MenOrden = x.MenOrden,
                menusHijos = MenusHijos(menusHijos, x.MenId)
            }).ToList();
        }

        //registra los datos a la base
        public async Task<long> Add(Menu entity)
        {
            await _controlHorarioContext.Menu.AddAsync(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MenId;
        }

        //actaliza un dato 
        public async Task<long> Update(Menu entity)
        {
            _controlHorarioContext.Menu.Update(entity);
            await _controlHorarioContext.SaveChangesAsync();
            return entity.MenId;
        }

        //elimina una lista de datos seleccionados por item principal
        public async Task<long> Delete(List<long> ids)
        {
            using (var tran = _controlHorarioContext.Database.BeginTransaction())
            {
                Menu carrera = null;
                try
                {
                    foreach (var item in ids)
                    {
                        carrera = await _controlHorarioContext.Menu.Where(x => x.MenId == item).FirstAsync();
                        _controlHorarioContext.Menu.Remove(carrera);
                    }
                    await _controlHorarioContext.SaveChangesAsync();
                    await tran.CommitAsync();
                    return 1;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    string messaje = e.Message;
                    if (e.InnerException != null)
                    {
                        if (e.InnerException.InnerException != null)
                        {
                            messaje += e.InnerException.InnerException.Message + " ";
                        }
                        else
                        {
                            messaje += e.InnerException.Message + " ";
                        }
                    }
                    throw new Exception(messaje);
                }
            }
        }
    }
}
