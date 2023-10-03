using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Infra.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {
        public async Task<IEnumerable<Noticias>> GetNoticias()
        {
            var noticias =  Enumerable.Range(1,10).Select(x=> new Noticias
            {
             Id = x,
             Titulo = "TITULO DE NOTICIA",
                Autor ="Mantarrayo",
                Copete ="Este es un copete",
                Cuerpo = $"Descripcion {x}",
                FechaNoticia =DateTime.Now,
                Estado = 1
            });

           await Task.Delay(10);
       
            return noticias;
        }
    }
}
