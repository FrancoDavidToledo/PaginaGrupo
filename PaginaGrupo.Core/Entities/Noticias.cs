namespace PaginaGrupo.Core.Entities
{
    public class Noticias
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Copete { get; set; }
        public string Cuerpo { get; set; }
        public DateTime FechaNoticia { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdUsuarioBaja { get; set; }
    }
}
