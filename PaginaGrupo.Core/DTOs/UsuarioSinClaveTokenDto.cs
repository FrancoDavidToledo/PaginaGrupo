namespace PaginaGrupo.Core.DTOs;
public partial class UsuarioSinClaveTokenDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Token { get; set; } = null!;

}
