namespace PaginaGrupo.Core.Entities;

public class Noticias : BaseEntity
{
    //    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Autor { get; set; }

    public string Copete { get; set; }

    public string Cuerpo { get; set; }

    public DateTime FechaNoticia { get; set; }

    public short Estado { get; set; } = 1;

    public DateTime? FechaBaja { get; set; }

    public int IdUsuario { get; set; }

    public int? IdUsuarioBaja { get; set; }

    public virtual ICollection<Adjuntos> Adjuntos { get; set; } = new List<Adjuntos>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario? IdUsuarioBajaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
