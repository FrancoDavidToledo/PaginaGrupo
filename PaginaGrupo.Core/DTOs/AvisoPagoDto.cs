namespace PaginaGrupo.Core.DTOs;

public class AvisoPagoDto
{
    public int Id { get; set; }
    public int Importe { get; set; }

    public string? Comentario { get; set; }

    public DateTime Fecha { get; set; }

    public string Comprobante { get; set; } = null!;

    public int IdUsuario { get; set; }

}
