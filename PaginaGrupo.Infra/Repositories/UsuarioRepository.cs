using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        //  private readonly PaginaGrupoContext _context;
        public UsuarioRepository(PaginaGrupoContext context) : base(context) { }

        //devuelve todas las noticias de un estado
        public async Task<Usuario> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Correo == login.Correo);
        }
    }
}
