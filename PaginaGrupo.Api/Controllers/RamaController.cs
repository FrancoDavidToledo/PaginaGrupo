using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class RamaController : Controller
    {
        private readonly IRamaRepository _ramaRepository;
        private readonly IMapper _mapper;
        public RamaController(IRamaRepository ramaRepository, IMapper mapper) 
        {
            _ramaRepository = ramaRepository;
            _mapper= mapper;
    }
        [HttpGet("GetRamas")]
        public async Task<IActionResult> GetRamas() 
        {

            var rama = await _ramaRepository.GetRamas();
            var ramaDto = _mapper.Map<IEnumerable<RamaDto>>(rama);

            return Ok(ramaDto);
        }

        [HttpGet("GetRama/{codigo}")]
        public async Task<IActionResult> GetRama(string codigo)
        {
            var rama = await _ramaRepository.GetRama(codigo);
            var ramaDto = _mapper.Map<RamaDto>(rama);
            return Ok(ramaDto);
           
        }

    }
}
