using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{

    public class ScoutRepository : BaseRepository<Scout>, IScoutRepository
    {
        public ScoutRepository(PaginaGrupoContext context) : base(context) { }

    }
    //public class ScoutRepository : IScoutRepository
    //{

    //    private readonly PaginaGrupoContext _context;
    //    public ScoutRepository(PaginaGrupoContext context)
    //    {

    //        _context = context;
    //    }

    //    //devuelve todos los usuarios
    //    public async Task<IEnumerable<Scout>> GetScouts()
    //    {
    //        var scouts = await _context.Scouts.ToListAsync();

    //        return scouts;
    //    }

    //    //devuelve un usuario
    //    public async Task<Scout> GetScout(int id)
    //    {
    //        var scout = await _context.Scouts.FirstOrDefaultAsync(x => x.Id == id);

    //        return scout;
    //    }

    //    //Crea un usuario
    //    public async Task<Scout> InsertarScout(Scout scout)
    //    {
    //        _context.Scouts.AddAsync(scout);
    //        await _context.SaveChangesAsync();
    //        return scout;
    //    }
    //}
}
