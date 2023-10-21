using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class NoticiasRepository : BaseRepository<Noticias>, INoticiasRepository
    {

        private readonly PaginaGrupoContext _context;
        public NoticiasRepository(PaginaGrupoContext context) : base(context) {     }

        //devuelve todas las noticias de un estado
        public IEnumerable<Noticias> GetNoticiasEstado(int estado)
        {
            var noticiasEstado=   _entities.Where(x => x.Estado == estado).ToList();

            return noticiasEstado;
        }

    }
}
