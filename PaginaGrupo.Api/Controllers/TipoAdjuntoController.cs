using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class TipoAdjuntoController : Controller
    {
        private readonly ITipoAdjuntoRepository _tipoAdjuntoRepository;
        private readonly IMapper _mapper;
        public TipoAdjuntoController(ITipoAdjuntoRepository tipoAdjuntoRepository, IMapper mapper) 
        {
            _tipoAdjuntoRepository = tipoAdjuntoRepository;
            _mapper= mapper;
    }
        [HttpGet("GetTiposAdjuntos")]
        public async Task<IActionResult> GetTiposAdjuntos() 
        {

            var tipoAdjunto = await _tipoAdjuntoRepository.GetTiposAdjuntos();
            var tipoAdjuntoDto = _mapper.Map<IEnumerable<TipoAdjuntoDto>>(tipoAdjunto);

            return Ok(tipoAdjuntoDto);
        }

        [HttpGet("GetTipoAdjunto/{id}")]
        public async Task<IActionResult> GetTipoAdjunto(int id)
        {
            var tipoAdjunto = await _tipoAdjuntoRepository.GetTipoAdjunto(id);
            var tipoAdjuntoDto = _mapper.Map<TipoAdjuntoDto>(tipoAdjunto);
            return Ok(tipoAdjuntoDto);
           
        }

    }
}
