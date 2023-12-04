using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Infra.Interfaces;
using PaginaGrupo.WebApp.Pages.Noticias;
using SocialMedia.Infrastructure.Services;
using System.Collections.Generic;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    //  [Authorize]
    //  [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente))]
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : Controller
    {

        private readonly INoticiasService _noticiasService;
        private readonly IAdjuntoService _adjuntoService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public NoticiaController(INoticiasService noticiasService, IMapper mapper, IUriService uriService, IAdjuntoService adjuntoService)
        {
            _noticiasService = noticiasService;
            _mapper = mapper;
            _uriService = uriService;
            _adjuntoService = adjuntoService;
        }

        //lo siguiente es para documentar
        /// <summary>
        /// Muestra todas las noticias ACTIVAS, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<NoticiaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticiasActivas")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public IActionResult GetNoticiasActivas([FromQuery] NoticiasQueryFilter filters)
        {
            var noticias = _noticiasService.GetNoticiasActivas(filters);
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaDto>>(noticias);

            var metadata = new Metadata
            {
                TotalCount = noticias.TotalCount,
                PageSize = noticias.PageSize,
                CurrentPage = noticias.CurrentPage,
                TotalPages = noticias.TotalPages,
                HasNextPage = noticias.HasNextPage,
                HasPreviousPage = noticias.HasPreviousPage,
                NextPageUrl = _uriService.GetNoticiaPaginationUri(filters, Url.RouteUrl(nameof(GetNoticiasActivas))).ToString(),
                PreviousPageUrl = _uriService.GetNoticiaPaginationUri(filters, Url.RouteUrl(nameof(GetNoticiasActivas))).ToString()
            };

            var response = new ApiResponse<IEnumerable<NoticiaDto>>(noticiaDto)
            {
                Meta = metadata
            }
            ;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }
        //lo siguiente es para documentar
        /// <summary>
        /// Muestra todas las noticias ACTIVAS, no requiere login
        /// </summary>
        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticiasActivasImagen")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetNoticiasActivasImagenAsync([FromQuery] NoticiasQueryFilter filters)
        {
            var noticias = _noticiasService.GetNoticiasActivasAdjunto(filters);
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaActivaImagenDto>>(noticias);
            foreach (var i in noticiaDto)
            {
                    i.Adjunto = await _adjuntoService.GetAdjuntoPrincipal(i.Id);
             }

            var metadata = new Metadata
            {
                TotalCount = noticias.TotalCount,
                PageSize = noticias.PageSize,
                CurrentPage = noticias.CurrentPage,
                TotalPages = noticias.TotalPages,
                HasNextPage = noticias.HasNextPage,
                HasPreviousPage = noticias.HasPreviousPage,
                NextPageUrl = _uriService.GetNoticiaPaginationUri(filters, Url.RouteUrl(nameof(GetNoticiasActivas))).ToString(),
                PreviousPageUrl = _uriService.GetNoticiaPaginationUri(filters, Url.RouteUrl(nameof(GetNoticiasActivas))).ToString()
            };

            var response = new ApiResponse<IEnumerable<NoticiaActivaImagenDto>>(noticiaDto)
            {
                Meta = metadata
            }
            ;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        //lo siguiente es para documentar
        /// <summary>
        /// Muestra todas las noticias, requiere rol Dirigente o Admin
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<NoticiaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticias")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public IActionResult GetNoticias([FromQuery] NoticiasQueryFilter filters)
        {
            var noticias = _noticiasService.GetNoticias(filters);
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaDto>>(noticias);

            var metadata = new Metadata
            {
                TotalCount = noticias.TotalCount,
                PageSize = noticias.PageSize,
                CurrentPage = noticias.CurrentPage,
                TotalPages = noticias.TotalPages,
                HasNextPage = noticias.HasNextPage,
                HasPreviousPage = noticias.HasPreviousPage,
                NextPageUrl = _uriService.GetNoticiaPaginationUri(filters, Url.RouteUrl(nameof(GetNoticias))).ToString(),
                PreviousPageUrl = _uriService.GetNoticiaPaginationUri(filters, Url.RouteUrl(nameof(GetNoticias))).ToString()
            };

            var response = new ApiResponse<IEnumerable<NoticiaDto>>(noticiaDto)
            {
                Meta = metadata
            }
            ;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar una noticia, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<NoticiaAltaDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticia/{id}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetNoticia(int id)
        {
            var noticia = await _noticiasService.GetNoticia(id);
            var noticiaDto = _mapper.Map<NoticiaAltaDto>(noticia);
            //     var response = new ApiResponse<NoticiaDto>(noticiaDto);



            //nuevo, se reconvierte a dto para responder
            var response = new ResponseDTO<NoticiaAltaDto>();
            if (noticiaDto != null)
            {

                response.EsCorrecto = true;
                response.Resultado = noticiaDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener la noticia";
            }


            return Ok(response);
        }


        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar una noticia, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<NoticiaAltaDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticiaActiva/{id}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]

        public async Task<IActionResult> GetNoticiaActiva(int id)
        {
            var noticia = await _noticiasService.GetNoticiaActiva(id);

            var noticiaDto = _mapper.Map<NoticiaAltaDto>(noticia);
            //     var response = new ApiResponse<NoticiaDto>(noticiaDto);



            //nuevo, se reconvierte a dto para responder
            var response = new ResponseDTO<NoticiaAltaDto>();

            response.EsCorrecto = false;
            response.Mensaje = "La noticia no fue encontrada. Si el error persiste por favor contacte al administrador.";

            if (noticiaDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = noticiaDto;
                response.Mensaje = null;
            }

             

            return Ok(response);
        }


        //lo siguiente para documentar
        /// <summary>
        /// Permite mostrar todas las noticias con un estado en particular, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<NoticiaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticiasEstado/{estado}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public IActionResult GetNoticiasEstado(int estado)
        {
            var noticias = _noticiasService.GetNoticiasEstado(estado);
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaDto>>(noticias);

            var response = new ResponseDTO<IEnumerable<NoticiaDto>>();

            if (noticiaDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = noticiaDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al crear la noticia";
            }

            return Ok(response);
        }


        [HttpPost("InsertarNoticia")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> InsertarNoticia([FromQuery] NoticiaAltaDto noticiaDto)
        {
            var noticia = _mapper.Map<Noticias>(noticiaDto);
            await _noticiasService.InsertarNoticia(noticia);

            //nuevo, se reconvierte a dto para responder
            noticiaDto = _mapper.Map<NoticiaAltaDto>(noticia);
            var response = new ResponseDTO<NoticiaAltaDto>();

            if (noticiaDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = noticiaDto;
                response.Mensaje = "Noticia creada con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al crear la noticia";
            }

            return Ok(response);

        }

        [HttpPut("ActualizarNoticia")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> ActualizarNoticia([FromQuery] NoticiaDto noticiaDto)
        {

            var noticia = await _noticiasService.GetNoticia(noticiaDto.Id);
            //aca actualizar todo lo que quieras
            noticia.Titulo = noticiaDto.Titulo;
            noticia.Autor = noticiaDto.Autor;
            noticia.Copete = noticiaDto.Copete;
            noticia.Cuerpo = noticiaDto.Cuerpo;
            noticia.FechaNoticia = noticiaDto.FechaNoticia;
            //cada vez que se edita, vuelve a estado borrador y se borran los datos de baja
            noticia.FechaBaja = null;
            noticia.IdUsuarioBaja = null;
            noticia.Estado = Convert.ToInt16(EstadoNoticias.Borrador);

            var result = await _noticiasService.ActualizarNoticia(noticia);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Noticia editada con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al editar la noticia";
            }

            return Ok(response);

        }

        [HttpPut("ActualizarEstadoNoticia")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> ActualizarEstadoNoticia([FromQuery] NoticiaEstadoDto noticiaDto)
        {
            var noticia = await _noticiasService.GetNoticia(noticiaDto.Id);
            //aca actualizar todo lo que quieras
            noticia.Estado = noticiaDto.Estado;
            if (noticia.Estado == 4)
            {
                noticia.FechaBaja = noticiaDto.FechaBaja;
                noticia.IdUsuarioBaja = noticiaDto.IdUsuarioBaja;
            }
            var result = await _noticiasService.ActualizarNoticia(noticia);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Noticia actualizada con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al actualizar la noticia";
            }

            return Ok(response);

        }

        [HttpDelete("BorrarNoticia/{id}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> BorrarNoticia(int id)
        {
            var result = await _noticiasService.BorrarNoticia(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }



    }
}
