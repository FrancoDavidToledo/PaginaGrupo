using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriasRepository
    {

        public CategoriaRepository(PaginaGrupoContext context) : base(context) { }


    }
}
