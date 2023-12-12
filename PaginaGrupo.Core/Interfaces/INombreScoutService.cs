using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INombreScoutService
    {
        IEnumerable<NombreScout> GetNombreScout(int idScout);
        Task<NombreScout> GetNombreScoutById(int id);
        //Task<IEnumerable<NombreScout>> GetNombreScoutsNoticiasActivas(int idNoticia);
        //Task<IEnumerable<NombreScout>> GetNombreScoutsEstado(int estado, int? idNoticia);
        Task<NombreScout> InsertarNombreScout(NombreScout NombreScout);
        Task<bool> ActualizarNombreScout(NombreScout NombreScout);
        Task<bool> BorrarNombreScout(int id);
    }
}