using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class NombreScoutRepository : INombreScoutRepository
    {

        private readonly PaginaGrupoContext _context;
        public NombreScoutRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<NombreScout>> GetNombresScouts()
        {
            var nombresScouts =await _context.NombreScouts.ToListAsync();
            
            return nombresScouts;
        }

        //devuelve un usuario
        public async Task<NombreScout> GetNombreScout(int id)
        {
            var nombreScout = await _context.NombreScouts.FirstOrDefaultAsync(x=> x.Id == id);

            return nombreScout;
        }

        //Crea un usuario
        public async Task<NombreScout> InsertarNombreScout(NombreScout nombreScout)
        {
            _context.NombreScouts.AddAsync(nombreScout);
            await _context.SaveChangesAsync();
            return nombreScout;
        }
    }
}
