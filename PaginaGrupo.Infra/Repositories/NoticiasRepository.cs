using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {

        private readonly PaginaGrupoContext _context;
        public NoticiasRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todas las noticias
        public async Task<IEnumerable<Noticia>> GetNoticias()
        {
            var noticias =await _context.Noticias.ToListAsync();
            
            return noticias;
        }

        //devuelve una noticia
        public async Task<Noticia> GetNoticia(int id)
        {
            var noticia = await _context.Noticias.FirstOrDefaultAsync(x=> x.Id == id);

            return noticia;
        }
    }
}
