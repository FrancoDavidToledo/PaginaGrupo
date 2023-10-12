using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class UnidadController : Controller
    {
        private readonly IUnidadRepository _unidadRepository;
        private readonly IMapper _mapper;
        public UnidadController(IUnidadRepository unidadRepository, IMapper mapper) 
        {
            _unidadRepository = unidadRepository;
            _mapper= mapper;
    }
        [HttpGet("GetUnidades")]
        public async Task<IActionResult> GetUnidades() 
        {

            var unidad = await _unidadRepository.GetUnidades();
            var unidadDto = _mapper.Map<IEnumerable<UnidadDto>>(unidad);

            return Ok(unidadDto);
        }

        [HttpGet("GetUnidad/{codigo}")]
        public async Task<IActionResult> GetUnidad(string codigo)
        {
            var unidad = await _unidadRepository.GetUnidad(codigo);
            var unidadDto = _mapper.Map<UnidadDto>(unidad);
            return Ok(unidadDto);
           
        }


    }
}
