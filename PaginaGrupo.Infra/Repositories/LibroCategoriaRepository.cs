using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class LibroCategoriaRepository : ILibroCategoriaRepository
    {

        private readonly PaginaGrupoContext _context;
        public LibroCategoriaRepository(PaginaGrupoContext context)
        {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<LibroCategoria>> GetLibrosCategorias()
        {
            var librosCategorias = await _context.LibroCategoria.ToListAsync();

            return librosCategorias;
        }

        //devuelve un usuario
        public async Task<LibroCategoria> GetLibroCategoria(int id)
        {
            var libroCategoria = await _context.LibroCategoria.FirstOrDefaultAsync(x => x.Id == id);

            return libroCategoria;
        }

        //Crea un usuario
        public async Task<LibroCategoria> InsertarLibroCategoria(LibroCategoria libroCategoria)
        {
            _context.LibroCategoria.AddAsync(libroCategoria);
            await _context.SaveChangesAsync();
            return libroCategoria;
        }
    }
}
