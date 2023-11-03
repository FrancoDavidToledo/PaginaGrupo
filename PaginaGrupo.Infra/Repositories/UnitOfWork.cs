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
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IAdjuntosRepository _adjuntosRepository;
        private readonly ILibroRepository _libroRepository;
        private readonly IAutoresRepository _autoresRepository;
        private readonly ICategoriasRepository _categoriasRepository;
        private readonly IAvisoPagoRepository _avisoPagoRepository;


        public UnitOfWork(PaginaGrupoContext context)
        {
            _context = context;
        }

        public INoticiasRepository NoticiasRepository => _noticiasRepository ?? new NoticiasRepository(_context);
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? new UsuarioRepository(_context);
        public IComentarioRepository ComentarioRepository => _comentarioRepository ?? new ComentarioRepository(_context);
        public IAdjuntosRepository AdjuntosRepository => _adjuntosRepository ?? new AdjuntosRepository(_context);
        public ILibroRepository LibroRepository => _libroRepository ?? new LibroRepository(_context);
        public ICategoriasRepository CategoriasRepository => _categoriasRepository ?? new CategoriaRepository(_context);
        public IAutoresRepository AutoresRepository => _autoresRepository ?? new AutorRepository(_context);
        public IAvisoPagoRepository AvisoPagoRepository => _avisoPagoRepository ?? new AvisoPagoRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            };
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
