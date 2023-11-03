using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;
        public AutorController(IAutorService autorService, IMapper mapper)
        {
            _autorService = autorService;
            _mapper = mapper;
        }

        //lo siguiente es para documentar
        /// <summary>
        /// Permite mostrar todos los autores, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AutoresDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar
        //lo siguiente es el nombre del servicio
        [HttpGet("GetAutores")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetAutores()
        {

            var autor =  _autorService.GetAutores();
            var autorDto = _mapper.Map<IEnumerable<AutoresDto>>(autor);

            return Ok(autorDto);
        }

    }
}
