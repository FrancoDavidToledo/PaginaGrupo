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
    public class AsistenciaScoutController : Controller
    {
        private readonly IAsistenciaScoutService _asistenciaScoutService;
        private readonly IMapper _mapper;
        public AsistenciaScoutController(IAsistenciaScoutService asistenciaScoutService, IMapper mapper)
        {
            _asistenciaScoutService = asistenciaScoutService;
            _mapper = mapper;
        }
        [HttpGet("GetAsistenciasScouts/{idFecha}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetAsistenciasScouts(int idFecha)
        {

            var asistenciaScout = _asistenciaScoutService.GetAsistenciasScouts(idFecha);
            var asistenciaScoutDto = _mapper.Map<IEnumerable<AsistenciaScoutDto>>(asistenciaScout);

            var response = new ResponseDTO<IEnumerable<AsistenciaScoutDto>>();

            if (asistenciaScoutDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = asistenciaScoutDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener las asistencias";
            }

            return Ok(response);
        }

        [HttpGet("GetAsistenciaScout/{id}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetAsistenciaScout(int id)
        {
            var asistenciaScout = await _asistenciaScoutService.GetAsistenciaScout(id);
            var asistenciaScoutDto = _mapper.Map<AsistenciaScoutDto>(asistenciaScout);
            return Ok(asistenciaScoutDto);

        }

        [HttpPost("InsertarAsistenciaScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> InsertarAsistenciaScout(AsistenciaScoutDto asistenciaScoutDto)
        {


            var asistenciaScout = _mapper.Map<AsistenciaScout>(asistenciaScoutDto);
            await _asistenciaScoutService.InsertarAsistenciaScout(asistenciaScout);

            return Ok(asistenciaScout);

        }
    }
}
