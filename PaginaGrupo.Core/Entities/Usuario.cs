using PaginaGrupo.Core.Enumerations;

namespace PaginaGrupo.Core.Entities;

public partial class Usuario : BaseEntity
{

    public string Nombre { get; set; }

    public string Correo { get; set; }

    public string Clave { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaUltimoIngreso { get; set; }

    public RolType Rol { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<HistoricoUsuario> HistoricoUsuarios { get; set; } = new List<HistoricoUsuario>();

    public virtual ICollection<Noticias> NoticiaIdUsuarioBajaNavigations { get; set; } = new List<Noticias>();

    public virtual ICollection<Noticias> NoticiaIdUsuarioNavigations { get; set; } = new List<Noticias>();

}
