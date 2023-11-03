namespace PaginaGrupo.Core.Entities;

public class HistoricoUsuario
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
