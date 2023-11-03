using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        //lo siguiente es para documentar
        /// <summary>
        /// Permite mostrar todas las categorias, no requiere login
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CategoriaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar
        //lo siguiente es el nombre del servicio
        [HttpGet("GetCategorias")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [AllowAnonymous]
        public async Task<IActionResult> GetCategorias()
        {

            var categoria =  _categoriaService.GetCategorias();
            var categoriaDto = _mapper.Map<IEnumerable<CategoriaDto>>(categoria);

            return Ok(categoriaDto);
        }


    }
}
