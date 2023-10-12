using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class ProgresionController : Controller
    {
        private readonly IProgresionRepository _progresionRepository;
        private readonly IMapper _mapper;
        public ProgresionController(IProgresionRepository progresionRepository, IMapper mapper) 
        {
            _progresionRepository = progresionRepository;
            _mapper= mapper;
    }
        [HttpGet("GetProgresiones")]
        public async Task<IActionResult> GetProgresiones() 
        {

            var progresion = await _progresionRepository.GetProgresiones();
            var progresionDto = _mapper.Map<IEnumerable<ProgresionDto>>(progresion);

            return Ok(progresionDto);
        }

        [HttpGet("GetProgresion/{id}")]
        public async Task<IActionResult> GetProgresion(int id)
        {
            var progresion = await _progresionRepository.GetProgresion(id);
            var progresionDto = _mapper.Map<ProgresionDto>(progresion);
            return Ok(progresionDto);
           
        }
    }
}
