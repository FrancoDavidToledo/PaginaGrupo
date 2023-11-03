using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        //  private readonly PaginaGrupoContext _context;
        public UsuarioRepository(PaginaGrupoContext context) : base(context) { }

     
        public async Task<Usuario> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Correo == login.Correo);
        }

        //devuelve todos los usuarios que tienen un rol
        public async Task<IEnumerable<Usuario>> GetUsuariosRol(RolType rol)
        {
            var comentarios = await _entities.Where(x => x.Rol == rol).ToListAsync();

            return comentarios;
        }


    }
}
