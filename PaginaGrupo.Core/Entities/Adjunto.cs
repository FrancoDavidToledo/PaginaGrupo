namespace PaginaGrupo.Core.Entities;

public partial class Adjuntos
{
    public int Id { get; set; }

    public string Adjunto { get; set; } = null!;

    public int IdNoticia { get; set; }

    public virtual Noticias IdNoticiaNavigation { get; set; } = null!;
}
