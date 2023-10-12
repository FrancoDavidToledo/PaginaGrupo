using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolesRepository _rolRepository;
        private readonly IMapper _mapper;
        public RolController(IRolesRepository rolRepository, IMapper mapper) 
        {
            _rolRepository = rolRepository;
            _mapper= mapper;
    }
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles() 
        {

            var rol = await _rolRepository.GetRoles();
            var rolDto = _mapper.Map<IEnumerable<RolesDto>>(rol);

            return Ok(rolDto);
        }

        [HttpGet("GetRol/{id}")]
        public async Task<IActionResult> GetRol(int id)
        {
            var rol = await _rolRepository.GetRol(id);
            var rolDto = _mapper.Map<RolesDto>(rol);
            return Ok(rolDto);
           
        }

    }
}
