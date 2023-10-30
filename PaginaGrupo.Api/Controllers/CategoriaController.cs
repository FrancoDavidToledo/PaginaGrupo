using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriasRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriasRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        [HttpGet("GetCategorias")]
        public async Task<IActionResult> GetCategorias()
        {

            var categoria = await _categoriaRepository.GetCategorias();
            var categoriaDto = _mapper.Map<IEnumerable<CategoriaDto>>(categoria);

            return Ok(categoriaDto);
        }

        [HttpGet("GetCategoria/{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);
            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return Ok(categoriaDto);

        }

    }
}
