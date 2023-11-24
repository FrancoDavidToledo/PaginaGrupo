namespace PaginaGrupo.Core.DTOs
{
    public class NoticiaActivaImagenDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Copete { get; set; } = null!;

        public short Estado { get; set; }

        public string Adjunto { get; set; }
    }
}
