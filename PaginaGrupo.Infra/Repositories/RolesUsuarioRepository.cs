using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class RolesUsuarioRepository : IRolesUsuarioRepository
    {

        private readonly PaginaGrupoContext _context;
        public RolesUsuarioRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<RolesUsuario>> GetRolesUsuarios()
        {
            var rolesUsuarios =await _context.RolesUsuarios.ToListAsync();
            
            return rolesUsuarios;
        }

        //devuelve un usuario
        public async Task<RolesUsuario> GetRolUsuario(int id)
        {
            var rolUsuario = await _context.RolesUsuarios.FirstOrDefaultAsync(x=> x.Id == id);

            return rolUsuario;
        }

        //Crea un usuario
        public async Task<RolesUsuario> InsertarRolesUsuario(RolesUsuario rolUsuario)
        {
            _context.RolesUsuarios.AddAsync(rolUsuario);
            await _context.SaveChangesAsync();
            return rolUsuario;
        }
    }
}
