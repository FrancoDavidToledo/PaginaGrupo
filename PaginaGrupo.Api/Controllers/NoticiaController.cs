using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Repositories;

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
            await Task.Delay(10);
            return Ok( await noticia);
        }
    }
}
