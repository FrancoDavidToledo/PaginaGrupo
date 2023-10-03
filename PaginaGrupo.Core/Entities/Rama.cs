namespace PaginaGrupo.Core.Entities;

public partial class Rama
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public virtual ICollection<Progresione> Progresiones { get; set; } = new List<Progresione>();

    public virtual ICollection<Unidade> Unidades { get; set; } = new List<Unidade>();
}
