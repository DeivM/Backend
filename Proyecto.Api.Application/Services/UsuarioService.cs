
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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Proyecto.Api.Business.Models.List;


namespace Proyecto.Api.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IPerfilService _perfilService;
        private readonly IMenuService _MenuService;
        public UsuarioService(IUsuarioRepository UsuarioRepository,
            IMapper mapper,
            IConfiguration config,
            IPerfilService perfilService,
            IMenuService MenuService
            )
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
            _config = config;
            _perfilService=perfilService;
            _MenuService = MenuService;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _UsuarioRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _UsuarioRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<UsuarioModel> Get(long id)
        {
            return await _UsuarioRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<UsuarioModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText)
        {
            return await _UsuarioRepository.GetAll(quantity, page, orderBy, orderType, searchText);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<UsuarioData> GetData(long id, long idEmpresa)
        {
            var data = new UsuarioData();
            data.Perfil = await _perfilService.GetList(idEmpresa);
            if (id > 0)
            {
                data.Data = await Get(id);
            }
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(UsuarioRequest data)
        {
            if (await Exist(data.UsuEmail)) throw new Exception(Mensajes.ExistsData());
            data.UsuPassword = EncriptPassword.HashPassword(data.UsuPassword);
            return await _UsuarioRepository.Add(_mapper.Map<Usuario>(data));
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(UsuarioRequest data)
        {
            //verificamos que el correo no exista
            if (await _UsuarioRepository.Exist(data.UsuId, data.UsuEmail))
                throw new Exception(Mensajes.EmailYaExiste());
            return await _UsuarioRepository.Update(_mapper.Map<Usuario>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _UsuarioRepository.Delete(ids);
        }

        public async Task<List<ListModel>> GetList()
        {
            return await _UsuarioRepository.GetList();
        }

        public async Task<List<ListModel>> GetList(long id)
        {
            return await _UsuarioRepository.GetList(id);
        }



        /// <summary>
        /// registra y genera el token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Token> login(UsuarioRequest data)
        {
            if (data == null || string.IsNullOrEmpty(data.UsuEmail) || string.IsNullOrEmpty(data.UsuPassword))
                throw new Exception(Mensajes.UserIncorrect());
            var usuarioEmail = await _UsuarioRepository.ExisteUsuario(data.UsuEmail);
            /*  if (usuarioEmail==null)
              {
                  await Add(data);
                  usuarioEmail = await _UsuarioRepository.ExisteUsuario(data.UsuEmail);
              }*/
            if (usuarioEmail==null)
            {
                throw new Exception(Mensajes.UsuarioNoExiste());
            }
            if (!EncriptPassword.ValidatePassword(data.UsuPassword, usuarioEmail.UsuPassword))
            {
                throw new Exception(Mensajes.UserIncorrect());
            }
            var menus = await _MenuService.GetMenuRol(usuarioEmail.PerId.Value);
            var dataToken = new Token();
            dataToken.UsuNombre = usuarioEmail.UsuNombres;
            dataToken.UsuApellidos=usuarioEmail.UsuApellidos;
            dataToken.UsuId = usuarioEmail.UsuId;
            dataToken.PerId=usuarioEmail.PerId;
            dataToken.UsuEmail = usuarioEmail.UsuEmail;
            dataToken.expires = DateTime.Now.AddDays(7);
            dataToken.Access_token = GenerateToken(usuarioEmail);
            dataToken.Menu = menus.Item1;
            dataToken.Paths = menus.Item2;
            return dataToken;
        }

        public string GenerateToken(UsuarioModel user)
        {
            //recorremos los permisos
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UsuId.ToString()));
            claims.Add(new Claim("idEmpresa", user.EmpId.ToString()));
            claims.Add(new Claim("idUsuario", user.UsuId.ToString()));
            claims.Add(new Claim("email", user.UsuEmail));
            claims.Add(new Claim("PerId", user.PerId.ToString()));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
           _config["Jwt:Issuer"],
           _config["Jwt:Issuer"],
           expires: DateTime.Now.AddDays(7),
           signingCredentials: creds,
           claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
