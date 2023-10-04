namespace PaginaGrupo.Core.Entities;

public class LibroCategoria
{
    public int Id { get; set; }

    public int? IdLibro { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
