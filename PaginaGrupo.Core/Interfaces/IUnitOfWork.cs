using PaginaGrupo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INoticiasRepository NoticiasRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
          
    }

}
