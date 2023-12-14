using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IScoutService
    {
        Task<Scout> GetScout(int id);
        //Task<IEnumerable<Scout>> GetScoutsNoticiasActivas(int idNoticia);
        //Task<IEnumerable<Scout>> GetScoutsEstado(int estado, int? idNoticia);
        Task<Scout> InsertarScout(Scout Scout);
        Task<bool> ActualizarScout(Scout Scout);
        IEnumerable<Scout> GetScouts(string? codigo, char? estado);
    }
}