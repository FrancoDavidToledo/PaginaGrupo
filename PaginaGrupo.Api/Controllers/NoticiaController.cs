using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.Infra.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    //  [Authorize]
    //[Authorize(Roles =nameof(RolType.Administrador)+ ","+nameof(RolType.Dirigente))]

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
        /// Muestra todas las noticias
        /// </summary>
        /// 
        //lo siguiente para documentar cada uno en particular
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<NoticiaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar


        [HttpGet("GetNoticias")]
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

        [HttpGet("GetNoticiasEstado/{estado}")]
        public IActionResult GetNoticiasEstado(int estado)
        {
            var noticias = _noticiasService.GetNoticiasEstado(estado);
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaDto>>(noticias);
            var response = new ApiResponse<IEnumerable<NoticiaDto>>(noticiaDto);
            return Ok(response);
        }

        [HttpGet("GetNoticia/{id}")]
        public async Task<IActionResult> GetNoticia(int id)
        {
            var noticia = await _noticiasService.GetNoticia(id);
            var noticiaDto = _mapper.Map<NoticiaDto>(noticia);
            var response = new ApiResponse<NoticiaDto>(noticiaDto);

            return Ok(response);

        }

        [HttpPost("InsertarNoticia")]
        public async Task<IActionResult> InsertarNoticia(NoticiaDto noticiaDto)
        {
            var noticia = _mapper.Map<Noticias>(noticiaDto);
            await _noticiasService.InsertarNoticia(noticia);

            //nuevo, se reconvierte a dto para responder
            noticiaDto = _mapper.Map<NoticiaDto>(noticia);
            var response = new ApiResponse<NoticiaDto>(noticiaDto);
            return Ok(response);

        }

        [HttpPut("ActualizarNoticia")]
        public async Task<IActionResult> ActualizarNoticia(int id, NoticiaDto noticiaDto)
        {

            var noticia = _mapper.Map<Noticias>(noticiaDto);
            noticia.Id = id;
            var result = await _noticiasService.ActualizarNoticia(noticia);
            var response = new ApiResponse<bool>(result);
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
