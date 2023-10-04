using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiasRepository _noticiasRepository;

        public NoticiaController(INoticiasRepository noticiasRepository) 
        {
            _noticiasRepository = noticiasRepository;
        }
        [HttpGet("GetNoticias")]
        public async Task<IActionResult> GetNoticias() 
        {

            var noticia = _noticiasRepository.GetNoticias();
            return Ok( await noticia);
        }

        [HttpGet("GetNoticia/{id}")]
        public async Task<IActionResult> GetNoticia(int id)
        {
            var noticia = _noticiasRepository.GetNoticia(id);

            return Ok(await noticia);
           
        }

        [HttpPost("InsertarNoticia")]
        public async Task<IActionResult> InsertarNoticia(Noticias noticia)
        {
            
            await _noticiasRepository.InsertarNoticia(noticia);
            
            return Ok(noticia);

        }
    }
}
