namespace PaginaGrupo.Core.Entities;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<LibroCategorium> LibroCategoria { get; set; } = new List<LibroCategorium>();
}
