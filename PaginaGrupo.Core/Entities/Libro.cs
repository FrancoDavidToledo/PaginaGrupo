namespace PaginaGrupo.Core.Entities;

public class Libro : BaseEntity
{
    public string Codigo { get; set; } = null!;

    public string? Idioma { get; set; }

    public short? Anio { get; set; }

    public short? Paginas { get; set; }

    public string? Formato { get; set; }

    public string Url { get; set; } = null!;

    public string UrlPortada { get; set; } = null!;
    public string Nombre { get; set; } = null!;

    public virtual ICollection<LibroAutor> LibroAutor { get; set; } = new List<LibroAutor>();

    public virtual ICollection<LibroCategoria> LibroCategoria { get; set; } = new List<LibroCategoria>();
}
