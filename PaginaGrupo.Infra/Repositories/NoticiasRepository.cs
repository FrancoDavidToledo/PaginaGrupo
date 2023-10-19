using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {

        private readonly PaginaGrupoContext _context;
        public NoticiasRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todas las noticias
        public async Task<IEnumerable<Noticias>> GetNoticias()
        {
            var noticias =await _context.Noticias.ToListAsync();
            
            return noticias;
        }

        //devuelve una noticia
        public async Task<Noticias> GetNoticia(int id)
        {
            var noticia = await _context.Noticias.FirstOrDefaultAsync(x=> x.Id == id);

            return noticia;
        }

        //Crea una noticia
        public async Task<Noticias> InsertarNoticia(Noticias noticia)
        {
            _context.Noticias.AddAsync(noticia);
            await _context.SaveChangesAsync();
            return noticia;
        }


        //Updatea una noticia
        public async Task<bool> ActualizarNoticia(Noticias noticia)
        {
            var currentNoticia = await GetNoticia(noticia.Id);
            //aca poner todos los campos
            currentNoticia.Estado = noticia.Estado;

            int rows = await _context.SaveChangesAsync();
            
            return rows > 0;
        }

        //Borra una noticia
        public async Task<bool> BorrarNoticia(int id)
        {
            var currentNoticia = await GetNoticia(id);

            _context.Noticias.Remove(currentNoticia);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
