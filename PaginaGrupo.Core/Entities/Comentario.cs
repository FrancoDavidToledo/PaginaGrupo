using PaginaGrupo.Core.Enumerations;

namespace PaginaGrupo.Core.Entities;

public class Comentario : BaseEntity
{
    public DateTime Fecha { get; set; }

    public string Contenido { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdNoticia { get; set; }
    public Int16 Estado { get; set; }

    public virtual Noticias IdNoticiaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
