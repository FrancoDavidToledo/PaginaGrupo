namespace PaginaGrupo.Core.Entities;

public partial class Scout
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoUnidad { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AsistenciaScout> AsistenciaScouts { get; set; } = new List<AsistenciaScout>();

    public virtual Unidade? CodigoUnidadNavigation { get; set; }

    public virtual ICollection<NombreScout> NombreScouts { get; set; } = new List<NombreScout>();

    public virtual ICollection<ProgresionScout> ProgresionScouts { get; set; } = new List<ProgresionScout>();
}
