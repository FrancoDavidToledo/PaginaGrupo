using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IMapper _mapper;
        public ComentarioController(IComentarioRepository comentarioRepository, IMapper mapper)
        {
            _comentarioRepository = comentarioRepository;
            _mapper = mapper;
        }
        [HttpGet("GetComentarios")]
        public async Task<IActionResult> GetComentarios()
        {

            var comentario = await _comentarioRepository.GetComentarios();
            var comentarioDto = _mapper.Map<IEnumerable<ComentarioDto>>(comentario);

            return Ok(comentarioDto);
        }

        [HttpGet("GetComentario/{id}")]
        public async Task<IActionResult> GetComentario(int id)
        {
            var comentario = await _comentarioRepository.GetComentario(id);
            var comentarioDto = _mapper.Map<ComentarioDto>(comentario);
            return Ok(comentarioDto);

        }

        [HttpPost("InsertarComentario")]
        public async Task<IActionResult> InsertarComentario(ComentarioDto comentarioDto)
        {


            var comentario = _mapper.Map<Comentario>(comentarioDto);
            await _comentarioRepository.InsertarComentario(comentario);

            return Ok(comentario);

        }
    }
}
