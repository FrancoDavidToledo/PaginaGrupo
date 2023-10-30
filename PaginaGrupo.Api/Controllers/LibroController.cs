using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;
        public LibroController(ILibroRepository libroRepository, IMapper mapper)
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }
        [HttpGet("GetLibros")]
        public async Task<IActionResult> GetLibros()
        {

            var libro = await _libroRepository.GetLibros();
            var libroDto = _mapper.Map<IEnumerable<LibroDto>>(libro);

            return Ok(libroDto);
        }

        [HttpGet("GetLibro/{id}")]
        public async Task<IActionResult> GetLibro(int id)
        {
            var libro = await _libroRepository.GetLibro(id);
            var libroDto = _mapper.Map<LibroDto>(libro);
            return Ok(libroDto);

        }

        [HttpPost("InsertarLibro")]
        public async Task<IActionResult> InsertarLibro(LibroDto libroDto)
        {


            var libro = _mapper.Map<Libro>(libroDto);
            await _libroRepository.InsertarLibro(libro);

            return Ok(libro);

        }
    }
}
