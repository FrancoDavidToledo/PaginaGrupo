using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IFechaRepository
    {
        Task<IEnumerable<Fecha>> GetFechas();
        Task<Fecha> GetFecha(int id);
        Task<Fecha> InsertarFecha(Fecha fecha);
    }
}
