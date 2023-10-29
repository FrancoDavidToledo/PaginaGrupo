using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;

namespace PaginaGrupo.Api.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper) 
        {
            _usuarioService = usuarioService;
            _mapper= mapper;
        }

        [HttpPost("InsertarUsuario")]
        public async Task<IActionResult> InsertarUsuario(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioService.RegisterUser(usuario);

            //nuevo, se reconvierte a dto para responder
            usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);

        }
    }
}
