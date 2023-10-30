using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class AdjuntoController : Controller
    {
        private readonly IAdjuntosRepository _adjuntoRepository;
        private readonly IMapper _mapper;
        public AdjuntoController(IAdjuntosRepository adjuntoRepository, IMapper mapper)
        {
            _adjuntoRepository = adjuntoRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAdjuntos")]
        public async Task<IActionResult> GetAdjuntos()
        {

            var adjunto = await _adjuntoRepository.GetAdjuntos();
            var adjuntoDto = _mapper.Map<IEnumerable<AdjuntosDto>>(adjunto);

            return Ok(adjuntoDto);
        }

        [HttpGet("GetAdjunto/{id}")]
        public async Task<IActionResult> GetAdjunto(int id)
        {
            var adjunto = await _adjuntoRepository.GetAdjunto(id);
            var adjuntoDto = _mapper.Map<AdjuntosDto>(adjunto);
            return Ok(adjuntoDto);

        }

        [HttpPost("InsertarAdjunto")]
        public async Task<IActionResult> InsertarAdjunto(AdjuntosDto adjuntoDto)
        {


            var adjunto = _mapper.Map<Adjuntos>(adjuntoDto);
            await _adjuntoRepository.InsertarAdjunto(adjunto);

            return Ok(adjunto);

        }
    }
}
