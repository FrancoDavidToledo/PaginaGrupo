using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IFechasService
    {
        IEnumerable<Fechas> GetFechas(int anio);
        //Task<IEnumerable<Fechas>> GetFechassNoticiasActivas(int idNoticia);
        //Task<IEnumerable<Fechas>> GetFechassEstado(int estado, int? idNoticia);
        //Task<Fechas> InsertarFechas(Fechas Fechas);
        //Task<bool> ActualizarFechas(Fechas Fechas);
    }
}