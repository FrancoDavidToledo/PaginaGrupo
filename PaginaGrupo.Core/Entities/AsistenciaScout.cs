namespace PaginaGrupo.Core.Entities;

public class AsistenciaScout : BaseEntity
{
    public int Id { get; set; }

    public int? IdScout { get; set; }

    public int? IdFecha { get; set; }

    public char? Asistencia { get; set; }

    public string? CodigoUnidad { get; set; }

    public virtual Unidad? CodigoUnidadNavigation { get; set; }

    public virtual Fechas? IdFechaNavigation { get; set; }

    public virtual Scout? IdScoutNavigation { get; set; }
}
