using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {

        private readonly PaginaGrupoContext _context;
        public LibroRepository(PaginaGrupoContext context) : base(context) { }


    }
}