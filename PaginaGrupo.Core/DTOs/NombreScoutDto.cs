namespace PaginaGrupo.Core.DTOs;
public class NombreScoutDto
{
    public int Id { get; set; }

    public int IdTipo { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string CodigoUnidad { get; set; } = null!;

    public int IdScout { get; set; }

}
