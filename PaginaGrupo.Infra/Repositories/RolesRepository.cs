using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class RolesRepository : IRolesRepository
    {

        private readonly PaginaGrupoContext _context;
        public RolesRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Roles>> GetRoles()
        {
            var roles =await _context.Roles.ToListAsync();
            
            return roles;
        }

        //devuelve un usuario
        public async Task<Roles> GetRol(int id)
        {
            var rol = await _context.Roles.FirstOrDefaultAsync(x=> x.Id == id);

            return rol;
        }

    }
}
