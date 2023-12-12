using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaGrupo.Core.Entities;


public class Adjuntos : BaseEntity
{

    public string Adjunto { get; set; }
    public int IdNoticia { get; set; }
    public byte[] DataImagen { get; set; } = new byte[0];
    public virtual Noticias IdNoticiaNavigation { get; set; } = null!;

}
