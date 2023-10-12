using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class LibroRepository : ILibroRepository
    {

        private readonly PaginaGrupoContext _context;
        public LibroRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Libro>> GetLibros()
        {
            var libros =await _context.Libros.ToListAsync();
            
            return libros;
        }

        //devuelve un usuario
        public async Task<Libro> GetLibro(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(x=> x.Id == id);

            return libro;
        }

        //Crea un usuario
        public async Task<Libro> InsertarLibro(Libro libro)
        {
            _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
            return libro;
        }
    }
}
