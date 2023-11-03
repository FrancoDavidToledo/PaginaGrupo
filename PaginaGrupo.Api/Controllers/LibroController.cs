using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Infra.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public LibroController(ILibroService libroService, IMapper mapper, IUriService uriService)
        {
            _libroService = libroService;
            _mapper = mapper;
            _uriService = uriService;
        }
        //lo siguiente es para documentar
        /// <summary>
        /// Permite mostrar todos los libros, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<LibroDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetLibros")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public IActionResult GetLibros(LibrosQueryFilter filters)
        {
            var libros = _libroService.GetLibros(filters);
            var librosDto = _mapper.Map<IEnumerable<LibroDto>>(libros);

            var metadata = new Metadata
            {
                TotalCount = libros.TotalCount,
                PageSize = libros.PageSize,
                CurrentPage = libros.CurrentPage,
                TotalPages = libros.TotalPages,
                HasNextPage = libros.HasNextPage,
                HasPreviousPage = libros.HasPreviousPage,
                NextPageUrl = _uriService.GetLibroPaginationUri(filters, Url.RouteUrl(nameof(GetLibros))).ToString(),
                PreviousPageUrl = _uriService.GetLibroPaginationUri(filters, Url.RouteUrl(nameof(GetLibros))).ToString()
            };

            var response = new ApiResponse<IEnumerable<LibroDto>>(librosDto)
            {
                Meta = metadata
            }
            ;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

    }
}
