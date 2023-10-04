namespace PaginaGrupo.Core.Entities;

public class Roles
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<RolesUsuario> RolesUsuarios { get; set; } = new List<RolesUsuario>();
}
