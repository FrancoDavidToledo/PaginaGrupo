using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class LibroCategoriaController : Controller
    {
        private readonly ILibroCategoriaRepository _libroCategoriaRepository;
        private readonly IMapper _mapper;
        public LibroCategoriaController(ILibroCategoriaRepository libroCategoriaRepository, IMapper mapper)
        {
            _libroCategoriaRepository = libroCategoriaRepository;
            _mapper = mapper;
        }
        [HttpGet("GetLibrosCategorias")]
        public async Task<IActionResult> GetLibrosCategorias()
        {

            var libroCategoria = await _libroCategoriaRepository.GetLibrosCategorias();
            var libroCategoriaDto = _mapper.Map<IEnumerable<LibroCategoriaDto>>(libroCategoria);

            return Ok(libroCategoriaDto);
        }

        [HttpGet("GetLibroCategoria/{id}")]
        public async Task<IActionResult> GetLibroCategoria(int id)
        {
            var libroCategoria = await _libroCategoriaRepository.GetLibroCategoria(id);
            var libroCategoriaDto = _mapper.Map<LibroCategoriaDto>(libroCategoria);
            return Ok(libroCategoriaDto);

        }

        [HttpPost("InsertarLibroCategoria")]
        public async Task<IActionResult> InsertarLibroCategoria(LibroCategoriaDto libroCategoriaDto)
        {


            var libroCategoria = _mapper.Map<LibroCategoria>(libroCategoriaDto);
            await _libroCategoriaRepository.InsertarLibroCategoria(libroCategoria);

            return Ok(libroCategoria);

        }
    }
}
