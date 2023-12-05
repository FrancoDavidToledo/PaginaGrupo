namespace PaginaGrupo.Core.DTOs;
public class ComentarioPublicoDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Contenido { get; set; } = null!;
    public int Estado { get; set; }
    public string? NombreUsuario { get; set; }

}
