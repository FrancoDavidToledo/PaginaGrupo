namespace PaginaGrupo.Core.DTOs;
public class HistoricoUsuarioDto
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;


}
