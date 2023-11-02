using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class TipoAdjuntoController : Controller
    {
        private readonly ITipoAdjuntoRepository _tipoAdjuntoRepository;
        private readonly IMapper _mapper;
        public TipoAdjuntoController(ITipoAdjuntoRepository tipoAdjuntoRepository, IMapper mapper)
        {
            _tipoAdjuntoRepository = tipoAdjuntoRepository;
            _mapper = mapper;
        }

        //lo siguiente es para documentar
        /// <summary>
        /// Muestra los tipos de adjuntos validos, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TipoAdjuntoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetTiposAdjuntos")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetTiposAdjuntos()
        {

            var tipoAdjunto = await _tipoAdjuntoRepository.GetTiposAdjuntos();
            var tipoAdjuntoDto = _mapper.Map<IEnumerable<TipoAdjuntoDto>>(tipoAdjunto);
            var response = new ApiResponse<IEnumerable<TipoAdjuntoDto>>(tipoAdjuntoDto);

            return Ok(response);
        }

        //[HttpGet("GetTipoAdjunto/{id}")]
        //public async Task<IActionResult> GetTipoAdjunto(int id)
        //{
        //    var tipoAdjunto = await _tipoAdjuntoRepository.GetTipoAdjunto(id);
        //    var tipoAdjuntoDto = _mapper.Map<TipoAdjuntoDto>(tipoAdjunto);
        //    return Ok(tipoAdjuntoDto);

        //}

    }
}
