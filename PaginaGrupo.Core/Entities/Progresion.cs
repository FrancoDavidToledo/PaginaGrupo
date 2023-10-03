namespace PaginaGrupo.Core.Entities;

public partial class Progresion
{
    public int Id { get; set; }

    public string CodigoRama { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public short Orden { get; set; }

    public virtual Rama CodigoRamaNavigation { get; set; } = null!;

    public virtual ICollection<ProgresionScout> ProgresionScouts { get; set; } = new List<ProgresionScout>();
}
