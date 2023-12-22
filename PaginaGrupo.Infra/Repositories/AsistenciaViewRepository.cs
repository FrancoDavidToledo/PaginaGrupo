using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AsistenciaViewRepository : IAsistenciaViewRepository
    {

        private readonly PaginaGrupoContext _context;
        public AsistenciaViewRepository(PaginaGrupoContext context)
        {

            _context = context;
        }


        public IEnumerable<AsistenciaView> GetAsistenciasUnidad(string? codigo, char estado, short anio)
        {
            var asistenciaViews = _context.AsistenciaView.Where(x => x.AnioScout == anio && x.CodigoUnidadScout == codigo && x.EstadoScout == estado).ToList();

            return asistenciaViews;
        }

        public IEnumerable<AsistenciaView> GetAsistenciasUnidadFecha(string? codigo, char estado, int idFecha)
        {
            var asistenciaViews = _context.AsistenciaView.Where(x => x.IdFecha == idFecha && x.CodigoUnidadScout == codigo && x.EstadoScout == estado).ToList();

            return asistenciaViews;
        }

    }
}
