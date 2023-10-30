﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaginaGrupo.Api.Controllers
{
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration, IUsuarioService usuarioService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _passwordService = passwordService;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autentication(UserLogin login)
        {
            //si es un usuario valido
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<(bool, Usuario)> IsValidUser(UserLogin login)
        {
            var user = await _usuarioService.GetLoginByCredentials(login);
            var isValid = _passwordService.Check(user.Clave, login.Clave);
            return (isValid, user);
        }

        private string GenerateToken(Usuario usuario)
        {

            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
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
              _configuration["Autentication:Issuer"],
              _configuration["Autentication:Audience"],
              claims,
              DateTime.Now,
              DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
