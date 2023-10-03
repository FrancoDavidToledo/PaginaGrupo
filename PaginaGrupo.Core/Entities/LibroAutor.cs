namespace PaginaGrupo.Core.Entities;

public partial class LibroAutor
{
    public int Id { get; set; }

    public int? IdLibro { get; set; }

    public int? IdAutor { get; set; }

    public virtual Autores? IdAutorNavigation { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
