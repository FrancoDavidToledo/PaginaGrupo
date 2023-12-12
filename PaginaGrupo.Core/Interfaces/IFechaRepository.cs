using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IFechaRepository : IRepository<Fechas>
    {
        IEnumerable<Fechas> GetByAnio(int anio);
        //Task<IEnumerable<Fechas>> GetFechas();
        //Task<Fechas> GetFecha(int id);
        //Task<Fechas> InsertarFecha(Fechas fecha);
    }
}
