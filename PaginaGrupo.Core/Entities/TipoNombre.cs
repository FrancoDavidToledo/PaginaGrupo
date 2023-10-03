namespace PaginaGrupo.Core.Entities;

public partial class TipoNombre
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<NombreScout> NombreScouts { get; set; } = new List<NombreScout>();
}
