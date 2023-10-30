using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class AvisoPagoController : Controller
    {
        private readonly IAvisoPagoRepository _avisoPagoRepository;
        private readonly IMapper _mapper;
        public AvisoPagoController(IAvisoPagoRepository avisoPagoRepository, IMapper mapper)
        {
            _avisoPagoRepository = avisoPagoRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAvisosPagos")]
        public async Task<IActionResult> GetAvisosPagos()
        {

            var avisoPago = await _avisoPagoRepository.GetAvisosPagos();
            var avisoPagoDto = _mapper.Map<IEnumerable<AvisoPagoDto>>(avisoPago);

            return Ok(avisoPagoDto);
        }

        [HttpGet("GetAvisoPago/{id}")]
        public async Task<IActionResult> GetAvisoPago(int id)
        {
            var avisoPago = await _avisoPagoRepository.GetAvisoPago(id);
            var avisoPagoDto = _mapper.Map<AvisoPagoDto>(avisoPago);
            return Ok(avisoPagoDto);

        }

        [HttpPost("InsertarAvisoPago")]
        public async Task<IActionResult> InsertarAvisoPago(AvisoPagoDto avisoPagoDto)
        {


            var avisoPago = _mapper.Map<AvisoPago>(avisoPagoDto);
            await _avisoPagoRepository.InsertarAvisoPago(avisoPago);

            return Ok(avisoPago);

        }
    }
}
