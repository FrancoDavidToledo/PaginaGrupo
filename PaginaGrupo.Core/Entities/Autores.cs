namespace PaginaGrupo.Core.Entities;

public partial class Autores
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<LibroAutor> LibroAutors { get; set; } = new List<LibroAutor>();
}
