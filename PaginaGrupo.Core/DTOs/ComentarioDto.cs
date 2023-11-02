namespace PaginaGrupo.Core.DTOs;
public class ComentarioDto
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Contenido { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdNoticia { get; set; }
    public Int16 Estado { get; set; }

}
