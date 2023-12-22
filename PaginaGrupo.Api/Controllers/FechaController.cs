using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : Controller
    {
        private readonly IFechasService _fechaService;
        private readonly IMapper _mapper;
        public FechaController(IFechasService fechaService, IMapper mapper)
        {
            _fechaService = fechaService;
            _mapper = mapper;
        }
        [HttpGet("GetFechas/{anio}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetFechas(int anio)
        {

            var fecha = _fechaService.GetFechas(anio);
            var fechaDto = _mapper.Map<IEnumerable<FechaDto>>(fecha);

            var response = new ResponseDTO<IEnumerable<FechaDto>>();

            if (fechaDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = fechaDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener las fechas";
            }

            return Ok(response);
        }

        //[HttpGet("GetFecha/{id}")]
        //public async Task<IActionResult> GetFecha(int id)
        //{
        //    var fecha = await _fechaService.GetFecha(id);
        //    var fechaDto = _mapper.Map<FechaDto>(fecha);
        //    return Ok(fechaDto);

        //}

        //[HttpPost("InsertarFecha")]
        //public async Task<IActionResult> InsertarFecha(FechaDto fechaDto)
        //{


        //    var fecha = _mapper.Map<Fechas>(fechaDto);
        //    await _fechaService.InsertarFecha(fecha);

        //    return Ok(fecha);

        //}
    }
}
