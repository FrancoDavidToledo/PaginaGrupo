using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAsistenciaScoutRepository : IRepository<AsistenciaScout>
    {
        IEnumerable<AsistenciaScout> GetByFecha(int idFecha);
        //Task<IEnumerable<AsistenciaScout>> GetAsistenciasScouts();
        //Task<AsistenciaScout> GetAsistenciaScout(int id);
        //Task<AsistenciaScout> InsertarAsistenciaScout(AsistenciaScout asistenciaScout);
    }
}
