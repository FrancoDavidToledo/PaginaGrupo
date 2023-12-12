using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class ComentarioRepository : BaseRepository<Comentario>, IComentarioRepository
    {
        public ComentarioRepository(PaginaGrupoContext context) : base(context) { }
        //devuelve todos los comentarios activos de una publicacion
        public async Task<IEnumerable<Comentario>> GetComentariosNoticiasActivas(int idNoticia)
        {
            var comentarios = await _entities.Where(x => x.IdNoticia == idNoticia && x.Estado ==Convert.ToInt16(EstadoComentarios.Aceptado)).ToListAsync();

            return comentarios;
        }

        //devuelve todos los comentarios con un estado en particular
        public async Task<IEnumerable<Comentario>> GetComentariosEstado(int estado)
        {
            var comentarios = await _entities.Where(x => x.Estado == Convert.ToInt16(estado)).ToListAsync();

            return comentarios;
        }
        public async Task<IEnumerable<Comentario>> GetComentariosEstadoFiltrado(int estado, string filtro)
        {
            var comentarios = await _entities.Where(x => x.Estado == Convert.ToInt16(estado) &&
                                                    (x.Contenido.ToLower().Contains(filtro.ToLower()) ||
                                                    x.IdUsuarioNavigation.Nombre.ToLower().Contains(filtro.ToLower()) ||
                                                    x.IdNoticiaNavigation.Titulo.ToLower().Contains(filtro.ToLower()) ||
                                                    x.IdNoticia.ToString() == filtro)
                                                    ).ToListAsync();

            return comentarios;
        }


    }
}
