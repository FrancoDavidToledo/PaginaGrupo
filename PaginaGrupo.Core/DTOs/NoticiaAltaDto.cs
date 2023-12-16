namespace PaginaGrupo.Core.DTOs
{
    public class NoticiaAltaDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public DateTime FechaNoticia { get; set; }

        //public short Estado { get; set; } = 1;
        public int IdUsuario { get; set; }
        public string? Copete { get; set; }

        public string? Cuerpo { get; set; }
    }
}
