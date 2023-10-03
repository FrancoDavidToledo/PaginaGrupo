namespace PaginaGrupo.Core.Entities;

public partial class Noticias
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Copete { get; set; } = null!;

    public string Cuerpo { get; set; } = null!;

    public DateTime FechaNoticia { get; set; }

    public short Estado { get; set; }

    public DateTime? FechaBaja { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdUsuarioBaja { get; set; }

    public virtual ICollection<Adjuntos> Adjuntos { get; set; } = new List<Adjuntos>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario? IdUsuarioBajaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
