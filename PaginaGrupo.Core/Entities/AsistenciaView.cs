namespace PaginaGrupo.Core.Entities;

public class AsistenciaView
{
    public int Id { get; set; }
    public int IdScout { get; set; }
    public int IdFecha { get; set; }
    public char Asistencia { get; set; }
    public string CodigoUnidad { get; set; }
    public string? CodigoUnidadScout { get; set; }
    public char EstadoScout { get; set; }
    public short AnioScout { get; set; }
}
