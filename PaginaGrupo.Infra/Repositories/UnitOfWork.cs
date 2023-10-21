using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PaginaGrupoContext _context; 
        private readonly INoticiasRepository _noticiasRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public  UnitOfWork(PaginaGrupoContext context)
        {
            _context = context;
        }

        public INoticiasRepository NoticiasRepository => _noticiasRepository ?? new NoticiasRepository(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new BaseRepository<Usuario>(_context);

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
