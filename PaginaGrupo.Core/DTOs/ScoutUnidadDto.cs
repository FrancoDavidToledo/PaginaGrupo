namespace PaginaGrupo.Core.DTOs
{
    public class ScoutUnidadDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } = null!;
        public string? Apellido { get; set; } = null!;
        public string CodigoUnidad { get; set; }

    }
}
