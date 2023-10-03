namespace PaginaGrupo.Core.Entities;

public partial class AvisoPago
{
    public int Id { get; set; }

    public int? Importe { get; set; }

    public string? Comentario { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Comprobante { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
