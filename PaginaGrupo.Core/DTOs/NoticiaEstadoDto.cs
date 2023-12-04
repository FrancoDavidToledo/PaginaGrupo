namespace PaginaGrupo.Core.DTOs
{
    public class NoticiaEstadoDto
    {
        public int Id { get; set; }

        public short Estado { get; set; }

        public DateTime? FechaBaja { get; set; }

        public int? IdUsuarioBaja { get; set; }
    }
}
