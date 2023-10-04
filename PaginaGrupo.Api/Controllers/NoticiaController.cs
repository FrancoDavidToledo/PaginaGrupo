using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiasRepository _noticiasRepository;
        private readonly IMapper _mapper;
        public NoticiaController(INoticiasRepository noticiasRepository, IMapper mapper) 
        {
            _noticiasRepository = noticiasRepository;
            _mapper= mapper;
    }
        [HttpGet("GetNoticias")]
        public async Task<IActionResult> GetNoticias() 
        {

            var noticias = await _noticiasRepository.GetNoticias();
            var noticiaDto = _mapper.Map<IEnumerable<NoticiaDto>>(noticias);

            return Ok(noticiaDto);
        }

        [HttpGet("GetNoticia/{id}")]
        public async Task<IActionResult> GetNoticia(int id)
        {
            var noticia = await _noticiasRepository.GetNoticia(id);
            var noticiaDto = _mapper.Map<NoticiaDto>(noticia);
            return Ok(noticiaDto);
           
        }

        [HttpPost("InsertarNoticia")]
        public async Task<IActionResult> InsertarNoticia(NoticiaDto noticiaDto)
        {


            var noticia = _mapper.Map<Noticias>(noticiaDto);
            await _noticiasRepository.InsertarNoticia(noticia);
            
            return Ok(noticia);

        }
    }
}
