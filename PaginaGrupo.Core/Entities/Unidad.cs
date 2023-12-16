namespace PaginaGrupo.Core.Entities;

public class Unidad
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string CodigoRama { get; set; } = null!;

    public short Orden { get; set; }
    public virtual ICollection<AsistenciaScout> AsistenciaScouts { get; set; } = new List<AsistenciaScout>();

    public virtual Rama CodigoRamaNavigation { get; set; } = null!;

    public virtual ICollection<NombreScout> NombreScouts { get; set; } = new List<NombreScout>();

    public virtual ICollection<Scout> Scouts { get; set; } = new List<Scout>();

}
