using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PaginaGrupoContext _context; 
        private readonly INoticiasRepository _noticiasRepository;
        //   private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public  UnitOfWork(PaginaGrupoContext context)
        {
            _context = context;
        }

        public INoticiasRepository NoticiasRepository => _noticiasRepository ?? new NoticiasRepository(_context);

        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? new UsuarioRepository(_context);

        public void Dispose()
        {
            if (_context != null) 
            {
                _context.Dispose();
             } ;
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
