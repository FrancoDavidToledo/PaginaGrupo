namespace PaginaGrupo.Core.Entities;

public partial class AsistenciaScout
{
    public int Id { get; set; }

    public int? IdScout { get; set; }

    public int? IdFecha { get; set; }

    public string? Asistencia { get; set; }

    public string? CodigoUnidad { get; set; }

    public virtual Unidade? CodigoUnidadNavigation { get; set; }

    public virtual Fecha? IdFechaNavigation { get; set; }

    public virtual Scout? IdScoutNavigation { get; set; }
}
