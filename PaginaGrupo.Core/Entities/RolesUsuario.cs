namespace PaginaGrupo.Core.Entities;

public partial class RolesUsuario
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public int IdUsuario { get; set; }

    public virtual Roles IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
