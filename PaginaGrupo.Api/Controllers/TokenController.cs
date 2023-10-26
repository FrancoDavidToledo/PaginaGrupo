using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaginaGrupo.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaginaGrupo.Api.Controllers
{
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost("autenticas")]
        public IActionResult Autentication(UserLogin login)
        {
            //si es un usuario valido
            if (IsValidUser(login))
            {
                var token = GenerateToken();
            return Ok(new {token});
            }

            return NotFound();
        }

        private bool IsValidUser(UserLogin login)
        {
            return true;
        }

        private string GenerateToken()
        {

            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);


            //claims
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, "Franco Toledo"),
                new Claim(ClaimTypes.Email, "ftoledo@gmail.com"),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            //payload
            var payload = new JwtPayload
            (
              _configuration["Autentication:Issuer"],
              _configuration["Autentication:Audience"],
              claims,
              DateTime.Now,
              DateTime.UtcNow.AddMinutes(2)
            );

            var token = new JwtSecurityToken(header,payload);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
