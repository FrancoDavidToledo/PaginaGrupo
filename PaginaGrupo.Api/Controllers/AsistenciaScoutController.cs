using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class AsistenciaScoutController : Controller
    {
        private readonly IAsistenciaScoutRepository _asistenciaScoutRepository;
        private readonly IMapper _mapper;
        public AsistenciaScoutController(IAsistenciaScoutRepository asistenciaScoutRepository, IMapper mapper)
        {
            _asistenciaScoutRepository = asistenciaScoutRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAsistenciasScouts")]
        public async Task<IActionResult> GetAsistenciasScouts()
        {

            var asistenciaScout = await _asistenciaScoutRepository.GetAsistenciasScouts();
            var asistenciaScoutDto = _mapper.Map<IEnumerable<AsistenciaScoutDto>>(asistenciaScout);

            return Ok(asistenciaScoutDto);
        }

        [HttpGet("GetAsistenciaScout/{id}")]
        public async Task<IActionResult> GetAsistenciaScout(int id)
        {
            var asistenciaScout = await _asistenciaScoutRepository.GetAsistenciaScout(id);
            var asistenciaScoutDto = _mapper.Map<AsistenciaScoutDto>(asistenciaScout);
            return Ok(asistenciaScoutDto);

        }

        [HttpPost("InsertarAsistenciaScout")]
        public async Task<IActionResult> InsertarAsistenciaScout(AsistenciaScoutDto asistenciaScoutDto)
        {


            var asistenciaScout = _mapper.Map<AsistenciaScout>(asistenciaScoutDto);
            await _asistenciaScoutRepository.InsertarAsistenciaScout(asistenciaScout);

            return Ok(asistenciaScout);

        }
    }
}
