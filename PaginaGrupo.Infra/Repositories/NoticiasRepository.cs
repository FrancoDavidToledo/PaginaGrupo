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


        public async Task<IEnumerable<Noticias>> GetNoticias()
        {


            var noticia =await _context.Noticias.ToListAsync();
         
       
            return noticia;
        }
    }
}
