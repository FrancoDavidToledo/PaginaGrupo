using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutoresRepository _autorRepository;
        private readonly IMapper _mapper;
        public AutorController(IAutoresRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAutores")]
        public async Task<IActionResult> GetAutores()
        {

            var autor = await _autorRepository.GetAutores();
            var autorDto = _mapper.Map<IEnumerable<AutoresDto>>(autor);

            return Ok(autorDto);
        }

        [HttpGet("GetAutor/{id}")]
        public async Task<IActionResult> GetAutor(int id)
        {
            var autor = await _autorRepository.GetAutor(id);
            var autorDto = _mapper.Map<AutoresDto>(autor);
            return Ok(autorDto);

        }

        [HttpPost("InsertarAutor")]
        public async Task<IActionResult> InsertarAutor(AutoresDto autorDto)
        {


            var autor = _mapper.Map<Autores>(autorDto);
            await _autorRepository.InsertarAutor(autor);

            return Ok(autor);

        }
    }
}
