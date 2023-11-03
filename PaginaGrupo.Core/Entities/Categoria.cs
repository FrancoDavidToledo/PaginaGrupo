namespace PaginaGrupo.Core.Entities;

public class Categoria : BaseEntity
{
    public string? Nombre { get; set; }

    public virtual ICollection<LibroCategoria> LibroCategoria { get; set; } = new List<LibroCategoria>();
}
