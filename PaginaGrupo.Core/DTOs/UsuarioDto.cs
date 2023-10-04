namespace PaginaGrupo.Core.DTOs;
public partial class UsuarioDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaUltimoIngreso { get; set; }

}
