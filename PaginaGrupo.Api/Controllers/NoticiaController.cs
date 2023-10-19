using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiasService _noticiasService;
        private readonly IMapper _mapper;
        public NoticiaController(INoticiasService noticiasService, IMapper mapper) 
        {
            _noticiasService = noticiasService;
            _mapper= mapper;
    }
        [HttpGet("GetNoticias")]
        public async Task<IActionResult> GetNoticias() 
        {

            var noticias = await _noticiasService.GetNoticias();
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
