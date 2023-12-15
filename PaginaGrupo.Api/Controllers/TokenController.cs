using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        public TokenController(IConfiguration configuration, IUsuarioService usuarioService, IPasswordService passwordService, IMapper mapper)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        //lo siguiente para documentar
        /// <summary>
        /// Realiza la validacion de correo y contraseña, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpPost("AutenticarLogin")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]

        public async Task<IActionResult> Autentication(UserLogin login)
        {
            var response = new ResponseDTO<UsuarioSinClaveTokenDto>();
            //si es un usuario valido
            var validation = await IsValidUser(login);
            if (validation.Item1)
            { 
                var token = GenerateToken(validation.Item2);
                var unidadDto = _mapper.Map<UsuarioSinClaveTokenDto>(validation.Item2);
                unidadDto.Token = token;
                response.EsCorrecto = true;
                response.Resultado = unidadDto;

                return Ok(response);
            }

            response.EsCorrecto = false;
            response.Mensaje = "Error al realizar login";
            return Ok(response);
        }

        private async Task<(bool, Usuario)> IsValidUser(UserLogin login)
        {
            var user = await _usuarioService.GetLoginByCredentials(login);
            var isValid= false;
            if (user != null)
            {
                isValid = _passwordService.Check(user.Clave, login.Clave);
            }
            return (isValid, user);
        }

        private string GenerateToken(Usuario usuario)
        {

            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);


            //claims
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Rol.ToString())
            };

            //payload
            var payload = new JwtPayload
            (
              _configuration["Jwt:Issuer"],
              _configuration["Jwt:Audience"],
              claims,
              DateTime.Now,
              DateTime.UtcNow.AddMinutes(60)
            );

            var token = new JwtSecurityToken(header, payload);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
