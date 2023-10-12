using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class FechaRepository : IFechaRepository
    {

        private readonly PaginaGrupoContext _context;
        public FechaRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Fecha>> GetFechas()
        {
            var fechas =await _context.Fechas.ToListAsync();
            
            return fechas;
        }

        //devuelve un usuario
        public async Task<Fecha> GetFecha(int id)
        {
            var fecha = await _context.Fechas.FirstOrDefaultAsync(x=> x.Id == id);

            return fecha;
        }

        //Crea un usuario
        public async Task<Fecha> InsertarFecha(Fecha fecha)
        {
            _context.Fechas.AddAsync(fecha);
            await _context.SaveChangesAsync();
            return fecha;
        }
    }
}
