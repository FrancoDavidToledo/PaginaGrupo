namespace PaginaGrupo.Core.Entities;

public class Fechas : BaseEntity
{
    public DateTime Fecha { get; set; }

    public short AnioScout { get; set; }

    public virtual ICollection<AsistenciaScout> AsistenciaScouts { get; set; } = new List<AsistenciaScout>();
}
