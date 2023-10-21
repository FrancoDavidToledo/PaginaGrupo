namespace PaginaGrupo.Core.Entities;

public class Adjuntos : BaseEntity
{

    public string Adjunto { get; set; } = null!;

    public int IdNoticia { get; set; }

    public virtual Noticias IdNoticiaNavigation { get; set; } = null!;
}
