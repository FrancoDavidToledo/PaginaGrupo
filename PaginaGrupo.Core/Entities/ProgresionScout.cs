namespace PaginaGrupo.Core.Entities;

public partial class ProgresionScout
{
    public int Id { get; set; }

    public int IdScout { get; set; }

    public int IdProgresion { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Progresion IdProgresionNavigation { get; set; } = null!;

    public virtual Scout IdScoutNavigation { get; set; } = null!;
}
