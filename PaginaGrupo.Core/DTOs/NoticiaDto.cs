namespace PaginaGrupo.Core.DTOs
{
    public class NoticiaDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Autor { get; set; } = null!;

        public string Copete { get; set; } = null!;

        public string Cuerpo { get; set; } = null!;

        public DateTime FechaNoticia { get; set; }

        public short Estado { get; set; }

        public DateTime? FechaBaja { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdUsuarioBaja { get; set; }
    }
}
