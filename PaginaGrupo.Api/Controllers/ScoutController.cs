using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class ScoutController : Controller
    {
        private readonly IScoutRepository _scoutRepository;
        private readonly IMapper _mapper;
        public ScoutController(IScoutRepository scoutRepository, IMapper mapper) 
        {
            _scoutRepository = scoutRepository;
            _mapper= mapper;
    }
        [HttpGet("GetScouts")]
        public async Task<IActionResult> GetScouts() 
        {

            var scout = await _scoutRepository.GetScouts();
            var scoutDto = _mapper.Map<IEnumerable<ScoutDto>>(scout);

            return Ok(scoutDto);
        }

        [HttpGet("GetScout/{id}")]
        public async Task<IActionResult> GetScout(int id)
        {
            var scout = await _scoutRepository.GetScout(id);
            var scoutDto = _mapper.Map<ScoutDto>(scout);
            return Ok(scoutDto);
           
        }

        [HttpPost("InsertarScout")]
        public async Task<IActionResult> InsertarScout(ScoutDto scoutDto)
        {


            var scout = _mapper.Map<Scout>(scoutDto);
            await _scoutRepository.InsertarScout(scout);
            
            return Ok(scout);

        }
    }
}
