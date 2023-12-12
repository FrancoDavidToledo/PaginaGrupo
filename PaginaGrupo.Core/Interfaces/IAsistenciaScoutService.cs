using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAsistenciaScoutService
    {
        Task<AsistenciaScout> GetAsistenciaScout(int id);
        //Task<IEnumerable<AsistenciaScout>> GetAsistenciaScoutsNoticiasActivas(int idNoticia);
        //Task<IEnumerable<AsistenciaScout>> GetAsistenciaScoutsEstado(int estado, int? idNoticia);
        Task<AsistenciaScout> InsertarAsistenciaScout(AsistenciaScout AsistenciaScout);
        Task<bool> ActualizarAsistenciaScout(AsistenciaScout AsistenciaScout);
        IEnumerable<AsistenciaScout> GetAsistenciasScouts(int idFecha);
    }
}