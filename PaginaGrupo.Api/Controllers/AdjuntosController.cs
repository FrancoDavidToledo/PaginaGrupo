using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using System.Net;
using System.Text;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjuntoController : Controller
    {
        private readonly IAdjuntoService _adjuntoService;
        private readonly IMapper _mapper;
        public AdjuntoController(IAdjuntoService adjuntoService, IMapper mapper)
        {
            _adjuntoService = adjuntoService;
            _mapper = mapper;
        }

        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todos los adjuntos de una noticia, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AdjuntosDto>>))]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetAdjuntos/{idNoticia}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetAdjuntos(int idNoticia)
        {

            var adjunto = await _adjuntoService.GetAdjuntosNoticia(idNoticia);
            var adjuntoDto = _mapper.Map<IEnumerable<AdjuntosDto>>(adjunto);
            var response = new ApiResponse<IEnumerable<AdjuntosDto>>(adjuntoDto);
            return Ok(response);
        }

        //[HttpGet("GetAdjunto/{id}")]
        //public async Task<IActionResult> GetAdjunto(int id)
        //{
        //    var adjunto = await _adjuntoService.GetAdjunto(id);
        //    var adjuntoDto = _mapper.Map<AdjuntosDto>(adjunto);
        //    return Ok(adjuntoDto);

        //}

        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todos los adjuntos de una noticia, no requiere login
        /// </summary>
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AdjuntosDto>>))]
        //lo siguiente es el nombre del servicio
        [HttpPost("InsertarAdjunto")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> InsertarAdjunto([FromQuery] AdjuntosDto adjuntoDto)
        {

            var adjunto = _mapper.Map<Adjuntos>(adjuntoDto);

            await _adjuntoService.InsertarAdjunto(adjunto);

            return Ok(adjunto);
        }


        [HttpDelete("EliminarAdjunto/{idAdjunto}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> EliminarAdjunto(int idAdjunto)
        {
            var result = await _adjuntoService.EliminarAdjunto(idAdjunto);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }



    }
}
