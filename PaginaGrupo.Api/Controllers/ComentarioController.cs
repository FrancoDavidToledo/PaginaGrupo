using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        private readonly IMapper _mapper;
        public ComentarioController(IComentarioService comentarioService, IMapper mapper)
        {
            _comentarioService = comentarioService;
            _mapper = mapper;
        }


        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todos los comentarios de una publicacion(Activos), no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ComentarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetComentarioPublicacionActivo/{idNoticia}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetComentariosNoticiasActivas(int idNoticia)
        {
            var comentarios = await _comentarioService.GetComentariosNoticiasActivas(idNoticia);
            var comentariosDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
            var response = new ApiResponse<IEnumerable<ComentarioDto>>(comentariosDto);
            return Ok(response);
        }


        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todos los comentarios con un estado en particular, requiere rol de Dirigente o Administrador
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ComentarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetComentariosEstado/{estado}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente))]
        public async Task<IActionResult> GetComentariosEstado(int estado)
        {
            var comentarios = await _comentarioService.GetComentariosEstado(estado);
            var comentariosDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
            var response = new ApiResponse<IEnumerable<ComentarioDto>>(comentariosDto);
            return Ok(response);
        }


        //[HttpGet("GetComentarios")]
        //public async Task<IActionResult> GetComentarios()
        //{

        //    var comentario = await _comentarioService.GetComentarios();
        //    var comentarioDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentario);

        //    return Ok(comentarioDto);
        //}

        //[HttpGet("GetComentario/{id}")]
        //public async Task<IActionResult> GetComentario(int id)
        //{
        //    var comentario = await _comentarioService.GetComentario(id);
        //    var comentarioDto = _mapper.Map<ComentarioDto>(comentario);
        //    return Ok(comentarioDto);

        //}

        //[HttpPost("InsertarComentario")]
        //public async Task<IActionResult> InsertarComentario(ComentarioDto comentarioDto)
        //{


        //    var comentario = _mapper.Map<Comentario>(comentarioDto);
        //    await _comentarioService.InsertarComentario(comentario);

        //    return Ok(comentario);

        //}
    }
}
