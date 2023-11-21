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
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public NoticiaController(INoticiasService noticiasService, IMapper mapper, IUriService uriService)
        {
            _noticiasService = noticiasService;
            _mapper = mapper;
            _uriService = uriService;
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
        public IActionResult GetNoticiasActivas(NoticiasQueryFilter filters)
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
        /// Muestra todas las noticias, requiere rol Dirigente o Admin
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<NoticiaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetNoticias")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente))]
        public IActionResult GetNoticias(NoticiasQueryFilter filters)
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
        [AllowAnonymous]

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
                response.Mensaje = "Error al realizar registro";
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
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente))]
        public IActionResult GetNoticiasEstado(int estado)
        {
            var noticias = _noticiasService.GetNoticiasEstado(estado);
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaDto>>(noticias);
            var response = new ApiResponse<IEnumerable<NoticiaDto>>(noticiaDto);
            return Ok(response);
        }


        [HttpPost("InsertarNoticia")]
        // [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente))]
        public async Task<IActionResult> InsertarNoticia(NoticiaAltaDto noticiaDto)
        {
            //var noticia = _mapper.Map<Noticias>(noticiaDto);
            //await _noticiasService.InsertarNoticia(noticia);

            ////nuevo, se reconvierte a dto para responder
            //noticiaDto = _mapper.Map<NoticiaAltaDto>(noticia);
            //var response = new ApiResponse<NoticiaAltaDto>(noticiaDto);
            //return Ok(response);

            //////////////////////////////////////////
            var noticia = _mapper.Map<Noticias>(noticiaDto);
            await _noticiasService.InsertarNoticia(noticia);

            //nuevo, se reconvierte a dto para responder
            noticiaDto = _mapper.Map<NoticiaAltaDto>(noticia);
            var response = new ResponseDTO<string>();

            if (noticiaDto != null)
            {
                response.EsCorrecto = true;
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
        public async Task<IActionResult> ActualizarNoticia(NoticiaDto noticiaDto)
        {

            var noticia = await _noticiasService.GetNoticia(noticiaDto.Id);
            //aca actualizar todo lo que quieras
            noticia.Titulo = noticiaDto.Titulo;
            noticia.Autor = noticiaDto.Autor;
            noticia.Copete = noticiaDto.Copete;
            noticia.Cuerpo = noticiaDto.Cuerpo;
            noticia.FechaNoticia = noticiaDto.FechaNoticia;
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

        [HttpDelete("BorrarNoticia/{id}")]
        public async Task<IActionResult> BorrarNoticia(int id)
        {
            var result = await _noticiasService.BorrarNoticia(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }



    }
}
