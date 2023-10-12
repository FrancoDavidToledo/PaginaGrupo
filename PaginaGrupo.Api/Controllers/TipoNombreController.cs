using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class TipoNombreController : Controller
    {
        private readonly ITipoNombreRepository _tipoNombreRepository;
        private readonly IMapper _mapper;
        public TipoNombreController(ITipoNombreRepository tipoNombreRepository, IMapper mapper) 
        {
            _tipoNombreRepository = tipoNombreRepository;
            _mapper= mapper;
    }
        [HttpGet("GetTiposNombres")]
        public async Task<IActionResult> GetTiposNombres() 
        {
            var tipoNombre = await _tipoNombreRepository.GetTiposNombres();
            var tipoNombreDto = _mapper.Map<IEnumerable<TipoNombreDto>>(tipoNombre);

            return Ok(tipoNombreDto);
        }

        [HttpGet("GetTipoNombre/{id}")]
        public async Task<IActionResult> GetTipoNombre(int id)
        {
            var tipoNombre = await _tipoNombreRepository.GetTipoNombre(id);
            var tipoNombreDto = _mapper.Map<TipoNombreDto>(tipoNombre);
            return Ok(tipoNombreDto);
           
        }


    }
}
