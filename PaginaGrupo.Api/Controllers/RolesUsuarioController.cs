using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class RolesUsuarioController : Controller
    {
        private readonly IRolesUsuarioRepository _rolesUsuarioRepository;
        private readonly IMapper _mapper;
        public RolesUsuarioController(IRolesUsuarioRepository rolesUsuarioRepository, IMapper mapper) 
        {
            _rolesUsuarioRepository = rolesUsuarioRepository;
            _mapper= mapper;
    }
        [HttpGet("GetRolesUsuarios")]
        public async Task<IActionResult> GetRolesUsuarios() 
        {

            var rolesUsuario = await _rolesUsuarioRepository.GetRolesUsuarios();
            var rolesUsuarioDto = _mapper.Map<IEnumerable<RolesUsuarioDto>>(rolesUsuario);

            return Ok(rolesUsuarioDto);
        }

        [HttpGet("GetRolUsuario/{id}")]
        public async Task<IActionResult> GetRolUsuario(int id)
        {
            var rolesUsuario = await _rolesUsuarioRepository.GetRolUsuario(id);
            var rolesUsuarioDto = _mapper.Map<RolesUsuarioDto>(rolesUsuario);
            return Ok(rolesUsuarioDto);
           
        }

        [HttpPost("InsertarRolesUsuario")]
        public async Task<IActionResult> InsertarRolesUsuario(RolesUsuarioDto rolesUsuarioDto)
        {


            var rolesUsuario = _mapper.Map<RolesUsuario>(rolesUsuarioDto);
            await _rolesUsuarioRepository.InsertarRolesUsuario(rolesUsuario);
            
            return Ok(rolesUsuario);

        }
    }
}
