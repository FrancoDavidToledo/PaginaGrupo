using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class LibroAutorRepository : ILibroAutorRepository
    {

        private readonly PaginaGrupoContext _context;
        public LibroAutorRepository(PaginaGrupoContext context)
        {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<LibroAutor>> GetLibrosAutores()
        {
            var librosAutores = await _context.LibrosAutores.ToListAsync();

            return librosAutores;
        }

        //devuelve un usuario
        public async Task<LibroAutor> GetLibroAutor(int id)
        {
            var libroAutor = await _context.LibrosAutores.FirstOrDefaultAsync(x => x.Id == id);

            return libroAutor;
        }

        //Crea un usuario
        public async Task<LibroAutor> InsertarLibroAutor(LibroAutor libroAutor)
        {
            _context.LibrosAutores.AddAsync(libroAutor);
            await _context.SaveChangesAsync();
            return libroAutor;
        }
    }
}
