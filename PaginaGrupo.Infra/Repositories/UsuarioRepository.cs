using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PaginaGrupoContext _context;
        public UsuarioRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var noticias =await _context.Usuarios.ToListAsync();
            
            return noticias;
        }

        //devuelve un usuario
        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x=> x.Id == id);

            return usuario;
        }

        //Crea un usuario
        public async Task<Usuario> InsertarUsuario(Usuario noticia)
        {
            _context.Usuarios.AddAsync(noticia);
            await _context.SaveChangesAsync();
            return noticia;
        }
    }
}
