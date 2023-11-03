namespace PaginaGrupo.Core.DTOs;
public partial class UsuarioDtoSinClave
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaUltimoIngreso { get; set; }
    public string Rol { get; set; }

}
