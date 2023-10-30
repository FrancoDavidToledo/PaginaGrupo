using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class FechaController : Controller
    {
        private readonly IFechaRepository _fechaRepository;
        private readonly IMapper _mapper;
        public FechaController(IFechaRepository fechaRepository, IMapper mapper)
        {
            _fechaRepository = fechaRepository;
            _mapper = mapper;
        }
        [HttpGet("GetFechas")]
        public async Task<IActionResult> GetFechas()
        {

            var fecha = await _fechaRepository.GetFechas();
            var fechaDto = _mapper.Map<IEnumerable<FechaDto>>(fecha);

            return Ok(fechaDto);
        }

        [HttpGet("GetFecha/{id}")]
        public async Task<IActionResult> GetFecha(int id)
        {
            var fecha = await _fechaRepository.GetFecha(id);
            var fechaDto = _mapper.Map<FechaDto>(fecha);
            return Ok(fechaDto);

        }

        [HttpPost("InsertarFecha")]
        public async Task<IActionResult> InsertarFecha(FechaDto fechaDto)
        {


            var fecha = _mapper.Map<Fecha>(fechaDto);
            await _fechaRepository.InsertarFecha(fecha);

            return Ok(fecha);

        }
    }
}
