using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AdjuntosRepository : BaseRepository<Adjuntos>, IAdjuntosRepository
    {

        public AdjuntosRepository(PaginaGrupoContext context) : base(context) { }

        //devuelve todos los adjuntos de una noticia
        public async Task<IEnumerable<Adjuntos>> GetAdjuntosNoticia(int idNoticia)
        {
         //   var adjuntos = await _entities.ToListAsync();
            var adjuntos = await _entities.Where(x => x.IdNoticia == idNoticia).ToListAsync();
            return adjuntos;
        }

        //devuelve un adjunto
        public async Task<Adjuntos> GetAdjunto(int idNoticia)
        {
            var adjunto = await _entities.FirstOrDefaultAsync(x => x.IdNoticia == idNoticia);

            return adjunto;
        }

        ////inserta un adjunto
        //public async Task<Adjuntos> InsertarAdjunto(Adjuntos adjunto)
        //{
        //    _context.Adjuntos.AddAsync(adjunto);
        //    await _context.SaveChangesAsync();
        //    return adjunto;
        //}
    }
}
