using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;

namespace PaginaGrupo.Api.Controllers
{
    public class NombreScoutController : Controller
    {
        private readonly INombreScoutService _nombreScoutService;
        private readonly IMapper _mapper;
        public NombreScoutController(INombreScoutService nombreScoutService, IMapper mapper)
        {
            _nombreScoutService = nombreScoutService;
            _mapper = mapper;
        }
        [HttpGet("GetNombresScouts/{idScout}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetNombresScouts(int idScout)
        {
            var nombreScout = _nombreScoutService.GetNombreScout(idScout);
            var nombreScoutDto = _mapper.Map<IEnumerable<NombreScoutDto>>(nombreScout);

            return Ok(nombreScoutDto);
        }

        [HttpPost("InsertarNombreScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> InsertarNombreScout([FromQuery] NombreScoutDto nombreScoutDto)
        {


            var nombreScout = _mapper.Map<NombreScout>(nombreScoutDto);
            await _nombreScoutService.InsertarNombreScout(nombreScout);

            return Ok(nombreScout);

        }

        [HttpPut("ActualizarNombreScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> ActualizarNombreScout([FromQuery] NombreScoutDto scoutDto)
        {

            var scout = await _nombreScoutService.GetNombreScoutById(scoutDto.Id);
            //aca actualizar todo lo que quieras
            scout.Nombre = scoutDto.Nombre;
            scout.IdTipo = scoutDto.IdTipo;
            scout.Fecha = scoutDto.Fecha;
            scout.CodigoUnidad = scoutDto.CodigoUnidad;


            var result = await _nombreScoutService.ActualizarNombreScout(scout);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Nombre Scout editado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al editar el Nombre Scout";
            }

            return Ok(response);

        }
        [HttpDelete("BorrarNombreScout/{id}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> BorrarNombreScout(int id)
        {
            var result = await _nombreScoutService.BorrarNombreScout(id);
            var response = new ResponseDTO<string>();
            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Nombre Scout eliminado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al eliminar el Nombre Scout";
            }

            return Ok(response);
        }

    }
}
