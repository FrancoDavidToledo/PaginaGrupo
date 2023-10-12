using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper) 
        {
            _usuarioRepository = usuarioRepository;
            _mapper= mapper;
    }
        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> GetUsuarios() 
        {

            var usuario = await _usuarioRepository.GetUsuarios();
            var usuarioDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuario);

            return Ok(usuarioDto);
        }

        [HttpGet("GetUsuario/{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetUsuario(id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(usuarioDto);
           
        }

        [HttpPost("InsertarUsuario")]
        public async Task<IActionResult> InsertarUsuario(UsuarioDto usuarioDto)
        {


            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.InsertarUsuario(usuario);
            
            return Ok(usuario);

        }
    }
}
