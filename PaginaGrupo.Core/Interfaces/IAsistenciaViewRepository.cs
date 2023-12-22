using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAsistenciaViewRepository
    {
        IEnumerable<AsistenciaView> GetAsistenciasUnidad(string? codigo, char estado, short anio);
        IEnumerable<AsistenciaView> GetAsistenciasUnidadFecha(string? codigo, char estado, int idFecha);
    }
}
