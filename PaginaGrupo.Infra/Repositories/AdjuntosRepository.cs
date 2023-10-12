using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AdjuntosRepository : IAdjuntosRepository
    {

        private readonly PaginaGrupoContext _context;
        public AdjuntosRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los adjuntos
        public async Task<IEnumerable<Adjuntos>> GetAdjuntos()
        {
            var adjuntos = await _context.Adjuntos.ToListAsync();
            
            return adjuntos;
        }

        //devuelve un adjunto
        public async Task<Adjuntos> GetAdjunto(int id)
        {
            var adjunto = await _context.Adjuntos.FirstOrDefaultAsync(x=> x.Id == id);

            return adjunto;
        }

        //inserta un adjunto
        public async Task<Adjuntos> InsertarAdjunto(Adjuntos adjunto)
        {
            _context.Adjuntos.AddAsync(adjunto);
            await _context.SaveChangesAsync();
            return adjunto;
        }
    }
}
