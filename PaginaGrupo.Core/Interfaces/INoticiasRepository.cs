using PaginaGrupo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INoticiasRepository
    {
        Task<IEnumerable<Noticias>> GetNoticias();
        
    }
}
