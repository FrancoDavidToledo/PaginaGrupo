namespace PaginaGrupo.Core.Entities;

public partial class HistoricoUsuario
{
    public string Id { get; set; } = null!;

    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
