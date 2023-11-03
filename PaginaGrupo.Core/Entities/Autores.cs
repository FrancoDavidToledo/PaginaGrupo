namespace PaginaGrupo.Core.Entities;

public class Autores :BaseEntity
{
    public string? Nombre { get; set; }

    public virtual ICollection<LibroAutor> LibroAutor { get; set; } = new List<LibroAutor>();
}
