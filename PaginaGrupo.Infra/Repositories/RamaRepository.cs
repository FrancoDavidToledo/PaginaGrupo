using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class RamaRepository : IRamaRepository
    {

        private readonly PaginaGrupoContext _context;
        public RamaRepository(PaginaGrupoContext context)
        {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Rama>> GetRamas()
        {
            var ramas = await _context.Ramas.ToListAsync();

            return ramas;
        }

        //devuelve un usuario
        public async Task<Rama> GetRama(string codigo)
        {
            var rama = await _context.Ramas.FirstOrDefaultAsync(x => x.Codigo == codigo);

            return rama;
        }

        //Crea un usuario
        public async Task<Rama> CrearRama(Rama rama)
        {
            _context.Ramas.AddAsync(rama);
            await _context.SaveChangesAsync();
            return rama;
        }
    }
}
