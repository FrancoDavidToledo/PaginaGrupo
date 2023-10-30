using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class CategoriaRepository : ICategoriasRepository
    {

        private readonly PaginaGrupoContext _context;
        public CategoriaRepository(PaginaGrupoContext context)
        {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync();

            return categorias;
        }

        //devuelve un usuario
        public async Task<Categoria> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            return categoria;
        }

    }
}
