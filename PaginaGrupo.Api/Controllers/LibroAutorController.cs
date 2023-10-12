using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class LibroAutorController : Controller
    {
        private readonly ILibroAutorRepository _libroAutorRepository;
        private readonly IMapper _mapper;
        public LibroAutorController(ILibroAutorRepository libroAutorRepository, IMapper mapper) 
        {
            _libroAutorRepository = libroAutorRepository;
            _mapper= mapper;
    }
        [HttpGet("GetLibrosAutores")]
        public async Task<IActionResult> GetLibrosAutores() 
        {

            var libroAutor = await _libroAutorRepository.GetLibrosAutores();
            var libroAutorDto = _mapper.Map<IEnumerable<LibroAutorDto>>(libroAutor);

            return Ok(libroAutorDto);
        }

        [HttpGet("GetLibroAutor/{id}")]
        public async Task<IActionResult> GetLibroAutor(int id)
        {
            var libroAutor = await _libroAutorRepository.GetLibroAutor(id);
            var libroAutorDto = _mapper.Map<LibroAutorDto>(libroAutor);
            return Ok(libroAutorDto);
           
        }

        [HttpPost("InsertarLibroAutor")]
        public async Task<IActionResult> InsertarLibroAutor(LibroAutorDto libroAutorDto)
        {


            var libroAutor = _mapper.Map<LibroAutor>(libroAutorDto);
            await _libroAutorRepository.InsertarLibroAutor(libroAutor);
            
            return Ok(libroAutor);

        }
    }
}
