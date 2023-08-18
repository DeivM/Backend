
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Proyecto.Api.Business.helpers;
using Proyecto.Api.Business.Models;
using WebApi.GlobalErrorHandling;
using Proyecto.Api.Application.Contracts.Services;
using Proyecto.Api.Business.Request;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    public class MenuPerfilController : BaseApiController
    {
        private readonly IMenuPerfilService _TipoPermisoService;
        public MenuPerfilController(IMenuPerfilService TipoPermisoService)
        {
            _TipoPermisoService = TipoPermisoService;
        }

        /// <summary>
        /// api para obtener todos los datos
        /// </summary>
        /// <param name="quantity">Fiitidad de elementos a obtener</param>
        /// <param name="page">Número de página de resultados</param>
        /// <param name="orderby">Campo por el que se desea ordenar</param>
        /// <param name="ascdesc">ordena ascendente o descendente</param>
        /// <param name="search">filtra la búsqueda</param>
        [ProducesResponseType(200)]//Proceso exitoso
        [ProducesResponseType(400)]//Error en los datos enviados
        [ProducesResponseType(401)]//Token inválido
        [ProducesResponseType(404)]//Datos no encontrados
        [ProducesResponseType(500)]//Error del servidor
        [ResponseType(typeof(RespuestaModel<ListadoPaginadoModel<MenuPerfilModel>>))]
        [HttpGet]
        public async Task<IActionResult> GetAll( int quantity = 10, int page = 0, string orderby = "MepId", string ascdesc = "descending", string search = null)
        {
            var resultado = new RespuestaModel<ListadoPaginadoModel<MenuPerfilModel>>
            {
                Data = await _TipoPermisoService.GetAll(quantity, page, orderby, ascdesc, search)
            };
            return Ok(resultado);
        }

        /// <summary>
        /// api para obtener todos los datos para el formulario 
        /// </summary>
        /// <param name="id">id del dato que desea obtener</param>
        [ProducesResponseType(200)]//Proceso exitoso
        [ProducesResponseType(400)]//Error en los Data enviados
        [ProducesResponseType(401)]//Token inválido
        [ProducesResponseType(404)]//Datos no encontrado
        [ProducesResponseType(500)]//Error del servido servidor                         
        [ResponseType(typeof(RespuestaModel<MenuPerfilData>))]
        [HttpGet]
        [Route("GetData")]

        public async Task<IActionResult> GetData(int id = 0)
        {
            long EmpId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "idEmpresa").Value);
            var resultado = new RespuestaModel<MenuPerfilData>
            {
                Data = await _TipoPermisoService.GetData(id, EmpId)
            };
            if (id > 0 && resultado.Data != null && resultado.Data.Data == null)
            {
                return NotFound(new CodeErrorResponse(404, Mensajes.NofountData()));
            }
            return Ok(resultado);
        }
      

        /// <summary>
        /// api para crear un nuevo registro y retorna su identificador
        /// </summary>
        /// <param name="data">Datos del nuevo registro</param>
        /// <remarks>api para crear un nuevo data</remarks>
        [ProducesResponseType(200)]//Proceso exitoso
        [ProducesResponseType(400)]//Error en la Data enviados
        [ProducesResponseType(401)]//Token inválido
        [ProducesResponseType(404)]//Datos no encontrado
        [ProducesResponseType(500)]//Error del servido servidor
        [ResponseType(typeof(RespuestaModel<long?>))]
        [HttpPost]
        public async Task<IActionResult> Post(MenuPerfilRequest data)
        {
            var resultado = new RespuestaModel<long?>
            {
                Data = await _TipoPermisoService.Add(data)
            };
            return Ok(resultado);
        }


        /// <summary>
        /// api para editar un data por su id
        /// </summary>
        /// <param name="id">id de la data que se desea editar</param>
        /// <param name="data">Nuevos Data de la data</param>
        /// <remarks>api para editar un data por su identificador</remarks>
        [ProducesResponseType(200)]//Proceso exitoso
        [ProducesResponseType(400)]//Error en la Data enviados
        [ProducesResponseType(401)]//Token inválido
        [ProducesResponseType(404)]//Datos no encontrado
        [ProducesResponseType(500)]//Error del servido servidor
        [ResponseType(typeof(RespuestaModel<object>))]
        [HttpPut]
        public async Task<IActionResult> Update(int id, MenuPerfilRequest data)
        {
            data.MepId = id;
            var resultado = new RespuestaModel<long?>
            {
                Data = await _TipoPermisoService.Update(data)
            };
            return Ok(resultado);
        }

        /// <summary>
        /// api para eliminar datos
        /// </summary>
        /// <param name="ids">ids de los datos que se desean eliminar</param>
        /// <remarks>api para eliminar varios items por su id</remarks>
        [ProducesResponseType(200)]//Proceso exitoso
        [ProducesResponseType(400)]//Error en la Data enviados
        [ProducesResponseType(401)]//Token inválido
        [ProducesResponseType(404)]//Datos no encontrado
        [ProducesResponseType(500)]//Error del servido servidor
        [ResponseType(typeof(RespuestaModel<object>))]
        [HttpDelete]
        public async Task<IActionResult> Delete(List<long> ids)
        {
            var resultado = new RespuestaModel<object>();
            await _TipoPermisoService.Delete(ids);
            return Ok(resultado);    
        }


    }
}
