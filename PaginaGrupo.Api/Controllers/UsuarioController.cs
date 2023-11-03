using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Infra.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IPasswordService passwordService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        //lo siguiente para documentar
        /// <summary>
        /// Permite generar un usuario, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpPost("InsertarUsuario")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> InsertarUsuario(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Clave = _passwordService.Hash(usuario.Clave);
            await _usuarioService.RegisterUser(usuario);

            //nuevo, se reconvierte a dto para responder
            usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);

        }


        //lo siguiente para documentar
        /// <summary>
        /// permite consultar el listado completo de usuarios, solo para usuario Admin
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UsuarioDtoSinClave>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetUsuarios")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador))]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = _usuarioService.GetUsuarios();
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDtoSinClave>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioDtoSinClave>>(usuariosDto);
            return Ok(response);
        }


        //lo siguiente para documentar
        /// <summary>
        /// permite consultar el listado completo de usuarios, solo para usuario Admin
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDtoSinClave>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetUsuario/{id}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador))]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);
            var usuarioDto = _mapper.Map<UsuarioDtoSinClave>(usuario);
            var response = new ApiResponse<UsuarioDtoSinClave>(usuarioDto);
            return Ok(response);
        }


        //lo siguiente para documentar
        /// <summary>
        /// permite consultar el listado completo de usuarios, solo para usuario Admin
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UsuarioDtoSinClave>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetUsuariosRol")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
       // [Authorize(Roles = nameof(RolType.Administrador))]
        public async Task<IActionResult> GetUsuariosRol(RolType rol)
        {
            var usuarios = await _usuarioService.GetUsuariosRol(rol);
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDtoSinClave>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioDtoSinClave>>(usuariosDto);
            return Ok(response);
        }
    }
}
