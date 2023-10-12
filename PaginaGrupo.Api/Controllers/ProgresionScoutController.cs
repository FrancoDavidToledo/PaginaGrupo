using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class ProgresionScoutController : Controller
    {
        private readonly IProgresionScoutRepository _progresionScoutRepository;
        private readonly IMapper _mapper;
        public ProgresionScoutController(IProgresionScoutRepository progresionScoutRepository, IMapper mapper) 
        {
            _progresionScoutRepository = progresionScoutRepository;
            _mapper= mapper;
    }
        [HttpGet("GetProgresionesScouts")]
        public async Task<IActionResult> GetProgresionesScouts() 
        {

            var progresionScout = await _progresionScoutRepository.GetProgresionesScouts();
            var progresionScoutDto = _mapper.Map<IEnumerable<ProgresionScoutDto>>(progresionScout);

            return Ok(progresionScoutDto);
        }

        [HttpGet("GetProgresionScout/{id}")]
        public async Task<IActionResult> GetProgresionScout(int id)
        {
            var progresionScout = await _progresionScoutRepository.GetProgresionScout(id);
            var progresionScoutDto = _mapper.Map<ProgresionScoutDto>(progresionScout);
            return Ok(progresionScoutDto);
           
        }

        [HttpPost("InsertarProgresionScout")]
        public async Task<IActionResult> InsertarProgresionScout(ProgresionScoutDto progresionScoutDto)
        {


            var progresionScout = _mapper.Map<ProgresionScout>(progresionScoutDto);
            await _progresionScoutRepository.InsertarProgresionScout(progresionScout);
            
            return Ok(progresionScout);

        }
    }
}
