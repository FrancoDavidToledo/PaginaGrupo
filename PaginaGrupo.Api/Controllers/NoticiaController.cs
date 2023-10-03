using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiasRepository _noticiasRepository;
        public NoticiaController(INoticiasRepository noticiasRepository) 
        {
            _noticiasRepository = noticiasRepository;
        }

        public async Task<IActionResult> GetNoticias() 
        {

            var noticia = _noticiasRepository.GetNoticias();
            return Ok( await noticia);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoticia(int id)
        {
            var noticia = _noticiasRepository.GetNoticia(id);

            return Ok(await noticia);
           
        }
    }
}
