namespace PaginaGrupo.Core.DTOs;
public class ScoutAsistenciaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public char? Asistencia { get; set; }
}
