namespace PaginaGrupo.Core.Entities;

public class Comentario
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Contenido { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdNoticia { get; set; }

    public virtual Noticias IdNoticiaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
