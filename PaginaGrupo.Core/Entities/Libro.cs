namespace PaginaGrupo.Core.Entities;

public partial class Libro
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Idioma { get; set; }

    public short? Anio { get; set; }

    public short? Paginas { get; set; }

    public string? Formato { get; set; }

    public string Url { get; set; } = null!;

    public string UrlPortada { get; set; } = null!;

    public virtual ICollection<LibroAutor> LibroAutors { get; set; } = new List<LibroAutor>();

    public virtual ICollection<LibroCategorium> LibroCategoria { get; set; } = new List<LibroCategorium>();
}
