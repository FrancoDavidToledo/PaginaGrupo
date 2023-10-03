namespace PaginaGrupo.Core.Entities;

public partial class Fecha
{
    public int Id { get; set; }

    public DateTime Fecha1 { get; set; }

    public short AnioScout { get; set; }

    public virtual ICollection<AsistenciaScout> AsistenciaScouts { get; set; } = new List<AsistenciaScout>();
}
