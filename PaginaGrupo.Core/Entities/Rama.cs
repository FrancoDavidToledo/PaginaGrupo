namespace PaginaGrupo.Core.Entities;

public class Rama
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public virtual ICollection<Progresion> Progresiones { get; set; } = new List<Progresion>();

    public virtual ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
}
