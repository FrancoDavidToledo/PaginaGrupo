using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AutorRepository : IAutoresRepository
    {

        private readonly PaginaGrupoContext _context;
        public AutorRepository(PaginaGrupoContext context)
        {

            _context = context;
        }

        //devuelve todos los autores
        public async Task<IEnumerable<Autores>> GetAutores()
        {
            var autores = await _context.Autores.ToListAsync();

            return autores;
        }

        //devuelve un autor
        public async Task<Autores> GetAutor(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            return autor;
        }

        //inserta un autor
        public async Task<Autores> InsertarAutor(Autores autor)
        {
            _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
            return autor;
        }
    }
}
