
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Proyecto.Api.Business.helpers;
using Proyecto.Api.Business.Models;
using WebApi.GlobalErrorHandling;
using Proyecto.Api.Application.Contracts.Services;
using Proyecto.Api.Business.Request;
using System.Linq;
using System;
using Proyecto.Api.Application.Services;
using Proyecto.Api.Business.Models.List;

namespace WebApi.Controllers
{
    //[Authorize]
    public class UsuarioController : BaseApiController
    {
        private readonly IUsuarioService _UsuarioService;
        public UsuarioController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
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
        [ResponseType(typeof(RespuestaModel<ListadoPaginadoModel<UsuarioModel>>))]
        [HttpGet]
        public async Task<IActionResult> GetAll( int quantity = 10, int page = 0, string orderby = "UsuId", string ascdesc = "descending", string search = null)
        {
            var resultado = new RespuestaModel<ListadoPaginadoModel<UsuarioModel>>
            {
                Data = await _UsuarioService.GetAll(quantity, page, orderby, ascdesc, search)
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
        [ResponseType(typeof(RespuestaModel<UsuarioData>))]
        [HttpGet]
        [Route("GetData")]

        public async Task<IActionResult> GetData(int id = 0)
        {
            long EmpId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "idEmpresa").Value);
            var resultado = new RespuestaModel<UsuarioData>
            {
                Data = await _UsuarioService.GetData(id, EmpId)
            };
            if (id > 0 && resultado.Data != null && resultado.Data.Data == null)
            {
                return NotFound(new CodeErrorResponse(404, Mensajes.NofountData()));
            }
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
        [ResponseType(typeof(RespuestaModel<UsuarioData>))]
        [HttpGet]
        [Route("GetList")]

        public async Task<IActionResult> GetList(long id = 0)
        {
  
            return Ok(await _UsuarioService.GetList(id));
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
        public async Task<IActionResult> Post(UsuarioRequest data)
        {
            var resultado = new RespuestaModel<long?>
            {
                Data = await _UsuarioService.Add(data)
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
        public async Task<IActionResult> Update(int id, UsuarioRequest data)
        {
            data.UsuId = id;
            var resultado = new RespuestaModel<long?>
            {
                Data = await _UsuarioService.Update(data)
            };
            return Ok(resultado);
        }

        /// <summary>
        /// api para crear un nuevo registro y retorna su identificador
        /// </summary>
        /// <param name="data">Datos del nuevo registro</param>
        /// <remarks>api para crear un nuevo data</remarks>
        //[ProducesResponseType(200)]//Proceso exitoso
        //[ProducesResponseType(400)]//Error en la Data enviados
        //[ProducesResponseType(401)]//Token inválido
        //[ProducesResponseType(404)]//Datos no encontrado
        //[ProducesResponseType(500)]//Error del servido servidor
        //[ResponseType(typeof(RespuestaModel<long?>))]
        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login(UsuarioRequest data)
        //{
        //    var resultado = new RespuestaModel<Token>
        //    {
        //        Data = await _UsuarioService.login(data)
        //    };
        //    return Ok(resultado);
        //}


    }
}
