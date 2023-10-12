using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class ProgresionScoutRepository : IProgresionScoutRepository
    {

        private readonly PaginaGrupoContext _context;
        public ProgresionScoutRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<ProgresionScout>> GetProgresionesScouts()
        {
            var progresionesScouts =await _context.ProgresionScouts.ToListAsync();
            
            return progresionesScouts;
        }

        //devuelve un usuario
        public async Task<ProgresionScout> GetProgresionScout(int id)
        {
            var progresionScout = await _context.ProgresionScouts.FirstOrDefaultAsync(x=> x.Id == id);

            return progresionScout;
        }

        //Crea un usuario
        public async Task<ProgresionScout> InsertarProgresionScout(ProgresionScout progresionScout)
        {
            _context.ProgresionScouts.AddAsync(progresionScout);
            await _context.SaveChangesAsync();
            return progresionScout;
        }
    }
}
