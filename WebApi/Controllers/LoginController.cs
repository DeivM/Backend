
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
using Proyecto.Api.Application.Services;

namespace WebApi.Controllers
{
 
    public class LoginController : BaseApiController
    {
        private readonly IUsuarioService _UsuarioService;
        public LoginController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
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
        [Route("Login")]
        public async Task<IActionResult> Login(UsuarioRequest data)
        {
            var resultado = new RespuestaModel<Token>
            {
                Data = await _UsuarioService.login(data)
            };
            return Ok(resultado);
        }

    }
}
