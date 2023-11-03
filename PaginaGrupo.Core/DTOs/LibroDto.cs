namespace PaginaGrupo.Core.DTOs;

public class LibroDto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Idioma { get; set; }

    public short? Anio { get; set; }

    public short? Paginas { get; set; }

    public string? Formato { get; set; }

    public string Url { get; set; } = null!;

    public string UrlPortada { get; set; } = null!;
    public string Nombre { get; set;} = null!;

}
