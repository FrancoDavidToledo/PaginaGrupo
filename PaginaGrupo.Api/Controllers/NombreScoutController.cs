using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class NombreScoutController : Controller
    {
        private readonly INombreScoutRepository _nombreScoutRepository;
        private readonly IMapper _mapper;
        public NombreScoutController(INombreScoutRepository nombreScoutRepository, IMapper mapper)
        {
            _nombreScoutRepository = nombreScoutRepository;
            _mapper = mapper;
        }
        [HttpGet("GetNombresScouts")]
        public async Task<IActionResult> GetNombresScouts()
        {

            var nombreScout = await _nombreScoutRepository.GetNombresScouts();
            var nombreScoutDto = _mapper.Map<IEnumerable<NombreScoutDto>>(nombreScout);

            return Ok(nombreScoutDto);
        }

        [HttpGet("GetNombreScout/{id}")]
        public async Task<IActionResult> GetNombreScout(int id)
        {
            var nombreScout = await _nombreScoutRepository.GetNombreScout(id);
            var nombreScoutDto = _mapper.Map<NombreScoutDto>(nombreScout);
            return Ok(nombreScoutDto);

        }

        [HttpPost("InsertarNombreScout")]
        public async Task<IActionResult> InsertarNombreScout(NombreScoutDto nombreScoutDto)
        {


            var nombreScout = _mapper.Map<NombreScout>(nombreScoutDto);
            await _nombreScoutRepository.InsertarNombreScout(nombreScout);

            return Ok(nombreScout);

        }
    }
}
