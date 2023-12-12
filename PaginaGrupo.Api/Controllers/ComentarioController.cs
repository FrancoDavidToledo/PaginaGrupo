using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly INoticiasService _noticiasService;
        public ComentarioController(IComentarioService comentarioService, IMapper mapper, IUsuarioService usuarioService, INoticiasService noticiasService)
        {
            _comentarioService = comentarioService;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _noticiasService = noticiasService;
        }


        //crear, eliminar, autorizar, obtener listado (por estado, idnoticia)

        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todos los comentarios de una publicacion(Activos), no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ComentarioPublicoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetComentarioPublicacionActivo/{idNoticia}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetComentariosNoticiasActivas(int idNoticia)
        {
            var comentarios = await _comentarioService.GetComentariosNoticiasActivas(idNoticia);
            var comentariosDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
            var usuario = new Usuario();
            foreach (var i in comentariosDto)
            {
                usuario = await _usuarioService.GetUsuario(i.IdUsuario);
                i.NombreUsuario = usuario.Nombre;
            }
            var comentariosDto2 = _mapper.Map<IEnumerable<ComentarioPublicoDto>>(comentariosDto);

            var response = new ApiResponse<IEnumerable<ComentarioPublicoDto>>(comentariosDto2);
            return Ok(response);
        }


        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todos los comentarios con un estado en particular, requiere rol de Dirigente o Administrador
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO<IEnumerable<ComentarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetComentariosEstado")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetComentariosEstado([FromQuery] int estado, int? idNoticia)
        {
            var comentarios = await _comentarioService.GetComentariosEstado(estado, idNoticia);
            var comentariosDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
            var response = new ResponseDTO<IEnumerable<ComentarioDto>>();
            var usuario = new Usuario();
            var noticia = new Noticias();


            foreach (var i in comentariosDto)
            {
                usuario = await _usuarioService.GetUsuario(i.IdUsuario);
                i.NombreUsuario = usuario.Nombre;
                noticia = await _noticiasService.GetNoticia(i.IdNoticia);
                i.TituloNoticia = noticia.Titulo;
            }

            if (comentariosDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = comentariosDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al buscar la noticia";
            }

            return Ok(response);

        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO<IEnumerable<ComentarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetComentariosEstadoFiltrado")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetComentariosEstadoFiltrado([FromQuery] int estado, string? filtro)
        {
            if (string.IsNullOrEmpty(filtro))
                filtro = "";

            var comentarios = await _comentarioService.GetComentariosEstadoFiltrado(estado ,filtro);
            var comentariosDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
            var response = new ResponseDTO<IEnumerable<ComentarioDto>>();
            var usuario = new Usuario();
            var noticia = new Noticias();


            foreach (var i in comentariosDto)
            {
                usuario = await _usuarioService.GetUsuario(i.IdUsuario);
                i.NombreUsuario = usuario.Nombre;
                noticia = await _noticiasService.GetNoticia(i.IdNoticia);
                i.TituloNoticia = noticia.Titulo;
            }

            if (comentariosDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = comentariosDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al buscar la noticia";
            }

            return Ok(response);

        }

        [HttpPost("InsertarComentario")]
        [Authorize]
        public async Task<IActionResult> InsertarComentario([FromQuery] ComentarioDto comentarioDto)
        {
            var comentario = _mapper.Map<Comentario>(comentarioDto);
            await _comentarioService.InsertarComentario(comentario);

            //nuevo, se reconvierte a dto para responder
            comentarioDto = _mapper.Map<ComentarioDto>(comentario);
            var response = new ResponseDTO<ComentarioDto>();

            if (comentarioDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = comentarioDto;
                response.Mensaje = "Comentario cargado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al crear el comentario";
            }

            return Ok(response);

        }

        [HttpPut("ActualizarEstadoComentario")]
        [Authorize(Roles = nameof(RolType.Administrador))]
        public async Task<IActionResult> ActualizarEstadoNoticia([FromQuery] int id, int estado)
        {
            var comentario = await _comentarioService.GetComentario(id);
            //aca actualizar todo lo que quierass
            comentario.Estado = Convert.ToInt16(estado);

            var result = await _comentarioService.ActualizarComentario(comentario);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Comentario actualizado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al actualizar el comentario";
            }

            return Ok(response);

        }
    }
}
