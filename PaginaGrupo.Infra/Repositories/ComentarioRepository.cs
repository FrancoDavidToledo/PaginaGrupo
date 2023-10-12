using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {

        private readonly PaginaGrupoContext _context;
        public ComentarioRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Comentario>> GetComentarios()
        {
            var comentarios =await _context.Comentarios.ToListAsync();
            
            return comentarios;
        }

        //devuelve un usuario
        public async Task<Comentario> GetComentario(int id)
        {
            var comentario = await _context.Comentarios.FirstOrDefaultAsync(x=> x.Id == id);

            return comentario;
        }

        //Crea un usuario
        public async Task<Comentario> InsertarComentario(Comentario comentario)
        {
            _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }
    }
}
